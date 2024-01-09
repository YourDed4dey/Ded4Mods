/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace RuinMod.Content.Projectiles.MeleeProjectiles.SwordOfSouls
{
    internal class SwordOfSoulsFlightProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 86;
            Projectile.height = 36;
            Projectile.scale -= .1f;

            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 60 * 5;
            Projectile.tileCollide = false;
        }
        public override void AI()
        {
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
            float maxhome = 800f;
            bool target = false;
            for (int k = 0; k < 200; k++)
            {
                if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5)
                {
                    Vector2 newHome = Main.npc[k].Center - Projectile.Center;
                    float howFar = (float)Math.Sqrt(newHome.X * newHome.X + newHome.Y * newHome.Y);
                    if (howFar < maxhome)
                    {
                        move = newHome;
                        maxhome = howFar;
                        target = true;
                    }
                }
            }
            if (target)
            {
                AdjustMagnitude(ref move);
                Projectile.velocity = (10 * Projectile.velocity + move) / 5f;
                AdjustMagnitude(ref Projectile.velocity);
            }

            Vector2 vector14 = Projectile.Center + Projectile.velocity * 3f;
            if (Main.rand.NextBool(3))
            {
                int num30 = Dust.NewDust(vector14 - Projectile.Size / 2f, Projectile.width, Projectile.height, DustID.IceTorch, Projectile.velocity.X, Projectile.velocity.Y, 100, default(Color), 2f);
                Main.dust[num30].noGravity = true;
                Main.dust[num30].position -= Projectile.velocity;
            }
        }
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
