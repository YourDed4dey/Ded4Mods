/*using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader.Utilities;
using Terraria.GameContent.ItemDropRules;
using System.Collections.Generic;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Biomes;

namespace RuinMod.Content.NPCS.Enemies.Girl
{
    public class Girl : ModNPC
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Girl");
            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.Nymph];
        }

        public override void SetDefaults()
        {
            NPC.CloneDefaults(NPCID.Nymph);
            AnimationType = NPCID.Nymph;

            NPC.damage = 85;
            NPC.defense = 36;
            NPC.lifeMax = 400;
            NPC.value = Item.buyPrice(silver: 55);
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new List<IBestiaryInfoElement> {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime,
                new FlavorTextBestiaryInfoElement("Blood thirsty monsters with appearance of a girl.")
            });
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.PlanteraDefeated)
            {
                return SpawnCondition.OverworldNightMonster.Chance * 0.1f;
            }

            return 0f;
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            //npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Content.Items.DarkEssence.DarkEssence>(), 1, 1, 10)); // using Terraria.GameContent.ItemDropRules; needed for modded items to be able to be part of loot
        }
    }
}*/
