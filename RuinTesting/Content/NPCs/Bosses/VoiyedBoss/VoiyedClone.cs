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
    public class VoiyedClone : ModNPC
    {
        //TODO:Make the boss's clones able to teleport and do the Celestial Dance like attack. That would make the fight incredibly harder.


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
        public bool SecondStage
        {
            get => NPC.ai[0] == 1f;
            set => NPC.ai[0] = value ? 1f : 0f;
        }
        private bool isSecondStage_LaserAttackActive = false;
        private int LaserAttackTimer = 0;
        private float LaserAttackCooldown = Main.rand.NextFloat(250, 300); // 300 ticks = 5 seconds

        private int celestialTeleportTimer = 0;
        private int celestialTeleportCooldown = 180; // Cooldown for teleportation attack, 180 ticks = 3 seconds
        private int celestialTeleportDustTimer = 0;
        private const int celestialTeleportDustDuration = 120; // 2 seconds (60 ticks per second)
        private bool preparingCelestialTeleport = false;
        private Vector2 celestialTeleportPosition = Vector2.Zero;
        private float celestialTeleportDashSpeed = 25f;
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
            NPC.damage = 25;
            NPC.defense = 10;
            NPC.lifeMax = 9500;
            NPC.knockBackResist = 0f;
            NPC.value = Item.buyPrice(0, 0, 0, 0);
            NPC.npcSlots = 5f; // Set the number of NPC slots the boss occupies (check vanilla bosses for reference)
            NPC.lavaImmune = true;
            NPC.noTileCollide = true;
            NPC.noGravity = true;
            NPC.netAlways = true;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath5;
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
                NPC.velocity.X *= 0.98f; // Slow down horizontally

                // Dash attack
                aiTimer++;
                if (aiTimer >= 60)
                {
                    float randomVelocity = Main.rand.NextFloat(10f, 20f);
                    NPC.velocity = Vector2.Normalize(bossToPlayer) * randomVelocity;
                    aiTimer = 0;
                }

                if (SecondStage && LaserAttackTimer <= 0 && Main.expertMode)
                {
                    isSecondStage_LaserAttackActive = true;
                    LaserAttackTimer = (int)LaserAttackCooldown;
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
            }

            if (!NPC.AnyNPCs(ModContent.NPCType<Voiyed>()))
            {
                NPC.active = false;
            }
        }
        private void SecondStage_Laser()
        {
            if (Main.netMode != NetmodeID.MultiplayerClient && Main.expertMode)
            {
                // Calculate the direction to the player
                Vector2 directionToPlayer = Main.player[NPC.target].Center - NPC.Center;
                directionToPlayer.Normalize();

                for (int i = 0; i < 8; i++)
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
        private void CheckSecondStage()
        {
            if (SecondStage)
            {
                return;
            }

            if (NPC.life <= NPC.lifeMax * 1f && !SecondStage && Main.netMode != NetmodeID.MultiplayerClient)
            {
                SecondStage = true;
                NPC.netUpdate = true;
            }
        }
    }
}
