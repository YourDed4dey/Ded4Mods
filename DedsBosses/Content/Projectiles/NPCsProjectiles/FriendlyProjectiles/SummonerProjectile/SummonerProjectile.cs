using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DedsBosses.Content.Projectiles.NPCsProjectiles.FriendlyProjectiles.SummonerProjectile
{
    public class SummonerProjectile : ModProjectile
    {
        private bool dashing = false;
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 2;
        }
        public override void SetDefaults()
        {
            // Set Projectile defaults
            Projectile.width = 20;
            Projectile.height = 32;
            Projectile.friendly = true;
            Projectile.minion = true;
            Projectile.aiStyle = -1;
            Projectile.timeLeft = 360;
            Projectile.tileCollide = true;
            Projectile.npcProj = true;
            Projectile.penetrate = 2;

            // Set up animation frames
            //Main.projFrames[Projectile.type] = 2;
        }
        private int timer = 60;
        public override void AI()
        {
            NPC target = GetClosestEnemy(Projectile.Center, 2000f);

            if (target != null)
            {
                if (!dashing)
                {
                    Vector2 projectileToTarget = target.Center - Projectile.Center;
                    projectileToTarget.Normalize();

                    Projectile.rotation = projectileToTarget.ToRotation() + -MathHelper.PiOver2;

                    /*Vector2 direction = target.Center - Projectile.Center;
                    direction.Normalize();*/
                    //Projectile.velocity = direction * 16f;
                    /*Projectile.velocity = Vector2.Normalize(projectileToTarget) * 5f; //Change depending on difficulty
                    dashing = true;*/
                }

                Projectile.spriteDirection = Projectile.velocity.X > 0 ? 1 : -1;
                AnimateProjectile();
                if (timer <= 0)
                {
                    Vector2 projectileToTarget = target.Center - Projectile.Center;
                    projectileToTarget.Normalize();
                    dashing = false;
                    //Projectile.velocity *= 0.98f;
                    Projectile.velocity = Vector2.Normalize(projectileToTarget) * 4f; //Change depending on difficulty
                    timer = 60; // Reset the timer to 60 ticks
                    AnimateProjectile();
                }
                else
                {
                    timer--;
                }
            }
            else
            {
                dashing = false;
                Projectile.velocity *= 0.98f;
                timer = 60; // Reset the timer to 60 ticks
                AnimateProjectile();
            }
        }

        private void AnimateProjectile()
        {
            // Animation logic
            int frameSpeed = 10; // Adjust the frame switch speed (higher values slow down animation)
            int totalFrames = 2; // Total number of frames

            // Increment frameCounter based on frameSpeed
            Projectile.frameCounter++;
            if (Projectile.frameCounter >= frameSpeed)
            {
                Projectile.frameCounter = 0;
                Projectile.frame = (Projectile.frame + 1) % totalFrames; // Cycle frames
            }
        }

        private NPC GetClosestEnemy(Vector2 position, float maxDistance)
        {
            NPC closestNPC = null;
            float closestDistance = maxDistance;

            for (int i = 0; i < Main.npc.Length; i++)
            {
                NPC npc = Main.npc[i];
                if (npc.active && !npc.friendly && npc.lifeMax > 5 && npc.type != NPCID.TargetDummy)
                {
                    float distance = npc.Distance(position);
                    if (distance < closestDistance)
                    {
                        closestNPC = npc;
                        closestDistance = distance;
                    }
                }
            }

            return closestNPC;
        }
    }
}
