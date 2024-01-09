using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;
using RuinMod.Content.Classes.ShieldClass;

namespace RuinMod.Content.Armor.ShieldClassArmor.PreHardmode.DefenderArmor
{
    [AutoloadEquip(EquipType.Body)]
    internal class DefenderChestplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Defender Chestplate");
            //Tooltip.SetDefault("15% increased contact damage and critical strike chance\nIncreased contact damage armor penetration by 4");
        }

        public override void SetDefaults()//Item stats
        {
            Item.width = 46;
            Item.height = 36;
            Item.rare = ItemRarityID.Orange;
            Item.defense = 10;
            Item.wornArmor = true;
        }

        public override void UpdateEquip(Player player)//Individual armor piece bonus
        {
            player.GetCritChance(ModContent.GetInstance<ShieldClassDamage>()) += 0.15f;
            player.GetDamage(ModContent.GetInstance<ShieldClassDamage>()) += 0.15f;
            player.GetArmorPenetration(ModContent.GetInstance<ShieldClassDamage>()) += 4f;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.HellstoneBar, 30)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
