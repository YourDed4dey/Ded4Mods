/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;
using Terraria.Audio;
using Terraria.Localization;

namespace RuinMod.Content.Armor.Hardmode.All.FrozenTurtleArmor
{
    [AutoloadEquip(EquipType.Head)]
    internal class FrozenTurtleHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Frozen Turtle Helmet");
            //Tooltip.SetDefault("5% increased whip range multiplier\n15% increased damage\n+20 max mana\n+2 max minions");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
        }

        public override void SetDefaults() //Item Stats
        {
            Item.width = 26;
            Item.height = 22;
            Item.rare = ItemRarityID.Yellow;
            Item.defense = 10;
            Item.wornArmor = true;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<FrozenTurtleMail>() && legs.type == ItemType<FrozenTurtleLeggings>();
        }

        public override void UpdateArmorSet(Player player) //Armor set bonuses
        {
            //player.setBonus = "10% increased damage, melee speed and critical strike chance\nIncreased life regeneration\nReduces damage taken by 25%\n+1 max minion";

            player.setBonus = Language.GetTextValue("Mods.RuinMod.ItemSetBonus.FrozenTurtleSet");

            player.GetAttackSpeed(DamageClass.Default) += 0.10f;
            player.GetAttackSpeed(DamageClass.Generic) += 0.10f;
            player.GetAttackSpeed(DamageClass.Melee) += 0.10f;
            player.GetAttackSpeed(DamageClass.Magic) += 0.10f;
            player.GetAttackSpeed(DamageClass.Ranged) += 0.10f;
            player.GetAttackSpeed(DamageClass.Summon) += 0.10f;
            player.GetAttackSpeed(GetInstance<Classes.GamerClass.GamerClassDamage>()) += 0.10f;

            player.GetCritChance(DamageClass.Default) += 0.10f;
            player.GetCritChance(DamageClass.Generic) += 0.10f;
            player.GetCritChance(DamageClass.Melee) += 0.10f;
            player.GetCritChance(DamageClass.Magic) += 0.10f;
            player.GetCritChance(DamageClass.Ranged) += 0.10f;
            player.GetCritChance(DamageClass.Summon) += 0.10f;
            player.GetCritChance(GetInstance<Classes.GamerClass.GamerClassDamage>()) += 0.10f;

            player.maxMinions += 1;
            player.numMinions += 1;
            player.slotsMinions += 1;

            player.lifeRegen += 20;

            if(player.active == true)
            {
                player.AddBuff(BuffID.IceBarrier, timeToAdd: 1);
            }
            else
            {
                player.AddBuff(BuffID.IceBarrier, timeToAdd: 0);
            }
        }

        public override void UpdateEquip(Player player) //Individual armor piece bonus
        {
            player.statManaMax2 += 20;

            player.maxMinions += 2;
            player.numMinions += 2;
            player.slotsMinions += 2;
            player.whipRangeMultiplier += 0.05f;

            player.GetDamage(DamageClass.Default) += 0.15f;
            player.GetDamage(DamageClass.Generic) += 0.15f;
            player.GetDamage(DamageClass.Melee) += 0.15f;
            player.GetDamage(DamageClass.Magic) += 0.15f;
            player.GetDamage(DamageClass.Ranged) += 0.15f;
            player.GetDamage(DamageClass.Summon) += 0.15f;
            player.GetDamage(GetInstance<Classes.GamerClass.GamerClassDamage>()) += 0.15f;
        }
    }
}*/