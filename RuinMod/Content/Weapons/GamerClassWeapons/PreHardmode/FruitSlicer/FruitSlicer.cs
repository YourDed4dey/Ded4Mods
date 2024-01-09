/*using Terraria.ID;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using RuinMod.Content.Classes.GamerClass;
using RuinMod.Content.Rarity;
using RuinMod.Content.Items.Placeables.TV.Tile;

namespace RuinMod.Content.Weapons.GamerClassWeapons.PreHardmode.FruitSlicer
{
    internal class FruitSlicer : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Fruit Slicer");
            //Tooltip.SetDefault("'Follow the path of the ninja!'");
        }
        public override void SetDefaults()
        {

            Item.height = 48;
            Item.width = 54;
            Item.UseSound = SoundID.Item1;

            Item.damage = 20;
            Item.ArmorPenetration = 5;
            Item.crit = 2;
            Item.knockBack = 8;
            Item.DamageType = ModContent.GetInstance<GamerClassDamage>();

            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.autoReuse = true;

            Item.rare = ModContent.RarityType<GamerClassRarity>();

        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Katana)
                .AddIngredient(ItemID.Apple)
                .AddIngredient(ItemID.Apricot)
                .AddIngredient(ItemID.Grapefruit)
                .AddIngredient(ItemID.Lemon)
                .AddIngredient(ItemID.Peach)
                .AddTile<TVTile>()
                .Register();
        }
    }
}*/
