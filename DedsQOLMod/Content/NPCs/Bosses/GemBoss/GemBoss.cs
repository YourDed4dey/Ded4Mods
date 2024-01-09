using DedsQOLMod.Common.Systems;
using DedsQOLMod.Content.Items.Armor.Vanity.BossMasks;
using DedsQOLMod.Content.Items.Drops.GemmyDrops.GemmyBossBag;
using DedsQOLMod.Content.Items.Drops.GemmyDrops.GemmyRelic;
using DedsQOLMod.Content.Items.Drops.GemmyDrops.GemmyTrophy;
using DedsQOLMod.Content.Items.Pets.GemmyPet;
using DedsQOLMod.Content.Weapons.MageClass.PreHardmode.GemmySpellBooks;
using DedsQOLMod.Content.Weapons.RangerClass.PreHardmode.GemmyGun;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.NPCs.Bosses.GemBoss
{
    [AutoloadBossHead]
    public class GemBoss : ModNPC
    {
        private int aiTimer = 0;

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 9; // Set the number of frames for the boss

            NPCID.Sets.MPAllowedEnemies[Type] = true;

            NPCID.Sets.BossBestiaryPriority.Add(Type);

            NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Confused] = true;
            NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Poisoned] = true;
        }

        public override void SetDefaults()
        {
            NPC.width = 56;
            NPC.height = 89;
            NPC.aiStyle = -1; // Use a custom AI style if needed
            NPC.damage = 30; // Weaker damage compared to King Slime
            NPC.defense = 10; // Weaker defense compared to King Slime
            NPC.lifeMax = 1500; // Lower life than King Slime
            NPC.knockBackResist = 0f; // Adjust knockback resistance as desired
            NPC.boss = true;
            NPC.npcSlots = 10f; // Take up open spawn slots, preventing random NPCs from spawning during the fight
            NPC.lavaImmune = true;
            NPC.noGravity = true; // Set to false if you don't want it to float
            NPC.noTileCollide = true; // Set to true if you want it to pass through tiles
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = Item.buyPrice(0, 1, 0, 0); // Adjust value accordingly
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // Sets the description of this NPC that is listed in the bestiary
            bestiaryEntry.Info.AddRange(new List<IBestiaryInfoElement> {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns,
                new FlavorTextBestiaryInfoElement("After seeing many of his fallen comrades be mined, he is in the mission to seek for revenge.")
            });
        }
        public override void OnKill()
        {
            NPC.SetEventFlagCleared(ref DownedBossSystem.downedGemBoss, -1);
        }
        /*public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            Less damage, defense and health than King Slime.

            /*Normal Mode:
            - Boss does 30 damage  - Boss has 1500 hp

            Expert Mode:
            - Boss does 62 damage - Boss has 2100 hp //2835 on 2 players (1.35 is multiplier for each player)
            
            Master Mode:
            - Boss does 94 damage - Boss has 3150 hp //4252 on 2 players (1.35 is multiplier for each player)
            
            //DMG MULTIPLIER OF FTW = 33.33% (or .3333)

             FTW Expert Mode:
            - Boss does 62 damage - Boss has 2100 hp //2835 on 2 players (1.35 is multiplier for each player)
            
             FTW Master Mode:
            - Boss does 94 damage - Boss has 3150 hp //4252 on 2 players (1.35 is multiplier for each player)
            
             FTW Legendary Mode:
            - Boss does 168 damage - Boss has 4200 hp //5670 on 2 players (1.35 is multiplier for each player)*/


        // Scale the boss's health and damage for expert mode
        /*NPC.lifeMax = (int)(NPC.lifeMax * .75f * bossLifeScale);
        NPC.damage = (int)(NPC.damage * .85f); // 102 damage in Stage 1 for Expert
     }*/
        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * balance * .7f);
            NPC.damage = (int)(NPC.damage * 1.05f);
        }
        public override void HitEffect(NPC.HitInfo hit)
        {
            if (Main.netMode == NetmodeID.Server)
            {
                return;
            }

            int[] gemDusts = new int[]
{
                DustID.GemAmber,
                DustID.GemAmethyst,
                DustID.GemDiamond,
                DustID.GemEmerald,
                DustID.GemRuby,
                DustID.GemSapphire,
                DustID.GemTopaz
            };

            int randomDustIndex = Main.rand.Next(gemDusts.Length);
            int randomDustType = gemDusts[randomDustIndex];

            // Add dust effects
            Dust dust = Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, randomDustType); // Use a random dust type
            dust.scale = 1f; // Adjust the dust scale as needed
            dust.velocity *= 0.2f; // Adjust the dust velocity as needed
            dust.noGravity = true; // Set to true if you want the dust to float

            if (NPC.life <= 0)
            {
                int backGoreType = Mod.Find<ModGore>("GemBossGore_Back").Type;
                int frontGoreType = Mod.Find<ModGore>("GemBossGore_Front").Type;

                var entitySource = NPC.GetSource_Death();

                for (int i = 0; i < 1; i++)
                {
                    Gore.NewGore(entitySource, NPC.position, new Vector2(Main.rand.Next(-6, 7), Main.rand.Next(-6, 7)), backGoreType);
                    Gore.NewGore(entitySource, NPC.position, new Vector2(Main.rand.Next(-6, 7), Main.rand.Next(-6, 7)), frontGoreType);
                }
            }
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {

            LeadingConditionRule notExpertRule = new LeadingConditionRule(new Conditions.NotExpert());

            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GemmyTrophy>(), 10));

            notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<GemmyMask>(), 7));

            bool findMod = ModLoader.TryGetMod("DedsBosses", out Mod dedsQOLMod);
            if (findMod)
            {
                notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<GemmyGemSpellBook>(), 10));

                npcLoot.Add(ItemDropRule.MasterModeDropOnAllPlayers(ModContent.ItemType<GemmyGun>(), 10));
            }

            npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<GemmyBossBag>()));

            npcLoot.Add(ItemDropRule.MasterModeCommonDrop(ModContent.ItemType<GemmyRelic>()));

            npcLoot.Add(ItemDropRule.MasterModeDropOnAllPlayers(ModContent.ItemType<GemmyPet>(), 4));

            npcLoot.Add(notExpertRule);
        }
        public override void AI()
        {
            Player player = Main.player[NPC.target];
            NPC.TargetClosest(true);

            Vector2 bossToPlayer = player.Center - NPC.Center;
            bossToPlayer.Normalize();

            NPC.rotation = bossToPlayer.ToRotation() + -MathHelper.PiOver2;

            if (NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead || !Main.player[NPC.target].active)
            {
                NPC.TargetClosest();
            }

            if (player.dead)
            {
                NPC.velocity.Y -= 0.04f;
                NPC.EncourageDespawn(10);
                return;
            }

            // Add dust effects
            Dust dust = Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, DustID.OrangeTorch); // Change DustID as needed
            dust.scale = 1f; // Adjust the dust scale as needed
            dust.velocity *= 0.2f; // Adjust the dust velocity as needed
            dust.noGravity = true; // Set to true if you want the dust to float


            NPC.velocity.X *= 0.98f; // Slow down horizontally //Change depending on difficulty

            // Dash attack
            aiTimer++;
            if (aiTimer >= 60)
            {
                float speed = 5f;
                float healthFraction = (float)NPC.life / NPC.lifeMax;


                if (healthFraction <= 0.75f && healthFraction > 0.5f)
                {
                    speed *= 1.5f;
                }
                else if (healthFraction <= 0.5f && healthFraction > 0.25f)
                {
                    speed *= 1.5f;
                }
                else if (healthFraction <= 0.25f)
                {
                    speed *= 1.5f;
                }

                // You can clamp the speed increase to a certain maximum value
                float maxSpeed = 50f; // Adjust this value as needed
                speed = Math.Min(speed, maxSpeed);
                NPC.velocity = Vector2.Normalize(bossToPlayer) * speed; //Change depending on difficulty
                aiTimer = 0;

                // Shoot fireball projectiles
                if (Main.netMode != NetmodeID.MultiplayerClient) // Ensure projectiles are only spawned on the server
                {
                    Vector2 projectileVelocity = bossToPlayer * 8f; // Adjust the projectile speed as needed
                    int damage = 20; // Adjust the projectile damage as needed
                    int type = ProjectileID.Fireball; // The projectile type

                    Projectile.NewProjectile(null,NPC.Center, projectileVelocity, type, damage, 0f, Main.myPlayer);
                }
            }
        }
        public override void FindFrame(int frameHeight)
        {
            int startFrame = 0;
            int finalFrame = Main.npcFrameCount[NPC.type] - 1;

            if (NPC.frame.Y < startFrame * frameHeight)
            {
                NPC.frame.Y = startFrame * frameHeight;
            }

            int frameSpeed = 5;

            /*if (starAttack)
            {
                NPC.frameCounter += 0.5f;
                if (NPC.frameCounter > frameSpeed)
                {
                    NPC.frameCounter = 0;
                    NPC.frame.Y += frameHeight;

                    if (NPC.frame.Y > finalFrame * frameHeight)
                    {
                        NPC.frame.Y = (startFrame + 6) * frameHeight; // Start from the first frame of the starAttack animation
                    }
                }
            }
            else
            {*/
                NPC.frameCounter += 0.5f;
                NPC.frameCounter += NPC.velocity.Length() / 10f;
                if (NPC.frameCounter > frameSpeed)
                {
                    NPC.frameCounter = 0;
                    NPC.frame.Y += frameHeight;

                    if (NPC.frame.Y > (finalFrame - 3) * frameHeight) // Use only the first 6 frames when not in starAttack
                    {
                        NPC.frame.Y = startFrame * frameHeight;
                    }
                }
            //}
        }

    }
}
