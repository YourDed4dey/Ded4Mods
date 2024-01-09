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

namespace RuinMod.Content.Projectiles.GamerClass.EggCannon
{
    internal class EggCannonProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Egg");
        }

        public override void SetDefaults()
        {
            Projectile.width = 22;
            Projectile.height = 24;

            Projectile.DamageType = ModContent.GetInstance<GamerClassDamage>();
            Projectile.damage = 14;
            Projectile.CritChance = 4;

            Projectile.friendly = true;
            Projectile.penetrate = 1;
            Projectile.aiStyle = 1;

            Projectile.tileCollide = true;
            Projectile.timeLeft = 60 * 5;
            Projectile.extraUpdates = 1;

            AIType = ProjectileID.Bullet;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            int backGoreType = Mod.Find<ModGore>("EggCannonProjectileBroken1_Back").Type;
            int frontGoreType = Mod.Find<ModGore>("EggCannonProjectileBroken2_Front").Type;

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

            int backGoreType = Mod.Find<ModGore>("EggCannonProjectileBroken1_Back").Type;
            int frontGoreType = Mod.Find<ModGore>("EggCannonProjectileBroken2_Front").Type;

            var entitySource = Projectile.GetSource_Death();

            Gore.NewGore(entitySource, Projectile.position, new Vector2(Main.rand.Next(-6, 7), Main.rand.Next(-6, 7)), backGoreType);
            Gore.NewGore(entitySource, Projectile.position, new Vector2(Main.rand.Next(-6, 7), Main.rand.Next(-6, 7)), frontGoreType);

            return false;
        }

        public override void AI()
        {
            Projectile.rotation += 0.1f * (float)Projectile.direction;
            Projectile.spriteDirection = Projectile.direction;
        }
    }
}*/
