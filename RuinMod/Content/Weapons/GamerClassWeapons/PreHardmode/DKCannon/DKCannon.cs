/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;
using RuinMod.Content.Projectiles.GamerClass.EggCannon;
using Terraria.GameContent.Creative;
using RuinMod.Content.Classes.GamerClass;
using RuinMod.Content.Projectiles.GamerClass.DKCannon;
using RuinMod.Content.Rarity;

namespace RuinMod.Content.Weapons.GamerClassWeapons.PreHardmode.DKCannon
{
    internal class DKCannon : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("DK Cannon");
            //Tooltip.SetDefault("'Bananaaaaa!'");
        }
        public override void SetDefaults()
        {
            Item.width = 52;
            Item.height = 42;

            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useTime = 12;
            Item.useAnimation = 12;

            Item.damage = 23;
            Item.DamageType = GetInstance<GamerClassDamage>();
            Item.crit = -4;
            Item.knockBack = 3f;
            Item.autoReuse = true;

            Item.shootSpeed = 14f;
            Item.shoot = ProjectileType<OogaBugaBanana>();
            Item.useAmmo = AmmoID.Bullet;
            Item.noMelee = true;
            Item.UseSound = SoundID.Item7;

            Item.rare = ModContent.RarityType<GamerClassRarity>();
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            type = ProjectileType<OogaBugaBanana>();
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddRecipeGroup(RecipeGroupID.Wood, 75)
                .AddIngredient(ItemID.IronBar, 15)
                .AddIngredient(ItemID.Banana, 1)
                .AddTile(TileID.WorkBenches)
                .Register();

            CreateRecipe()
                .AddRecipeGroup(RecipeGroupID.Wood, 75)
                .AddIngredient(ItemID.LeadBar, 15)
                .AddIngredient(ItemID.Banana, 1)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}*/
