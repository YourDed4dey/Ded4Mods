using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;

namespace RuinMod.Content.Armor.Hardmode.Magic.SpectralArmor
{
    [AutoloadEquip(EquipType.Legs)]
    internal class SpectralSubligar : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Spectral Subligar");
            //Tooltip.SetDefault("10% increased movement speed and magical damage\r\nIncreases maximum mana by 30");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 22;
            Item.rare = ItemRarityID.Pink;
            Item.defense = 15;
            Item.wornArmor = true;
        }

        public override void UpdateEquip(Player player) //Individual armor piece bonus
        {
            player.GetDamage(DamageClass.Magic) += 0.1f;
            player.moveSpeed += 0.1f;
            player.statManaMax2 += 30;
        }
    }
}
