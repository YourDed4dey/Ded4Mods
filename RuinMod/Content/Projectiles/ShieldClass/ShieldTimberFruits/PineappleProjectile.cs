using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using RuinMod.Content.Classes.ShieldClass;
using System;

namespace RuinMod.Content.Projectiles.ShieldClass.ShieldTimberFruits
{
    internal class PineappleProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Pineapple");
        }

        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 32;



            Projectile.DamageType = ModContent.GetInstance<ShieldClassDamage>();
            Projectile.damage = 44;
            Projectile.extraUpdates = 2;


            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.timeLeft = 15 * 60;



            //Projectile.light = 6f; //light 
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
            Projectile.rotation = 0 * Projectile.direction;
            Projectile.aiStyle = ProjectileID.Bullet;
        }
        public override void AI()
        {
            //Projectile.rotation += 0.1f * (float)Projectile.direction;
            Projectile.spriteDirection = Projectile.direction;

            if (Main.rand.Next(4) < 3)
            {
                Dust dust18 = Dust.NewDustDirect(new Vector2(Projectile.position.X - 2f, Projectile.position.Y - 2f), Projectile.width + 4, Projectile.height + 4, DustID.JunglePlants, Projectile.velocity.X * 0.4f, Projectile.velocity.Y * 0.4f, 100, default(Color), .5f);
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
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            int backGoreType = Mod.Find<ModGore>("PineappleProjectile_Back").Type;
            int frontGoreType = Mod.Find<ModGore>("PineappleProjectile_Front").Type;

            var entitySource = Projectile.GetSource_Death();

            Gore.NewGore(entitySource, Projectile.position, new Vector2(Main.rand.Next(-6, 7), Main.rand.Next(-6, 7)), backGoreType);
            Gore.NewGore(entitySource, Projectile.position, new Vector2(Main.rand.Next(-6, 7), Main.rand.Next(-6, 7)), frontGoreType);
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.penetrate--;
            if (Projectile.penetrate <= 0)
            {
                Projectile.Kill();
            }
            else
            {
                Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);

                if (Math.Abs(Projectile.velocity.X - oldVelocity.X) > float.Epsilon)
                {
                    Projectile.velocity.X = -oldVelocity.X;
                }
                if (Math.Abs(Projectile.velocity.Y - oldVelocity.Y) > float.Epsilon)
                {
                    Projectile.velocity.Y = -oldVelocity.Y;
                }
            }

            int backGoreType = Mod.Find<ModGore>("PineappleProjectile_Back").Type;
            int frontGoreType = Mod.Find<ModGore>("PineappleProjectile_Front").Type;

            var entitySource = Projectile.GetSource_Death();

            Gore.NewGore(entitySource, Projectile.position, new Vector2(Main.rand.Next(-6, 7), Main.rand.Next(-6, 7)), backGoreType);
            Gore.NewGore(entitySource, Projectile.position, new Vector2(Main.rand.Next(-6, 7), Main.rand.Next(-6, 7)), frontGoreType);

            return false;
        }
    }
}
