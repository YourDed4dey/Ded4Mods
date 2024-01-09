/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using RuinMod.Content.Items.Placeables.GemAnvil.Tile;

namespace RuinMod.Content.Items.GemmysGem
{
    internal class GemmysGem : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Gemmy's Gem");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
            ItemID.Sets.SortingPriorityMaterials[Type] = 200;
        }
        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 46;
            Item.maxStack = 999;
            Item.value = Item.buyPrice(silver: 20);
            Item.rare = ItemRarityID.Pink;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Ruby, 3)
                .AddIngredient(ItemID.Diamond, 3)
                .AddIngredient(ItemID.Emerald, 3)
                .AddIngredient(ItemID.Sapphire, 3)
                .AddIngredient(ItemID.Amethyst, 3)
                .AddIngredient(ItemID.Topaz, 3)
                .AddIngredient(ItemID.Amber, 3)
                .AddTile<GemAnvilTile>()
                .Register();
        }
    }
}*/
