using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;
using RuinMod.Content.Classes.ShieldClass;

namespace RuinMod.Content.Armor.ShieldClassArmor.Hardmode.BrokenHeroArmor
{
    [AutoloadEquip(EquipType.Legs)]
    internal class BrokenHeroLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Broken Hero Boots");
            //Tooltip.SetDefault("12% increased contact damage and critical strike chance\nIncreased contact damage armor penetration by 6\n5% increased movement speed");
            //CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 82;
            Item.height = 32;
            Item.rare = ItemRarityID.Yellow;
            Item.defense = 15;
            Item.wornArmor = true;
        }

        public override void UpdateEquip(Player player) //Individual armor piece bonus
        {
            player.GetCritChance(ModContent.GetInstance<ShieldClassDamage>()) += 0.12f;
            player.GetDamage(ModContent.GetInstance<ShieldClassDamage>()) += 0.12f;
            player.GetArmorPenetration(ModContent.GetInstance<ShieldClassDamage>()) += 6f;
            player.stepSpeed += 0.05f;
        }
    }
}
