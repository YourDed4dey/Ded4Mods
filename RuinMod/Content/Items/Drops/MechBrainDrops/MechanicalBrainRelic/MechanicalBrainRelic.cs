/*using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace RuinMod.Content.Items.Drops.MechBrainDrops.MechanicalBrainRelic
{
    public class MechanicalBrainRelic : ModItem
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
            Item.DefaultToPlaceableTile(ModContent.TileType<RelicTile.MechanicalBrainRelicTile>(), 0);

            Item.width = 45;
            Item.height = 52;
            Item.maxStack = 99;
            Item.rare = ItemRarityID.Master;
            Item.master = true;
        }
    }
}*/