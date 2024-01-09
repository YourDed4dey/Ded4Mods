using Microsoft.Xna.Framework;
using RuinMod.Common.Global.DevastatedDiff.Potions.Debuffs.Oiled;
using RuinMod.Content.Classes.ShieldClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RuinMod.Content.Projectiles.ShieldClass.MiniMothronBaby
{
    internal class MiniMothronBabyProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 4;
            //DisplayName.SetDefault("Mini-Mothron Baby");
        }

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.Bee);
            Projectile.width = 10;
            Projectile.height = 10;

            Projectile.DamageType = ModContent.GetInstance<ShieldClassDamage>();
            Projectile.damage = 45;

            Projectile.friendly = true;
            Projectile.hostile = false;
        }
        public override void AI()
        {
            //Projectile.rotation += 0.1f * (float)Projectile.direction;
            //Projectile.spriteDirection = Projectile.direction;

            if (Main.rand.Next(4) < 3)
            {
                Dust dust18 = Dust.NewDustDirect(new Vector2(Projectile.position.X - 2f, Projectile.position.Y - 2f), Projectile.width + 4, Projectile.height + 4, DustID.Mothron, Projectile.velocity.X * 0.4f, Projectile.velocity.Y * 0.4f, 100, default(Color), .20f);
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
