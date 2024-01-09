using RuinMod.Content.Armor.ShieldClassArmor.Hardmode.BrokenHeroArmor;
using RuinMod.Content.Armor.ShieldClassArmor.Hardmode.PaladinArmor;
using RuinMod.Content.Items.Drops.EssencesOrSoulsOrFragments.Fragments.FaithfulFragment;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace RuinMod.Content.Armor.ShieldClassArmor
{
    internal class GlobalShieldNPCsArmor : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.Paladin)
            {
                /*int ChanceNumerator = 333; // This gives Infinity%, which would be cool for a OP item
                int ChanceDenominator = 5000;
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PaladinMask>(), ChanceNumerator / ChanceDenominator, 1, 1));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PaladinPlateMail>(), ChanceNumerator / ChanceDenominator, 1, 1));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PaladinGreaves>(), ChanceNumerator / ChanceDenominator, 1, 1));*/

                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PaladinMask>(), (int)23, 1, 1));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PaladinPlateMail>(), (int)23, 1, 1));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PaladinGreaves>(), (int)23, 1, 1));
            }

            if(npc.type == NPCID.Mothron)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BrokenHeroHelmet>(), (int)11.5, 1, 1));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BrokenHeroChestplate>(), (int)11.5, 1, 1));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BrokenHeroLeggings>(), (int)11.5, 1, 1));
            }
            if (npc.type == NPCID.LunarTowerSolar || npc.type == NPCID.LunarTowerNebula || npc.type == NPCID.LunarTowerStardust || npc.type == NPCID.LunarTowerVortex)
            {
                //LeadingConditionRule notExpertRule = new LeadingConditionRule(new Conditions.NotExpert());
                int itemType = ModContent.ItemType<FaithfulFragment>();
                var parameters = new DropOneByOne.Parameters()
                {
                    ChanceNumerator = 1,
                    ChanceDenominator = 1,
                    MinimumStackPerChunkBase = 1,
                    MaximumStackPerChunkBase = 1,
                    MinimumItemDropsCount = 12,
                    MaximumItemDropsCount = 15,
                };

                //notExpertRule.OnSuccess(new DropOneByOne(itemType, parameters));
                npcLoot.Add(new DropOneByOne(itemType, parameters));
            }
        }
    }
}
