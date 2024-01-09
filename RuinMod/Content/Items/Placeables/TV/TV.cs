/*using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using RuinMod.Content.Rarity;

namespace RuinMod.Content.Items.Placeables.TV
{
    internal class TV : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Monitor");
            //Tooltip.SetDefault("It has a mouse and everything\n'You can play, but only for 1 hour!'");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.createTile = ModContent.TileType<Tile.TVTile>();

            Item.width = 30;
            Item.height = 18;

            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 20;
            Item.useAnimation = 25;

            Item.maxStack = 99;
            Item.consumable = true;
            Item.rare = ModContent.RarityType<GamerClassRarity>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Glass, 25)
                .AddIngredient(ItemID.IronBar, 5)
                .AddIngredient(ItemID.Wire, 50)
                .AddTile(TileID.Anvils)
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.Glass, 25)
                .AddIngredient(ItemID.LeadBar, 5)
                .AddIngredient(ItemID.Wire, 50)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}*/
