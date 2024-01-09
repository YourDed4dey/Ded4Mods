/*using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using RuinMod.Common.Systems;
using Terraria.ModLoader.Utilities;
using RuinMod.Content.Armor.VanityArmor.MechanicalBrainMask;
using System.Reflection;
using Mono.Cecil;
using RuinMod.Content.NPCS.Bosses.MechBrain;
using Microsoft.Xna.Framework.Audio;

namespace RuinMod.Content.NPCS.Bosses.F4Rn2E
{
    [AutoloadBossHead]
    internal class F4Rn2E : ModNPC
    {
        public static int secondStageHeadSlot = -1;
        public bool SecondStage
        {
            get => NPC.ai[0] == 1f;
            set => NPC.ai[0] = value ? 1f : 0f;
        }
        public Vector2 FirstStageDestination
        {
            get => new Vector2(NPC.ai[1], NPC.ai[2]);
            set
            {
                NPC.ai[1] = value.X;
                NPC.ai[2] = value.Y;
            }
        }
        public Vector2 LastFirstStageDestination { get; set; } = Vector2.Zero;

        private const int FirstStageTimerMax = 90;
        public ref float FirstStageTimer => ref NPC.localAI[1];
        public ref float Stage2HP => ref NPC.localAI[2];

        public ref float HandOfJudgmentTimer => ref NPC.localAI[2];

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
            //DisplayName.SetDefault("F4Rn2E");
            Main.npcFrameCount[Type] = 6;

            NPCID.Sets.MPAllowedEnemies[Type] = true;

            NPCID.Sets.BossBestiaryPriority.Add(Type);
        }

        public override void SetDefaults()
        {
            NPC.aiStyle = -1; //-1

            NPC.width = 84;
            NPC.height = 84;
            NPC.damage = 100;
            NPC.defense = 80;
            NPC.lifeMax = 80000;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0f;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.value = Item.buyPrice(gold: 25);
            NPC.SpawnWithHigherTime(30);
            NPC.boss = true;
            NPC.npcSlots = 10f;

            Music = MusicID.Boss5;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // Sets the description of this NPC that is listed in the bestiary
            bestiaryEntry.Info.AddRange(new List<IBestiaryInfoElement> {
                new MoonLordPortraitBackgroundProviderBestiaryInfoElement(), // Plain black background
				new FlavorTextBestiaryInfoElement("Death is the only escape, unless a hero leads the forsaken to him...")
            });
        }
        /*public override void ModifyNPCLoot(NPCLoot npcLoot)
        {

            LeadingConditionRule notExpertRule = new LeadingConditionRule(new Conditions.NotExpert());

            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.MechanicalBrainTrophy.MechanicalBrainTrophy>(), 10));

            notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<MechanicalBrainMask>(), 7));

            notExpertRule.OnSuccess(ItemDropRule.Common(ItemID.HallowedBar, 1, 15, 30));

            notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<Items.SoulOfBlight.SoulOfBlight>(), 1, 25, 40));

            notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<Weapons.GamerClassWeapons.Hardmode.ThePortalGun.ThePortalGun>(), 5, 1, 1));

            notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<Armor.GamerClassArmor.Hardmode.RickSanchezArmor.RickSanchezHead>(), 3, 1, 1));

            notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<Armor.GamerClassArmor.Hardmode.RickSanchezArmor.RickSanchezBody>(), 3, 1, 1));

            notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<Armor.GamerClassArmor.Hardmode.RickSanchezArmor.RickSanchezLegs>(), 3, 1, 1));

            npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<Items.MechanicalBrainBossBag.MechBrainBossBag>()));

            npcLoot.Add(ItemDropRule.MasterModeCommonDrop(ModContent.ItemType<Items.MechanicalBrainRelic.MechanicalBrainRelic>()));

            npcLoot.Add(ItemDropRule.MasterModeDropOnAllPlayers(ModContent.ItemType<Consumables.Pets.OcramsEye.EyeSpeculum>(), 4));

            npcLoot.Add(notExpertRule);
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldNight.Chance * 0.0f;
        }

        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.GreaterHealingPotion;
        }

        public override bool CanHitPlayer(Player target, ref int cooldownSlot)
        {
            cooldownSlot = ImmunityCooldownID.Bosses;
            return true;
        }
        public override void FindFrame(int frameHeight)
        {
            int startFrame = 0;
            int finalFrame = 2;

            if (SecondStage)
            {
                startFrame = 3;
                finalFrame = Main.npcFrameCount[NPC.type] - 1;

                if (NPC.frame.Y < startFrame * frameHeight)
                {
                    NPC.frame.Y = startFrame * frameHeight;
                }
            }

            int frameSpeed = 5;
            NPC.frameCounter += 0.5f;
            NPC.frameCounter += NPC.velocity.Length() / 10f;
            if (NPC.frameCounter > frameSpeed)
            {
                NPC.frameCounter = 0;
                NPC.frame.Y += frameHeight;

                if (NPC.frame.Y > finalFrame * frameHeight)
                {
                    NPC.frame.Y = startFrame * frameHeight;
                }
            }
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (Main.netMode == NetmodeID.Server)
            {
                return;
            }

            if (NPC.life <= 0) //xd
            {
                int backGoreType = Mod.Find<ModGore>("F4Rn2ESecondStage_Back").Type;
                int frontGoreType = Mod.Find<ModGore>("F4Rn2ESecondStage_Front").Type;

                var entitySource = NPC.GetSource_Death();

                for (int i = 0; i < 2; i++)
                {
                    Gore.NewGore(entitySource, NPC.position, new Vector2(Main.rand.Next(-6, 7), Main.rand.Next(-6, 7)), backGoreType);
                    Gore.NewGore(entitySource, NPC.position, new Vector2(Main.rand.Next(-6, 7), Main.rand.Next(-6, 7)), frontGoreType);
                }

                SoundEngine.PlaySound(SoundID.Roar, NPC.Center);
            }
        }
        public override void AI()
        {
            //NPC.rotation += 0.1f * (float)NPC.direction;
            NPC.spriteDirection = NPC.direction;

            if (Main.dayTime == false)
            {
                if (NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead || !Main.player[NPC.target].active)
                {
                    NPC.TargetClosest();
                }

                Player player = Main.player[NPC.target];

                if (player.dead)
                {
                    NPC.velocity.Y -= 0.04f;
                    NPC.EncourageDespawn(10);
                    return;
                }

                CheckSecondStage();

                if (SecondStage)
                {
                    DoSecondStage(player);
                }
                else
                {
                    DoFirstStage(player);
                }
            }
            else
            {
                NPC.aiStyle = NPCAIStyleID.EyeOfCthulhu;
            }
        }
        private void CheckSecondStage()
        {
            if (SecondStage)
            {
                return;
            }

            float MaxLife = 50284;

            if(NPC.life <= MaxLife && Main.netMode != NetmodeID.MultiplayerClient)
            {
                SecondStage = true;
                NPC.netUpdate = true;
                int backGoreType = Mod.Find<ModGore>("F4Rn2E_Back").Type;
                int frontGoreType = Mod.Find<ModGore>("F4Rn2E_Front").Type;

                var entitySource = NPC.GetSource_Death();

                for (int i = 0; i < 2; i++)
                {
                    Gore.NewGore(entitySource, NPC.position, new Vector2(Main.rand.Next(-6, 7), Main.rand.Next(-6, 7)), backGoreType);
                    Gore.NewGore(entitySource, NPC.position, new Vector2(Main.rand.Next(-6, 7), Main.rand.Next(-6, 7)), frontGoreType);
                }

                SoundEngine.PlaySound(SoundID.Roar, NPC.Center);
            }
        }
        private void DoFirstStage(Player player)
        {
            //NPC.rotation += 0.1f * (float)NPC.direction;
            NPC.spriteDirection = NPC.direction;

            FirstStageTimer++;
            if (FirstStageTimer > FirstStageTimerMax)
            {
                FirstStageTimer = 0;
            }

            float distance = 200;

            if (FirstStageTimer == 0)
            {
                Vector2 fromPlayer = NPC.Center - player.Center;

                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    float angle = fromPlayer.ToRotation();
                    float twelfth = MathHelper.Pi / 6;

                    angle += MathHelper.Pi + Main.rand.NextFloat(-twelfth, twelfth);
                    if (angle > MathHelper.TwoPi)
                    {
                        angle -= MathHelper.TwoPi;
                    }
                    else if (angle < 0)
                    {
                        angle += MathHelper.TwoPi;
                    }

                    Vector2 relativeDestination = angle.ToRotationVector2() * distance;

                    FirstStageDestination = player.Center; //+ relativeDestination;
                    NPC.netUpdate = true;
                }
            }
            Vector2 toDestination = FirstStageDestination - NPC.Center;
            Vector2 toDestinationNormalized = toDestination.SafeNormalize(Vector2.UnitY);
            float speed = Math.Min(distance, toDestination.Length());
            NPC.velocity = toDestinationNormalized * speed / 15; // /30

            if (FirstStageDestination != LastFirstStageDestination)
            {
                NPC.TargetClosest();

                if (Main.netMode != NetmodeID.Server)
                {
                    NPC.position += NPC.netOffset;
                    NPC.position -= NPC.netOffset;
                }
            }
            LastFirstStageDestination = FirstStageDestination;

            HeadLaser(player);

            NPC.damage = 65;
        }
        private void DoSecondStage(Player player)
        {
            //NPC.rotation += 0.1f * (float)NPC.direction;
            NPC.spriteDirection = NPC.direction;

            Vector2 toPlayer = player.Center - NPC.Center;

            float offsetX = 200f;

            Vector2 abovePlayer = player.Center + new Vector2(NPC.direction * offsetX, -NPC.height);

            Vector2 toAbovePlayer = abovePlayer - NPC.Center;
            Vector2 toAbovePlayerNormalized = toAbovePlayer.SafeNormalize(Vector2.UnitY);

            float changeDirOffset = offsetX * 0.7f;

            if (NPC.direction == -1 && NPC.Center.X - changeDirOffset < abovePlayer.X ||
                NPC.direction == 1 && NPC.Center.X + changeDirOffset > abovePlayer.X)
            {
                NPC.direction *= -1;
            }

            float speed = 22f; // 8f, 18 is good
            float inertia = 40f;

            if (NPC.Top.Y > player.Bottom.Y)
            {
                speed = 26f; // 12f, 22 is good
            }

            Vector2 moveTo = toAbovePlayerNormalized * speed;
            NPC.velocity = (NPC.velocity * (inertia - 1) + moveTo) / inertia;

            float MaxLife = 50284;
            if (NPC.life <= MaxLife     && Main.netMode != NetmodeID.MultiplayerClient)
            {
                HandOfJudgmentAttack(player);
            }

            NPC.damage = NPC.defDamage;

            NPC.alpha = 0;
        }
        private void HeadLaser(Player player)
        {
            float timerMax = Utils.Clamp((float)NPC.life / NPC.lifeMax, 0.35f, 1f) * 50; //, 0.13f, 1f) * 30;

            HandOfJudgmentTimer++;
            if (HandOfJudgmentTimer > timerMax)
            {
                HandOfJudgmentTimer = 0;
            }

            if (NPC.HasValidTarget && HandOfJudgmentTimer == 0 && Main.netMode != NetmodeID.MultiplayerClient)
            {
                Vector2 position = NPC.Center;
                Vector2 targetPosition = Main.player[NPC.target].Center;
                Vector2 direction = targetPosition - position;
                direction.Normalize();
                float speed = 10f;

                int type = ProjectileID.EyeBeam; //ProjectileID.SaucerLaser is good too
                Vector2 velocity = direction * speed;
                int damage = 55;

                const int NumProjectiles = 1;

                for (int i = 0; i < NumProjectiles; i++)
                {
                    Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(15));

                    newVelocity *= 1f - Main.rand.NextFloat(0.3f);

                    Projectile.NewProjectile(null, position, newVelocity, type, damage, 0, Main.myPlayer);
                }
            }
        }

        private void HandOfJudgmentAttack(Player player)
        {
            float timerMax = Utils.Clamp((float)NPC.life / NPC.lifeMax, 0.60f, 1f) * 80; //, 0.13f, 1f) * 30;

            HandOfJudgmentTimer++;
            if (HandOfJudgmentTimer > timerMax)
            {
                HandOfJudgmentTimer = 0;
            }

            if (NPC.HasValidTarget && HandOfJudgmentTimer == 0 && Main.netMode != NetmodeID.MultiplayerClient)
            {
                Vector2 position = NPC.Center;
                Vector2 targetPosition = Main.player[NPC.target].Center;
                Vector2 direction = targetPosition - position;
                direction.Normalize();
                float speed = 13f;

                //int type = ModContent.ProjectileType<Projectiles.NPCSProjectiles.BossProjectiles.HandOfJudgment.HandOfJudgment>();
                int type = ProjectileID.SaucerLaser;
                Vector2 velocity = direction * speed;
                int damage = 110;

                const int NumProjectiles = 1;

                for (int i = 0; i < NumProjectiles; i++)
                {
                    Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(15));

                    newVelocity *= 1f - Main.rand.NextFloat(0.3f);

                    int proj =Projectile.NewProjectile(null, position, newVelocity, type, damage, 0, Main.myPlayer);
                    Main.projectile[proj].tileCollide = false;
                    SoundEngine.PlaySound(SoundID.Item12);
                }
            }
        }
    }
}*/
