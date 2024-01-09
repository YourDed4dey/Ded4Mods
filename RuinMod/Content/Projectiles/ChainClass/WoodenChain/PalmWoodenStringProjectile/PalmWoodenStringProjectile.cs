/*using Terraria;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using RuinMod.Content.Classes.ChainClass;

namespace RuinMod.Content.Projectiles.ChainClass.WoodenChain.PalmWoodenStringProjectile;

internal class PalmWoodenStringProjectile : ModProjectile
{
	public override void SetStaticDefaults()
	{
		//DisplayName.SetDefault("Palmwood Wooden String");
	}

	public override void SetDefaults()
	{
		Projectile.width = 14;
		Projectile.height = 7;



		Projectile.DamageType = ModContent.GetInstance<ChainClassDamage>();
		Projectile.damage = 4;
		Projectile.extraUpdates = 2;



		Projectile.aiStyle = ProjAIStyleID.ScutlixLaser;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.penetrate = 1;
		Projectile.timeLeft = 50;


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

