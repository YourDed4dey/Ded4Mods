using Microsoft.Xna.Framework;
using RuinMod.Common.Global.DevastatedDiff.Potions.Debuffs.Oiled;
using RuinMod.Content.Classes.ShieldClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RuinMod.Content.Projectiles.ShieldClass.Hearted
{
    internal class HeartedProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Hearted");
        }

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.TerraBeam);
            Projectile.width = 44;
            Projectile.height = 44;

            Projectile.DamageType = ModContent.GetInstance<ShieldClassDamage>();
            Projectile.damage = 92;
            Projectile.extraUpdates = 2;

            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = 8;
            Projectile.timeLeft = 16 * 60;

            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
        }
        public override void AI()
        {
            //Projectile.rotation += 0.1f * (float)Projectile.direction;
            //Projectile.spriteDirection = Projectile.direction;

            if (Main.rand.Next(4) < 3)
            {
                Dust dust18 = Dust.NewDustDirect(new Vector2(Projectile.position.X - 2f, Projectile.position.Y - 2f), Projectile.width + 4, Projectile.height + 4, DustID.HeartCrystal, Projectile.velocity.X * 0.4f, Projectile.velocity.Y * 0.4f, 100, default(Color), 1.5f);
                dust18.noGravity = true;
                dust18.velocity.X = 1.8f;
                dust18.velocity.Y -= 0.5f;
                if (Main.rand.NextBool(4))
                {
                    dust18.noGravity = false;
                    dust18.scale = 0.5f;
                }
            }
        }
    }
}
