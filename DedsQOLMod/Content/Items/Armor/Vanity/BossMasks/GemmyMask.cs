using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Armor.Vanity.BossMasks
{
    [AutoloadEquip(EquipType.Head)]
    public class GemmyMask : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 34;

            // Common values for every boss mask
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(silver: 75);
            Item.vanity = true;
            Item.maxStack = 1;
        }
    }
}
