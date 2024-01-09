using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;
using Terraria.Audio;
using Terraria.Localization;

namespace RuinMod.Content.Armor.Hardmode.Summoner.EdgeArmor
{
    [AutoloadEquip(EquipType.Head)]
    internal class EdgeHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Edge Helmet");
            //Tooltip.SetDefault("5% increased summon damage\n+1 max minions");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
        }

        public override void SetDefaults() //Item Stats
        {
            Item.width = 28;
            Item.height = 28;
            Item.rare = ItemRarityID.Pink;
            Item.defense = 14;
            Item.wornArmor = true;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<EdgeChestplate>() && legs.type == ItemType<EdgeLeggings>(); //What makes armor set bonus work
        }

        public override void UpdateArmorSet(Player player) //Armor set bonuses
        {
            //player.setBonus = "40% increased whip range multiplier\n+3 max minions";

            player.setBonus = Language.GetTextValue("Mods.RuinMod.ItemSetBonus.EdgeSet");

            player.whipRangeMultiplier += 0.40f;

            player.maxMinions += 3;
            player.numMinions += 3;
            player.slotsMinions += 3;
        }

        public override void UpdateEquip(Player player) //Individual armor piece bonus
        {
            player.GetDamage(DamageClass.Summon) += 0.05f;

            player.maxMinions += 1;
            player.numMinions += 1;
            player.slotsMinions += 1;
        }
    }
}