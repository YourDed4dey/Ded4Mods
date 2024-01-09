/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using System.Collections.Generic;
using RuinMod.Content.Consumables.Pets.CorrupterJr;
using RuinMod.Assets.Textures.BossBars;
using System.IO;
using System;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Creative;
using RuinMod.Assets.Music;

namespace RuinMod.Content.NPCS.Bosses.Corrupter
{
    [AutoloadBossHead]
    internal class Corrupter : ModNPC
    {
        private int ai;
        private int attackTimer = 0;
        private bool fastSpeed = false;

        private bool stunned;
        private int stunnedTimer;

        private int frame = 2;
        private double counting;

        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Corrupter");
            Main.npcFrameCount[NPC.type] = 6;
            var drawModifier = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            { // Influences how the NPC looks in the Bestiary
                CustomTexturePath = "RuinMod/Assets/Textures/NPCS/Bosses/Corrupter/CorrupterBestiary",
                Position = new Vector2(5f, 40f),
                PortraitPositionXOverride = 0f,
                PortraitPositionYOverride = 20f

            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, drawModifier);
        }

        public override void SetDefaults()
        {
            NPC.width = 43;
            NPC.height = 51;
            NPC.scale = 2f;

            NPC.boss = true;
            NPC.aiStyle = -1; //-1
            NPC.npcSlots = 1f;
            NPC.rotation = 0;

            NPC.lifeMax = 79012;
            NPC.damage = 200;
            NPC.defense = 100;
            NPC.knockBackResist = 0f;

            NPC.value = Item.buyPrice(gold: 69);

            NPC.lavaImmune = true;
            NPC.noTileCollide = true;
            NPC.noGravity = true;
            NPC.BossBar = ModContent.GetInstance<CorrupterBossBar>();
            NPC.GetSource_FromAI();

            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath10;

            Music = MusicLoader.GetMusicSlot("RuinMod/Assets/Music/BossThemes/CorrTheme/CorrTheme");
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {

                new FlavorTextBestiaryInfoElement("'Your life is on the line, you don't realize the danger you are in...'")
            });
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * bossLifeScale);
            NPC.damage = (int)(NPC.damage * 0.3f);
        }

        public override void AI()
        {
            NPC.rotation += 0.1f * (float)NPC.direction;
            NPC.spriteDirection = NPC.direction;
            NPC.TargetClosest(true);
            Player player = Main.player[NPC.target];
            Vector2 target = NPC.HasPlayerTarget ? player.Center : Main.npc[NPC.target].Center;

            NPC.rotation = 0.0f;
            NPC.netAlways = true;
            NPC.TargetClosest(true);

            if (NPC.life >= NPC.lifeMax)
                NPC.life = NPC.lifeMax;

            if (NPC.target < 0 || NPC.target == 255 || player.dead || !player.active)
            {
                NPC.TargetClosest(false);
                NPC.direction = 1;
                NPC.velocity.Y = NPC.velocity.Y - 0.1f;
                if (NPC.timeLeft > 20)
                {
                    NPC.timeLeft = 20;
                    return;
                }
            }

            if (stunned)
            {
                NPC.velocity.X = 0.0f;
                NPC.velocity.Y = 0.0f;

                stunnedTimer++;

                if (stunnedTimer >= 100)
                {
                    stunned = false;
                    stunnedTimer = 0;
                }
            }

            ai++;

            NPC.ai[0] = (float)ai * 1f;
            int distance = (int)Vector2.Distance(target, NPC.Center);
            if ((double)NPC.ai[0] < 300)
            {
                frame = 0;
                //MoveTowards(NPC, target, (float)(distance > 300 ? 13f : 7f), 30f); //300 ? 13f : 7f), 30f);
                NPC.netUpdate = true;
            }
            else if ((double)NPC.ai[0] >= 300 && (double)NPC.ai[0] < 450.0)
            {
                stunned = false;//true
                frame = 1;

                NPC.defense = 0;
                NPC.damage = 0;

                NPC.life +=  25;
                NPC.HealEffect(1);
                SoundEngine.PlaySound(SoundID.Item4 with
                {
                    MaxInstances = 1,
                    SoundLimitBehavior = SoundLimitBehavior.IgnoreNew
                });

                NPC.aiStyle = -1;

                NPC.immortal = true;

                //MoveTowards(NPC, target, (float)(distance > 300 ? 13f : 7f), 30f); //300 ? 13f : 7f), 30f);
                NPC.netUpdate = true;
            }
            else if ((double)NPC.ai[0] >= 450.0)
            {
                frame = 2;
                stunned = false;

                NPC.damage = (int)(200 * 0.3f);
                NPC.defense = 80;

                NPC.aiStyle = NPCAIStyleID.EyeOfCthulhu;

                NPC.life += 5;
                NPC.lifeMax += 10;

                NPC.immortal = false;

                SoundEngine.PlaySound(SoundID.Roar with
                {
                    MaxInstances = 1,
                    SoundLimitBehavior = SoundLimitBehavior.IgnoreNew
                });

                if (!fastSpeed)
                {
                    fastSpeed = true;
                }
                else
                {
                    if ((double)NPC.ai[0] % 50 == 0)
                    {
                        Vector2 position = NPC.Center;
                        Vector2 targetPosition = Main.player[NPC.target].Center;
                        Vector2 direction = targetPosition - position;
                        direction.Normalize();
                        int speed = 10; //speed of proj
                        int type = ModContent.ProjectileType < Content.Projectiles.NPCSProjectiles.BossProjectiles.EatersBite.EatersBite>();
                        int damage = NPC.damage;
                        Projectile.NewProjectile(null, position, direction * speed, type, damage, 0, Main.myPlayer);
                    }
                }
                NPC.netUpdate = true;
            }

            if ((double)NPC.ai[0] % (Main.expertMode ? 100 : 150) == 0 && !stunned && !fastSpeed)
            {
                attackTimer++;
                if (attackTimer <= 2)
                {
                    frame = 2;
                    Vector2 position = NPC.Center;                                                               //
                    Vector2 targetPosition = Main.player[NPC.target].Center;                                     //
                    Vector2 direction = targetPosition - position;                                               //
                    direction.Normalize();                                                                       //     What makes boss shoot projectiles (at player)
                    float speed = 10f;                                                                           // (when creating float speed =, the next time you need to use it on the npc you dont need to put float anymore, just speed =
                    int type = ProjectileID.DeathLaser;
                    int damage = NPC.damage;                                                                     //
                    Projectile.NewProjectile(null, position, direction * speed, type, damage, 0, Main.myPlayer); //
                }
                else
                {
                    attackTimer = 0;
                }
            }


            if ((double)NPC.ai[0] >= 650.0)
            {
                ai = 0;
                NPC.alpha = 0;
                fastSpeed = false;
            }
        }

        public override void FindFrame(int frameHeight)
        {
            if (frame == 0)
            {
                counting += 1.0;
                if (counting < 8.0)
                {
                    NPC.frame.Y = 0;
                }
                else if (counting < 16.0)
                {
                    NPC.frame.Y = frameHeight;
                }
                else if (counting < 24.0)
                {
                    NPC.frame.Y = frameHeight * 2;
                }
                else if (counting < 32.0)
                {
                    NPC.frame.Y = frameHeight * 3;
                }
                else
                {
                    counting = 0.0;
                }
            }
            else if (frame == 1)
            {
                NPC.frame.Y = frameHeight * 4;
            }
            else
            {
                NPC.frame.Y = frameHeight * 5;
            }
        }
        public void MoveTowards(NPC npc, Vector2 playerTarget, float speed, float turnResistance)
        {
            var move = playerTarget - npc.Center;
            float length = move.Length();
            if (length > speed)
            {
                move *= speed / length;
            }
            move = (npc.velocity * turnResistance + move) / (turnResistance + 1f);
            length = move.Length();
            if (length > speed)
            {
                move *= speed / length;
            }
            npc.velocity = move;
        }

        public override bool CanHitPlayer(Player target, ref int cooldownSlot)
        {
            cooldownSlot = ImmunityCooldownID.Bosses;
            return true;
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Content.Consumables.HeartOfDarkness.HeartOfDarkness>(), 1, 5, 20)); //modded item drop

            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CorrupterJrItem>(), 1, 1, 1)); //modded item drop

            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Content.Items.EssenceOfDeath.EssenceOfDeath>(), 1, 20, 40)); //modded item drop

            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Content.Weapons.ChainClassWeapons.Hardmode.ChainOfSecrets.ChainOfSecrets>(), 4, 1, 1)); // 1 in 4 chances of it dropping

            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Content.Items.RedChlorophyte.Ore.RedChlorophyteOreItem>(), 1, 400, 500)); //modded item drop
        }

        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.GreaterHealingPotion;
        }

        public override void OnKill()
        {
            if (Main.netMode == NetmodeID.Server)
            {
                NetMessage.SendData(MessageID.WorldData);
            }
        }
    }
}*/
