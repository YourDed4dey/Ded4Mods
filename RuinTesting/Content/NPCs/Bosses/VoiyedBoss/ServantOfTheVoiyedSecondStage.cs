using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Terraria.DataStructures;
using Terraria.Audio;

namespace RuinTesting.Content.NPCs.Bosses.VoiyedBoss
{
    public class ServantOfTheVoiyedSecondStage : ModNPC
    {
        private const int FrameWidth = 20;
        private const int FrameHeight = 32;
        private const int TotalFrames = 2;

        private int frame = 0;
        private int frameCounter = 0;
        private int frameSpeed = 8;

        private float dashSpeed = 10f; // Adjust the dash speed as needed
        private bool isDashing = false;

        private bool isHealing = false;
        private int healCooldown = 0; // Adjust the heal cooldown in ticks
        private int healTimer = 0; // Timer for the heal cooldown

        private int attackTimer = 0; // Timer for controlling the summon's attacks
        private int attackDuration = 240; // Duration of each attack phase in ticks


        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Servant of the Voiyed");
            Main.npcFrameCount[NPC.type] = TotalFrames;

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
            NPC.damage = 55;
            NPC.defense = 10;
            NPC.lifeMax = 500;
            NPC.knockBackResist = 0f;
            NPC.noGravity = true;
            NPC.netAlways = true;
            NPC.noTileCollide = true;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
        }

        public override void FindFrame(int frameHeight)
        {
            NPC.frame.Y = frame * FrameHeight;
        }
        public override void HitEffect(NPC.HitInfo hit)
        {
            if (Main.netMode == NetmodeID.Server)
            {
                return;
            }

            if (NPC.life <= 0)
            {
                int backGoreType = Mod.Find<ModGore>("ServantOfTheVoiyed_Back").Type;
                int frontGoreType = Mod.Find<ModGore>("ServantOfTheVoiyedSecondStage_Front").Type;

                var entitySource = NPC.GetSource_Death();

                for (int i = 0; i < 1; i++)
                {
                    Gore.NewGore(entitySource, NPC.position, new Vector2(Main.rand.Next(-6, 7), Main.rand.Next(-6, 7)), backGoreType);
                    Gore.NewGore(entitySource, NPC.position, new Vector2(Main.rand.Next(-6, 7), Main.rand.Next(-6, 7)), frontGoreType);
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
                if (frame >= TotalFrames)
                {
                    frame = 0;
                }
            }

            Player player = Main.player[NPC.target];
            NPC.TargetClosest(true);

            Vector2 summonToPlayer = player.Center - NPC.Center;
            summonToPlayer.Normalize();

            NPC.rotation = summonToPlayer.ToRotation() + -MathHelper.PiOver2;
            Vector2 centerPosition = new Vector2(Main.maxTilesX / 2 * 16, Main.maxTilesY / 2 * 16);


            // Increment the attack timer
            attackTimer++;

            // Attack the player
            if (!isDashing && !isHealing)
            {
                //isAttackingPlayer = true;
                NPC.velocity = NPC.DirectionTo(player.Center) * dashSpeed;
                if (NPC.Hitbox.Intersects(player.Hitbox))
                {
                    isDashing = true;
                    for (int j = 0; j < 10; j++)
                    {
                        Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.GreenTorch, Scale: 1f);
                    }
                    // Reset the velocity
                    NPC.velocity = Vector2.Zero;
                    SoundEngine.PlaySound(SoundID.Item30, NPC.Center);
                }
            }

            // Handle the dash phase
            if (isDashing)
            {
                // Move towards the boss
                Vector2 bossPosition = Main.npc[(int)NPC.ai[0]].Center;
                NPC.velocity = NPC.DirectionTo(bossPosition) * dashSpeed;

                // Check if the summon has reached the boss
                if (NPC.Hitbox.Intersects(Main.npc[(int)NPC.ai[0]].Hitbox))
                {
                    isDashing = false;
                    isHealing = true;

                    // Reset the velocity
                    NPC.velocity = Vector2.Zero;
                }
            }

            // Handle the healing phase
            if (isHealing)
            {
                // Perform healing on the boss
                NPC healTarget = Main.npc[(int)NPC.ai[0]];
                if (healTarget != null && healTarget.active && healTarget.life < healTarget.lifeMax)
                {
                    // Only heal the boss if the heal cooldown has elapsed
                    if (healTimer >= healCooldown)
                    {
                        int healAmount = 120; // Adjust the healing amount as needed //Depending on the difficulty the summons heal more
                        if (Main.eclipse)
                        {
                            healAmount = 150;
                        }
                        else if (Main.bloodMoon)
                        {
                            healAmount = 200;
                        }
                        else
                        {
                            healAmount = 120;
                        }

                        if (Main.masterMode && !Main.getGoodWorld)
                        {
                            healAmount *= 3;
                        }
                        else if (Main.expertMode || Main.getGoodWorld)
                        {
                            healAmount *= 2;
                        }

                        if(Main.masterMode && Main.getGoodWorld)
                        {
                            healAmount *= 4;
                        }
                        healTarget.life += healAmount;
                        healTarget.HealEffect(healAmount);
                        for (int j = 0; j < 10; j++)
                        {
                            Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.GreenTorch, Scale: 1f);
                        }
                        SoundEngine.PlaySound(SoundID.Item4, NPC.Center);
                        NPC.active = false;
                        // Reset the heal cooldown
                        healTimer = 0;
                    }
                }

                // Move towards the center
                NPC.velocity = NPC.DirectionTo(centerPosition) * dashSpeed;
                isHealing = false;
                NPC.velocity = NPC.DirectionTo(player.Center) * dashSpeed;
                if (NPC.Hitbox.Intersects(player.Hitbox))
                {
                    isDashing = true;

                    // Reset the velocity
                    NPC.velocity = Vector2.Zero;
                }
            }

            // Increment the heal timer
            healTimer++;
        }
    }
}
