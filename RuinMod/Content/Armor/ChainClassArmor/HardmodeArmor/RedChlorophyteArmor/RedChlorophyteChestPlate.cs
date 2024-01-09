/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;
using RuinMod.Content.Classes.ChainClass;

namespace RuinMod.Content.Armor.ChainClassArmor.HardmodeArmor.RedChlorophyteArmor
{
    [AutoloadEquip(EquipType.Body)]
    internal class RedChlorophyteChestPlate : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Red Chlorophyte Chestplate");
            //Tooltip.SetDefault("8% increased chain damage and critical strike chance");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()//Item stats
        {
            Item.width = 24;
            Item.height = 22;
            Item.value = Item.buyPrice(gold: 40);
            Item.rare = ItemRarityID.Yellow;
            Item.defense = 35;
            Item.wornArmor = true;
        }

        public override void UpdateEquip(Player player)//Individual armor piece bonus
        {
            player.GetDamage(GetInstance<ChainClassDamage>()) += 0.08f;
            player.GetCritChance(GetInstance<ChainClassDamage>()) += 0.08f;
        }

        public override void AddRecipes() //Item Recipe
        {
            CreateRecipe()
                .AddIngredient(ItemType<Items.RedChlorophyte.RedChlorophyteBarItem>(), 34)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }

    }
}*/
