/*using RuinMod.Common.Global.DevastatedDiff.Potions.Debuffs.BadSugarRush;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RuinMod.Common.Global.DevastatedDiff.Projectiles.HostileAI.CandySpike
{
    public class CandySpikeProjectile : ModProjectile
    {
        //Projectile_605
        public override string Texture => "Terraria/Images/Projectile_" + ProjectileID.SpikedSlimeSpike;
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.SpikedSlimeSpike);
            Projectile.width = 10;
            Projectile.height = 20;
            Projectile.knockBack = 0f;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.hostile = true;
            Projectile.friendly = false;
            Projectile.hide = false;
            Projectile.alpha = 50;
        }
        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            if (!target.HasBuff(ModContent.BuffType<BadSugarRush>()))
            {
                target.AddBuff(ModContent.BuffType<BadSugarRush>(), 60 * 6);
            }
        }
        public override void AI()
        {
            Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.WhiteTorch, 0, 0, 0, default, 1.2f);
            Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + 3f;
            Projectile.rotation = Projectile.velocity.ToRotation();
        }
    }
}*/
