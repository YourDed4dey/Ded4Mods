using Terraria;
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

namespace RuinMod.Content.Projectiles.Ranged.VortexStar
{
    internal class VortexStar : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Vortex Star");
        }

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.SuperStar);
            Projectile.penetrate = -1;
            Projectile.light = 1f;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 60 * 10;
        }

        public override void AI()
        {
            Projectile.rotation += 0.1f * (float)Projectile.direction;
            Projectile.spriteDirection = Projectile.direction;
        }
    }
}

