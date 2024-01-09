/*using System.Collections.Generic;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader.Utilities;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent.Bestiary;
using RuinMod.Content.Potions.MilkBucket;

namespace RuinMod.Content.NPCS.Friendly.MC.Cow
{
    internal class MCCow : ModNPC
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Cow");
            Main.npcFrameCount[Type] = 2;
        }

        public override void SetDefaults()
        {
            NPC.CloneDefaults(NPCID.Bunny);
            NPC.lifeMax = 50000;
            NPC.value = Item.buyPrice(gold: 55);
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldDay.Chance * 0.001f;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new List<IBestiaryInfoElement> {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
                new FlavorTextBestiaryInfoElement("'Mooooo'")
            });
        }
        public override void FindFrame(int frameHeight) //2 frames code
        {
            /*NPC.frameCounter++;
            if (NPC.frameCounter == 10)
                NPC.frame.Y += frameHeight;
            else if (NPC.frameCounter == 30)
            {
                NPC.frame.Y = 0;
                NPC.frameCounter = 0;
            }*/
            /*NPC.frameCounter++;
            if (NPC.frameCounter >= 20)
            {
                NPC.frameCounter = 0;
            }
            NPC.frame.Y = (int)NPC.frameCounter / 10 * frameHeight;
        }
        public override void AI()
        {
            NPC.spriteDirection = NPC.direction;
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<MilkBucket>(), 1, 1, 1));
        }
    }
}*/
