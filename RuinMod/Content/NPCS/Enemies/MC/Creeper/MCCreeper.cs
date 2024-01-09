using Terraria.ModLoader;
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
using static Terraria.ModLoader.PlayerDrawLayer;
using RuinMod.Content.Projectiles.NPCSProjectiles.EnemiesProjectiles.CreeperBomb;

namespace RuinMod.Content.NPCS.Enemies.MC.Creeper
{
    public class MCCreeper : ModNPC
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Creeper");
            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.Zombie];
        }

        public override void SetDefaults()
        {
            NPC.CloneDefaults(NPCID.Zombie);
            AnimationType = NPCID.Zombie;
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
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new List<IBestiaryInfoElement> {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime,
                new FlavorTextBestiaryInfoElement("Iconic monster from the hit game Minecraft! 'Awww Man!'")
            });
        }
        public override void ModifyNPCLoot(NPCLoot NPCLoot)
        {

        }
        public override void OnKill()
        {
            if (Main.getGoodWorld)
            {
                for (int i = 0; i < 1; i++)
                {
                    Vector2 position = NPC.Center;
                    Vector2 targetPosition = Main.player[NPC.target].Center;
                    Vector2 direction = targetPosition - position;
                    direction.Normalize();
                    float speed = 10f;

                    int type = ModContent.ProjectileType<CreeperProjectile>();
                    Vector2 velocity = direction * speed;
                    int damage = 300;
                    Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(15)); //15

                    newVelocity *= 1f - Main.rand.NextFloat(0.3f);

                    Projectile.NewProjectile(null, position, newVelocity, type, damage, 0, Main.myPlayer);
                }
            }
        }
    }
}
