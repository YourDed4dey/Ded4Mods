/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace RuinMod.Content.Items.LostFragment;

internal class LostFragment : ModItem
{
    public override void SetStaticDefaults()
    {
        //DisplayName.SetDefault("Lost Fragment");
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
        ItemID.Sets.SortingPriorityMaterials[Type] = 69;
    }


    public override void SetDefaults()
    {
        Item.width = 16;
        Item.height = 16;
        Item.maxStack = 999;

        Item.CloneDefaults(ItemID.GoldOre);

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useAnimation = 20;
        Item.useTime = 20;
        Item.useTurn = true;
        Item.autoReuse = true;
        Item.rare = ItemRarityID.LightRed;

        Item.createTile = ModContent.TileType<Items.LostFragment.Ore.LostFragmentOre>();
        Item.value = 0;
    }
}*/