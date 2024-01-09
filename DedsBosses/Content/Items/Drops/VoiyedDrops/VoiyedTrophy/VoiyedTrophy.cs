using DedsBosses.Content.Items.Drops.VoiyedDrops.VoiyedTrophy.Tile;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace DedsBosses.Content.Items.Drops.VoiyedDrops.VoiyedTrophy
{
    public class VoiyedTrophy : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Mechanical Brain Trophy");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<VoiyedTrophyTile>());

            Item.width = 52;
            Item.height = 50;
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.buyPrice(0, 5);
        }
    }
}