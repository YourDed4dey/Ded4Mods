/*using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RuinMod.Content.Projectiles.NPCSProjectiles.BossProjectiles.HauntingSkull
{
    internal class RedBossProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Haunting Skull");
        }

        public override void SetDefaults()
        {
            Projectile.width = 50;
            Projectile.height = 60;
            Projectile.scale = 1.25f;



            Projectile.DamageType = DamageClass.Generic;
            Projectile.damage = 100;
            Projectile.CritChance = 18;
            Projectile.extraUpdates = 2;



            Projectile.aiStyle = -1; //boomerang AI is 3 // 27
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.penetrate = 30;
            Projectile.timeLeft = 600;



            Projectile.light = 5f; //light 
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.rotation *= 0f * Projectile.direction;
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            if (!target.HasBuff(ModContent.BuffType<Potions.Debuffs.RedemptionDebuff.RedemptionDebuff>()))
            {
                target.AddBuff(ModContent.BuffType<Potions.Debuffs.RedemptionDebuff.RedemptionDebuff>(), 60 * 20);
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {

            if (!target.HasBuff(ModContent.BuffType<Potions.Debuffs.RedemptionDebuff.RedemptionDebuff>()))
            {
                target.AddBuff(ModContent.BuffType<Potions.Debuffs.RedemptionDebuff.RedemptionDebuff>(), 60 * 20);
            }
        }

        public override void AI()
        {
            int dust = Dust.NewDust(Projectile.Center, 1, 1, DustID.SomethingRed, 0f, 0f, 0, default(Color), 1f);
            Main.dust[dust].velocity *= 0.2f;
            Main.dust[dust].scale = (float)Main.rand.Next(80, 115) * 0.013f;
            Main.dust[dust].noGravity = true;
            Projectile.spriteDirection = Projectile.direction;
            //Projectile.rotation += 0.4f * (float)Projectile.direction; //what makes it rotate 360 degrees 
        }

    }
}*/
