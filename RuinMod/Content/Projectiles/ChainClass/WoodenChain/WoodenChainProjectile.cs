/*using Terraria;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using RuinMod.Content.Classes.ChainClass;

namespace RuinMod.Content.Projectiles.ChainClass.WoodenChain;

internal class WoodenChainProjectile : ModProjectile
{
	public override void SetStaticDefaults()
	{
		//DisplayName.SetDefault("Wooden Chain");
	}

	public override void SetDefaults()
	{
		Projectile.width = 28;
		Projectile.height = 14;
		Projectile.scale = 1f;



		Projectile.DamageType = ModContent.GetInstance<ChainClassDamage>();
		Projectile.damage = 1;
		Projectile.extraUpdates = 2;



		Projectile.aiStyle = ProjAIStyleID.ScutlixLaser;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.penetrate = 10;
		Projectile.timeLeft = 100;


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
}*/


