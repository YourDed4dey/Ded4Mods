using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;
using System;

namespace RuinMod.Content.Projectiles.Ranged.MiniSkull
{
	internal class MiniSkullProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Mini Skull");
		}

		public override void SetDefaults()
		{
			Projectile.width = 11;
			Projectile.height = 10;
			Projectile.scale += 1f;



			Projectile.DamageType = DamageClass.Ranged;
			Projectile.damage = 35;
			Projectile.CritChance = 4;
			Projectile.extraUpdates = 2;



			Projectile.aiStyle = ProjectileID.Bullet;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.penetrate = 15;
			Projectile.timeLeft = 600;



			Projectile.ignoreWater = true;
			Projectile.tileCollide = true;
			Projectile.rotation *= 0f * Projectile.direction;
		}

		public override void AI()
		{
			Projectile.spriteDirection = Projectile.direction;
			//Projectile.rotation += 0.4f * (float)Projectile.direction; //what makes it rotate 360 degrees 
		}
	}
}
