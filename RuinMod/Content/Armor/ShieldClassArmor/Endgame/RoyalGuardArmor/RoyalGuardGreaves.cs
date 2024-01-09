using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;
using RuinMod.Content.Classes.ShieldClass;
using RuinMod.Content.Items.Drops.EssencesOrSoulsOrFragments.Fragments.FaithfulFragment;

namespace RuinMod.Content.Armor.ShieldClassArmor.Endgame.RoyalGuardArmor
{
    [AutoloadEquip(EquipType.Legs)]
    internal class RoyalGuardGreaves : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Royal Guard Greaves");
            //Tooltip.SetDefault("15% increased contact damage and critical strike chance\nIncreased contact damage armor penetration by 10\n18% increased movement speed\nEnemies are less likely to target you");
            //CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 70;
            Item.height = 74;
            Item.rare = ItemRarityID.Red;
            Item.defense = 21;
            Item.wornArmor = true;
        }

        public override void UpdateEquip(Player player) //Individual armor piece bonus
        {
            player.GetCritChance(ModContent.GetInstance<ShieldClassDamage>()) += 0.15f;
            player.GetDamage(ModContent.GetInstance<ShieldClassDamage>()) += 0.15f;
            player.GetArmorPenetration(ModContent.GetInstance<ShieldClassDamage>()) += 10f;
            player.aggro -= 100; //Enemies are less likely to target you
            player.stepSpeed += 0.18f;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.LunarBar, 15)
                .AddIngredient(ModContent.ItemType<FaithfulFragment>(), 12)
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }
}
