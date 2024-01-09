using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;

namespace RuinMod.Content.Armor.Hardmode.Summoner.EdgeArmor
{
    [AutoloadEquip(EquipType.Legs)]
    internal class EdgeLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Edge Leggings");
            //Tooltip.SetDefault("20% increased movement speed and summon damage\n+1 max minions");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 22;
            Item.rare = ItemRarityID.Pink;
            Item.defense = 13;
            Item.wornArmor = true;
        }

        public override void UpdateEquip(Player player) //Individual armor piece bonus
        {
            player.GetDamage(DamageClass.Summon) += 0.20f;
            player.moveSpeed += 0.20f;

            player.maxMinions += 1;
            player.numMinions += 1;
            player.slotsMinions += 1;
        }
    }
}
