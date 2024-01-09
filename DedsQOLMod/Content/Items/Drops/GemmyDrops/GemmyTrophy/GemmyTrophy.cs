using DedsQOLMod.Content.Items.Drops.GemmyDrops.GemmyTrophy.Tile;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Drops.GemmyDrops.GemmyTrophy
{
    public class GemmyTrophy : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<GemmyTrophyTile>());

            Item.width = 28;
            Item.height = 24;
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.buyPrice(0, 5);
        }
    }
}
