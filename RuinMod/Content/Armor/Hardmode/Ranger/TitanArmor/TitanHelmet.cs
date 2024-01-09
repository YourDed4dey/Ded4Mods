using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;
using Terraria.Audio;
using Terraria.Localization;

namespace RuinMod.Content.Armor.Hardmode.Ranger.TitanArmor
{
    [AutoloadEquip(EquipType.Head)]
    internal class TitanHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Titan Helmet");
            //Tooltip.SetDefault("15% increased ranged damage,\n10% increased ranged critical strike chance");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
        }

        public override void SetDefaults() //Item Stats
        {
            Item.width = 24;
            Item.height = 22;
            Item.rare = ItemRarityID.Pink;
            Item.defense = 14;
            Item.wornArmor = true;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<TitanMail>() && legs.type == ItemType<TitanLeggings>(); //What makes armor set bonus work
        }

        public override void UpdateArmorSet(Player player) //Armor set bonuses
        {
            //player.setBonus = "25% chance to not consume ammo";
            player.setBonus = Language.GetTextValue("Mods.RuinMod.ItemSetBonus.TitanSet");

            player.ammoCost75 = true; //20%
        }

        public override void UpdateEquip(Player player) //Individual armor piece bonus
        {
            player.GetDamage(DamageClass.Ranged) += 0.15f;
            player.GetCritChance(DamageClass.Ranged) += 0.1f;
        }
    }
}