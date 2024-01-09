/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using RuinMod.Common.Systems;
using Terraria.ModLoader.Utilities;
using RuinMod.Content.Armor.VanityArmor.GemBossMask;
using System.Reflection;
using Mono.Cecil;
using RuinMod.Content.Weapons.ShieldClassWeapons.PreHardmode.ReinforcedGem;

namespace RuinMod.Content.NPCS.Bosses.GemBoss
{
    [AutoloadBossHead]
    public class GemBoss : ModNPC
    {
        public Vector2 FirstAttackDestination
        {
            get => new Vector2(NPC.ai[1], NPC.ai[2]);
            set
            {
                NPC.ai[1] = value.X;
                NPC.ai[2] = value.Y;
            }
        }
        public Vector2 AttackDestination { get; set; } = Vector2.Zero;

        private const int AttackTimerMax = 90;
        public ref float AttackTimer => ref NPC.localAI[1];
        public ref float AttackTimer_Lasers => ref NPC.localAI[3];
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Gemmonide");
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

            NPC.width = 56;
            NPC.height = 89;
            NPC.scale += 1f;

            NPC.damage = 35;
            NPC.defense = 15;

            NPC.lifeMax = 4500;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0f;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.value = Item.buyPrice(gold: 5);
            NPC.SpawnWithHigherTime(30);
            NPC.boss = true;
            NPC.npcSlots = 10f;

            //NPC.BossBar = ModContent.GetInstance<Assets.Textures.BossBars.RuinBossBar>();
            NPC.BossBar = null;

            Music = MusicID.Boss1;

            if (Main.getGoodWorld)
            {
                NPC.scale = 1f;
            }
            /*if (Main.expertMode)
            {

            }
            if (Main.masterMode)
            {

            }
            if (Main.GameMode == GameModeID.Normal)
            {

            }*/
        /*}
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // Sets the description of this NPC that is listed in the bestiary
            bestiaryEntry.Info.AddRange(new List<IBestiaryInfoElement> {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns,
                new FlavorTextBestiaryInfoElement("After seeing many of his fallen comrades be mined, he is in the mission to seek for revenge.")
            });
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {

            LeadingConditionRule notExpertRule = new LeadingConditionRule(new Conditions.NotExpert());

            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Drops.GemBossDrops.GemBossTrophy.GemBossTrophy>(), 10));

            notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<GemBossMask>(), 7));

            notExpertRule.OnSuccess(ItemDropRule.Common(ItemID.Amethyst, 7, 10, 15));

            notExpertRule.OnSuccess(ItemDropRule.Common(ItemID.Amber, 7, 10, 15));

            notExpertRule.OnSuccess(ItemDropRule.Common(ItemID.Sapphire, 7, 10, 15));

            notExpertRule.OnSuccess(ItemDropRule.Common(ItemID.Topaz, 7, 10, 15));

            notExpertRule.OnSuccess(ItemDropRule.Common(ItemID.Ruby, 7, 10, 15));

            notExpertRule.OnSuccess(ItemDropRule.Common(ItemID.Diamond, 7, 10, 15));

            notExpertRule.OnSuccess(ItemDropRule.Common(ItemID.Emerald, 7, 10, 15));

            //notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<ReinforcedGemShield>(), 4, 1, 1));

            npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<Items.Drops.GemBossDrops.GemBossBossBag.GemBossBossBag>()));

            npcLoot.Add(ItemDropRule.MasterModeCommonDrop(ModContent.ItemType<Items.Drops.GemBossDrops.GemBossRelic.GemBossRelic>()));

            npcLoot.Add(ItemDropRule.MasterModeDropOnAllPlayers(ModContent.ItemType<Consumables.Pets.GemBossPet.GemBossPetItem>(), 4));

            npcLoot.Add(notExpertRule);
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.Cavern.Chance * 0.0f;
        }
        public override void OnKill()
        {
            NPC.SetEventFlagCleared(ref DownedBossSystem.downedGemBoss, -1);
        }
        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.HealingPotion;
        }

        public override bool CanHitPlayer(Player target, ref int cooldownSlot) 
        {
            cooldownSlot = ImmunityCooldownID.Bosses;
            return true;
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

        public override void AI()
        {
            NPC.rotation += 0.1f * (float)NPC.direction;
            NPC.spriteDirection = NPC.direction;

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

            DoAttack(player);

            Vector2 vector14 = NPC.Center + NPC.velocity * 3f;
            if (Main.rand.NextBool(3))
            {
                int num30 = Dust.NewDust(vector14 - NPC.Size / 2f, NPC.width, NPC.height, DustID.Lava, NPC.velocity.X, NPC.velocity.Y, 100, default(Color), 2f);
                Main.dust[num30].noGravity = true;
                Main.dust[num30].position -= NPC.velocity;
            }
        }

        private void DoAttack(Player player)
        {
            NPC.rotation += 0.1f * (float)NPC.direction;
            NPC.spriteDirection = NPC.direction;

            AttackTimer++;
            if (AttackTimer > AttackTimerMax)
            {
                AttackTimer = 0;
            }

            float distance = 400;

            if (AttackTimer == 0)
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

                    FirstAttackDestination = player.Center + relativeDestination;
                    NPC.netUpdate = true;
                }
            }
            Vector2 toDestination = FirstAttackDestination - NPC.Center;
            Vector2 toDestinationNormalized = toDestination.SafeNormalize(Vector2.UnitY);
            float speed = Math.Min(distance, toDestination.Length());
            NPC.velocity = toDestinationNormalized * speed / 50;

            if (FirstAttackDestination != AttackDestination)
            {
                NPC.TargetClosest();

                if (Main.netMode != NetmodeID.Server)
                {
                    NPC.position += NPC.netOffset;
                    NPC.position -= NPC.netOffset;
                }
            }
            AttackDestination = FirstAttackDestination;

            NPC.damage = 35;

            NPC.rotation = NPC.velocity.ToRotation() - MathHelper.PiOver2;

            Attack_Lasers(player);

        }
        private void Attack_Lasers(Player player)
        {
            if (Main.masterMode)
            {
                float timerMax = Utils.Clamp((float)NPC.life / NPC.lifeMax, 0.45f, 1f) * 67; //, 0.13f, 1f) * 30;

                AttackTimer_Lasers++;
                if (AttackTimer_Lasers > timerMax)
                {
                    AttackTimer_Lasers = 0;
                }

                if (NPC.HasValidTarget && AttackTimer_Lasers == 0 && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    Vector2 position = NPC.Center;
                    Vector2 targetPosition = Main.player[NPC.target].Center;
                    Vector2 direction = targetPosition - position;
                    direction.Normalize();
                    float speed = 25f;

                    //int type = ProjectileID.InfernoHostileBlast;
                    int type = ProjectileID.InfernoHostileBolt;
                    Vector2 velocity = direction * speed;
                    int damage = 8;

                    const int NumProjectiles = 5;

                    for (int i = 0; i < NumProjectiles; i++)
                    {
                        Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(10));

                        newVelocity *= 1f - Main.rand.NextFloat(0.3f);

                        Projectile.NewProjectile(null, position, newVelocity, type, damage, 0, Main.myPlayer);
                    }
                }
            }
            else if (Main.expertMode || Main.getGoodWorld)
            {
                float timerMax = Utils.Clamp((float)NPC.life / NPC.lifeMax, 0.45f, 1f) * 67; //, 0.13f, 1f) * 30;

                AttackTimer_Lasers++;
                if (AttackTimer_Lasers > timerMax)
                {
                    AttackTimer_Lasers = 0;
                }

                if (NPC.HasValidTarget && AttackTimer_Lasers == 0 && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    Vector2 position = NPC.Center;
                    Vector2 targetPosition = Main.player[NPC.target].Center;
                    Vector2 direction = targetPosition - position;
                    direction.Normalize();
                    float speed = 25f;

                    //int type = ProjectileID.InfernoHostileBlast;
                    int type = ProjectileID.Fireball;
                    Vector2 velocity = direction * speed;
                    int damage = 8;

                    const int NumProjectiles = 5;

                    for (int i = 0; i < NumProjectiles; i++)
                    {
                        Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(30));

                        newVelocity *= 1f - Main.rand.NextFloat(0.3f);

                        Projectile.NewProjectile(null, position, newVelocity, type, damage, 0, Main.myPlayer);
                    }
                }
            }
            else
            {
                float timerMax = Utils.Clamp((float)NPC.life / NPC.lifeMax, 0.90f, 1f) * 135; //, 0.13f, 1f) * 30;

                AttackTimer_Lasers++;
                if (AttackTimer_Lasers > timerMax)
                {
                    AttackTimer_Lasers = 0;
                }

                if (NPC.HasValidTarget && AttackTimer_Lasers == 0 && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    Vector2 position = NPC.Center;
                    Vector2 targetPosition = Main.player[NPC.target].Center;
                    Vector2 direction = targetPosition - position;
                    direction.Normalize();
                    float speed = 20f;

                    int type = ProjectileID.Fireball;
                    Main.projectile[type].hostile = true;
                    Vector2 velocity = direction * speed;
                    int damage = 8;

                    const int NumProjectiles = 3;

                    for (int i = 0; i < NumProjectiles; i++)
                    {
                        Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(30));

                        newVelocity *= 1f - Main.rand.NextFloat(0.3f);

                        Projectile.NewProjectile(null, position, newVelocity, type, damage, 0, Main.myPlayer);
                    }
                }
            }

            /*private void Attack_Lasers(Player player)
            {
                float timerMax = Utils.Clamp((float)NPC.life / NPC.lifeMax, 0.90f, 1f) * 135; //, 0.13f, 1f) * 30;

                AttackTimer_Lasers++;
                if (AttackTimer_Lasers > timerMax)
                {
                    AttackTimer_Lasers = 0;
                }

                if (NPC.HasValidTarget && AttackTimer_Lasers == 0 && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    if (Main.getGoodWorld || Main.masterMode)
                    {
                        Vector2 position = NPC.Center;
                        Vector2 targetPosition = Main.player[NPC.target].Center;
                        Vector2 direction = targetPosition - position;
                        direction.Normalize();
                        float speed = 25f;

                        int type = ProjectileID.InfernoHostileBlast;
                        Vector2 velocity = direction * speed;
                        int damage = 35;

                        const int NumProjectiles = 3;

                        for (int i = 0; i < NumProjectiles; i++)
                        {
                            Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(10));

                            newVelocity *= 1f - Main.rand.NextFloat(0.3f);

                            Projectile.NewProjectile(null, position, newVelocity, type, damage, 0, Main.myPlayer);
                        }
                    }
                    else
                    {
                        Vector2 position = NPC.Center;
                        Vector2 targetPosition = Main.player[NPC.target].Center;
                        Vector2 direction = targetPosition - position;
                        direction.Normalize();
                        float speed = 20f;

                        int type = ProjectileID.Fireball;
                        Main.projectile[type].hostile = true;
                        Vector2 velocity = direction * speed;
                        int damage = 35;

                        Projectile.NewProjectile(null, position, velocity, type, damage, 0f, Main.myPlayer);
                    }
                }
            }*/
        /*}
    }
}*/
