using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;
using RuinMod.Content.Classes.ShieldClass;
using RuinMod.Content.Items.Drops.EssencesOrSoulsOrFragments.Fragments.FaithfulFragment;

namespace RuinMod.Content.Armor.ShieldClassArmor.Endgame.RoyalGuardArmor
{
    [AutoloadEquip(EquipType.Body)]
    internal class RoyalGuardBreastplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Royal Guard Breastplate");
            //Tooltip.SetDefault("20% increased contact damage and critical strike chance\nIncreased contact damage armor penetration by 10\nEnemies are less likely to target you");
            //CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()//Item stats
        {
            Item.width = 78;
            Item.height = 78;
            Item.rare = ItemRarityID.Red;
            Item.defense = 33;
            Item.wornArmor = true;
        }

        public override void UpdateEquip(Player player)//Individual armor piece bonus
        {
            player.GetCritChance(ModContent.GetInstance<ShieldClassDamage>()) += 0.20f;
            player.GetDamage(ModContent.GetInstance<ShieldClassDamage>()) += 0.20f;
            player.GetArmorPenetration(ModContent.GetInstance<ShieldClassDamage>()) += 10f;
            player.aggro -= 300; //Enemies are less likely to target you
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.LunarBar, 22)
                .AddIngredient(ModContent.ItemType<FaithfulFragment>(), 25)
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }
}
