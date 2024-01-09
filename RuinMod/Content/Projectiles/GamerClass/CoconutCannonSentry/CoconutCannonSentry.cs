/*using Terraria;
using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria.ModLoader;

namespace RuinMod.Content.Projectiles.GamerClass.CoconutCannonSentry
{
    internal class CoconutCannonSentry : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 9;
        }
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.FrostHydra);

            Projectile.sentry = true;
        }
        public override void AI()
        {
            if (++Projectile.frameCounter >= 2)
            {
                Projectile.frameCounter = 0;
                if (++Projectile.frame >= 9)
                {
                    Projectile.frame = 0;
                }
            }
            Projectile.rotation = (float)Math.Atan2((double)Projectile.velocity.Y, (double)Projectile.velocity.X) + 3f;
            Projectile.rotation = Projectile.velocity.ToRotation();
        }
    }
}*/
