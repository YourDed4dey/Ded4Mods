/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;

namespace RuinMod.Content.Armor.Hardmode.All.FrozenTurtleArmor
{
    [AutoloadEquip(EquipType.Legs)]
    internal class FrozenTurtleLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Frozen Turtle Leggings");
            //Tooltip.SetDefault("5% increased whip range multiplier\n15% increased movement speed\nIncreased armor penetration\n+10 max mana");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 18;
            Item.rare = ItemRarityID.Yellow;
            Item.defense = 17;
            Item.wornArmor = true;
        }

        public override void UpdateEquip(Player player) //Individual armor piece bonus
        {
            player.statManaMax2 += 10;

            player.moveSpeed += 0.15f;

            player.whipRangeMultiplier += 0.05f;

            player.GetArmorPenetration(DamageClass.Default) += 2;
            player.GetArmorPenetration(DamageClass.Generic) += 2;
            player.GetArmorPenetration(DamageClass.Melee) += 2;
            player.GetArmorPenetration(DamageClass.Magic) += 2;
            player.GetArmorPenetration(DamageClass.Ranged) += 2;
            player.GetArmorPenetration(DamageClass.Summon) += 2;
            player.GetArmorPenetration(GetInstance<Classes.GamerClass.GamerClassDamage>()) += 2;
        }
    }
}*/
