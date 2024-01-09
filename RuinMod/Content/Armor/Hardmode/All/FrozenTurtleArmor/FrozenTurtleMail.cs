/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;

namespace RuinMod.Content.Armor.Hardmode.All.FrozenTurtleArmor
{
    [AutoloadEquip(EquipType.Body)]
    internal class FrozenTurtleMail : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Frozen Turtle Mail");
            //Tooltip.SetDefault("5% increased whip range multiplier\n15% increased damage\n+15 max mana\n+2 max minions");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()//Item stats
        {
            Item.width = 34;
            Item.height = 28;
            Item.rare = ItemRarityID.Yellow;
            Item.defense = 20;
            Item.wornArmor = true;
        }

        public override void UpdateEquip(Player player)//Individual armor piece bonus
        {
            player.GetDamage(DamageClass.Default) += 0.15f;
            player.GetDamage(DamageClass.Generic) += 0.15f;
            player.GetDamage(DamageClass.Melee) += 0.15f;
            player.GetDamage(DamageClass.Magic) += 0.15f;
            player.GetDamage(DamageClass.Ranged) += 0.15f;
            player.GetDamage(DamageClass.Summon) += 0.15f;
            player.GetDamage(GetInstance<Classes.GamerClass.GamerClassDamage>()) += 0.15f;

            player.maxMinions += 2;
            player.numMinions += 2;
            player.slotsMinions += 2;

            player.statManaMax2 += 15;

            player.whipRangeMultiplier += 0.05f;
        }
    }
}*/
