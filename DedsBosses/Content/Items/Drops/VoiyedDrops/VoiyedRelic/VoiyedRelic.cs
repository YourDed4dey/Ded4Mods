using DedsBosses.Content.Items.Drops.VoiyedDrops.VoiyedRelic.RelicTile;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace DedsBosses.Content.Items.Drops.VoiyedDrops.VoiyedRelic
{
    public class VoiyedRelic : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Mechanical Brain Relic");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            // Vanilla has many useful methods like these, use them! This substitutes setting Item.createTile and Item.placeStyle aswell as setting a few values that are common across all placeable items
            // The place style (here by default 0) is important if you decide to have more than one relic share the same tile type (more on that in the tiles' code)
            Item.DefaultToPlaceableTile(ModContent.TileType<VoiyedRelicTile>(), 0);

            Item.width = 44;
            Item.height = 56;
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Master;
            Item.master = true;
            Item.value = Item.buyPrice(0, 5);
        }
    }
}