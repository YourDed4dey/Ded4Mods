/*using Terraria;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using RuinMod.Content.Classes.ChainClass;

namespace RuinMod.Content.Projectiles.ChainClass.SsargsSuffering;

internal class SsargsSufferingProjectile : ModProjectile
{
	public override void SetStaticDefaults()
	{
		//DisplayName.SetDefault("Ssarg's Suffering");
	}

	public override void SetDefaults()
	{
		Projectile.width = 28;
		Projectile.height = 16;



		Projectile.DamageType = ModContent.GetInstance<ChainClassDamage>();
		Projectile.damage = 400;
		Projectile.extraUpdates = 2;



		Projectile.aiStyle = ProjAIStyleID.ScutlixLaser;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.penetrate = -1;
		Projectile.timeLeft = 75;


		Projectile.ignoreWater = true;
		Projectile.rotation *= 0f * Projectile.direction;
	}
	public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
	{
		if (!target.HasBuff(BuffID.Poisoned))
		{
			target.AddBuff(BuffID.Poisoned, 60 * 3);
		}
	}
	public override void AI()
	{
		Projectile.spriteDirection = Projectile.direction;
		Projectile.rotation = Projectile.velocity.ToRotation();
	}
}*/
