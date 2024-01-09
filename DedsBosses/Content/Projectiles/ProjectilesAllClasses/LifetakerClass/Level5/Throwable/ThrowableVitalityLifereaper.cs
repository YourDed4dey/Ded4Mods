using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using DedsBosses.Content.DamageClasses;

namespace DedsBosses.Content.Projectiles.ProjectilesAllClasses.LifetakerClass.Level5.Throwable
{
    public class ThrowableVitalityLifereaper : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 44;
            Projectile.height = 44;



            Projectile.DamageType = ModContent.GetInstance<LifetakerDamageClass>();
            Projectile.damage = 92;
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
        }
	}
}