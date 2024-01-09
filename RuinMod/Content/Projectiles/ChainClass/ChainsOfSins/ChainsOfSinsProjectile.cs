/*using Terraria;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using RuinMod.Content.Classes.ChainClass;

namespace RuinMod.Content.Projectiles.ChainClass.ChainsOfSins;

internal class ChainsOfSinsProjectile : ModProjectile
{
	public override void SetStaticDefaults()
	{
		//DisplayName.SetDefault("Chains Of Sins");
	}

	public override void SetDefaults()
	{
		Projectile.width = 27;
		Projectile.height = 7;
		Projectile.scale = 1.50f;



		Projectile.DamageType = ModContent.GetInstance<ChainClassDamage>();
		Projectile.damage = 400;
		Projectile.extraUpdates = 2;



		Projectile.aiStyle = ProjAIStyleID.ScutlixLaser;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.penetrate = -1;
		Projectile.timeLeft = 125;

		Projectile.light = 2;
		Projectile.ignoreWater = true;
		Projectile.rotation *= 0f * Projectile.direction;
	}
	public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
	{
		if (!target.HasBuff(BuffID.OnFire))
		{
			target.AddBuff(BuffID.OnFire, 60 * 3);
		}
		if (!target.HasBuff(BuffID.OnFire3))
		{
			target.AddBuff(BuffID.OnFire3, 60 * 3);
		}
	}
	public override void AI()
	{
		Projectile.spriteDirection = Projectile.direction;
		Projectile.rotation = Projectile.velocity.ToRotation();
	}
}*/
