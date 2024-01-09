/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace RuinMod.Content.Items.LostFragment.Handle;

internal class LostFragmentHandle : ModItem
{
    public override void SetStaticDefaults()
    {
        //DisplayName.SetDefault("Lost Fragment Handle");
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
        ItemID.Sets.SortingPriorityMaterials[Type] = 69;
    }


    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 32;
        Item.maxStack = 10;

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useAnimation = 20;
        Item.useTime = 20;
        Item.useTurn = true;
        Item.autoReuse = true;
        Item.rare = ItemRarityID.LightRed;

    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ModContent.ItemType<LostFragment>(), 10)
            .AddTile(TileID.Anvils)
            .Register();
    }
}*/
