using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;
using RuinMod.Content.Classes.ShieldClass;

namespace RuinMod.Content.Armor.ShieldClassArmor.PreHardmode.GuardArmor
{
    [AutoloadEquip(EquipType.Body)]
    internal class GuardChestplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Guard Chestplate");
            //Tooltip.SetDefault("18% increased contact damage and critical strike chance\nIncreased contact damage armor penetration by 4");
        }

        public override void SetDefaults()//Item stats
        {
            Item.width = 34;
            Item.height = 24;
            Item.rare = ItemRarityID.Green;
            Item.defense = 10;
            Item.wornArmor = true;
        }

        public override void UpdateEquip(Player player)//Individual armor piece bonus
        {
            player.GetCritChance(ModContent.GetInstance<ShieldClassDamage>()) += 0.18f;
            player.GetDamage(ModContent.GetInstance<ShieldClassDamage>()) += 0.18f;
            player.GetArmorPenetration(ModContent.GetInstance<ShieldClassDamage>()) += 4f;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.DemoniteBar, 35)
                .AddIngredient(ItemID.ShadowScale, 30)
                .AddTile(TileID.Anvils)
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.CrimtaneBar, 35)
                .AddIngredient(ItemID.TissueSample, 30)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
