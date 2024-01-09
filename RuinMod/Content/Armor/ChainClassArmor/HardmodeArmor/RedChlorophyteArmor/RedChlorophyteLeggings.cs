/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;
using RuinMod.Content.Classes.ChainClass;

namespace RuinMod.Content.Armor.ChainClassArmor.HardmodeArmor.RedChlorophyteArmor
{
    [AutoloadEquip(EquipType.Legs)]
    internal class RedChlorophyteLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Red Chlorophyte Leggings");
            //Tooltip.SetDefault("7% increased chain damage");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 22;
            Item.value = Item.buyPrice(gold: 30);
            Item.rare = ItemRarityID.Yellow;
            Item.defense = 19;
            Item.wornArmor = true;
        }

        public override void UpdateEquip(Player player) //Individual armor piece bonus
        {
            player.GetDamage(GetInstance<ChainClassDamage>()) += 0.07f;

            player.moveSpeed += 0.05f;
        }

        public override void AddRecipes() //Item Recipe
        {
            CreateRecipe()
                .AddIngredient(ItemType<Items.RedChlorophyte.RedChlorophyteBarItem>(), 28)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }

    }
}*/
