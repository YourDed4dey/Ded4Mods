using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;
using RuinMod.Content.Classes.ShieldClass;

namespace RuinMod.Content.Armor.ShieldClassArmor.PreHardmode.GuardArmor
{
    [AutoloadEquip(EquipType.Legs)]
    internal class GuardLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Guard Leggings");
            //Tooltip.SetDefault("4% increased contact damage and critical strike chance\nIncreased contact damage armor penetration by 2");
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 22;
            Item.rare = ItemRarityID.Green;
            Item.defense = 8;
            Item.wornArmor = true;
        }

        public override void UpdateEquip(Player player) //Individual armor piece bonus
        {
            player.GetCritChance(ModContent.GetInstance<ShieldClassDamage>()) += 0.04f;
            player.GetDamage(ModContent.GetInstance<ShieldClassDamage>()) += 0.04f;
            player.GetArmorPenetration(ModContent.GetInstance<ShieldClassDamage>()) += 2f;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.DemoniteBar, 30)
                .AddIngredient(ItemID.ShadowScale, 25)
                .AddTile(TileID.Anvils)
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.CrimtaneBar, 30)
                .AddIngredient(ItemID.TissueSample, 25)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
