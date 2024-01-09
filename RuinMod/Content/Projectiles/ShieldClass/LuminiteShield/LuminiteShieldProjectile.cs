using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RuinMod.Content.Classes.ShieldClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RuinMod.Content.Projectiles.ShieldClass.LuminiteShield
{
    internal class LuminiteShieldProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 42;
            Projectile.height = 46;
            Projectile.scale -= .5f;

            Projectile.DamageType = ModContent.GetInstance<ShieldClassDamage>();
            Projectile.CritChance = 4;

            Projectile.aiStyle = 3;
            Projectile.friendly = true;
            Projectile.penetrate = 2;
            Projectile.timeLeft = 600;

            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
            Projectile.rotation = 0;
            Projectile.extraUpdates = 1;
        }
        public override void AI()
        {
            int dust = Dust.NewDust(Projectile.Center, 1, 1, DustID.LunarOre, 0f, 0f, 0, default, 1f);
            Main.dust[dust].velocity *= 0.2f;
            Main.dust[dust].scale = Main.rand.Next(80, 115) * 0.013f;
            Main.dust[dust].noGravity = true;

            //Projectile.rotation = (float)Math.Atan2((double)Projectile.velocity.Y, (double)Projectile.velocity.X) + 3f;
            //Projectile.rotation = Projectile.velocity.ToRotation();
            Projectile.rotation += 0.1f * Projectile.direction;
            Projectile.spriteDirection = Projectile.direction;
        }
    }
}