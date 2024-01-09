/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace RuinMod.Content.TestStuff.TestArmor
{
    [AutoloadEquip(EquipType.Body)]
    internal class TestChestplate : ModItem
    {
        public override void SetStaticDefaults()
        {

        }

        public override void SetDefaults()//Item stats
        {
            Item.width = 24;
            Item.height = 22;
            Item.value = Item.buyPrice(gold: 30);
            Item.rare = ItemRarityID.Master;
            Item.defense = 999999999;
            Item.wornArmor = true;
        }

        public override void UpdateEquip(Player player)//Individual armor piece bonus
        {
            player.lifeRegen = 5;
            player.cShieldFallback = 1;
            player.dash = 2;
            player.dashType = 2;
            player.statDefense += 2;
        }
    }
}*/
