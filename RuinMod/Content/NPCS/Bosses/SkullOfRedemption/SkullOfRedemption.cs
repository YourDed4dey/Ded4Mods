/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using RuinMod.Assets.Textures.BossBars;
using RuinMod.Common.Systems;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using System;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.GameContent.Bestiary;
using RuinMod.Assets.Music;
using System.Collections.Generic;

namespace RuinMod.Content.NPCS.Bosses.SkullOfRedemption
{
    [AutoloadBossHead]
    internal class SkullOfRedemption : ModNPC
    {
        private int ai;
        private int attackTimer = 0;
        private bool fastSpeed = false;

        private bool stunned;
        private int stunnedTimer;

        private int frame = 3;
        private double counting;
        public int ParentIndex
        {
            get => (int)NPC.ai[0] - 1;
            set => NPC.ai[0] = value + 1;
        }

        public bool HasParent => ParentIndex > -1;
        public int PositionIndex
        {
            get => (int)NPC.ai[1] - 1;
            set => NPC.ai[1] = value + 1;
        }
        public bool SpawnedMinions
        {
            get => NPC.localAI[0] == 1f;
            set => NPC.localAI[0] = value ? 1f : 0f;
        }
        public static int MinionType()
        {
            return ModContent.NPCType<SkullOfRedemptionHand>();
        }
        public static int MinionCount()
        {
            int count = 2;

            if (Main.expertMode)
            {
                count += 1;
            }

            if (Main.getGoodWorld)
            {
                count += 1;
            }

            return count;
        }

        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Skull of Redemption");
            Main.npcFrameCount[NPC.type] = 6;

            var drawModifier = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            { // Influences how the NPC looks in the Bestiary
                CustomTexturePath = "RuinMod/Assets/Textures/NPCS/Bosses/SkullOfRedemption/TestBossBestiary",
                Position = new Vector2(1f, -8f),
                PortraitPositionXOverride = 0f,
                PortraitPositionYOverride = 0f

            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, drawModifier);
        }

        public override void SetDefaults()
        {
            NPC.width = 64;
            NPC.height = 64;

            NPC.boss = true;
            NPC.aiStyle = -1; //-1
            NPC.npcSlots = 1f;
            NPC.rotation = 0;

            NPC.lifeMax = 30000;
            NPC.damage = 150;
            NPC.defense = 80;
            NPC.knockBackResist = 0f;
            NPC.reflectsProjectiles = true;

            NPC.value = Item.buyPrice(gold: 15);

            NPC.lavaImmune = true;
            NPC.noTileCollide = true;
            NPC.noGravity = true;

            NPC.BossBar = ModContent.GetInstance<TestBossBossBar>();

            NPC.GetSource_FromAI();

            NPC.HitSound = SoundID.NPCHit4;
            NPC.DeathSound = SoundID.NPCDeath14;

            Music = MusicLoader.GetMusicSlot("RuinMod/Assets/Music/BossThemes/SORTheme/SORTheme");

            //SoundEngine.PlaySound(SORThemeSoundStyle);
            //SoundEngine.PlaySound(new SoundStyle("RuinMod/Assets/Music/BossThemes/SORTheme/SORTheme"));
            //Music = SoundEngine.PlaySound(SORThemeSoundStyle);
            //Music = SoundEngine.PlaySound(new SoundStyle("RuinMod/Assets/Music/BossThemes/SORTheme/SORTheme.ogg"));
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {

                new FlavorTextBestiaryInfoElement("'Skull ready to redeem your sins'")
            });
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * bossLifeScale);
            NPC.damage = (int)(NPC.damage * 1.3f);
        }

        public override void AI()
        {
            if(NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead || !Main.player[NPC.target].active) { 
                NPC.TargetClosest();
            }

            SpawnMinions();

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
                MoveTowards(NPC, target, (float)(distance > 300 ? 13f : 7f), 30f); //300 ? 13f : 7f), 30f);
                NPC.netUpdate = true;
            }
            else if ((double)NPC.ai[0] >= 300 && (double)NPC.ai[0] < 450.0)
            {
                stunned = false;//true
                frame = 1;
                NPC.defense = 120;
                NPC.damage = 100;
                NPC.reflectsProjectiles = false;
                MoveTowards(NPC, target, (float)(distance > 300 ? 13f : 7f), 30f); //300 ? 13f : 7f), 30f);
                NPC.netUpdate = true;
            }
            else if ((double)NPC.ai[0] >= 450.0)
            {
                frame = 2;
                stunned = false;
                NPC.damage = (int)(150 * 1.3f);
                NPC.defense = 80;
                SoundEngine.PlaySound(SoundID.Roar with
                {
                    MaxInstances = 1,
                    SoundLimitBehavior = SoundLimitBehavior.IgnoreNew
                });
                NPC.reflectsProjectiles = true;
                if (!fastSpeed)
                {
                    fastSpeed = true;
                }
                else
                {
                    if ((double)NPC.ai[0] % 50 == 0)
                    {
                        float speed = 0f; //12f
                        Vector2 vector = -new Vector2(NPC.position.X + (float)NPC.width * 0.5f, NPC.position.Y + (float)NPC.height * 0.5f);
                        float x = player.position.X + (float)(player.width / 2) - vector.X;
                        float y = player.position.Y + (float)(player.height / 2) - vector.Y;
                        float distance2 = (float)Math.Sqrt(x * x + y * y);
                        float factor = speed / distance2;
                        NPC.velocity.X = x * factor;
                        NPC.velocity.Y = y * factor;

                        Vector2 position = NPC.Center;
                        Vector2 targetPosition = Main.player[NPC.target].Center;
                        Vector2 direction = targetPosition - position;
                        direction.Normalize();
                        speed = 10f;
                        int type = ModContent.ProjectileType<Content.Projectiles.NPCSProjectiles.BossProjectiles.HauntingSkull.BossProjectile>();
                        SoundEngine.PlaySound(SoundID.Item100);
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
                    int type = ModContent.ProjectileType<Content.Projectiles.NPCSProjectiles.BossProjectiles.HauntingSkull.BossProjectile>();
                    SoundEngine.PlaySound(SoundID.Item100);
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
        private void SpawnMinions()
        {
            if (SpawnedMinions)
            {
                return;
            }

            SpawnedMinions = true;

            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                return;
            }

            int count = MinionCount();
            var entitySource = NPC.GetSource_FromAI();

            for (int i = 0; i < count; i++)
            {
                int index = NPC.NewNPC(entitySource, (int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType<SkullOfRedemptionHand>(), NPC.whoAmI);
                NPC minionNPC = Main.npc[index];

                if (minionNPC.ModNPC is SkullOfRedemptionHand minion)
                {
                    minion.ParentIndex = NPC.whoAmI;
                    minion.PositionIndex = i;
                }
                if (Main.netMode == NetmodeID.Server && index < Main.maxNPCs)
                {
                    NetMessage.SendData(MessageID.SyncNPC, number: index);
                }
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
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Content.Items.LostFragment.LostFragment>(), 1, 30, 50)); //modded item drop

            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Content.Items.EssenceOfDeath.EssenceOfDeath>(), 1, 15, 25)); //modded item drop

            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Content.Weapons.ProjectileWeapons.Hardmode.AbandonedScythe.AbandonedScythe>(), 4, 1, 1)); // 1 in 4 chances of it dropping

            npcLoot.Add(ItemDropRule.Common(ItemID.ChlorophyteBar, 1, 30,50));
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

