using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using RuinMod.Content.Classes.ShieldClass;

namespace RuinMod.Content.Armor.ShieldClassArmor.PreHardmode.DefenderArmor
{
    [AutoloadEquip(EquipType.Head)]
    internal class DefenderHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Defender Mask");
            //Tooltip.SetDefault("12% increased contact damage and critical strike chance\nIncreased contact damage armor penetration by 3");
        }

        public override void SetDefaults() //Item Stats
        {
            Item.width = 22;
            Item.height = 26;
            Item.rare = ItemRarityID.Orange;
            Item.defense = 9;
            Item.wornArmor = true;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<DefenderChestplate>() && legs.type == ItemType<DefenderLeggings>();
        }

        public override void UpdateArmorSet(Player player) //Armor set bonuses
        {
            player.setBonus = Language.GetTextValue("Mods.RuinMod.ItemSetBonus.DefenderSet"); // "Reduces damage taken by 5%"
            player.endurance += 0.05f;
        }

        public override void UpdateEquip(Player player) //Individual armor piece bonus
        {
            player.GetCritChance(ModContent.GetInstance<ShieldClassDamage>()) += 0.12f;
            player.GetDamage(ModContent.GetInstance<ShieldClassDamage>()) += 0.12f;
            player.GetArmorPenetration(ModContent.GetInstance<ShieldClassDamage>()) += 3f;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.HellstoneBar, 20)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}