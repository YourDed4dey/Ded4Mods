using RuinMod.Content.Weapons.ShieldClassWeapons.Endgame.MeowShield;
using RuinMod.Content.Weapons.ShieldClassWeapons.Endgame.StellarShield;
using RuinMod.Content.Weapons.ShieldClassWeapons.Hardmode.BrokenHeroShield;
using RuinMod.Content.Weapons.ShieldClassWeapons.Hardmode.Horseman_sShield;
using RuinMod.Content.Weapons.ShieldClassWeapons.Hardmode.InfluxShield;
using RuinMod.Content.Weapons.ShieldClassWeapons.Hardmode.SeedShield;
using RuinMod.Content.Weapons.ShieldClassWeapons.PreHardmode.BeeShield;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace RuinMod.Content.Weapons.ShieldClassWeapons
{
    internal class GlobalShieldNPCsWeapons : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            LeadingConditionRule notExpertRule = new LeadingConditionRule(new Conditions.NotExpert());
            if (npc.type == NPCID.QueenBee)
            {
                notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<BeeShield>(), (int)3, 1, 1));
                npcLoot.Add(notExpertRule);
            }
            if (npc.type == NPCID.Plantera)
            {
                notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<SeedShield>(), (int)7, 1, 1));
                npcLoot.Add(notExpertRule);
            }
            if (npc.type == NPCID.Mothron)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BrokenHeroShield>(), (int)4, 1, 1));
            }
            if (npc.type == NPCID.Pumpking)
            {
                //npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Horseman_sShield>(), (int)8, 1, 1));
                LeadingConditionRule PumpMoon = new LeadingConditionRule(new Conditions.IsPumpkinMoon());
                PumpMoon.OnSuccess(ItemDropRule.Common(ModContent.ItemType<Horseman_sShield>(), (int)8, 1, 1));
                npcLoot.Add(PumpMoon);
            }
            if (npc.type == NPCID.MartianSaucerCore)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<InfluxShield>(), (int)6, 1, 1));
            }
            if (npc.type == NPCID.MoonLordCore)
            {
                notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<StellarShield>(), (int)9, 1, 1));
                notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<MeowShield>(), (int)9, 1, 1));
                npcLoot.Add(notExpertRule);
            }
        }
    }
}
