/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RuinMod.Content.Projectiles.NPCSProjectiles.BossProjectiles.CrystalBolt
{
    public class CrystalBoltProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 26;
            Projectile.height = 16;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.hostile = true;
            Projectile.friendly = false;
        }
        public override void AI()
        {
            Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.GreenTorch, 0, 0, 0, default, 1.2f);
            Projectile.rotation = (float)Math.Atan2((double)Projectile.velocity.Y, (double)Projectile.velocity.X) + 3f;
            Projectile.rotation = Projectile.velocity.ToRotation();
        }
    }
}*/
