/*using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader.Utilities;
using Terraria.GameContent.ItemDropRules;
using System;
using System.IO;
using Terraria.GameContent.Bestiary;
using Terraria.ModLoader.IO;
using System.Collections.Generic;

namespace RuinMod.Content.NPCS.Enemies.Dummy
{
    public class Dummy : ModNPC
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Dummy");
            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.Mimic];
        }

        public override void SetDefaults()
        {
            NPC.CloneDefaults(NPCID.Mimic);
            AnimationType = NPCID.Mimic;
            NPC.damage = 35;
            NPC.defense = 50;
            NPC.lifeMax = 700;
            NPC.value = Item.buyPrice(silver: 80);
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new List<IBestiaryInfoElement> {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns,
                new FlavorTextBestiaryInfoElement("They mimic the appearance of a dummy, yet their width is bigger than a normal dummy.")
            });
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.PlanteraDefeated)
            {
                return SpawnCondition.Cavern.Chance * 0.06f;
            }

            return 0f;
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Content.Armor.VanityArmor.DummyMask.DummyMask>(), 100, 1, 1));
            //npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Content.Items.DarkEssence.DarkEssence>(), 1, 1, 5));
        }
    }
}*/
