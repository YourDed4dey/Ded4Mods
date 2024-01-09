using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using DedsBosses.Content.DamageClasses;

namespace DedsBosses.Content.Projectiles.ProjectilesAllClasses.LifetakerClass.Level2.Throwable
{
    public class ThrowableHoneystrikeScythe : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 52;
            Projectile.height = 46;



            Projectile.DamageType = ModContent.GetInstance<LifetakerDamageClass>();
            Projectile.damage = 28;
            Projectile.CritChance = 4;
            Projectile.extraUpdates = 2;


			Projectile.alpha = 255;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = 2;
            Projectile.timeLeft = 100;



            Projectile.ignoreWater = true;
            //Projectile.tileCollide = false;
            Projectile.rotation = 0;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
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
        int timer;
		public override void AI()
		{
			Projectile.rotation += 0.1f * (float)Projectile.direction;
			Projectile.spriteDirection = Projectile.direction;

			if (Projectile.alpha > 70)
			{
				Projectile.alpha -= 15;
				if (Projectile.alpha < 70)
				{
					Projectile.alpha = 70;
				}
			}

            timer++;
            if (timer < 10)
            {
                Projectile.tileCollide = false;
            }
            else
            {
                Projectile.tileCollide = true;
            }
        }
	}
}