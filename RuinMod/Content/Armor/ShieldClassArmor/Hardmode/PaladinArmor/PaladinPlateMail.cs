using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;
using RuinMod.Content.Classes.ShieldClass;

namespace RuinMod.Content.Armor.ShieldClassArmor.Hardmode.PaladinArmor
{
    [AutoloadEquip(EquipType.Body)]
    internal class PaladinPlateMail : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Paladin Platemail");
            //Tooltip.SetDefault("16% increased contact damage and critical strike chance\nIncreased contact damage armor penetration by 7");
            //CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()//Item stats
        {
            Item.width = 44;
            Item.height = 28;
            Item.rare = ItemRarityID.Yellow;
            Item.defense = 32;
            Item.wornArmor = true;
        }

        public override void UpdateEquip(Player player)//Individual armor piece bonus
        {
            player.GetCritChance(ModContent.GetInstance<ShieldClassDamage>()) += 0.16f;
            player.GetDamage(ModContent.GetInstance<ShieldClassDamage>()) += 0.16f;
            player.GetArmorPenetration(ModContent.GetInstance<ShieldClassDamage>()) += 7f;
        }
    }
}
