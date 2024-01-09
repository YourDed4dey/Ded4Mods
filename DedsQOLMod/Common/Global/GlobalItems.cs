using DedsQOLMod.Content.Projectiles.Gems;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace DedsQOLMod.Common.Global
{
    public class GlobalItems : GlobalItem
    {
        public override void ModifyItemLoot(Item item, ItemLoot itemLoot)
        {
            if (item.type == ItemID.WallOfFleshBossBag)
            {
                itemLoot.Add(ItemDropRule.NotScalingWithLuck(ItemID.AdamantitePickaxe, 1, 1));
                itemLoot.Add(ItemDropRule.NotScalingWithLuck(ItemID.OrichalcumAnvil, 1, 1));
                itemLoot.Add(ItemDropRule.NotScalingWithLuck(ItemID.AdamantiteForge, 1, 1));
            }
        }
    }
}
