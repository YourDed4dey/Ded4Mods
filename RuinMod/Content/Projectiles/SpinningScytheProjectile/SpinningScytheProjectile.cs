/*using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace RuinMod.Content.Projectiles.SpinningScytheProjectile
{
    internal class SpinningScytheProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Abandoned Scythe");
        }

        public override void SetDefaults()
        {
            Projectile.width = 160;
            Projectile.height = 160;



            Projectile.DamageType = DamageClass.Generic;
            Projectile.damage = 300;
            Projectile.CritChance = 18;



            Projectile.aiStyle = 0; //boomerang AI is 3
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = -1;



            Projectile.light = 6f; //light 
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (!target.HasBuff(BuffID.CursedInferno))
            {
                target.AddBuff(BuffID.CursedInferno, 60 * 3);
            }
        }

        public override void AI()
        {
            float num = 48f;
            float num2 = 2f;
            float quarterPi = -(float)Math.PI / 4f;

            float scaleFactor = 20f;

            Player player = Main.player[Projectile.owner];
            Vector2 relativePoint = player.RotatedRelativePoint(player.MountedCenter);
            if(player.dead)
            {
                Projectile.Kill();
                return;
            }

            int sign = Math.Sign(Projectile.velocity.X);

            Projectile.velocity = new Vector2(sign, 0f);

            if (Projectile.ai[0] == 0f)
            {
                Projectile.rotation = new Vector2(sign, 0f - player.gravDir).ToRotation() + quarterPi + (float)Math.PI;
                if(Projectile.velocity.X < 0f)
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
            } else if (isDone)
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

            Vector2 dustVector1 = Projectile.Center + (rotationValue + ((sign == -1) ? ((float)Math.PI) : 0f)).ToRotationVector2() * 30f;
            Vector2 dustPosition = rotationValue.ToRotationVector2();
            Vector2 dustVector2 = dustPosition.RotatedBy((float)Math.PI / 2f * (float)Projectile.spriteDirection);

            if(Main.rand.NextBool(2))
            {
                Dust dust = Dust.NewDustDirect(dustVector1 - new Vector2(5f), 10, 10, DustID.TerraBlade, player.velocity.X, player.velocity.Y, 150);
                dust.velocity = Projectile.DirectionTo(dust.position) * 0.1f + dust.velocity * 0.1f;
            }


            Projectile.position = relativePoint - Projectile.Size / 2f;
            Projectile.position += positionVector;
            Projectile.spriteDirection = Projectile.direction; //???? is this what makes it rotate???
            Projectile.timeLeft = 2;

            player.ChangeDir(Projectile.direction);
            player.heldProj = Projectile.whoAmI;
            player.itemTime = 2;
            player.itemAnimation = 2;
            player.itemRotation = MathHelper.WrapAngle(Projectile.rotation);
        }
    }
}*/

