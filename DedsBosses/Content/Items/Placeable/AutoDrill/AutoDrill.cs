/*using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;

namespace DedsBosses.Content.Items.Placeable.AutoDrill
{
    internal class AutoDrill : ModItem
    {
        public override void SetStaticDefaults()
        {
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(3, 19));
        }
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tile.AutoDrillTile>());
            Item.width = 64; // The item texture's width
            Item.height = 64; // The item texture's height
            Item.value = 150;
        }
        public override void AddRecipes()
        {
            /*CreateRecipe()
                .AddIngredient(ItemID.WorkBench)
                .AddIngredient<ExampleItem>(10)
                .Register();*/
        /*}
    }
}*/
