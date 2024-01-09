/*using Terraria;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using RuinMod.Content.Classes.ChainClass;

namespace RuinMod.Content.Projectiles.ChainClass.ChainOfCosmos.CosmosProjectiles;

internal class CosmosAngelsPain : ModProjectile
{
	public override void SetStaticDefaults()
	{
		//DisplayName.SetDefault("Cosmos Angel's Pain");
	}

	public override void SetDefaults()
	{
		Projectile.width = 76;
		Projectile.height = 38;



		Projectile.DamageType = ModContent.GetInstance<ChainClassDamage>();
		Projectile.damage = 400;
		Projectile.extraUpdates = 2;



		Projectile.aiStyle = ProjAIStyleID.ScutlixLaser;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.penetrate = -1;
		Projectile.timeLeft = 350;


		Projectile.light = 6f; //light 
		Projectile.ignoreWater = true;
		Projectile.tileCollide = false;
		Projectile.rotation *= 0f * Projectile.direction;
	}

	public override void AI()
	{
		Projectile.spriteDirection = Projectile.direction;
		Projectile.rotation = Projectile.velocity.ToRotation();
		if (Projectile.alpha > 70)
		{
			Projectile.alpha -= 15;
			if (Projectile.alpha < 70)
			{
				Projectile.alpha = 70;
			}
		}
		if (Projectile.localAI[0] == 0f)
		{
			AdjustMagnitude(ref Projectile.velocity);
			Projectile.localAI[0] = 1f;
		}
		Vector2 move = Vector2.Zero;
		float distance = 400f;
		bool target = false;
		for (int k = 0; k < 200; k++)
		{
			if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5)
			{
				Vector2 newMove = Main.npc[k].Center - Projectile.Center;
				float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
				if (distanceTo < distance)
				{
					move = newMove;
					distance = distanceTo;
					target = true;
				}
			}
		}
		if (target)
		{
			AdjustMagnitude(ref move);
			Projectile.velocity = (10 * Projectile.velocity + move) / 11f;
			AdjustMagnitude(ref Projectile.velocity);
		}
	}

	private void AdjustMagnitude(ref Vector2 vector)
	{
		float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
		if (magnitude > 6f)
		{
			vector *= 6f / magnitude;
		}
	}
}*/
