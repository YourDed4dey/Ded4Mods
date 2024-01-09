using System;
using System.Numerics;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace RuinTesting.Common.Global
{
    public class RuinTestingGlobalProjectile : GlobalProjectile
    {
        public Action<Projectile> meteorExplosionDelegate;
        public override bool InstancePerEntity => true;
        public override bool OnTileCollide(Projectile projectile, Microsoft.Xna.Framework.Vector2 oldVelocity)
        {
            RuinTesting modInstance = ModContent.GetInstance<RuinTesting>();
            meteorExplosionDelegate?.Invoke(projectile);
            return base.OnTileCollide(projectile, oldVelocity);
        }
    }
}
