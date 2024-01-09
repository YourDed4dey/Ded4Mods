using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;
using RuinMod.Content.Classes.ShieldClass;

namespace RuinMod.Content.Armor.ShieldClassArmor.Hardmode.BrokenHeroArmor
{
    [AutoloadEquip(EquipType.Body)]
    internal class BrokenHeroChestplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Broken Hero Chestplate");
            //Tooltip.SetDefault("15% increased contact damage and critical strike chance\nIncreased contact damage armor penetration by 6");
            //CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()//Item stats
        {
            Item.width = 50;
            Item.height = 42;
            Item.rare = ItemRarityID.Yellow;
            Item.defense = 28;
            Item.wornArmor = true;
        }

        public override void UpdateEquip(Player player)//Individual armor piece bonus
        {
            player.GetCritChance(ModContent.GetInstance<ShieldClassDamage>()) += 0.15f;
            player.GetDamage(ModContent.GetInstance<ShieldClassDamage>()) += 0.15f;
            player.GetArmorPenetration(ModContent.GetInstance<ShieldClassDamage>()) += 6f;
        }
    }
}
