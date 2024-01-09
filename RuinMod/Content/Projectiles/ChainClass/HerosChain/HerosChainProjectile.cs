﻿/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RuinMod.Content.Classes.ChainClass;

namespace RuinMod.Content.Projectiles.ChainClass.HerosChain
{
	internal class HerosChainProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Hero's Chain");
		}

		public override void SetDefaults()
		{
			Projectile.width = 118;
			Projectile.height = 19;



			Projectile.DamageType = ModContent.GetInstance<ChainClassDamage>();
			Projectile.damage = 30;
			Projectile.extraUpdates = 2;



			Projectile.aiStyle = ProjAIStyleID.ScutlixLaser;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.penetrate = 10;
			Projectile.timeLeft = 100;


			Projectile.light = 1;
			Projectile.ignoreWater = false;
			Projectile.tileCollide = true;
			Projectile.rotation = 0;
		}

		public override void AI()
		{
			Projectile.spriteDirection = Projectile.direction;
			Projectile.rotation = Projectile.velocity.ToRotation();
			//Projectile.rotation += 0.1f * (float)Projectile.direction; //what makes it rotate 360 degrees
		}
	}
}*/