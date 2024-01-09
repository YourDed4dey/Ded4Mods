/*using Microsoft.Xna.Framework;
using System;
using System.Runtime.CompilerServices;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using RuinMod.Content.Projectiles.NPCSProjectiles.BossProjectiles.CrystalBolt;
using Terraria.Audio;

namespace RuinMod.Content.NPCS.Bosses.LeafBoss
{
    public class LeafBoss : ModNPC
    {
        bool phase2;
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Leaf Boss");
            Main.npcFrameCount[Type] = 4;
        }
        public override void SetDefaults() 
        {
            NPC.height = 46;
            NPC.width = 80;
            NPC.damage = 25;
            NPC.lifeMax = 1500;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.boss = true;
            NPC.knockBackResist = 0f;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.alpha = 255;
            NPC.aiStyle = -1;
            AIType = -1;
            NPC.npcSlots = 5f;
            if (Main.expertMode)
            {
                NPC.scale *= 1.3f;
            }
        }

        float State
        {
            get => NPC.ai[0];
            set => NPC.ai[0] = value;
        }

        float Timer
        {
            get => NPC.ai[1];
            set => NPC.ai[1] = value;
        }
        public override void AI()
        {
            float lifeRatio = NPC.life / (float)NPC.lifeMax;
            if (NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead || !Main.player[NPC.target].active)
            {
                NPC.TargetClosest();
            }

            Player player = Main.player[NPC.target];

            if (player.dead || !player.active)
            {
                Player p = Main.player[NPC.target];
                if (p.dead || !p.active)
                {
                    NPC.velocity.Y -= 0.06f;
                    NPC.EncourageDespawn(10);
                    CreateDusts();
                    return;
                }
            }
            if (lifeRatio < 0.5f && !phase2)
            {
                State = 3;
                Timer = 0;
                phase2 = true;
                NPC.netUpdate = true;
            }
            Timer++;
            NPC.TargetClosest();
            if (State == 0)
            {
                DoFadeIn();
                NPC.dontTakeDamage = true;
                if (Timer == 180)
                    State = 1;
            }
            else if (State == 1)
            {
                ChaseFaster();
                ProjectileAttack();
                NPC.dontTakeDamage = false;
                if (Timer == 360)
                {
                    Timer = 0;
                    State = 2f;
                }
            }
            else if (State == 2)
            {
                Chase();
                CircleProjectile();
                if (Timer == 180)
                {
                    State = 1;
                    Timer = 0;
                }
            }
            if (State == 3)
            {
                ChaseFaster();
                ProjectileAttackp2();
                if (Timer == 240)
                {
                    Timer = 0;
                    State = 4f;
                }
            }
            else if (State == 4)
            {
                CirclePlayer();
                CircleProjectile();
                if (Timer == 240)
                {
                    Timer = 0;
                    State = 3f;
                }
            }
        }

        private void ProjectileAttack()
        {
            if (Timer % 60 == 0 && Main.netMode != NetmodeID.MultiplayerClient)
            {
                SoundEngine.PlaySound(SoundID.Item73, position: NPC.Center);
                Vector2 center = NPC.Center;
                Vector2 vector2 = Main.player[NPC.target].Center - center;
                vector2.Normalize();
                float num4 = 14f;
                Vector2 spinninpoint = vector2 * num4;
                int Damage = 15;
                for (int index = 0; index < 3; ++index)
                {
                    Vector2 velocity = spinninpoint.RotatedByRandom(MathHelper.ToRadians(30f)) * (1f - Main.rand.NextFloat(0.3f));
                    if (Main.netMode != NetmodeID.MultiplayerClient)
                        Projectile.NewProjectile(NPC.GetSource_FromAI(), center, velocity, ModContent.ProjectileType<CrystalBoltProjectile>(), Damage, 0.0f, Main.myPlayer);
                }
            }
        }
        private void ProjectileAttackp2()
        {
            if (Timer % 50 == 0 && Main.netMode != NetmodeID.MultiplayerClient)
            {
                SoundEngine.PlaySound(SoundID.Item73, position: NPC.Center);
                Vector2 center = NPC.Center;
                Vector2 vector2 = Main.player[NPC.target].Center - center;
                vector2.Normalize();
                float num4 = 18f;
                Vector2 spinninpoint = vector2 * num4;
                int Damage = 15;
                for (int index = 0; index < 4; ++index)
                {
                    Vector2 velocity = spinninpoint.RotatedByRandom(MathHelper.ToRadians(30f)) * (1f - Main.rand.NextFloat(0.3f));
                    if (Main.netMode != NetmodeID.MultiplayerClient)
                        Projectile.NewProjectile(NPC.GetSource_FromAI(), center, velocity, ModContent.ProjectileType<CrystalBoltProjectile>(), Damage, 0.0f, Main.myPlayer);
                }
            }
        }
        private void Chase()
        {
            Player target = Main.player[NPC.target];
            Vector2 ToPlayer = NPC.DirectionTo(target.Center) * 3;
            NPC.velocity = ToPlayer;
        }
        private void ChaseFaster()
        {
            Player target = Main.player[NPC.target];
            Vector2 ToPlayer = NPC.DirectionTo(target.Center) * 5;
            NPC.velocity = ToPlayer;
        }
        private void CirclePlayer()
        {
            Player target = Main.player[NPC.target];
            NPC.velocity *= 0.9f;
            NPC.Center = NPC.Center.MoveTowards(target.Center - Vector2.UnitY.RotatedBy(NPC.ai[3]) * 540f, 30f);
            NPC.ai[3] += MathHelper.ToRadians(1.8f);
        }
        private void CircleProjectile()
        {
            if (Timer % 90 == 0 && Main.netMode != NetmodeID.MultiplayerClient)
            {
                SoundEngine.PlaySound(SoundID.Item84, position: NPC.Center);
                for (int i = 0; i < 360; i += 24)
                {
                    Player target = Main.player[NPC.target];
                    Vector2 ToPlayer = NPC.DirectionTo(target.Center).RotatedBy(MathHelper.ToRadians(i));//By default, rotation uses radians.  I prefer to use degrees, and therefore I convert the radians. 
                    if (Main.netMode != NetmodeID.MultiplayerClient)
                        Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center.X, NPC.Center.Y, ToPlayer.X * 3.5f, ToPlayer.Y * 3.5f, ModContent.ProjectileType<CrystalBoltProjectile>(), 15, 0f, Main.myPlayer);//fire the projectile
                }
            }
        }
        private void DoFadeIn()
        {
            if (NPC.alpha != 0)
            {
                NPC.alpha--;
                CreateDusts();
            }
        }
        private void CreateDusts()
        {
            for (int index = 0; index < 3; ++index)
            {
                Dust dust = Dust.NewDustDirect(new Vector2(NPC.position.X, NPC.position.Y + 4f), NPC.width, NPC.height, DustID.GreenTorch, Alpha: 100, Scale: 1.4f);
                dust.velocity *= 0.1f;
                dust.scale *= (float)(1.0 + Main.rand.Next(20) * 0.0099999997764825821);
                dust.noGravity = true;
                if (Main.rand.NextBool(2))
                    dust.fadeIn = 0.5f;
            }
        }
        public override void FindFrame(int frameHeight = 46)
        {

            NPC.frameCounter++;
            if (NPC.frameCounter == 10)
            {
                NPC.frame.Y += frameHeight;
            }
            else if (NPC.frameCounter == 20)
            {
                NPC.frame.Y += frameHeight;
            }
            else if (NPC.frameCounter == 30)
            {
                NPC.frame.Y += frameHeight;
            }
            else if (NPC.frameCounter == 40)
            {
                NPC.frameCounter = 0;
                NPC.frame.Y = 0;
            }
        }
    }
}*/