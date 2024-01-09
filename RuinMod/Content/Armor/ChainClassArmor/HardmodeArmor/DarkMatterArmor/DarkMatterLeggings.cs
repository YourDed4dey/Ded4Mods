/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;
using RuinMod.Content.Classes.ChainClass;

namespace RuinMod.Content.Armor.ChainClassArmor.HardmodeArmor.DarkMatterArmor
{
    [AutoloadEquip(EquipType.Legs)]
    internal class DarkMatterLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Dark Matter Leggings");
            //Tooltip.SetDefault("20% increased movement speed");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 22;
            Item.value = Item.buyPrice(gold: 30);
            Item.rare = ItemRarityID.Red;
            Item.defense = 22;
            Item.wornArmor = true;
        }

        public override void UpdateEquip(Player player) //Individual armor piece bonus
        {
            //player.GetDamage(GetInstance<ChainClassDamage>()) += 0.07f;

            player.moveSpeed += 0.20f;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<Content.Items.FragmentOfCosmos.FragmentOfCosmos>(), 15)
                .AddIngredient(ItemID.LunarBar, 12)
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }
}*/
