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
using UtfUnknown.Core.Probers.MultiByte.Chinese;

namespace RuinMod.Content.NPCS.Enemies.Devil
{
    public class Devil : ModNPC
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Devil");
            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.Zombie];
        }

        public override void SetDefaults()
        {
            NPC.CloneDefaults(NPCID.Zombie);
            AnimationType = NPCID.Zombie;
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.Player.ZoneUnderworldHeight)
            {
                return SpawnCondition.Underworld.Chance * 0.1f;
            }

            return 0f;
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new List<IBestiaryInfoElement> {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheUnderworld,
                new FlavorTextBestiaryInfoElement("Lives in hell and looks like the player. Some people say they are dangerous but really, who knows?!")
            });
        }

        public override void AI()
        {
            /*if (Main.dayTime)
            {
                NPC.AddBuff(BuffID.OnFire, 60 * 5);
            }
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {

        }
    }
}*/
