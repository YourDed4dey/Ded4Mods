/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;

namespace RuinMod.Content.TestStuff.TestArmor
{
    [AutoloadEquip(EquipType.Head)]
    internal class TestHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {

        }

        public override void SetDefaults() //Item Stats
        {
            Item.width = 24;
            Item.height = 22;
            Item.value = Item.buyPrice(gold: 24);
            Item.rare = ItemRarityID.Master;
            Item.defense = 999999999;
            Item.wornArmor = true;
        }

        /*public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<TestChestplate>() && legs.type == ItemType<TestLeggings>(); //What makes armor set bonus work
        }

        public override void UpdateArmorSet(Player player) //Armor set bonuses
        {
            player.lifeRegen = 999999999;
            player.buffImmune[BuffID.ChaosState] = true;
            player.buffImmune[BuffID.OnFire] = true;
            player.buffImmune[BuffID.OnFire3] = true;
            //player.BrainOfConfusionDodge(); //Makes player immortal
            player.statDefense -= 999999999;
            player.statLifeMax2 += 999999999;
            player.GetDamage(DamageClass.Generic) += 9999f;
            player.GetCritChance(DamageClass.Generic) += 9999f;
            player.AddBuff(BuffID.LeafCrystal, timeToAdd: 1);
            player.AddBuff(ModContent.BuffType<Content.Potions.Buffs.SoulBuff.SoulBuff>(), timeToAdd: 1);

           
        }

        public override void UpdateEquip(Player player) //Individual armor piece bonus
        {
            player.lifeRegen = 5;
            player.manaFlower = true;

            player.maxMinions += 9999;
            player.numMinions += 9999;
            player.slotsMinions += 9999;
        }
    }
}*/
