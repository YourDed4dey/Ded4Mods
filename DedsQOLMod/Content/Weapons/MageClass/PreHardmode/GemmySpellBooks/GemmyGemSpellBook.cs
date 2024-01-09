using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using DedsQOLMod.Content.Projectiles.Gems;
using Terraria.DataStructures;

namespace DedsQOLMod.Content.Weapons.MageClass.PreHardmode.GemmySpellBooks
{
    public class GemmyGemSpellBook : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 7;
            Item.scale = .9f;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 10;
            Item.width = 28;
            Item.height = 30;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 4;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item8;
            //Item.autoReuse = true;
            Item.shoot = ProjectileID.Bullet; // Replace with your gem projectile type
            Item.shootSpeed = 12f;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(4, 4);
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int[] gemProjectiles = new int[]
            {
                ModContent.ProjectileType<Amber>(),
                ModContent.ProjectileType<Amethyst>(),
                ModContent.ProjectileType<Diamond>(),
                ModContent.ProjectileType<Emerald>(),
                ModContent.ProjectileType<Ruby>(),
                ModContent.ProjectileType<Sapphire>(),
                ModContent.ProjectileType<Topaz>()
            };
            int randomProjectileIndex = Main.rand.Next(gemProjectiles.Length);
            int randomProjectileType = gemProjectiles[randomProjectileIndex];

            int proj = Projectile.NewProjectile(source, position, velocity, randomProjectileType, damage, knockback, player.whoAmI);
            Main.projectile[proj].aiStyle = AmmoID.Bullet; //Makes proj stop in air, looks cool
            Main.projectile[proj].timeLeft = 200;
            int penetrationNum = Main.rand.Next(1,10);
            Main.projectile[proj].penetrate = penetrationNum;

            return false;
        }
        public override bool CanUseItem(Player player)
        {
            return player.statMana >= Item.mana;
        }
    }
}
