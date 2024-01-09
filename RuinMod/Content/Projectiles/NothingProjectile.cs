using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RuinMod.Content.Projectiles
{
    internal class NothingProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            
        }

        public override void SetDefaults()
        {
            Projectile.width = 64;
            Projectile.height = 64;

            Projectile.aiStyle = -1; //20
            Projectile.friendly = true;
            Projectile.damage = 0;
            Projectile.penetrate = 0;
            Projectile.tileCollide = true;
            Projectile.timeLeft = 1;

        }
    }
}
