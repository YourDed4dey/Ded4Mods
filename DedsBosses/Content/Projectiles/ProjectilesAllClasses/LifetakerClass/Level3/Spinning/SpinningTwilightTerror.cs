using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System;
using DedsBosses.Content.DamageClasses;

namespace DedsBosses.Content.Projectiles.ProjectilesAllClasses.LifetakerClass.Level3.Spinning
{
    public class SpinningTwilightTerror : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 52;
            Projectile.height = 48;
            //Projectile.scale = 1.7f;


            Projectile.DamageType = ModContent.GetInstance<LifetakerDamageClass>();
            Projectile.damage = 53;
            Projectile.CritChance = 4;



            Projectile.aiStyle = 0; //boomerang AI is 3
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = -1; // Make "-1" into "1" and when player gets close to enemy they deal massive damage, good for a scythe's ability



            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
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
