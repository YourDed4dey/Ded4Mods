/*using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RuinMod.Content.Classes.GamerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RuinMod.Content.Projectiles.GamerClass.DKCannon
{
    internal class OogaBugaBanana : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 22;
            Projectile.height = 34;

            Projectile.DamageType = ModContent.GetInstance<GamerClassDamage>();
            Projectile.CritChance = 4;

            Projectile.aiStyle = 3;
            Projectile.friendly = true;
            Projectile.penetrate = 10;
            Projectile.timeLeft = 600;

            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
            Projectile.rotation = 0;
            Projectile.extraUpdates = 1;
        }
        public override void AI()
        {
            int dust = Dust.NewDust(Projectile.Center, 1, 1, DustID.YellowTorch, 0f, 0f, 0, default(Color), 1f);
            Main.dust[dust].velocity *= 0.2f;
            Main.dust[dust].scale = (float)Main.rand.Next(80, 115) * 0.013f;
            Main.dust[dust].noGravity = true;

          //Projectile.rotation = (float)Math.Atan2((double)Projectile.velocity.Y, (double)Projectile.velocity.X) + 3f;
          //Projectile.rotation = Projectile.velocity.ToRotation();
          Projectile.rotation += 0.1f * (float)Projectile.direction;
          Projectile.spriteDirection = Projectile.direction;
        }
    }
}*/
