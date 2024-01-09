/*using Terraria;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using RuinMod.Content.Classes.GamerClass;

namespace RuinMod.Content.Projectiles.ChainClass.BarkBarkChain;

internal class BarkBarkChainProjectile : ModProjectile
{
	public override void SetStaticDefaults()
	{
		//DisplayName.SetDefault("Bark-BAARK");
	}

	public override void SetDefaults()
	{
		Projectile.width = 40;
		Projectile.height = 38;



		Projectile.DamageType = ModContent.GetInstance<GamerClassDamage>();
		Projectile.damage = 400;
		Projectile.extraUpdates = 2;



		Projectile.aiStyle = ProjAIStyleID.ScutlixLaser;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.penetrate = -1;
		Projectile.timeLeft = 250;


		Projectile.light = 6f; //light 
		Projectile.ignoreWater = true;
		Projectile.tileCollide = false;
		Projectile.rotation *= 0f * Projectile.direction;
	}

	public override void AI()
	{
		Projectile.spriteDirection = Projectile.direction;
		Projectile.rotation = Projectile.velocity.ToRotation();
	}
}*/
