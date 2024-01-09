using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using DedsBosses.Content.DamageClasses;
using Microsoft.CodeAnalysis;

namespace DedsBosses.Content.Projectiles.ProjectilesAllClasses.LifetakerClass.Level3.Throwable
{
    public class ThrowableTwilightCleaver : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 52;
            Projectile.height = 48;



            Projectile.DamageType = ModContent.GetInstance<LifetakerDamageClass>();
            Projectile.damage = 38;
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

            // Find the direction to the player's cursor
            Vector2 target = Main.MouseWorld;
            Vector2 direction = target - Projectile.Center;
            direction.Normalize();

            // Adjust the projectile's velocity to home in on the cursor
            float speed = 2f; // Adjust the speed as needed
            Projectile.velocity = direction * speed;
        }
    }
}