using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Terraria.DataStructures;

namespace RuinTesting.Content.NPCs.Bosses.VoiyedBoss
{
    public class ServantOfTheVoiyed : ModNPC
    {
        private const int FrameWidth = 20;
        private const int FrameHeight = 32;
        private const int TotalFrames = 2;

        private int frame = 0;
        private int frameCounter = 0;
        private int frameSpeed = 8;

        private int dashTimer = 0;
        private int dashDuration = 30; // Dash duration in ticks
        private float dashSpeed = 10f; // Dash speed

        private int dashCount = 0;
        private int maxDashCount = 3; // Maximum number of dashes

        private int shootTimer = 0;
        private int shootDuration = 180; // Shoot duration in ticks
        private int shootCooldown = 60; // Shoot cooldown in ticks
        private int shootCount = 0;
        private int maxShootCount = 3; // Maximum number of shots to be fired during a dash

        private float projectileSpeed = 10f; // Placeholder value, adjust as needed
        private int projectileType = ProjectileID.EyeLaser; // Placeholder value, adjust as needed
        private int projectileDamage = 20; // Placeholder value, adjust as needed
        private float projectileKnockback = 2f; // Placeholder value, adjust as needed

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
            NPC.damage = 50;
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
                int frontGoreType = Mod.Find<ModGore>("ServantOfTheVoiyed_Front").Type;

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

            // Dash towards the player
            if (dashCount < maxDashCount)
            {
                dashTimer++;
                if (dashTimer <= dashDuration)
                {
                    NPC.velocity = Vector2.Normalize(summonToPlayer) * dashSpeed;
                }
                else
                {
                    NPC.velocity = Vector2.Zero;
                    dashTimer = 0;
                    dashCount++;
                }
            }
            else
            {
                // Shoot at the player when not dashing
                shootTimer++;
                if (shootTimer <= shootDuration)
                {
                    if (shootTimer % shootCooldown == 0)
                    {
                        Projectile.NewProjectile(null, NPC.Center, Vector2.Normalize(summonToPlayer) * projectileSpeed, projectileType, projectileDamage, projectileKnockback, Main.myPlayer);
                        for (int j = 0; j < 10; j++)
                        {
                            Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.PurpleTorch, Scale: 1f);
                        }
                    }
                }
                else
                {
                    shootTimer = 0;
                    dashCount = 0;
                }
            }
        }
    }
}
