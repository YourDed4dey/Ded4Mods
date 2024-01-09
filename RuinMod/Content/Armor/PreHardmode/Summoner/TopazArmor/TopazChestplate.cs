/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;

namespace RuinMod.Content.Armor.PreHardmode.Summoner.TopazArmor
{
    [AutoloadEquip(EquipType.Body)]
    internal class TopazChestplate : ModItem
    {

        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Topaz Chestplate");
            //Tooltip.SetDefault("+2 max minions");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()//Item stats
        {
            Item.width = 34;
            Item.height = 24;
            Item.rare = ItemRarityID.Blue;
            Item.defense = 6;
            Item.wornArmor = true;
        }

        public override void UpdateEquip(Player player)//Individual armor piece bonus
        {
            player.maxMinions += 2;
            player.numMinions += 2;
            player.slotsMinions += 2;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Topaz, 8)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}*/
