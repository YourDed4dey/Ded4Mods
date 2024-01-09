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

namespace RuinMod.Content.Projectiles.NPCSProjectiles.BossProjectiles.HandOfJudgment
{
	internal class HandOfJudgment : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Hand of Judgment");
            Main.projFrames[Projectile.type] = 4;
        }

		public override void SetDefaults()
		{
			Projectile.width = 38;
			Projectile.height = 34;


			Projectile.DamageType = DamageClass.Generic;
			Projectile.damage = 25;
			Projectile.CritChance = 3;
			Projectile.extraUpdates = 2;



			Projectile.aiStyle = -1;
			Projectile.friendly = false;
			Projectile.hostile = true;
			Projectile.penetrate = 15;
			Projectile.timeLeft = 600;



			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.rotation = 0;
			Projectile.light = ProjectileID.EyeFire;
		}

		public override void AI()
		{
			int dust = Dust.NewDust(Projectile.Center, 1, 1, DustID.CorruptGibs, 0f, 0f, 0, default(Color), 1f);
			Main.dust[dust].velocity *= 0.2f;
			Main.dust[dust].scale = (float)Main.rand.Next(80, 115) * 0.013f;
			Main.dust[dust].noGravity = true;

            Projectile.rotation = (float)Math.Atan2((double)Projectile.velocity.Y, (double)Projectile.velocity.X) + 3f;
            Projectile.rotation = Projectile.velocity.ToRotation();

            if (++Projectile.frameCounter >= 8)
            {
                Projectile.frameCounter = 0;
                if (++Projectile.frame >= 4)
                {
                    Projectile.frame = 0;
                }
            }
        }
	}
}*/
