/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace RuinMod.Content.Items.RedChlorophyte.Ore;

internal class RedChlorophyteOreItem : ModItem
{
    public override void SetStaticDefaults()
    {
        //DisplayName.SetDefault("Red Chlorophyte Ore");
        //Tooltip.SetDefault("'Consumes flesh'");
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
        ItemID.Sets.SortingPriorityMaterials[Type] = 69;
    }


    public override void SetDefaults()
    {
        Item.width = 16;
        Item.height = 16;
        Item.maxStack = 999;
        Item.value = Item.buyPrice(gold: 4, silver: 80);

        Item.CloneDefaults(ItemID.ChlorophyteOre);

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useAnimation = 20;
        Item.useTime = 20;
        Item.useTurn = true;
        Item.autoReuse = true;
        Item.rare = ItemRarityID.Yellow;

        Item.createTile = ModContent.TileType<Items.RedChlorophyte.Ore.RedChlorophyteOre>();
    }
}*/