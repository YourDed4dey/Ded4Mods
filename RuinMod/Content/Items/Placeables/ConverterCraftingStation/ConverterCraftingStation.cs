using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace RuinMod.Content.Items.Placeables.ConverterCraftingStation
{
    public class ConverterCraftingStation : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Converter");
            //Tooltip.SetDefault("Converts ores and bars");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.createTile = ModContent.TileType<Tile.ConverterCraftingStationTile>(); // This sets the id of the tile that this item should place when used.

            Item.width = 30; // The item texture's width
            Item.height = 18; // The item texture's height

            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 10;
            Item.useAnimation = 15;

            Item.maxStack = 99;
            Item.consumable = true;
            Item.rare = ItemRarityID.Orange;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                //.AddIngredient(ModContent.ItemType<Items.LostFragment.LostFragment>(), 15)
                .AddIngredient(ItemID.DemoniteBar, 15)
                .AddIngredient(ItemID.Bone, 5)
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.CrimtaneBar, 15)
                .AddIngredient(ItemID.Bone, 5)
                .Register();
        }
    }
}