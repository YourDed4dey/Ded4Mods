using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using RuinTesting.Common.Global;
using System.Collections.Generic;
using System.Linq;
using Terraria.Audio;

namespace RuinTesting.Content.NPCs.Bosses.VoiyedBoss
{
    [AutoloadBossHead]
    public class Voiyed : ModNPC
    {
        //TODO: Damage on FTW Difficulties

        //Info

        public static int secondStageHeadSlot = -1;
        private const int FrameWidth = 110;
        private const int FrameHeight = 166;
        private const int TotalFrames = 6;
        private const int Stage1Frames = 3;
        private const int Stage2Frames = 3;

        private int frame = 0;
        private int frameCounter = 0;
        private int frameSpeed = 5;

        private int aiTimer = 0;

        //Stage 1

        private int summonTimer = 0;
        private int summonDelayStage1 = 180; // Summon every 3 seconds in Stage 1

        private int meteorShowerCooldown = 300; // 5 second cooldown (60 ticks per second)

        private int teleportTimer = 0;
        private int teleportCooldown = 300; // Cooldown for teleportation attack, 300 ticks = 5 seconds
        private int teleportDustTimer = 0;
        private const int teleportDustDuration = 180; // 3 seconds (60 ticks per second)
        private bool preparingTeleport = false;
        private Vector2 teleportPosition = Vector2.Zero;
        private float dashSpeed = 20f;


        //Stage 2

        private int summonTimerStage2 = 0;
        private int summonDelayStage2 = 300; // 300 ticks = 5 seconds

        private bool isSecondStage_LaserAttackActive = false;
        private int LaserAttackTimer = 0;
        private int LaserAttackCooldown = 300; // 300 ticks = 5 seconds

        public bool SecondStage
        {
            get => NPC.ai[0] == 1f;
            set => NPC.ai[0] = value ? 1f : 0f;
        }

        //Blood Moon

        private int bloodMoonSummonTimer = 0;
        private int bloodMoonSummonDelay = 480; // 480 ticks = 8 seconds

        private int gravityWellCooldown = 600; // Cooldown for the Gravity Well attack (measured in frames) // 600 ticks = 10 seconds
        private int gravityWellTimer = 0; // Timer to track the cooldown
        private int gravityWellDuration = 300; // Duration of the Gravity Well attack (measured in frames) // 300 ticks = 5 seconds
        private int gravityWellDurationTimer = 0; // Timer to track the duration of the attack

        private bool bloodRainAttack; // A flag to check if the boss is currently doing the Blood Rain attack
        private int bloodRainTimer; // A timer to control the duration of the Blood Rain attack


        //Eclipse

        private int eclipseSummonTimer = 0;
        private int eclipseSummonDelay = 960; // 960 ticks = 16 seconds

        private int solarFlareAttackTimer = 0;
        private int solarFlareAttackCooldown = 720; // 720 ticks = 12 seconds

        private int celestialTeleportTimer = 0;
        private int celestialTeleportCooldown = 180; // Cooldown for teleportation attack, 180 ticks = 3 seconds
        private int celestialTeleportDustTimer = 0;
        private const int celestialTeleportDustDuration = 120; // 2 seconds (60 ticks per second)
        private bool preparingCelestialTeleport = false;
        private Vector2 celestialTeleportPosition = Vector2.Zero;
        private float celestialTeleportDashSpeed = 30f;

        private bool createClones;
        private bool cloneAttackTriggered;

        public override void Load()
        {
            string texture = BossHeadTexture + "_SecondStage";
            secondStageHeadSlot = Mod.AddBossHeadTexture(texture, -1);
        }

        public override void BossHeadSlot(ref int index)
        {
            int slot = secondStageHeadSlot;
            if (SecondStage && slot != -1)
            {
                index = slot;
            }
        }
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Voiyed");
            Main.npcFrameCount[NPC.type] = TotalFrames;
            NPCID.Sets.BossBestiaryPriority.Add(Type);

            NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData
            {
                SpecificallyImmuneTo = new int[]
                {
                    BuffID.Confused,
                    BuffID.Poisoned,
                    BuffID.OnFire,
                    BuffID.CursedInferno,
                    BuffID.DryadsWardDebuff,
                    BuffID.Bleeding,
                    BuffID.Venom,
                    BuffID.OnFire3,
                    BuffID.ShadowFlame
                }
            };
            NPCID.Sets.DebuffImmunitySets.Add(Type, debuffData);
        }

        public override void SetDefaults()
        {
            NPC.aiStyle = -1;
            NPC.width = FrameWidth;
            NPC.height = FrameHeight;
            NPC.damage = 60;
            NPC.defense = 20;
            NPC.lifeMax = 37750;
            NPC.knockBackResist = 0f;
            NPC.boss = true;
            NPC.value = Item.buyPrice(platinum:0, gold:40, silver:0, copper:0);
            NPC.npcSlots = 15f; // Set the number of NPC slots the boss occupies (check vanilla bosses for reference)
            NPC.lavaImmune = true;
            NPC.noTileCollide = true;
            NPC.noGravity = true;
            NPC.netAlways = true;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath5;
        }
        /*public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            More damage, defense and health than plantera. Less damage and defense than golem.

            /*Normal Mode:
            - Boss does 60 damage in Stage 1  - Boss has 37750 hp
            - Boss does 90 damage in Stage 2

            Expert Mode:
            - Boss does 138 damage in Stage 1 - Boss has 52850 hp //71347 on 2 players (1.35 is multiplier for each player)
            - Boss does 205 damage in Stage 2
            
            Master Mode:
            - Boss does 207 damage in Stage 1 - Boss has 79275 hp //107021 on 2 players (1.35 is multiplier for each player)
            - Boss does 309 damage in Stage 2
            
            //DMG MULTIPLIER OF FTW = 33.33% (or .3333)

             FTW Expert Mode:
            - Boss does 138 damage in Stage 1 - Boss has 52850 hp //71347 on 2 players (1.35 is multiplier for each player)
            - Boss does 273 damage in Stage 2
            
             FTW Master Mode:
            - Boss does 207 damage in Stage 1 - Boss has 79275 hp //107021 on 2 players (1.35 is multiplier for each player)
            - Boss does 411 damage in Stage 2
            
             FTW Legendary Mode:
            - Boss does 368 damage in Stage 1 - Boss has 105700 hp //142695 on 2 players (1.35 is multiplier for each player)
            - Boss supposed to do 549 damage but he does 411 in Stage 2*/



        // Scale the boss's health and damage for expert mode
        /*NPC.lifeMax = (int)(NPC.lifeMax * .75f * bossLifeScale);
        NPC.damage = (int)(NPC.damage * .85f); // 102 damage in Stage 1 for Expert
     }*/
        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * balance * .7f);
            NPC.damage = (int)(NPC.damage * 1.15f);
        }
        public override void FindFrame(int frameHeight)
        {
            int frameStart = 0;
            int frameCount = 0;

            if (!SecondStage)
            {
                frameStart = 0;
                frameCount = Stage1Frames;
            }
            else if (SecondStage)
            {
                frameStart = Stage1Frames;
                frameCount = Stage2Frames;
            }

            NPC.frame.Y = (frame + frameStart) * FrameHeight;
        }
        public override void HitEffect(NPC.HitInfo hit)
        {
            if (Main.netMode == NetmodeID.Server)
            {
                return;
            }

            if (NPC.life <= 0)
            {
                int backGoreType = Mod.Find<ModGore>("VoiyedStage1Gore_Back").Type;
                int frontGoreType = Mod.Find<ModGore>("VoiyedStage1Gore_Front").Type;
                int middleGoreType = Mod.Find<ModGore>("VoiyedStage2Gore_Middle").Type;

                var entitySource = NPC.GetSource_Death();

                for (int i = 0; i < 2; i++)
                {
                    Gore.NewGore(entitySource, NPC.position, new Vector2(Main.rand.Next(-6, 7), Main.rand.Next(-6, 7)), backGoreType);
                    Gore.NewGore(entitySource, NPC.position, new Vector2(Main.rand.Next(-6, 7), Main.rand.Next(-6, 7)), frontGoreType);
                    Gore.NewGore(entitySource, NPC.position, new Vector2(Main.rand.Next(-6, 7), Main.rand.Next(-6, 7)), middleGoreType);
                }
            }

            if (NPC.life <= NPC.lifeMax * 0.5f && !SecondStage)
            {
                for (int i = 0; i < 2; i++) // You can adjust the number of gore spawned
                {
                    int backGoreType = Mod.Find<ModGore>("VoiyedStage1Gore_Back").Type;
                    int frontGoreType = Mod.Find<ModGore>("VoiyedStage1Gore_Front").Type;

                    int backGore = Gore.NewGore(null, NPC.position, new Vector2(Main.rand.Next(-6, 7), Main.rand.Next(-6, 7)), backGoreType);
                    int frontGore = Gore.NewGore(null, NPC.position, new Vector2(Main.rand.Next(-6, 7), Main.rand.Next(-6, 7)), frontGoreType);

                    Main.gore[backGore].timeLeft = 720; // Adjust the time the gore stays on screen // 720 ticks = 12 seconds
                    Main.gore[frontGore].timeLeft = 720; // Adjust the time the gore stays on screen // 720 ticks = 12 seconds
                }

                SoundEngine.PlaySound(SoundID.Roar, NPC.Center);
            }
        }
        public override void AI()
        {
            frameCounter++;
            if (frameCounter >= frameSpeed)
            {
                frameCounter = 0;
                frame++;
                if (!SecondStage && frame >= Stage1Frames)
                {
                    frame = 0;
                }
                else if (SecondStage && frame >= Stage2Frames)
                {
                    frame = 0;
                }
            }

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

            CheckSecondStage();

            if (SecondStage)
            {
                if (!Main.expertMode && !Main.masterMode && !Main.getGoodWorld)
                {
                    NPC.damage = 90; // Normal Mode
                }

                if (Main.expertMode && !Main.masterMode)
                {
                    NPC.damage = 205; // Expert Mode
                }

                if (Main.masterMode)
                {
                    NPC.damage = 309; // Masted Mode
                }

                if (Main.getGoodWorld)
                {
                    NPC.damage = (int)(NPC.damage * 1.3333);
                }

                /*if (Main.zenithWorld)
                {
                    NPC.damage = 549;
                }*/

                NPC.velocity.X *= 0.98f; // Slow down horizontally //Change depending on difficulty

                // Dash attack
                aiTimer++;
                if (aiTimer >= 60)
                {
                    NPC.velocity = Vector2.Normalize(bossToPlayer) * 20f; //Change depending on difficulty
                    aiTimer = 0;
                }

                // Summon more ServantOfTheVoiyedSecondStage during Stage 2
                summonTimerStage2++;
                if (summonTimerStage2 >= summonDelayStage2)
                {
                    if (Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        for (int i = 0; i < 3; i++) //Change depending on difficulty
                        {
                            Vector2 spawnPosition = NPC.Center + new Vector2(200f * (float)Math.Cos(i * MathHelper.TwoPi / 5f), 200f * (float)Math.Sin(i * MathHelper.TwoPi / 5f));
                            int servantSecondStage = NPC.NewNPC(null, (int)spawnPosition.X, (int)spawnPosition.Y, ModContent.NPCType<ServantOfTheVoiyedSecondStage>(), ai0: NPC.whoAmI);
                            Main.npc[servantSecondStage].velocity = NPC.DirectionTo(player.Center) * 10f;
                            if (Main.netMode == NetmodeID.Server)
                            {
                                NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, servantSecondStage);
                            }
                        }
                    }
                    // Spawn blood dust
                    for (int j = 0; j < 20; j++)
                    {
                        Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Blood, Scale: 2f);
                    }
                    SoundEngine.PlaySound(SoundID.Roar, NPC.Center);
                    summonTimerStage2 = 0;
                }

                if (SecondStage && LaserAttackTimer <= 0)
                {
                    isSecondStage_LaserAttackActive = true;
                    LaserAttackTimer = LaserAttackCooldown;
                    for (int j = 0; j < 20; j++)
                    {
                        Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.PurpleTorch, Scale: 2f);
                    }
                }

                // Update the Laser attack
                if (isSecondStage_LaserAttackActive)
                {
                    SecondStage_Laser();
                }

                LaserAttackTimer--;


                // Blood Moon AI()



                bloodMoonSummonTimer++;
                if (bloodMoonSummonTimer >= bloodMoonSummonDelay)
                {
                    if (Main.bloodMoon)
                    {
                        if (Main.netMode != NetmodeID.MultiplayerClient)
                        {
                            for (int i = 0; i < 5; i++) //Change depending on difficulty
                            {

                                BloodMoonSummons();
                                for (int j = 0; j < 20; j++)
                                {
                                    Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.RedTorch, Scale: 2f);
                                }
                            }
                            SoundEngine.PlaySound(SoundID.Roar, NPC.Center);
                        }
                    }
                    bloodMoonSummonTimer = 0;
                }

                if (Main.bloodMoon == true)
                {
                    GravityWell_Attack();
                    BloodRain_Attack();
                }







                // Eclipse AI()



                eclipseSummonTimer++;
                if (eclipseSummonTimer >= eclipseSummonDelay)
                {
                    if (Main.eclipse)
                    {
                        if (Main.netMode != NetmodeID.MultiplayerClient)
                        {
                            for (int i = 0; i < 5; i++) //Change depending on difficulty
                            {

                                EclipseSummons();
                                for (int j = 0; j < 20; j++)
                                {
                                    Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.RedTorch, Scale: 2f);
                                }
                            }
                            SoundEngine.PlaySound(SoundID.Roar, NPC.Center);
                        }
                    }
                    eclipseSummonTimer = 0;
                }

                if (Main.eclipse == true)
                {
                    SolarFlare_Attack();
                    Clone_Attack();
                    // Check if teleportation attack is off cooldown
                    if (celestialTeleportTimer <= 0)
                    {
                        // Randomly select a position to teleport relative to the player
                        int teleportDirection = Main.rand.Next(4); // 0, 1, 2, or 3

                        switch (teleportDirection)
                        {
                            case 0: // Top left
                                celestialTeleportPosition = player.Center + new Vector2(-200, -200);
                                break;
                            case 1: // Top right
                                celestialTeleportPosition = player.Center + new Vector2(200, -200);
                                break;
                            case 2: // Bottom left
                                celestialTeleportPosition = player.Center + new Vector2(-200, 200);
                                break;
                            case 3: // Bottom right
                                celestialTeleportPosition = player.Center + new Vector2(200, 200);
                                break;
                        }

                        // Set the preparingTeleport flag to true and start the teleportation dust timer
                        preparingCelestialTeleport = true;
                        celestialTeleportDustTimer = celestialTeleportDustDuration;

                        // Set the teleportation cooldown
                        celestialTeleportTimer = celestialTeleportCooldown;
                    }
                    else
                    {
                        // If the teleportation attack is on cooldown, decrement the timer
                        celestialTeleportTimer--;
                    }
                }

                // Update the teleportation dust behavior
                if (preparingCelestialTeleport)
                {
                    // Dust will be shown for 3 seconds before the teleportation happens
                    if (celestialTeleportDustTimer <= 0)
                    {
                        // Teleport to the destination
                        NPC.position = celestialTeleportPosition;

                        // Start dashing towards the player
                        Vector2 dashVelocity = player.Center - NPC.Center;
                        dashVelocity.Normalize();
                        dashVelocity *= celestialTeleportDashSpeed;
                        NPC.velocity = dashVelocity;

                        // Remove the preparingTeleport flag
                        preparingCelestialTeleport = false;

                        SoundEngine.PlaySound(SoundID.Item6, NPC.Center);
                    }
                    else
                    {
                        // Create the teleportation indicator dust
                        Dust.NewDust(celestialTeleportPosition, NPC.width, NPC.height, DustID.OrangeTorch, Scale: 2f);

                        // Decrement the teleportation dust timer
                        celestialTeleportDustTimer--;
                    }
                }


                // Check if it's time to start the Lunar Eclipse or Blood Moon
                if (!Main.eclipse && !Main.bloodMoon && Main.dayTime && Main.rand.NextBool(600))
                {
                    Main.eclipse = true;
                    Main.time = 0;
                    Main.dayRate = 1f;
                    Main.sunModY = 0;
                }
                else if (!Main.eclipse && !Main.bloodMoon && !Main.dayTime && Main.rand.NextBool(600))
                {
                    Main.bloodMoon = true;
                    Main.time = 0;
                    Main.dayRate = 1f;
                    Main.moonModY = 0;
                }
            }
            else
            {

                NPC.velocity.X *= 0.98f; // Slow down horizontally  //Change depending on difficulty

                // Dash attack
                aiTimer++;
                if (aiTimer >= 60)
                {
                    NPC.velocity = Vector2.Normalize(bossToPlayer) * 10f; //Change depending on difficulty
                    aiTimer = 0;
                }

                // Summon ServantOfTheVoiyed during Stage 1
                summonTimer++;
                if (summonTimer >= summonDelayStage1)
                {
                    if (Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        for (int i = 0; i < 5; i++) //Change depending on difficulty
                        {
                            Vector2 spawnPosition = NPC.Center + new Vector2(200f * (float)Math.Cos(i * MathHelper.TwoPi / 5f), 200f * (float)Math.Sin(i * MathHelper.TwoPi / 5f));
                            int servant = NPC.NewNPC(null, (int)spawnPosition.X, (int)spawnPosition.Y, ModContent.NPCType<ServantOfTheVoiyed>(), ai0: NPC.whoAmI);
                            Main.npc[servant].velocity = NPC.DirectionTo(player.Center) * 10f;
                            if (Main.netMode == NetmodeID.Server)
                            {
                                NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, servant);
                            }
                        }
                    }
                    // Spawn blood dust
                    for (int j = 0; j < 20; j++)
                    {
                        Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Blood, Scale: 2f);
                    }
                    SoundEngine.PlaySound(SoundID.Roar, NPC.Center);
                    summonTimer = 0;
                }

                // Meteor Shower attack
                if (meteorShowerCooldown <= 0)
                {
                    // Trigger the "Meteor Shower" attack
                    TriggerMeteorShower();
                    // Reset the cooldown to 5 seconds
                    meteorShowerCooldown = 300;
                }
                else
                {
                    meteorShowerCooldown--;
                }

                if (NPC.life < NPC.lifeMax * 0.75f)
                {
                    // Check if teleportation attack is off cooldown
                    if (teleportTimer <= 0)
                    {
                        // Randomly select a position to teleport relative to the player
                        int teleportDirection = Main.rand.Next(4); // 0, 1, 2, or 3

                        switch (teleportDirection)
                        {
                            case 0: // Top left
                                teleportPosition = player.Center + new Vector2(-200, -200);
                                break;
                            case 1: // Top right
                                teleportPosition = player.Center + new Vector2(200, -200);
                                break;
                            case 2: // Bottom left
                                teleportPosition = player.Center + new Vector2(-200, 200);
                                break;
                            case 3: // Bottom right
                                teleportPosition = player.Center + new Vector2(200, 200);
                                break;
                        }

                        // Set the preparingTeleport flag to true and start the teleportation dust timer
                        preparingTeleport = true;
                        teleportDustTimer = teleportDustDuration;

                        // Set the teleportation cooldown
                        teleportTimer = teleportCooldown;
                    }
                    else
                    {
                        // If the teleportation attack is on cooldown, decrement the timer
                        teleportTimer--;
                    }
                }

                // Update the teleportation dust behavior
                if (preparingTeleport)
                {
                    // Dust will be shown for 3 seconds before the teleportation happens
                    if (teleportDustTimer <= 0)
                    {
                        // Teleport to the destination
                        NPC.position = teleportPosition;

                        // Start dashing towards the player
                        Vector2 dashVelocity = player.Center - NPC.Center;
                        dashVelocity.Normalize();
                        dashVelocity *= dashSpeed;
                        NPC.velocity = dashVelocity;

                        // Remove the preparingTeleport flag
                        preparingTeleport = false;

                        SoundEngine.PlaySound(SoundID.Item6, NPC.Center);
                    }
                    else
                    {
                        // Create the teleportation indicator dust
                        Dust.NewDust(teleportPosition, NPC.width, NPC.height, DustID.PurpleTorch, Scale: 2f);

                        // Decrement the teleportation dust timer
                        teleportDustTimer--;
                    }
                }
            }
        }

        public override void BossLoot(ref string name, ref int potionType)
        {
            name = "Ded's Eye";
            potionType = ItemID.GreaterHealingPotion;
        }
        private void TriggerMeteorShower()
        {
            // Check if the boss is at 90% health or below
            if (NPC.life <= NPC.lifeMax * 0.9f)
            {
                // Number of meteors to spawn
                int meteorCount = Main.rand.Next(15, 21);

                float angleOffset = MathHelper.TwoPi / meteorCount; // Angle between each meteor

                for (int i = 0; i < meteorCount; i++)
                {
                    // Calculate the angle for the current meteor
                    float angle = angleOffset * i;

                    // Get the player's Y position
                    float playerY = Main.player[NPC.target].Center.Y;

                    // Calculate the spawn position above the player off the screen
                    Vector2 spawnPosition = new Vector2(Main.player[NPC.target].Center.X + Main.screenWidth / 2f * (float)Math.Cos(angle), playerY - Main.screenHeight + 500f);

                    Vector2 velocity = new Vector2(Main.rand.NextFloat(-3f, 3f), Main.rand.NextFloat(10f, 15f));

                    // Spawn the meteor projectile
                    int projectileType = Main.rand.Next(new int[] { ProjectileID.Meteor1, ProjectileID.Meteor2, ProjectileID.Meteor3 });
                    int projectileIndex = Projectile.NewProjectile(null, spawnPosition, velocity, projectileType, NPC.damage / 4, 0f, Main.myPlayer);

                    SoundEngine.PlaySound(SoundID.DD2_BetsyFlameBreath);

                    // Set the custom homing behavior for the meteor projectile
                    if (projectileIndex != Main.maxProjectiles)
                    {
                        Projectile projectile = Main.projectile[projectileIndex];
                        projectile.tileCollide = true;
                        projectile.netUpdate = true;
                        projectile.hostile = true;
                        projectile.friendly = false;
                        projectile.timeLeft = 600;
                        projectile.penetrate = -1;
                        projectile.aiStyle = 1;
                        projectile.usesLocalNPCImmunity = true;
                        projectile.localNPCHitCooldown = -1;
                        projectile.GetGlobalProjectile<RuinTestingGlobalProjectile>().meteorExplosionDelegate = ExplodeMeteor;

                        projectile.ai[0] = 0; // Custom homing AI: State 0: Moving downwards
                        projectile.ai[1] = 0; // Custom homing AI: Timer

                        if (projectile.ai[0] == 0) // Moving downwards
                        {
                            projectile.ai[1]++;
                            if (projectile.ai[1] >= 60) // Change direction after 60 ticks
                            {
                                projectile.ai[0] = 1; // Change to upward movement
                                projectile.ai[1] = 0; // Reset the timer
                            }
                            else
                            {
                                // Move the projectile downwards
                                projectile.velocity.Y += 0.1f;
                            }
                        }
                        else if (projectile.ai[0] == 1) // Moving upwards
                        {
                            // Move the projectile upwards
                            projectile.velocity.Y -= 0.1f;
                        }
                    }
                }
            }
        }
        private void ExplodeMeteor(Projectile projectile)
        {
            Vector2 explosionPosition = projectile.Center;
            int explosionRadius = 100;

            int explosion = Projectile.NewProjectile(null, explosionPosition, Vector2.Zero, ProjectileID.DD2ExplosiveTrapT3Explosion, NPC.damage / 4, 0f, Main.myPlayer);

            Main.projectile[explosion].hostile = true;
            Main.projectile[explosion].friendly = false;

            for (int j = 0; j < Main.maxPlayers; j++)
            {
                if (Main.player[j].active && !Main.player[j].dead && (explosionPosition - Main.player[j].Center).Length() < explosionRadius)
                {
                    Main.player[j].Hurt(PlayerDeathReason.ByNPC(NPC.whoAmI), projectile.damage, 0);
                }
            }
        }
        private void SecondStage_Laser()
        {
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                // Calculate the direction to the player
                Vector2 directionToPlayer = Main.player[NPC.target].Center - NPC.Center;
                directionToPlayer.Normalize();
                for (int i = 0; i < 8; i++)  //Change depending on difficulty
                {
                    float rotation = MathHelper.TwoPi / 8f * i;

                    // Offset position from the boss
                    float offsetMagnitude = 60f; // Adjust the magnitude of the offset
                    Vector2 projectileOffset = new Vector2(offsetMagnitude, 0f).RotatedBy(rotation);

                    int secondaryProjectile = Projectile.NewProjectile(
                        null,
                        NPC.Center + projectileOffset, // Spawn the projectile on the boss with the offset
                        directionToPlayer * 10f, // No initial velocity, the projectile will move towards the player
                        ProjectileID.EyeLaser,
                        NPC.damage / 4,
                        0f,
                        Main.myPlayer
                    );

                    // Additional customization for the secondary projectile, if needed
                    Main.projectile[secondaryProjectile].friendly = false;
                    Main.projectile[secondaryProjectile].hostile = true;
                    Main.projectile[secondaryProjectile].tileCollide = false;
                    Main.projectile[secondaryProjectile].timeLeft = 240;

                    // Set the rotation of the secondary projectile to make it face the player
                    Main.projectile[secondaryProjectile].rotation = rotation;

                    // Set localAI[1] to the target player's ID
                    Main.projectile[secondaryProjectile].localAI[1] = NPC.target;


                    if (Main.projectile[secondaryProjectile].ai[0] == 0f)
                    {
                        Main.projectile[secondaryProjectile].ai[0] = 1f;
                        Main.projectile[secondaryProjectile].netUpdate = true;
                    }

                    if (Main.player[Main.projectile[secondaryProjectile].owner].active)
                    {
                        // Calculate the direction to the player
                        Vector2 projectileToPlayer = Main.player[Main.projectile[secondaryProjectile].owner].Center - Main.projectile[secondaryProjectile].Center;
                        projectileToPlayer.Normalize();

                        // Set the velocity of the projectile to move towards the player
                        float speed = 10f; // Adjust the speed as needed
                        Main.projectile[secondaryProjectile].velocity = projectileToPlayer * speed;

                        // Face the projectile towards the player (optional)
                        Main.projectile[secondaryProjectile].rotation = projectileToPlayer.ToRotation() + MathHelper.PiOver2;

                        // Optional: Add homing behavior to the projectile
                        float homingStrength = 0.1f; // Adjust the homing strength as needed
                        Main.projectile[secondaryProjectile].velocity = Vector2.Lerp(Main.projectile[secondaryProjectile].velocity, projectileToPlayer * speed, homingStrength);
                    }
                }
            }

            isSecondStage_LaserAttackActive = false;
        }




        // Blood Moon





        // Array to store the IDs of the enemies to summon during the Blood Moon
        private int[] bloodMoonEnemyTypesPreHardmode = new int[]
        {
            NPCID.BloodZombie,
            NPCID.Drippler,
            NPCID.EyeballFlyingFish,
            // Add more enemy IDs here as needed
        };

        private int[] bloodMoonEnemyTypesHardmode = new int[]
        {
            NPCID.BloodZombie,
            NPCID.Drippler,
            NPCID.EyeballFlyingFish,
            NPCID.Clown, // Add "NPCID.Clown" only during Hardmode
            // Add more enemy IDs here as needed
        };
        private void BloodMoonSummons()
        {
            if (Main.bloodMoon)
            {
                bloodMoonSummonTimer++;
                if (bloodMoonSummonTimer >= bloodMoonSummonDelay)
                {
                    bloodMoonSummonTimer = 0;

                    // Randomly select an enemy ID from the appropriate array based on whether it's Hardmode or not
                    int[] selectedEnemyTypes = Main.hardMode ? bloodMoonEnemyTypesHardmode : bloodMoonEnemyTypesPreHardmode;
                    int enemyType = selectedEnemyTypes[Main.rand.Next(selectedEnemyTypes.Length)];

                    // Summon the selected enemy
                    Vector2 spawnPosition = NPC.Center + new Vector2(Main.rand.Next(-200, 201), Main.rand.Next(-200, 201)); // Randomize the spawn position around the boss
                    int spawnedNPC = NPC.NewNPC(null, (int)spawnPosition.X, (int)spawnPosition.Y, enemyType);

                    // Optional: Customize the summoned enemy, if needed
                    if (spawnedNPC >= 0 && spawnedNPC < Main.npc.Length)
                    {
                        Main.npc[spawnedNPC].ai[0] = NPC.whoAmI; // Set the AI target to the boss
                        Main.npc[spawnedNPC].ai[1] = 1f; // Set the AI state, if applicable
                    }

                    // Make sure the summoned enemy is hostile to players
                    if (Main.netMode != NetmodeID.MultiplayerClient &&spawnedNPC >= 0 && spawnedNPC < Main.maxNPCs)
                    {
                        Main.npc[spawnedNPC].target = NPC.target;
                        Main.npc[spawnedNPC].netUpdate = true;
                        Main.npc[spawnedNPC].value = Item.buyPrice(0, 0, 0, 0);
                    }
                }
            }
        }

        private void GravityWell_Attack()
        {
            // Check if Gravity Well attack is off cooldown
            if (gravityWellTimer <= 0)
            {
                // Set the Gravity Well duration timer
                gravityWellDurationTimer = gravityWellDuration;

                // Set the Gravity Well cooldown
                gravityWellTimer = gravityWellCooldown;

                // Apply the visual effect for the Gravity Well (swirling particles or distortion)
                // You can use Dust.NewDust or other visual effects here.
            }
            else
            {
                // If the Gravity Well attack is on cooldown, decrement the timer
                gravityWellTimer--;
            }

            // During the Gravity Well attack
            if (gravityWellDurationTimer > 0)
            {
                // Apply a constant force towards the center of the gravity well to players
                foreach (Player person in Main.player)
                {
                    if (person.active && !person.dead && Vector2.Distance(person.Center, NPC.Center) < 300f)
                    {
                        Vector2 directionToBoss = NPC.Center - person.Center;
                        directionToBoss.Normalize();
                        person.velocity += directionToBoss * 2f; // Adjust the force to your liking

                        SoundEngine.PlaySound(SoundID.Roar, NPC.Center);
                    }
                }

                // Apply a constant force towards the center of the gravity well to projectiles
                foreach (Projectile projectile in Main.projectile)
                {
                    if (projectile.active && projectile.friendly && Vector2.Distance(projectile.Center, NPC.Center) < 300f)
                    {
                        Vector2 directionToBoss = NPC.Center - projectile.Center;
                        directionToBoss.Normalize();
                        projectile.velocity += directionToBoss * 1f; // Adjust the force to your liking
                    }
                }

                // Decrement the Gravity Well duration timer
                gravityWellDurationTimer--;
            }
        }

        private void BloodRain_Attack()
        {
            bool hasSpecificMask = Main.player[NPC.target].armor.Any(item => item.type == ItemID.RainHat);

            /*if (Main.expertMode || Main.getGoodWorld)
            {

            }
            else
            {
                // Skip the attack if the player has the specific mask equipped
                if (hasSpecificMask)
                {
                    return;
                }
            }*/

            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                // Check if Blood Moon is active
                if (Main.bloodMoon == true)
                {
                    // Check if the Blood Rain attack is not currently ongoing
                    if (!bloodRainAttack)
                    {
                        if (Main.rand.NextBool(600))
                        {
                            bloodRainAttack = true;
                            bloodRainTimer = 300; // Set the duration of the Blood Rain attack
                        }
                    }
                    else
                    {
                        // Blood Rain attack is ongoing
                        bloodRainTimer--;

                        // Spawn the Blood Rain projectiles
                        if (bloodRainTimer % 30 == 0) // Spawn a new projectile every 30 ticks (half a second)
                        {
                            for (int i = 0; i < 20; i++)
                            {
                                // Number of rain to spawn
                                int rainCount = Main.rand.Next(15, 21);

                                float angleOffset = MathHelper.TwoPi / rainCount; // Angle between each rain drop
                                                                                  // Calculate the angle for the current rain drop
                                float angle = angleOffset * i;

                                // Get the player's Y position
                                float playerY = Main.player[NPC.target].Center.Y;

                                // Calculate the spawn position above the player off the screen
                                Vector2 spawnPosition = new Vector2(Main.player[NPC.target].Center.X + Main.screenWidth / 2f * (float)Math.Cos(angle), playerY - Main.screenHeight + 500f);

                                Vector2 velocity = new Vector2(Main.rand.NextFloat(-3f, 3f), Main.rand.NextFloat(10f, 15f));

                                // Spawn the meteor projectile
                                int projectileIndex = Projectile.NewProjectile(null, spawnPosition, velocity, ProjectileID.BloodRain, NPC.damage / 4, 0f, Main.myPlayer);
                                Main.projectile[projectileIndex].hostile = true;
                                Main.projectile[projectileIndex].friendly = false;

                                SoundEngine.PlaySound(SoundID.Drip, NPC.Center);

                                if (Main.expertMode || Main.getGoodWorld)
                                {

                                }
                                else if (Main.player[NPC.target].active && !Main.player[NPC.target].dead && hasSpecificMask)
                                {
                                    Main.projectile[projectileIndex].damage = 0;
                                }
                            }
                        }

                        // Check if the Blood Rain attack should end
                        if (bloodRainTimer <= 0)
                        {
                            bloodRainAttack = false;
                        }
                    }
                }
            }
        }








        // Eclipse





        // Array to store the IDs of the enemies to summon during the Eclipse Moon
        private int[] eclipseEnemyTypesPreHardmode = new int[]
        {
            NPCID.Eyezor,
            NPCID.SwampThing,
            NPCID.Vampire,
        };

        private int[] eclipseEnemyTypesHardmode = new int[]
        {
            NPCID.Eyezor,
            NPCID.SwampThing,
            NPCID.Vampire,
            NPCID.Reaper,
        };
        private void EclipseSummons()
        {
            if (Main.eclipse)
            {
                eclipseSummonTimer++;
                if (eclipseSummonTimer >= eclipseSummonDelay)
                {
                    eclipseSummonTimer = 0;

                    // Randomly select an enemy ID from the appropriate array based on whether it's Hardmode or not
                    int[] selectedEnemyTypes = Main.hardMode ? eclipseEnemyTypesHardmode : eclipseEnemyTypesPreHardmode;
                    int enemyType = selectedEnemyTypes[Main.rand.Next(selectedEnemyTypes.Length)];

                    // Summon the selected enemy
                    Vector2 spawnPosition = NPC.Center + new Vector2(Main.rand.Next(-200, 201), Main.rand.Next(-200, 201)); // Randomize the spawn position around the boss
                    int spawnedNPC = NPC.NewNPC(null, (int)spawnPosition.X, (int)spawnPosition.Y, enemyType);

                    // Optional: Customize the summoned enemy, if needed
                    if (spawnedNPC >= 0 && spawnedNPC < Main.npc.Length)
                    {
                        Main.npc[spawnedNPC].ai[0] = NPC.whoAmI; // Set the AI target to the boss
                        Main.npc[spawnedNPC].ai[1] = 1f; // Set the AI state, if applicable
                    }

                    // Make sure the summoned enemy is hostile to players
                    if (Main.netMode != NetmodeID.MultiplayerClient && spawnedNPC >= 0 && spawnedNPC < Main.maxNPCs)
                    {
                        Main.npc[spawnedNPC].target = NPC.target;
                        Main.npc[spawnedNPC].netUpdate = true;
                        Main.npc[spawnedNPC].value = Item.buyPrice(0, 0, 0, 0);
                    }
                }
            }
        }

        private void SolarFlare_Attack()
        {
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                if (Main.eclipse)
                {
                    solarFlareAttackTimer--;

                    if (solarFlareAttackTimer <= 0)
                    {
                        solarFlareAttackTimer = solarFlareAttackCooldown;

                        // Summon the shadowy orbs
                        int numberOfOrbs = 4; // You can adjust the number of orbs as you like
                        float angleIncrement = MathHelper.TwoPi / numberOfOrbs;

                        for (int i = 0; i < numberOfOrbs; i++)
                        {
                            Vector2 spawnPosition = NPC.Center + new Vector2(200f, 0f).RotatedBy(angleIncrement * i);
                            int orbNPCID = NPC.NewNPC(null, (int)spawnPosition.X, (int)spawnPosition.Y, NPCID.SolarFlare); // Replace the NPCID with the ID of your shadow orb NPC
                            for (int j = 0; j < 20; j++)
                            {
                                Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.OrangeTorch, Scale: 2f);
                            }

                            if (Main.netMode != NetmodeID.SinglePlayer)
                            {
                                NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, orbNPCID);
                            }

                            // Set the orb's rotation speed and direction
                            NPC orbNPC = Main.npc[orbNPCID];
                            orbNPC.noTileCollide = true;
                            orbNPC.ai[0] = 1f; // Set the AI state to indicate that this is a shadow orb
                            orbNPC.ai[1] = NPC.whoAmI; // Remember the original boss NPC index
                            orbNPC.ai[2] = i * 2f; // Set the rotation speed for each orb
                            orbNPC.ai[3] = 1f; // Set the rotation direction (1 for clockwise, -1 for counterclockwise)
                        }
                    }
                }
            }
        }
        private void Clone_Attack()
        {
            if (!cloneAttackTriggered)
            {
                createClones = true;
                cloneAttackTriggered = true;
            }

            if (Main.eclipse && createClones)
            {
                float spacing = MathHelper.TwoPi / 3f; // Angle between each clone (120 degrees)
                float angle = 0f; // Starting angle

                int numberOfClones = 1;
                if (Main.expertMode)
                {
                    numberOfClones = 2;
                }
                if (Main.masterMode || Main.getGoodWorld)
                {
                    numberOfClones = 3;
                }

                for (int i = 0; i < numberOfClones; i++)
                {
                    float spawnDist = 300f; // Distance from the boss at which clones spawn
                    int offsetX = (int)(spawnDist * Math.Cos(angle)); // X offset from the boss's position
                    int offsetY = (int)(spawnDist * Math.Sin(angle)); // Y offset from the boss's position

                    int clone = NPC.NewNPC(null, (int)NPC.Center.X + offsetX,
                                           (int)NPC.Center.Y + offsetY, ModContent.NPCType<VoiyedClone>());
                    Main.npc[clone].ai[0] = NPC.whoAmI; // Set the AI target to the boss

                    angle += spacing; // Increment the angle for the next clone
                }

                // Set createClones to false to prevent further clone creation
                createClones = false;
            }
        }
        private void CheckSecondStage()
        {
            if (SecondStage)
            {
                return;
            }

            if (NPC.life <= NPC.lifeMax * 0.5f && !SecondStage && Main.netMode != NetmodeID.MultiplayerClient)
            {
                SecondStage = true;
                NPC.netUpdate = true;
            }
        }
    }
}
