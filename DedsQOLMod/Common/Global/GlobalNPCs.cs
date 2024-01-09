using Terraria;
using Terraria.Audio;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace DedsQOLMod.Common.Global
{
    public class GlobalNPCs : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.WallofFlesh)
            {
                LeadingConditionRule notExpertRule = new LeadingConditionRule(new Conditions.NotExpert());
                notExpertRule.OnSuccess(ItemDropRule.Common(ItemID.AdamantitePickaxe, 1, 1));
                notExpertRule.OnSuccess(ItemDropRule.Common(ItemID.OrichalcumAnvil, 1, 1));
                notExpertRule.OnSuccess(ItemDropRule.Common(ItemID.AdamantiteForge, 1, 1));

                npcLoot.Add(notExpertRule);
            }
        }
    }
}
