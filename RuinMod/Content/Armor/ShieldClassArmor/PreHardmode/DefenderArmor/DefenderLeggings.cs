using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;
using RuinMod.Content.Classes.ShieldClass;

namespace RuinMod.Content.Armor.ShieldClassArmor.PreHardmode.DefenderArmor
{
    [AutoloadEquip(EquipType.Legs)]
    internal class DefenderLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Defender Leggings");
            //Tooltip.SetDefault("5% increased contact damage and critical strike chance\nIncreased contact damage armor penetration by 3");
        }

        public override void SetDefaults()
        {
            Item.width = 54;
            Item.height = 36;
            Item.rare = ItemRarityID.Orange;
            Item.defense = 9;
            Item.wornArmor = true;
        }

        public override void UpdateEquip(Player player) //Individual armor piece bonus
        {
            player.GetCritChance(ModContent.GetInstance<ShieldClassDamage>()) += 0.05f;
            player.GetDamage(ModContent.GetInstance<ShieldClassDamage>()) += 0.05f;
            player.GetArmorPenetration(ModContent.GetInstance<ShieldClassDamage>()) += 3f;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.HellstoneBar, 25)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
