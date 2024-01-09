using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;

namespace RuinMod.Content.Armor.Hardmode.Ranger.TitanArmor
{
    [AutoloadEquip(EquipType.Legs)]
    internal class TitanLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Titan Leggings");
            //Tooltip.SetDefault("10% increased movement speed and ranged damage");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 22;
            Item.rare = ItemRarityID.Pink;
            Item.defense = 13;
            Item.wornArmor = true;
        }

        public override void UpdateEquip(Player player) //Individual armor piece bonus
        {
            player.GetDamage(DamageClass.Ranged) += 0.1f;
            player.moveSpeed += 0.1f;
        }
    }
}
