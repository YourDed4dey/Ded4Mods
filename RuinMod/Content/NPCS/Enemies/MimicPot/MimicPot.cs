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

namespace RuinMod.Content.NPCS.Enemies.MimicPot
{
    public class MimicPot : ModNPC
    {
        public ref float ShootStar => ref NPC.localAI[3];
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Normal Pot");
            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.Mimic];
        }

        public override void SetDefaults()
        {
            NPC.CloneDefaults(NPCID.Mimic);
            NPC.value = Item.buyPrice(gold: 2);
            AnimationType = NPCID.Mimic;
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.Player.ZoneNormalCaverns)
            {
                return SpawnCondition.Cavern.Chance * 0.1f;
            }

            return 0f;
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new List<IBestiaryInfoElement> {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Underground,
                new FlavorTextBestiaryInfoElement("Pots that look like mimics or mimics that look like pots?\nThey can't be birthed from ordinary pots by force")
            });
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {

        }
    }
}*/
