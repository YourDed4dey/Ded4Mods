/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;
using RuinMod.Content.Classes.ChainClass;

namespace RuinMod.Content.Armor.ChainClassArmor.HardmodeArmor.DarkMatterArmor
{
    [AutoloadEquip(EquipType.Body)]
    internal class DarkMatterChestplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Dark Matter Breastplate");
            //Tooltip.SetDefault("30% increased chain damage");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()//Item stats
        {
            Item.width = 24;
            Item.height = 22;
            Item.value = Item.buyPrice(gold: 40);
            Item.rare = ItemRarityID.Red;
            Item.defense = 40;
            Item.wornArmor = true;
        }

        public override void UpdateEquip(Player player)//Individual armor piece bonus
        {
            player.GetDamage(GetInstance<ChainClassDamage>()) += 0.30f;
            //player.GetCritChance(GetInstance<ChainClassDamage>()) += 0.30f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<Content.Items.FragmentOfCosmos.FragmentOfCosmos>(), 20)
                .AddIngredient(ItemID.LunarBar, 16)
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }
}*/
