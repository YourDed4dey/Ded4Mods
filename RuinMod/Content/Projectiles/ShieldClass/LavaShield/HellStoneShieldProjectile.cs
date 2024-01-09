using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using RuinMod.Content.Classes.ShieldClass;
using RuinMod.Common.Global.DevastatedDiff.Potions.Debuffs.Oiled;

namespace RuinMod.Content.Projectiles.ShieldClass.LavaShield
{
    internal class HellStoneShieldProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Lava Shield");
        }

        public override void SetDefaults()
        {
            Projectile.width = 18;
            Projectile.height = 24;



            Projectile.DamageType = ModContent.GetInstance<ShieldClassDamage>();
            Projectile.damage = 34;
            Projectile.extraUpdates = 2;


            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 34 * 60;



            //Projectile.light = 6f; //light 
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
            Projectile.rotation = 0;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (!target.HasBuff(BuffID.OnFire))
            {
                target.AddBuff(BuffID.OnFire, 60 * 5);
            }

            if (!target.HasBuff(ModContent.BuffType<Oiled>()))
            {
                target.AddBuff(ModContent.BuffType<Oiled>(), 60 * 5);
            }
        }

		public override void AI()
		{
			//Projectile.rotation += 0.1f * (float)Projectile.direction;
			Projectile.spriteDirection = Projectile.direction;

            if (Main.rand.Next(4) < 3)
            {
                Dust dust18 = Dust.NewDustDirect(new Vector2(Projectile.position.X - 2f, Projectile.position.Y - 2f), Projectile.width + 4, Projectile.height + 4, DustID.Lava, Projectile.velocity.X * 0.4f, Projectile.velocity.Y * 0.4f, 100, default(Color), 3.5f);
                dust18.noGravity = true;
                dust18.velocity.X = 1.8f;
                dust18.velocity.Y -= 0.5f;
                if (Main.rand.NextBool(4))
                {
                    dust18.noGravity = false;
                    dust18.scale = 0.5f;
                }
            }
        }
	}
}
