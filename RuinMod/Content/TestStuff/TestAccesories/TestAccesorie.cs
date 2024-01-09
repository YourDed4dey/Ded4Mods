/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using Terraria.ModLoader.IO;
using Mono.Cecil;
using Terraria.DataStructures;

namespace RuinMod.Content.TestStuff.TestAccesories
{
    internal class TestAccesorie : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.LifeforcePotion;
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("E");
        }

        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.rare = ItemRarityID.Red;
            Item.value = Item.sellPrice(gold: 15);
            //Item.shoot = ProjectileType<Projectiles.NothingProjectile>();
            //Item.shootSpeed = 5f;

            Item.color = Color.DarkViolet;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statLifeMax2 = 400;
        }
    }
}


            /*float speed = 0f;
            Vector2 direction = player.Top;
            Vector2 velocity = direction * speed;

            int proj = Projectile.NewProjectile(null,Main.MouseWorld, velocity, ProjectileID.RainbowCrystalExplosion, 10, 0, player.whoAmI);
            Main.projectile[proj].friendly = true;
            Main.projectile[proj].hostile = false;
            Main.projectile[proj].timeLeft = 2;
            Main.projectile[proj].rotation = 0;
            Main.projectile[proj].ArmorPenetration = 100;*/
            /*float maxSpeed = 0f;
              float speed = 0f;
            Vector2 direction = Main.MouseWorld - Main.projectile[proj].position * speed + Main.projectile[proj].velocity;

            Main.projectile[proj].velocity = direction * speed;

            Main.projectile[proj].velocity = direction * speed;

            if (Main.projectile[proj].velocity.X > maxSpeed)
                Main.projectile[proj].velocity.X = maxSpeed;
            else if (Main.projectile[proj].velocity.X < -maxSpeed)
                Main.projectile[proj].velocity.X = -maxSpeed;
            if (Main.projectile[proj].velocity.Y > maxSpeed)
                Main.projectile[proj].velocity.Y = maxSpeed;
            else if (Main.projectile[proj].velocity.Y < -maxSpeed)
                Main.projectile[proj].velocity.Y = -maxSpeed;*/

            /*float speed1 = 0f;
            Vector2 direction1 = player.Top;
            Vector2 velocity = direction1 * speed1;
            float kitingOffsetX = Utils.Clamp(player.velocity.X * 0, -100, 100);
            Vector2 positon1 = player.Top + new Vector2(kitingOffsetX + Main.rand.Next(0, 0), Main.rand.Next(-35, -35));

            int proj = Projectile.NewProjectile(null, positon1, velocity, ProjectileID.RainbowCrystalExplosion, 25, 0, player.whoAmI);
            //int proj = Projectile.NewProjectile(null,Main.MouseWorld, velocity, ProjectileID.RainbowCrystalExplosion, 15, 0, player.whoAmI);
            Main.projectile[proj].friendly = true;
            Main.projectile[proj].hostile = false;
            Main.projectile[proj].timeLeft = 2;
            Main.projectile[proj].rotation = 0;
            Main.projectile[proj].ArmorPenetration = 100;
        }
    }
}*/
