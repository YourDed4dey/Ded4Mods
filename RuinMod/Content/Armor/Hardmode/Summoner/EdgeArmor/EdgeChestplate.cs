using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;

namespace RuinMod.Content.Armor.Hardmode.Summoner.EdgeArmor
{
    [AutoloadEquip(EquipType.Body)]
    internal class EdgeChestplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Edge Chestplate");
            //Tooltip.SetDefault("15% increased summon damage and critical strike chance\n+1 max minions");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()//Item stats
        {
            Item.width = 30;
            Item.height = 18;
            Item.rare = ItemRarityID.Pink;
            Item.defense = 16;
            Item.wornArmor = true;
        }

        public override void UpdateEquip(Player player)//Individual armor piece bonus
        {
            player.GetCritChance(DamageClass.Summon) += 0.15f;
            player.GetDamage(DamageClass.Summon) += 0.15f;

            player.maxMinions += 1;
            player.numMinions += 1;
            player.slotsMinions += 1;
        }
    }
}
