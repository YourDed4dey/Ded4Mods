/*using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace RuinTesting.Content.Projectiles.NPCsProjectiles.BossProjectiles
{
    public class LunarBeamProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            // Set projectile properties
            Projectile.width = 74;
            Projectile.height = 26;
            Projectile.hostile = true;
            Projectile.friendly = false;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.alpha = 255;
            Projectile.timeLeft = 180;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            // Get a reference to the boss NPC
            NPC boss = Main.npc[(int)Projectile.ai[0]];

            if (!boss.active || boss.life <= 0)
            {
                // If the boss is dead or inactive, stop drawing the projectile
                return false;
            }

            // Get the position of the boss and the player
            Vector2 bossPosition = boss.Center;
            Vector2 playerPosition = Main.player[Projectile.owner].Center;

            // Calculate the direction and length of the laser beam
            Vector2 direction = Vector2.Normalize(playerPosition - bossPosition);
            float length = (playerPosition - bossPosition).Length();

            // Set the laser beam's color
            Color beamColor = new Color(255, 0, 0) * 0.8f; // Adjust the color as desired

            // Draw the laser beam
            float rotation = direction.ToRotation();
            Main.spriteBatch.Draw(Main.magicPixel, bossPosition, null, beamColor, rotation, new Vector2(0f, 1f), new Vector2(length, Projectile.height), SpriteEffects.None, 0f);

            return false; // Prevent default drawing
        }

        public override void AI()
        {
            // Get a reference to the boss NPC
            NPC boss = Main.npc[(int)Projectile.ai[0]];

            if (!boss.active || boss.life <= 0)
            {
                // If the boss is dead or inactive, kill the projectile
                Projectile.Kill();
                return;
            }

            // Set the position and direction of the projectile relative to the boss
            Projectile.Center = boss.Center + new Vector2(0, boss.height / 2);
            Projectile.velocity = boss.DirectionTo(Main.player[Projectile.owner].Center) * 20f;

            // Rotate the projectile based on its velocity
            Projectile.rotation = Projectile.velocity.ToRotation();

            // Set the projectile's transparency based on its remaining time
            if (Projectile.timeLeft <= 60)
            {
                Projectile.alpha = (int)(255f * (1f - (Projectile.timeLeft / 60f)));
            }
        }
    }
}*/
