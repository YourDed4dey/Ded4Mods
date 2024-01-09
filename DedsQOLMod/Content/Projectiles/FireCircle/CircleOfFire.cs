using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Projectiles.FireCircle
{
    public class CircleOfFire : ModProjectile
    {
        private bool initialized = false;
        private NPC targetNPC;
        public override void SetDefaults()
        {
            Projectile.width = 1;
            Projectile.height = 1;
            Projectile.penetrate = -1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.timeLeft = 600; // Adjust the time as needed
        }

        public override void AI()
        {
            if (!initialized)
            {
                FindClosestEnemy();
                initialized = true;
            }

            if (targetNPC == null || !targetNPC.active)
            {
                Projectile.Kill();
                return;
            }

            Vector2 targetPosition = targetNPC.Center;
            Vector2 direction = targetPosition - Projectile.Center;
            direction.Normalize();
            Projectile.velocity = direction * 3f;

            Vector2 center = Projectile.Center;
            float radius = 5 * 16f; // Convert radius from blocks to pixels


            for (float angle = 0; angle < MathHelper.TwoPi; angle += MathHelper.Pi / 30f) //# of particles
            {
                Vector2 offset = new Vector2(radius, 0).RotatedBy(angle);
                Vector2 position = center + offset;

                // Calculate the direction between the projectile and the current position
                Vector2 direction1 = position - center;
                direction1.Normalize();

                // Check for collisions with tiles and walls
                bool noCollision = true;
                for (int i = 1; i <= (int)(radius / 16); i++) // Check in increments of tiles
                {
                    Vector2 checkPosition = center + direction1 * (i * 16);
                    if (Collision.SolidCollision(checkPosition, 1, 1)) // Check for walls and solid tiles
                    {
                        noCollision = false;
                        break;
                    }
                }

                // If there are no collisions, spawn dust
                if (noCollision)
                {
                    int dustIndex = Dust.NewDust(position, 0, 0, DustID.OrangeTorch);
                    Main.dust[dustIndex].noGravity = true;
                    Main.dust[dustIndex].velocity = Vector2.Zero;
                }
            }

            for (int i = 0; i < Main.npc.Length; i++)
            {
                NPC npc = Main.npc[i];
                if (npc.active && !npc.friendly && Vector2.Distance(center, npc.Center) <= radius)
                {
                    npc.AddBuff(BuffID.OnFire, 60); // Apply "On Fire!" buff for 1 second
                    npc.AddBuff(BuffID.Oiled, 60);
                }
            }
        }

        private void FindClosestEnemy()
        {
            Vector2 center = Projectile.Center;
            float minDistance = float.MaxValue;
            targetNPC = null;

            for (int i = 0; i < Main.npc.Length; i++)
            {
                NPC npc = Main.npc[i];
                if (npc.active && !npc.friendly)
                {
                    float distance = Vector2.Distance(center, npc.Center);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        targetNPC = npc;
                    }
                }
            }

            // If no valid NPC found, kill the projectile
            if (targetNPC == null)
            {
                Projectile.Kill();
            }
        }
    }
}
