/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace RuinMod.Content.Armor.ChainClassArmor.PreHardmodeArmor.SolitudeArmor
{
    [AutoloadEquip(EquipType.Legs)]
    internal class SolitudeLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Solitude Leggings");
            //Tooltip.SetDefault("7% increased movement speed");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 22;
            Item.value = Item.buyPrice(gold: 10);
            Item.rare = ItemRarityID.Orange;
            Item.defense = 7;
            Item.wornArmor = true;
        }

        public override void UpdateEquip(Player player) //Individual armor piece bonus
        {
            player.moveSpeed += 0.07f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.HellstoneBar, 13)
                     .AddIngredient(ModContent.ItemType<Content.Items.LostFragment.LostFragment>(), 5)
                .AddTile(TileID.Anvils)
                .Register();
        }

    }
}*/
