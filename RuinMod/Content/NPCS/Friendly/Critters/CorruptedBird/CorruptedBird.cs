/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader.Utilities;
using Terraria.GameContent.ItemDropRules;
using System.IO;
using Terraria.GameContent.Bestiary;
using Terraria.ModLoader.IO;

namespace RuinMod.Content.NPCS.Friendly.Critters.CorruptedBird
{
    internal class CorruptedBird : ModNPC
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Corrupted Bird");
            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.Raven];
        }

        public override void SetDefaults()
        {
            NPC.CloneDefaults(NPCID.Raven);
            NPC.friendly = true;
            AnimationType = NPCID.Raven;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.Player.ZoneCorrupt)
            {
                    return SpawnCondition.Corruption.Chance * 0.1f;
            }

            return 0f;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new List<IBestiaryInfoElement> {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCorruption,
                new FlavorTextBestiaryInfoElement("A very weak bird that is damaged by stronger birds.")
            });
        }
    }
}*/
