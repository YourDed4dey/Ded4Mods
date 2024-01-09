/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace RuinMod.Content.Items.RedChlorophyte;

internal class RedChlorophyteBarItem : ModItem
{
    public override void SetStaticDefaults()
    {
        //DisplayName.SetDefault("Red Chlorophyte Bar");
        //Tooltip.SetDefault("Can't be placed\n'Consumes flesh'");
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
        ItemID.Sets.SortingPriorityMaterials[Type] = 69;
    }


    public override void SetDefaults()
    {
        Item.width = 16;
        Item.height = 16;
        Item.maxStack = 999;
        Item.CloneDefaults(ItemID.ChlorophyteBar);

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useAnimation = 20;
        Item.useTime = 20;
        Item.useTurn = true;
        Item.autoReuse = true;
        Item.rare = ItemRarityID.Yellow;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ModContent.ItemType<Items.RedChlorophyte.Ore.RedChlorophyteOreItem>(), 5)
            .AddTile(TileID.AdamantiteForge)
            .Register();
    }
}*/