/*using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RuinMod.Content.Projectiles.MeleeProjectiles.YaquiturimishaButterfly
{
    internal class YaquiturimishaButterflyYellow : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 5;
        }

        public override void SetDefaults()
        {
            Projectile.width = 90;
            Projectile.height = 66;

            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 60 * 8;
            Projectile.tileCollide = false;
            Projectile.light = 1f;
        }
        public override void AI()
        {
            if (++Projectile.frameCounter >= 4)
            {
                Projectile.frameCounter = 0;
                if (++Projectile.frame >= 5)
                {
                    Projectile.frame = 0;
                }
            }
            Projectile.rotation = (float)Math.Atan2((double)Projectile.velocity.Y, (double)Projectile.velocity.X) + 3f;
            Projectile.rotation = Projectile.velocity.ToRotation();

            if (Projectile.alpha > 70)
            {
                Projectile.alpha -= 15;
                if (Projectile.alpha < 70)
                {
                    Projectile.alpha = 70;
                }
            }
            if (Projectile.localAI[0] == 0f)
            {
                AdjustMagnitude(ref Projectile.velocity);
                Projectile.localAI[0] = 1f;
            }
            Vector2 move = Vector2.Zero;
            float distance = 150f; //400f
            bool target = false;
            for (int k = 0; k < 200; k++)
            {
                if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5)
                {
                    Vector2 newMove = Main.MouseWorld - Projectile.Center ;
                    float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
                    if (distanceTo < distance)
                    {
                        move = newMove;
                        distance = distanceTo;
                        target = true;
                    }
                }
            }
            if (target)
            {
                AdjustMagnitude(ref move);
                Projectile.velocity = (10 * Projectile.velocity + move) / 11f;
                AdjustMagnitude(ref Projectile.velocity);
            }

            /*float maxSpeed = 25f;
            float speed1 = 25f;
            Vector2 direction = Main.MouseWorld - Projectile.position * speed1 + Projectile.velocity;

            Projectile.velocity = direction * speed1;

            Projectile.velocity = direction * speed1;

            if (Projectile.velocity.X > maxSpeed)
                Projectile.velocity.X = maxSpeed;
            else if (Projectile.velocity.X < -maxSpeed)
                Projectile.velocity.X = -maxSpeed;
            if (Projectile.velocity.Y > maxSpeed)
                Projectile.velocity.Y = maxSpeed;
            else if (Projectile.velocity.Y < -maxSpeed)
                Projectile.velocity.Y = -maxSpeed;*/
        /*}
        private void AdjustMagnitude(ref Vector2 vector)
        {
            float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (magnitude > 6f)
            {
                vector *= 6f / magnitude;
            }
        }
    }
}*/
