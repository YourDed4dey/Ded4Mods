using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;

namespace RuinMod.Content.Armor.Hardmode.Ranger.TitanArmor
{
    [AutoloadEquip(EquipType.Body)]
    internal class TitanMail : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Titan Mail");
            //Tooltip.SetDefault("5% increased ranged damage,\n10% increased ranged critical strike chance");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()//Item stats
        {
            Item.width = 24;
            Item.height = 22;
            Item.rare = ItemRarityID.Pink;
            Item.defense = 18;
            Item.wornArmor = true;
        }

        public override void UpdateEquip(Player player)//Individual armor piece bonus
        {
            player.GetDamage(DamageClass.Ranged) += 0.05f;
            player.GetCritChance(DamageClass.Ranged) += 0.1f;
        }
    }
}
