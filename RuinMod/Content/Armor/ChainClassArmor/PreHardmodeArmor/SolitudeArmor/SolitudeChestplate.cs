/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;
using RuinMod.Content.Classes.ChainClass;

namespace RuinMod.Content.Armor.ChainClassArmor.PreHardmodeArmor.SolitudeArmor
{
    [AutoloadEquip(EquipType.Body)]
    internal class SolitudeChestplate :ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Solitude Chestplate");
            //Tooltip.SetDefault("7% increased chain damage");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()//Item stats
        {
            Item.width = 24;
            Item.height = 22;
            Item.value = Item.buyPrice(gold: 15);
            Item.rare = ItemRarityID.Orange;
            Item.defense = 8;
            Item.wornArmor = true;
        }

        public override void UpdateEquip(Player player)//Individual armor piece bonus
        {
            player.GetDamage(GetInstance<ChainClassDamage>()) += 0.07f;
        }

        public override void AddRecipes() //Item Recipe
        {
            CreateRecipe()
                .AddIngredient(ItemID.HellstoneBar, 18)
                     .AddIngredient(ModContent.ItemType<Content.Items.LostFragment.LostFragment>(), 5)
                .AddTile(TileID.Anvils)
                .Register();
        }

    }
}*/
