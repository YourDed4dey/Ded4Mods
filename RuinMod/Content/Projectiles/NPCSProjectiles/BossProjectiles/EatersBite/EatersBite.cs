/*using Terraria;
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

namespace RuinMod.Content.Projectiles.NPCSProjectiles.BossProjectiles.EatersBite
{
	internal class EatersBite : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Eaters Bite");
		}

		public override void SetDefaults()
		{
			Projectile.width = 14;
			Projectile.height = 16;



			Projectile.DamageType = DamageClass.Generic;
			Projectile.damage = 25;
			Projectile.CritChance = 3;
			Projectile.extraUpdates = 2;



			Projectile.aiStyle = ProjectileID.EatersBite;
			Projectile.friendly = false;
			Projectile.hostile = true;
			Projectile.penetrate = 15;
			Projectile.timeLeft = 600;



			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.rotation *= 0f * Projectile.direction;
		}

		public override void AI()
		{
			int dust = Dust.NewDust(Projectile.Center, 1, 1, DustID.CorruptGibs, 0f, 0f, 0, default(Color), 1f);
			Main.dust[dust].velocity *= 0.2f;
			Main.dust[dust].scale = (float)Main.rand.Next(80, 115) * 0.013f;
			Main.dust[dust].noGravity = true;
			Projectile.spriteDirection = Projectile.direction;
			//Projectile.rotation += 0.4f * (float)Projectile.direction; //what makes it rotate 360 degrees 
		}
	}
}*/
