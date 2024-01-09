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
using RuinMod.Content.Classes.GamerClass;

namespace RuinMod.Content.Projectiles.GamerClass.EarthKunai
{
    internal class EarthKunaiProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Earth Kunai");
        }

        public override void SetDefaults()
        {
            Projectile.width = 55;
            Projectile.height = 12;

            Projectile.DamageType = ModContent.GetInstance<GamerClassDamage>();
            Projectile.damage = 25;
            Projectile.CritChance = 4;

            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.penetrate = 2;
            Projectile.timeLeft = 600;

            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
            Projectile.rotation = 0;
            Projectile.light = 1f;
        }

        public override void AI()
        {
            int dust = Dust.NewDust(Projectile.Center, 1, 1, DustID.Bone, 0f, 0f, 0, default(Color), 1f);
            Main.dust[dust].velocity *= 0.2f;
            Main.dust[dust].scale = (float)Main.rand.Next(80, 115) * 0.013f;
            Main.dust[dust].noGravity = true;

            Projectile.rotation = (float)Math.Atan2((double)Projectile.velocity.Y, (double)Projectile.velocity.X) + 3f;
            Projectile.rotation = Projectile.velocity.ToRotation();
        }
    }
}*/
