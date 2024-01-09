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
    public class ThrowableSlimedEnchantedScythe : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 52;
            Projectile.height = 46;



            Projectile.DamageType = ModContent.GetInstance<LifetakerDamageClass>();
            Projectile.damage = 31;
            Projectile.CritChance = 4;
            Projectile.extraUpdates = 2;


			Projectile.alpha = 255;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = 2;
            Projectile.timeLeft = 300;



            Projectile.ignoreWater = true;
            //Projectile.tileCollide = true;
            Projectile.rotation = 0;
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

            // Handle tile collision
            Vector2 newPosition = Projectile.position + Projectile.velocity; // Calculate new position based on velocity

            if (Collision.SolidCollision(newPosition, (int)Projectile.width, (int)Projectile.height)) // Check for collision at the new position
            {
                // Reverse velocity components to make the projectile bounce off
                if (Projectile.velocity.X != 0f)
                {
                    Projectile.velocity.X = -Projectile.velocity.X;
                }

                if (Projectile.velocity.Y != 0f)
                {
                    Projectile.velocity.Y = Projectile.velocity.Y;
                }
            }
        }
	}
}