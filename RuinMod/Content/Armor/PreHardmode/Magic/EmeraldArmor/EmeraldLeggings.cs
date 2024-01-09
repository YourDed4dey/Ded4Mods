/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;

namespace RuinMod.Content.Armor.PreHardmode.EmeraldArmor
{
    [AutoloadEquip(EquipType.Legs)]
    internal class EmeraldLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Emerald Leggings");
            //Tooltip.SetDefault("5% increased movement speed\n5% reduced mana cost");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 22;
            Item.value = Item.buyPrice(silver: 89);
            Item.rare = ItemRarityID.Blue;
            Item.defense = 7;
            Item.wornArmor = true;
        }

        public override void UpdateEquip(Player player) //Individual armor piece bonus
        {
            player.moveSpeed += 0.05f;
            player.manaCost -= 0.05f;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Emerald, 8)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}*/
