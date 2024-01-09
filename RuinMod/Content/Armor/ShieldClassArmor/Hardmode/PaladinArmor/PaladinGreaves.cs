using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;
using RuinMod.Content.Classes.ShieldClass;

namespace RuinMod.Content.Armor.ShieldClassArmor.Hardmode.PaladinArmor
{
    [AutoloadEquip(EquipType.Legs)]
    internal class PaladinGreaves : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Paladin Greaves");
            //Tooltip.SetDefault("12% increased contact damage and critical strike chance\nIncreased contact damage armor penetration by 7");
            //CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 38;
            Item.height = 16;
            Item.rare = ItemRarityID.Yellow;
            Item.defense = 18;
            Item.wornArmor = true;
        }

        public override void UpdateEquip(Player player) //Individual armor piece bonus
        {
            player.GetCritChance(ModContent.GetInstance<ShieldClassDamage>()) += 0.12f;
            player.GetDamage(ModContent.GetInstance<ShieldClassDamage>()) += 0.12f;
            player.GetArmorPenetration(ModContent.GetInstance<ShieldClassDamage>()) += 7f;
        }
    }
}
