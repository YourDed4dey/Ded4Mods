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
using Terraria.ModLoader.Utilities;
using System.Reflection;
using Mono.Cecil;
using System.IO;
using RuinMod.Content.NPCS.Bosses.MechBrain;
using RuinMod.Common.Systems;
using RuinMod.Content.Armor.VanityArmor.MechanicalBrainMask;
//using RuinMod.Common.Systems.DiffSystem;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace RuinMod.Content.NPCS.Bosses.MechBrain
{
    [AutoloadBossHead]
    public class MechBrain : ModNPC
    {
        public static int secondStageHeadSlot = -1;

        public int SecondStageAttack;
        public float SecondStageSpinTimer;
        public int SecondStageMainTimer;
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

        public bool SpawnedMinions
        {
            get => NPC.localAI[0] == 1f;
            set => NPC.localAI[0] = value ? 1f : 0f;
        }

        private const int FirstStageTimerMax = 90;
        public ref float FirstStageTimer => ref NPC.localAI[1];

        public ref float RemainingShields => ref NPC.localAI[2];

        public ref float SecondStageTimer_DemonSickle => ref NPC.localAI[3];

        public ref float SecondStageTimer_Lasers => ref NPC.localAI[2];

        public static int MinionType()
        {
            return ModContent.NPCType<ServantOfMechanicalBrain>();
        }

        public static int MinionCount()
        {
            int count = 60;

            if (Main.expertMode)
            {
                count += 15;
            }

            if (Main.getGoodWorld)
            {
                count += 15;
            }

            return count;
        }

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
            //DisplayName.SetDefault("Mechanical Brain");
            Main.npcFrameCount[Type] = 6;

            NPCID.Sets.MPAllowedEnemies[Type] = true;

            NPCID.Sets.BossBestiaryPriority.Add(Type);

            NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData
            {
                SpecificallyImmuneTo = new int[] {
                    BuffID.Poisoned,

                    BuffID.Confused
				}
            };
            NPCID.Sets.DebuffImmunitySets.Add(Type, debuffData);
        }

        public override void SetDefaults()
        {
            NPC.aiStyle = -1; //-1

            NPC.width = 178; //178 
            NPC.height = 140; //140 
            NPC.scale += .25f;

            NPC.damage = 65;
            NPC.defense = 20;
            NPC.lifeMax = 35000;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0f;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.value = Item.buyPrice(gold: 12);
            NPC.SpawnWithHigherTime(30);
            NPC.boss = true;
            NPC.npcSlots = 10f;

            //NPC.BossBar = ModContent.GetInstance<Assets.Textures.BossBars.RuinBossBar>();
            NPC.BossBar = null;

            Music = MusicID.Boss5;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // Sets the description of this NPC that is listed in the bestiary
            bestiaryEntry.Info.AddRange(new List<IBestiaryInfoElement> {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime,
                new FlavorTextBestiaryInfoElement("A mechanically recreated Brain of Cthulhu, which shoots and summons various types of entities. ")
            });
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {

            LeadingConditionRule notExpertRule = new LeadingConditionRule(new Conditions.NotExpert());

            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Drops.MechBrainDrops.MechanicalBrainTrophy.MechanicalBrainTrophy>(), 10));

            notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<MechanicalBrainMask>(), 7));

            notExpertRule.OnSuccess(ItemDropRule.Common(ItemID.HallowedBar, 1, 15, 30));

            notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<Items.Drops.EssencesOrSoulsOrFragments.Souls.SoulOfBlight.SoulOfBlight>(), 1, 25, 40));

            notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<Weapons.ShieldClassWeapons.Hardmode.HallowedShield.HallowedShield>(), 4, 1, 1));

            notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<Armor.ShieldClassArmor.Hardmode.ProtectorArmor.ProtectorHelmet>(), 7, 1, 1));

            notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<Armor.ShieldClassArmor.Hardmode.ProtectorArmor.ProtectorChestplate>(), 7, 1, 1));

            notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<Armor.ShieldClassArmor.Hardmode.ProtectorArmor.ProtectorLeggings>(), 7, 1, 1));

            npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<Items.Drops.MechBrainDrops.MechanicalBrainBossBag.MechBrainBossBag>()));

            npcLoot.Add(ItemDropRule.MasterModeCommonDrop(ModContent.ItemType<Items.Drops.MechBrainDrops.MechanicalBrainRelic.MechanicalBrainRelic>()));

            npcLoot.Add(ItemDropRule.MasterModeDropOnAllPlayers(ModContent.ItemType<Consumables.Pets.OcramsEye.EyeSpeculum>(), 4));

            npcLoot.Add(notExpertRule);
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldNight.Chance * 0.0f;
        }

        public override void OnKill()
        {
            NPC.SetEventFlagCleared(ref DownedBossSystem.downedMechBrain, -1);
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

            if (NPC.life <= 0)
            {
                int backGoreType = Mod.Find<ModGore>("MechBrain_Back").Type;
                int frontGoreType = Mod.Find<ModGore>("MechBrain_Front").Type;

                var entitySource = NPC.GetSource_Death();

                for (int i = 0; i < 2; i++)
                {
                    Gore.NewGore(entitySource, NPC.position, new Vector2(Main.rand.Next(-6, 7), Main.rand.Next(-6, 7)), backGoreType);
                    Gore.NewGore(entitySource, NPC.position, new Vector2(Main.rand.Next(-6, 7), Main.rand.Next(-6, 7)), frontGoreType);
                }

                SoundEngine.PlaySound(SoundID.Roar, NPC.Center);
            }
        }

        public override void SendExtraAI(BinaryWriter writer)
        {
            writer.Write(SecondStageAttack);
            writer.Write(SecondStageMainTimer);
            writer.Write(SecondStageSpinTimer);
        }

        public override void ReceiveExtraAI(BinaryReader reader)
        {
            SecondStageAttack = reader.ReadInt32();
            SecondStageMainTimer = reader.ReadInt32();
            SecondStageSpinTimer = reader.ReadInt32();
        }

        public override void AI()
        {
            //NPC.rotation += 0.1f * (float)NPC.direction;
            //NPC.spriteDirection = NPC.direction;

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

                SpawnMinions();

                CheckSecondStage();

                NPC.dontTakeDamage = !SecondStage;

                if (SecondStage)
                {
                    /*if (RuinWorld.devastated)
                    {
                        DoSecondStageDeva(player);
                    }
                    else*/
                    /*{
                        DoSecondStage(player);
                    }

                    Vector2 vector14 = NPC.Center + NPC.velocity * 3f;
                    if (Main.rand.NextBool(3))
                    {
                        int num30 = Dust.NewDust(vector14 - NPC.Size / 2f, NPC.width, NPC.height, DustID.CursedTorch, NPC.velocity.X, NPC.velocity.Y, 100, default(Color), 2f);
                        Main.dust[num30].noGravity = true;
                        Main.dust[num30].position -= NPC.velocity;
                    }
                }
                else
                {
                    DoFirstStage(player);
                    Vector2 vector14 = NPC.Center + NPC.velocity * 3f;
                    if (Main.rand.NextBool(3))
                    {
                        int num30 = Dust.NewDust(vector14 - NPC.Size / 2f, NPC.width, NPC.height, DustID.Lava, NPC.velocity.X, NPC.velocity.Y, 100, default(Color), 2f);
                        Main.dust[num30].noGravity = true;
                        Main.dust[num30].position -= NPC.velocity;
                    }
                }
            }
            else
            {
                NPC.aiStyle = 4;
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
                int index = NPC.NewNPC(entitySource, (int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType<ServantOfMechanicalBrain>(), NPC.whoAmI);
                NPC minionNPC = Main.npc[index];

                if (minionNPC.ModNPC is ServantOfMechanicalBrain minion)
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

        private void CheckSecondStage()
        {
            if (SecondStage)
            {
                return;
            }

            float remainingShieldsSum = 0f;
            for (int i = 0; i < Main.maxNPCs; i++)
            {
                NPC otherNPC = Main.npc[i];
                if (otherNPC.active && otherNPC.type == MinionType() && otherNPC.ModNPC is ServantOfMechanicalBrain minion)
                {
                    if (minion.ParentIndex == NPC.whoAmI)
                    {
                        remainingShieldsSum += (float)otherNPC.life / otherNPC.lifeMax;
                    }
                }
            }

            // We reference this in the MinionBossBossBar
            RemainingShields = remainingShieldsSum / MinionCount();

            if (RemainingShields <= 0 && Main.netMode != NetmodeID.MultiplayerClient)
            {
                SecondStage = true;
                NPC.netUpdate = true;
            }
        }

        private void DoFirstStage(Player player)
        {
            //NPC.rotation += 0.1f * (float)NPC.direction;
            //NPC.spriteDirection = NPC.direction;

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

                    FirstStageDestination = player.Center + relativeDestination;
                    NPC.netUpdate = true;
                }
            }
            Vector2 toDestination = FirstStageDestination - NPC.Center;
            Vector2 toDestinationNormalized = toDestination.SafeNormalize(Vector2.UnitY);
            float speed = Math.Min(distance, toDestination.Length());
            NPC.velocity = toDestinationNormalized * speed / 30;

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

            NPC.damage = 65;

            //NPC.rotation = NPC.velocity.ToRotation() - MathHelper.PiOver2;
        }
        private void DoSecondStage(Player player)
        {
            //NPC.rotation += 0.1f * (float)NPC.direction;
            //NPC.spriteDirection = NPC.direction;

            Vector2 toPlayer = player.Center - NPC.Center;

            float offsetX = 200f;

            Vector2 abovePlayer = player.Top + new Vector2(NPC.direction * offsetX, -NPC.height);

            Vector2 toAbovePlayer = abovePlayer - NPC.Center;
            Vector2 toAbovePlayerNormalized = toAbovePlayer.SafeNormalize(Vector2.UnitY);

            float changeDirOffset = offsetX * 0.7f;

            if (NPC.direction == -1 && NPC.Center.X - changeDirOffset < abovePlayer.X ||
                NPC.direction == 1 && NPC.Center.X + changeDirOffset > abovePlayer.X)
            {
                NPC.direction *= -1;
            }

            float speed = 8f;
            float inertia = 40f;

            if (NPC.Top.Y > player.Bottom.Y)
            {
                speed = 12f;
            }

            Vector2 moveTo = toAbovePlayerNormalized * speed;
            NPC.velocity = (NPC.velocity * (inertia - 1) + moveTo) / inertia;

            //DoSecondStage_DemonSickle(player);

            DoSecondStage_Lasers(player);

            Dash(player);

            NPC.damage = NPC.defDamage;

            NPC.alpha = 0;

            //NPC.rotation = toPlayer.ToRotation() - MathHelper.PiOver2;
        }
        private void DoSecondStage_Lasers(Player player)
        {
            float timerMax = Utils.Clamp((float)NPC.life / NPC.lifeMax, 0.90f, 1f) * 140; //, 0.13f, 1f) * 30;

            SecondStageTimer_Lasers++;
            if (SecondStageTimer_Lasers > timerMax)
            {
                SecondStageTimer_Lasers = 0;
            }

            if (NPC.HasValidTarget && SecondStageTimer_Lasers == 0 && Main.netMode != NetmodeID.MultiplayerClient)
            {
                Vector2 position = NPC.Center;
                Vector2 targetPosition = Main.player[NPC.target].Center;
                Vector2 direction = targetPosition - position;
                direction.Normalize();
                float speed = 10f;

                int type = ProjectileID.EyeLaser; //ProjectileID.EyeLaser;
                Vector2 velocity = direction * speed;
                int damage = 15;

                //Projectile.NewProjectile(null, position, direction * speed, type, damage, 0, Main.myPlayer);

                const int NumProjectilesEasy = 10;
                const int NumProjectilesHard = 25;
                //Vector2 velocity = type * position;
                if (Main.getGoodWorld || Main.expertMode || Main.masterMode)
                {
                    for (int i = 0; i < NumProjectilesHard; i++)
                    {
                        Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(15)); //15

                        newVelocity *= 1f - Main.rand.NextFloat(0.3f);

                        Projectile.NewProjectile(null, position, newVelocity, type, damage, 0, Main.myPlayer);
                    }
                }
                else
                {
                    for (int i = 0; i < NumProjectilesEasy; i++)
                    {
                        Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(5)); //15

                        newVelocity *= 1f - Main.rand.NextFloat(0.3f);

                        Projectile.NewProjectile(null, position, newVelocity, type, damage, 0, Main.myPlayer);
                    }
                }
            }
        }

        private void Dash(Player player)
        {
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

                    FirstStageDestination = player.Center + relativeDestination;
                    NPC.netUpdate = true;
                }
            }
            Vector2 toDestination = FirstStageDestination - NPC.Center;
            Vector2 toDestinationNormalized = toDestination.SafeNormalize(Vector2.UnitY);
            float speed = Math.Min(distance, toDestination.Length());
            NPC.velocity = toDestinationNormalized * speed / 30;

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

            NPC.damage = 65;

            //NPC.rotation = NPC.velocity.ToRotation() - MathHelper.PiOver2;
        }
        private void DoSecondStageDeva(Player player)
        {
            //NPC.rotation += 0.1f * (float)NPC.direction;
            //NPC.spriteDirection = NPC.direction;

            Vector2 toPlayer = player.Center - NPC.Center;

            float offsetX = 200f;

            Vector2 abovePlayer = player.Top + new Vector2(NPC.direction * offsetX, -NPC.height);

            Vector2 toAbovePlayer = abovePlayer - NPC.Center;
            Vector2 toAbovePlayerNormalized = toAbovePlayer.SafeNormalize(Vector2.UnitY);

            float changeDirOffset = offsetX * 0.7f;

            if (NPC.direction == -1 && NPC.Center.X - changeDirOffset < abovePlayer.X ||
                NPC.direction == 1 && NPC.Center.X + changeDirOffset > abovePlayer.X)
            {
                NPC.direction *= -1;
            }

            float speed = 8f;
            //float inertia = 40f;

            if (NPC.Top.Y > player.Bottom.Y)
            {
                speed = 12f;
            }

            Vector2 moveTo = toAbovePlayerNormalized * speed;
            //NPC.velocity = (NPC.velocity * (inertia - 1) + moveTo) / inertia;

            //DoSecondStage_DemonSickle(player);

            //DoSecondStage_Lasers(player);
            DoSecondStage_1(player);
            //Dash(player);

            NPC.damage = NPC.defDamage;

            NPC.alpha = 0;

            //NPC.rotation = toPlayer.ToRotation() - MathHelper.PiOver2;
        }
        /*private void DoSecondStage_DemonSickle(Player player)
		{
			// At 100% health, spawn every 90 ticks
			// Drops down until 33% health to spawn every 30 ticks
			float timerMax = Utils.Clamp((float)NPC.life / NPC.lifeMax, 0.40f, 1f) * 60;

            SecondStageTimer_DemonSickle++;
			if (SecondStageTimer_DemonSickle > timerMax)
			{
                SecondStageTimer_DemonSickle = 0;
			}

			if (NPC.HasValidTarget && SecondStageTimer_DemonSickle == 0 && Main.netMode != NetmodeID.MultiplayerClient)
			{
				// Spawn projectile randomly below player, based on horizontal velocity to make kiting harder, starting velocity 1f upwards
				// (The projectiles accelerate from their initial velocity)

				float kitingOffsetX = Utils.Clamp(player.velocity.X * 16, -100, 100);
				Vector2 position = player.Bottom + new Vector2(kitingOffsetX + Main.rand.Next(-100, 100), Main.rand.Next(50, 100));

				int type = ProjectileID.DemonSickle;
				//Main.projectile[type].hostile = true;
				//Main.projectile[type].friendly = false;
				int damage = 30; //180, 60 is expert (180 is insta death)
                var entitySource = NPC.GetSource_FromAI();

				Projectile.NewProjectile(entitySource, position, -Vector2.UnitY, type, damage, 0f, Main.myPlayer);

				if (Main.expertMode)
				{
                    Vector2 expertposition = player.Top + new Vector2(kitingOffsetX + Main.rand.Next(-100, 100), Main.rand.Next(50, 100));
                    Vector2 experttargetPosition = Main.player[NPC.target].Center;
                    Vector2 expertdirection = experttargetPosition - expertposition;
                    expertdirection.Normalize();
                    float expertspeed = 10f;

                    int experttype = Projectile.NewProjectile(null, expertposition, expertdirection * expertspeed, ProjectileID.DemonSickle, damage, 0, Main.myPlayer);
                    Main.projectile[experttype].hostile = true;
                    Main.projectile[experttype].friendly = false;
                    Main.projectile[experttype].tileCollide = false;
                }
                /*if (Main.getGoodWorld)
                {

                }*/
        /*}
    }*/
        /*private void DoSecondStage_1(Player player)
        {
            SecondStageMainTimer++;
            if (SecondStageMainTimer >= 240 && SecondStageAttack == 0)
            {
                SecondStageAttack = Main.rand.Next(0, 3);
                SecondStageMainTimer = 0;
                SecondStageSpinTimer = 0;
                NPC.netUpdate = true;
            }
            if (SecondStageMainTimer >= 90 && SecondStageAttack == 1)
            {
                SecondStageAttack = Main.rand.Next(0, 3);
                SecondStageMainTimer = 0;
                SecondStageSpinTimer = 0;
                NPC.netUpdate = true;
            }
            if (SecondStageMainTimer >= 180 && SecondStageAttack == 2)
            {
                SecondStageAttack = Main.rand.Next(0, 3);
                SecondStageMainTimer = 0;
                SecondStageSpinTimer = 0;
                NPC.netUpdate = true;
            }
            switch (SecondStageAttack)
            {
                case 0:
                    DoSecondStage_LasersDeva(player);
                    break;
                case 1:
                    DoSecondStage_SpinBulletHellDeva();
                    break;
                case 2:
                    DoSecondStage_ChaseAndShootDeva();
                    break;
            }
        }
        private void DoSecondStage_ChaseAndShootDeva()
        {
            Player target = Main.player[NPC.target];
            Vector2 ToPlayer = NPC.DirectionTo(target.Center) * 5;
            NPC.velocity = ToPlayer;
            if (SecondStageMainTimer % 60 == 0 && Main.netMode != NetmodeID.MultiplayerClient)
            {
                Vector2 center = NPC.Center;
                Vector2 vector2 = Main.player[NPC.target].Center - center;
                vector2.Normalize();
                float num4 = 18f;
                Vector2 spinninpoint = vector2 * num4;
                for (int index = 0; index < 4; ++index)
                {
                    Vector2 velocity = spinninpoint.RotatedByRandom(MathHelper.ToRadians(30f)) * (1f - Main.rand.NextFloat(0.3f));
                    Projectile.NewProjectile(NPC.GetSource_FromAI(), center, velocity, ProjectileID.DemonSickle, 30, 0.0f, Main.myPlayer);
                }
            }
        }
        private void DoSecondStage_SpinBulletHellDeva()
        {
            NPC.velocity = Vector2.Zero;
            for (int x = 0; x < 1000; x++)
            {
                if (Main.projectile[x].active && Main.projectile[x].type == 83)
                    Main.projectile[x].active = false;
            }
            if (SecondStageMainTimer % 45 == 0)
            {
                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    for (int i = 0; i < 32; i++)
                    {
                        Vector2 projVelocity = (MathHelper.TwoPi * i / 24f).ToRotationVector2() * 1.4f;
                        int j = Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center + projVelocity * 3.5f, projVelocity, ProjectileID.DemonScythe, 26, 0f, Main.myPlayer);
                        Main.projectile[j].timeLeft = 300;
                        Main.projectile[j].hostile = true;
                        Main.projectile[j].friendly = false;
                        Main.projectile[j].tileCollide = false;
                    }
                }
            }

        }
        private void DoSecondStage_LasersDeva(Player player)
        {
            NPC.TargetClosest();
            player = Main.player[NPC.target];
            CirclePlayerAndDashDeva(player, NPC);
            float timerMax = Utils.Clamp((float)NPC.life / NPC.lifeMax, 0.90f, 1f) * 140; //, 0.13f, 1f) * 30;

            SecondStageTimer_Lasers++;
            if (SecondStageTimer_Lasers > timerMax)
            {
                SecondStageTimer_Lasers = 0;
            }

            if (NPC.HasValidTarget && SecondStageTimer_Lasers == 0 && Main.netMode != NetmodeID.MultiplayerClient)
            {
                Vector2 position = NPC.Center;
                Vector2 targetPosition = Main.player[NPC.target].Center;
                Vector2 direction = targetPosition - position;
                direction.Normalize();
                float speed = 10f;

                int type = ProjectileID.EyeLaser; //ProjectileID.EyeLaser;
                Vector2 velocity = direction * speed;
                int damage = 15;

                //Projectile.NewProjectile(null, position, direction * speed, type, damage, 0, Main.myPlayer);

                const int NumProjectilesEasy = 10;
                const int NumProjectilesHard = 25;
                //Vector2 velocity = type * position;
                if (Main.getGoodWorld || Main.expertMode || Main.masterMode)
                {
                    for (int i = 0; i < NumProjectilesHard; i++)
                    {
                        Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(15)); //15

                        newVelocity *= 1f - Main.rand.NextFloat(0.3f);

                        int j = Projectile.NewProjectile(null, position, newVelocity, type, damage, 0, Main.myPlayer);
                        Main.projectile[j].tileCollide = false;
                    }
                }
                else
                {
                    for (int i = 0; i < NumProjectilesEasy; i++)
                    {
                        Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(5)); //15

                        newVelocity *= 1f - Main.rand.NextFloat(0.3f);

                        int j = Projectile.NewProjectile(null, position, newVelocity, type, damage, 0, Main.myPlayer);
                        Main.projectile[j].tileCollide = false;
                    }
                }
            }
        }

        private void DashDeva(Player player)
        {

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

                    FirstStageDestination = player.Center + relativeDestination;
                    NPC.netUpdate = true;
                }
            }
            Vector2 toDestination = FirstStageDestination - NPC.Center;
            Vector2 toDestinationNormalized = toDestination.SafeNormalize(Vector2.UnitY);
            float speed = Math.Min(distance, toDestination.Length());
            NPC.velocity = toDestinationNormalized * speed / 30;

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

            NPC.damage = 65;

            //NPC.rotation = NPC.velocity.ToRotation() - MathHelper.PiOver2;
        }

        /*private void Enraged(Player player)
		{

            if (Main.dayTime == true)
			{
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

                        FirstStageDestination = player.Center + relativeDestination;
                        NPC.netUpdate = true;
                    }
                }
                Vector2 toDestination = FirstStageDestination - NPC.Center;
                Vector2 toDestinationNormalized = toDestination.SafeNormalize(Vector2.UnitY);
                float speed = Math.Min(distance, toDestination.Length());
                NPC.velocity = toDestinationNormalized * speed / 30;

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

                NPC.damage = 65;

                NPC.rotation = NPC.velocity.ToRotation() - MathHelper.PiOver2;



                float timerMax = Utils.Clamp((float)NPC.life / NPC.lifeMax, 0.10f, 1f) * 10;

                SecondStageTimer_DemonSickle++;
                if (SecondStageTimer_DemonSickle > timerMax)
                {
                    SecondStageTimer_DemonSickle = 0;
                }

                if (NPC.HasValidTarget && SecondStageTimer_DemonSickle == 0 && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    // Spawn projectile randomly below player, based on horizontal velocity to make kiting harder, starting velocity 1f upwards
                    // (The projectiles accelerate from their initial velocity)

                    float kitingOffsetX = Utils.Clamp(player.velocity.X * 16, -100, 100);
                    Vector2 position = player.Bottom + new Vector2(kitingOffsetX + Main.rand.Next(-100, 100), Main.rand.Next(50, 100));

                    int type = ProjectileID.DemonSickle;
                    //Main.projectile[type].hostile = true;
                    //Main.projectile[type].friendly = false;
                    int damage = 5000; //180, 60 is expert (180 is insta death)
                    var entitySource = NPC.GetSource_FromAI();

                    Projectile.NewProjectile(entitySource, position, -Vector2.UnitY, type, damage, 0f, Main.myPlayer);
                }

                SecondStageTimer_Lasers++;
                if (SecondStageTimer_Lasers > timerMax)
                {
                    SecondStageTimer_Lasers = 0;
                }

                if (NPC.HasValidTarget && SecondStageTimer_Lasers == 0 && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    Vector2 position = NPC.Center;
                    Vector2 targetPosition = Main.player[NPC.target].Center;
                    Vector2 direction = targetPosition - position;
                    direction.Normalize();
                    speed = 10f;

                    int type = ProjectileID.EyeLaser;
                    //Main.projectile[type].hostile = true;
                    //Main.projectile[type].friendly = false;
                    int damage = 5000; //180, 60 is expert (180 is insta death)

                    Projectile.NewProjectile(null, position, direction * speed, type, damage, 0, Main.myPlayer);
                }
            }
        }*/
        /*private void CirclePlayerAndDashDeva(Player player, NPC npc)
        {
            NPC.TargetClosest();
            player = Main.player[NPC.target];
            if (SecondStageMainTimer < 200)
            {
                ref float spinOffsetAngle = ref SecondStageSpinTimer;
                npc.velocity *= 0.9f;
                npc.Center = npc.Center.MoveTowards(player.Center - Vector2.UnitY.RotatedBy(spinOffsetAngle) * 540f, 16f);
                spinOffsetAngle += MathHelper.ToRadians(1.8f);
            }
            else if (SecondStageMainTimer == 200)
            {
                npc.TargetClosest();
                player = Main.player[npc.target];
                npc.velocity = npc.DirectionTo(player.Center) * 26f;
            }
        }
        public void MoveTowardsDeva(NPC npc, Vector2 playerTarget, float speed, float turnResistance)
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

        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            NPC npc = NPC;
            SpriteEffects effects = SpriteEffects.None;
            //if (npc.spriteDirection == 1)
                effects = SpriteEffects.FlipHorizontally;
            float num5 = 0.0f;
            Vector2 origin = new Vector2(TextureAssets.Npc[npc.type].Value.Width / 2, TextureAssets.Npc[npc.type].Value.Height / Main.npcFrameCount[npc.type] / 2);
            Color c1 = npc.GetAlpha(drawColor);
            Color alpha = c1;
            float num6 = 0.99f;
            alpha.R = (byte)(alpha.R * (double)num6);
            alpha.G = (byte)(alpha.G * (double)num6);
            alpha.B = (byte)(alpha.B * (double)num6);
            alpha.A = 50;
            if (SecondStage)
            {
                /*if (RuinWorld.devastated)
                {
                    for (int index = 0; index < 4; ++index)
                    {
                        Vector2 position = npc.position;
                        float num7 = Math.Abs(npc.Center.X - Main.LocalPlayer.Center.X);
                        float num8 = Math.Abs(npc.Center.Y - Main.LocalPlayer.Center.Y);
                        position.X = index == 0 || index == 2 ? Main.LocalPlayer.Center.X + num7 : Main.LocalPlayer.Center.X - num7;
                        position.X -= npc.width / 2;
                        position.Y = index == 0 || index == 1 ? Main.LocalPlayer.Center.Y + num8 : Main.LocalPlayer.Center.Y - num8;
                        position.Y -= npc.height / 2;
                        Main.spriteBatch.Draw(TextureAssets.Npc[npc.type].Value, new Vector2((float)(position.X - (double)screenPos.X + npc.width / 2 - TextureAssets.Npc[npc.type].Value.Width * (double)npc.scale / 2.0 + origin.X * (double)npc.scale), (float)(position.Y - (double)screenPos.Y + npc.height - TextureAssets.Npc[npc.type].Value.Height * (double)npc.scale / Main.npcFrameCount[npc.type] + 4.0 + origin.Y * (double)npc.scale) + num5 + npc.gfxOffY), new Rectangle?(npc.frame), alpha, npc.rotation, origin, npc.scale, effects, 0.0f);
                    }
                }*/
                /*if(Main.GameMode == GameModeID.Normal)
                {
                    for (int index = 0; index < 1; ++index)
                    {
                        Vector2 position = npc.position;
                        float num7 = Math.Abs(npc.Center.X - Main.LocalPlayer.Center.X);
                        float num8 = Math.Abs(npc.Center.Y - Main.LocalPlayer.Center.Y);
                        position.X = index == 0 || index == 2 ? Main.LocalPlayer.Center.X + num7 : Main.LocalPlayer.Center.X - num7;
                        position.X -= npc.width / 2;
                        position.Y = index == 0 || index == 1 ? Main.LocalPlayer.Center.Y + num8 : Main.LocalPlayer.Center.Y - num8;
                        position.Y -= npc.height / 2;
                        Main.spriteBatch.Draw(TextureAssets.Npc[npc.type].Value, new Vector2((float)(position.X - (double)screenPos.X + npc.width / 2 - TextureAssets.Npc[npc.type].Value.Width * (double)npc.scale / 2.0 + origin.X * (double)npc.scale), (float)(position.Y - (double)screenPos.Y + npc.height - TextureAssets.Npc[npc.type].Value.Height * (double)npc.scale / Main.npcFrameCount[npc.type] + 1.0 + origin.Y * (double)npc.scale) + num5 + npc.gfxOffY), new Rectangle?(npc.frame), alpha, npc.rotation, origin, npc.scale, effects, 0.0f);
                    }
                }
                else if (Main.expertMode)
                {
                    for (int index = 0; index < 2; ++index)
                    {
                        Vector2 position = npc.position;
                        float num7 = Math.Abs(npc.Center.X - Main.LocalPlayer.Center.X);
                        float num8 = Math.Abs(npc.Center.Y - Main.LocalPlayer.Center.Y);
                        position.X = index == 0 || index == 2 ? Main.LocalPlayer.Center.X + num7 : Main.LocalPlayer.Center.X - num7;
                        position.X -= npc.width / 2;
                        position.Y = index == 0 || index == 1 ? Main.LocalPlayer.Center.Y + num8 : Main.LocalPlayer.Center.Y - num8;
                        position.Y -= npc.height / 2;
                        Main.spriteBatch.Draw(TextureAssets.Npc[npc.type].Value, new Vector2((float)(position.X - (double)screenPos.X + npc.width / 2 - TextureAssets.Npc[npc.type].Value.Width * (double)npc.scale / 2.0 + origin.X * (double)npc.scale), (float)(position.Y - (double)screenPos.Y + npc.height - TextureAssets.Npc[npc.type].Value.Height * (double)npc.scale / Main.npcFrameCount[npc.type] + 2.0 + origin.Y * (double)npc.scale) + num5 + npc.gfxOffY), new Rectangle?(npc.frame), alpha, npc.rotation, origin, npc.scale, effects, 0.0f);
                    }
                }
                else if (Main.masterMode)
                {
                    for (int index = 0; index < 3; ++index)
                    {
                        Vector2 position = npc.position;
                        float num7 = Math.Abs(npc.Center.X - Main.LocalPlayer.Center.X);
                        float num8 = Math.Abs(npc.Center.Y - Main.LocalPlayer.Center.Y);
                        position.X = index == 0 || index == 2 ? Main.LocalPlayer.Center.X + num7 : Main.LocalPlayer.Center.X - num7;
                        position.X -= npc.width / 2;
                        position.Y = index == 0 || index == 1 ? Main.LocalPlayer.Center.Y + num8 : Main.LocalPlayer.Center.Y - num8;
                        position.Y -= npc.height / 2;
                        Main.spriteBatch.Draw(TextureAssets.Npc[npc.type].Value, new Vector2((float)(position.X - (double)screenPos.X + npc.width / 2 - TextureAssets.Npc[npc.type].Value.Width * (double)npc.scale / 2.0 + origin.X * (double)npc.scale), (float)(position.Y - (double)screenPos.Y + npc.height - TextureAssets.Npc[npc.type].Value.Height * (double)npc.scale / Main.npcFrameCount[npc.type] + 3.0 + origin.Y * (double)npc.scale) + num5 + npc.gfxOffY), new Rectangle?(npc.frame), alpha, npc.rotation, origin, npc.scale, effects, 0.0f);
                    }
                }
                else if (Main.getGoodWorld)
                {
                    for (int index = 0; index < 3; ++index)
                    {
                        Vector2 position = npc.position;
                        float num7 = Math.Abs(npc.Center.X - Main.LocalPlayer.Center.X);
                        float num8 = Math.Abs(npc.Center.Y - Main.LocalPlayer.Center.Y);
                        position.X = index == 0 || index == 2 ? Main.LocalPlayer.Center.X + num7 : Main.LocalPlayer.Center.X - num7;
                        position.X -= npc.width / 2;
                        position.Y = index == 0 || index == 1 ? Main.LocalPlayer.Center.Y + num8 : Main.LocalPlayer.Center.Y - num8;
                        position.Y -= npc.height / 2;
                        Main.spriteBatch.Draw(TextureAssets.Npc[npc.type].Value, new Vector2((float)(position.X - (double)screenPos.X + npc.width / 2 - TextureAssets.Npc[npc.type].Value.Width * (double)npc.scale / 2.0 + origin.X * (double)npc.scale), (float)(position.Y - (double)screenPos.Y + npc.height - TextureAssets.Npc[npc.type].Value.Height * (double)npc.scale / Main.npcFrameCount[npc.type] + 3.0 + origin.Y * (double)npc.scale) + num5 + npc.gfxOffY), new Rectangle?(npc.frame), alpha, npc.rotation, origin, npc.scale, effects, 0.0f);
                    }
                }
            }
            return true;
        }
    }
}*/