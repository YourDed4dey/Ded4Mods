using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader.Utilities;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent.Bestiary;
using System.Collections.Generic;
using RuinMod.Content.Armor.VanityArmor.TrafficConeHat;

namespace RuinMod.Content.NPCS.Enemies.PVZ.ConeHeadZombie
{
    public class PVZConeHeadZombie : ModNPC
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Conehead Zombie");
            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.Zombie];
        }

        public override void SetDefaults()
        {
            NPC.CloneDefaults(NPCID.Zombie);
            NPC.scale -= .25f;
        }
        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * balance * .7f);
            NPC.damage = (int)(NPC.damage * 1.05f);
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.Player.ZoneOverworldHeight)
            {
                return SpawnCondition.OverworldNightMonster.Chance * 0.1f;
            }

            return 0f;
        }
        public override void FindFrame(int frameHeight)
        {
            NPC.frameCounter++;
            if (NPC.frameCounter == 10)
                NPC.frame.Y += frameHeight;
            if (NPC.frameCounter == 20)
                NPC.frame.Y += frameHeight;
            else if (NPC.frameCounter == 40)
            {
                NPC.frame.Y = 0;
                NPC.frameCounter = 0;
            }
        }
        public override void AI()
        {
            NPC.spriteDirection = NPC.direction;
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new List<IBestiaryInfoElement> {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime,
                new FlavorTextBestiaryInfoElement("Iconic monster from the hit game Plants vs Zombies!")
            });
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<TrafficConeHat>(), 1, 1, 1));
        }
    }
}
