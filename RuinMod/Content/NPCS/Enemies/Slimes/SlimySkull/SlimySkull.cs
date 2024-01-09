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
using IL.Terraria.GameContent.UI.Elements;

namespace RuinMod.Content.NPCS.Enemies.Slimes.SlimySkull
{
    public class SlimySkull : ModNPC
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Slimy Skull");
            Main.npcFrameCount[NPC.type] = Main.npcFrameCount[2];
        }

        public override void SetDefaults()
        {
            NPC.width = 32;
            NPC.height = 15;
            NPC.damage = 15;
            NPC.defense = 10;
            NPC.lifeMax = 35;
            NPC.value = 50f;
            NPC.aiStyle = 1;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            AIType = NPCID.GreenSlime;
            AnimationType = NPCID.GreenSlime;
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new List<IBestiaryInfoElement> {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime,
                //new SpawnConditionBestiaryInfoElement("Surface", SurfaceBackgroundID.Forest1),
                new FlavorTextBestiaryInfoElement("A simple, gelatinous creature that swallows anything and everything whole! It takes a long time to digest anything.")
            });
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldDay.Chance * 0.3f;
        }

        public override void AI()
        {
            NPC.spriteDirection = NPC.direction;

            /*if (Main.dayTime)
            {
                NPC.AddBuff(BuffID.OnFire, 60* 5);      //Put it on the public override void AI()
            }*/
        /*}

        public override void FindFrame(int frameHeight)
        {
            NPC.frameCounter++;
            if (NPC.frameCounter >= 20)
            {
                NPC.frameCounter = 0;
            }
            NPC.frame.Y = (int)NPC.frameCounter / 10 * frameHeight;
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ItemID.Gel, 1, 1, 2));
            npcLoot.Add(ItemDropRule.Common(ItemID.Bone, 1, 5, 10));
            npcLoot.Add(ItemDropRule.Common(ItemID.SlimeStaff, 10000, 1));
        }

    }
}*/
