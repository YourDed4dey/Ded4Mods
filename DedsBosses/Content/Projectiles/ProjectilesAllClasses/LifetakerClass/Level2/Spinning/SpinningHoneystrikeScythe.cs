using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System;
using DedsBosses.Content.DamageClasses;

namespace DedsBosses.Content.Projectiles.ProjectilesAllClasses.LifetakerClass.Level2.Spinning
{
    public class SpinningHoneystrikeScythe : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 52;
            Projectile.height = 46;
            //Projectile.scale = 1.7f;


            Projectile.DamageType = ModContent.GetInstance<LifetakerDamageClass>();
            Projectile.damage = 28;
            Projectile.CritChance = 4;



            Projectile.aiStyle = 0; //boomerang AI is 3
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = -1; // Make "-1" into "1" and when player gets close to enemy they deal massive damage, good for a scythe's ability



            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            //Amazing visual from a Weapon, just make proj friendly

            /*Player player = Main.player[Projectile.owner];
            NPC NPC = target;
            Vector2 directionToPlayer = Main.player[NPC.target].Center - NPC.Center;
            directionToPlayer.Normalize();
            for (int i = 0; i < 8; i++)  //Change depending on difficulty
            {
                float rotation = MathHelper.TwoPi / 8f * i;

                // Offset position from the boss
                float offsetMagnitude = 60f; // Adjust the magnitude of the offset
                Vector2 projectileOffset = new Vector2(offsetMagnitude, 0f).RotatedBy(rotation);

                int secondaryProjectile = Projectile.NewProjectile(
                    null,
                    NPC.Center + projectileOffset, // Spawn the projectile on the boss with the offset
                    directionToPlayer * 10f, // No initial velocity, the projectile will move towards the player
                    ProjectileID.EyeLaser,
                    Projectile.damage,
                    0f,
                    Main.myPlayer
                );
            }*/

            // Calculate a random number between 1 and 100
            int chance = Main.rand.Next(1, 101);

            int confusedChance = 90; // Adjust this value as needed

            // If the random number is less than or equal to the poison chance, apply poison
            if (chance <= confusedChance)
            {
                target.AddBuff(BuffID.Confused, 120); // Apply Confused debuff for 2 seconds (120 frames)
            }

            NPC NPC = target;
            Vector2 directionToEnemy = Main.player[NPC.target].Center - NPC.Center;
            directionToEnemy.Normalize();
            if (target.type != NPCID.TargetDummy && !target.friendly)
            {
                for (int i = 0; i < 1; i++)  //Change depending on difficulty
                {
                    float rotation = MathHelper.TwoPi / 8f * i;

                    float offsetMagnitude = 60f; // Adjust the magnitude of the offset
                    Vector2 projectileOffset = new Vector2(offsetMagnitude, 0f).RotatedBy(rotation);

                    int secondaryProjectile = Projectile.NewProjectile(
                        null,
                        NPC.Center + projectileOffset, // Spawn the projectile on the boss with the offset
                        -directionToEnemy * 4f, // No initial velocity, the projectile will move towards the player
                        ProjectileID.Bee,
                        Projectile.damage,
                        0f,
                        Main.myPlayer
                    );
                }
            }
        }
        public override void AI()
        {
            float num = 48f;
            float num2 = 2f;
            float quarterPi = -(float)Math.PI / 4f;
            float scaleFactor = 1f;

            Player player = Main.player[Projectile.owner];
            Vector2 relativePoint = player.RotatedRelativePoint(player.MountedCenter);
            if (player.dead)
            {
                Projectile.Kill();
                return;
            }

            int sign = Math.Sign(Projectile.velocity.X);

            Projectile.velocity = new Vector2(sign, 0f); //new Vector2(sign * -.1f, 0f); makes it go crazy, crazy cool tho

            if (Projectile.ai[0] == 0f)
            {
                Projectile.rotation = new Vector2(sign, 0f - player.gravDir).ToRotation() + quarterPi + (float)Math.PI;
                if (Projectile.velocity.X < 0f)
                {
                    Projectile.rotation -= (float)Math.PI / 2f;
                }
            }

            Projectile.ai[0] += 1f;

            Projectile.rotation += (float)Math.PI * 2f * num2 / num * (float)sign;

            bool isDone = Projectile.ai[0] == (num / 2f);
            if (Projectile.ai[0] >= num || (isDone && !player.controlUseItem))
            {
                Projectile.Kill();
                player.reuseDelay = 2;
            }
            else if (isDone)
            {
                Vector2 mouseWorld = Main.MouseWorld;
                int dir = (player.DirectionTo(mouseWorld).X > 0f) ? 1 : -1;
                if ((float)dir != Projectile.velocity.X)
                {
                    player.ChangeDir(dir);
                    Projectile.velocity = new Vector2(dir, 0f);
                    Projectile.netUpdate = true;
                    Projectile.rotation -= (float)Math.PI;
                }
            }

            float rotationValue = Projectile.rotation - (float)Math.PI / 4f * (float)sign;
            Vector2 positionVector = (rotationValue + (sign == -1 ? (float)Math.PI : 0f)).ToRotationVector2() * scaleFactor;

            // Calculate the draw origin to center the projectile
            Vector2 drawOrigin = new(Projectile.width * 0.5f, Projectile.height * 0.5f);
            if (sign == -1)
            {
                drawOrigin.X += 11f; // Adjust this offset for left direction
            }
            else
            {
                drawOrigin.X -= 11f; // Adjust this offset for right direction
            }

            // Update projectile position
            Projectile.position = relativePoint - drawOrigin + positionVector;

            //Projectile.position = relativePoint - Projectile.Size / 2f;
            //Projectile.position += positionVector;
            Projectile.spriteDirection = Projectile.direction; //???? is this what makes it rotate???
            Projectile.timeLeft = 2;

            player.ChangeDir(Projectile.direction);
            player.heldProj = Projectile.whoAmI;
            player.itemTime = 2;
            player.itemAnimation = 2;
            player.itemRotation = MathHelper.WrapAngle(Projectile.rotation);
        }
    }
}
