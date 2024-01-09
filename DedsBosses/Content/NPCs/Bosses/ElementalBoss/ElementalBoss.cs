using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using System;
using Terraria.Audio;
using Terraria.DataStructures;

namespace DedsBosses.Content.NPCs.Bosses.ElementalBoss
{
    [AutoloadBossHead]
    public class ElementalBoss : ModNPC
    {
        private int attackTimer = 0;
        private int attackDuration = 240; // Time each attack lasts

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 6;

            // Automatically group with other bosses
            NPCID.Sets.BossBestiaryPriority.Add(Type);
            // Add this in for bosses that have a summon item, requires corresponding code in the item
            NPCID.Sets.MPAllowedEnemies[Type] = true;

            NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Confused] = true;
            NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Poisoned] = true;
            NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.OnFire] = true;
            NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Bleeding] = true;
            NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.OnFire3] = true;
        }

        public override void SetDefaults()
        {
            NPC.lifeMax = 3000;
            NPC.damage = 50;
            NPC.defense = 10;
            NPC.knockBackResist = 0f;
            NPC.width = 90;
            NPC.height = 128;
            NPC.value = Item.buyPrice(0, 5, 0, 0);
            NPC.boss = true;
            NPC.aiStyle = -1;
            NPC.noTileCollide = true;
            NPC.noGravity = true;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            Music = MusicID.Boss1;
        }

        public override void AI()
        {
            Player player = Main.player[NPC.target];

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

            Vector2 targetPosition = player.Center - new Vector2(0, 200); // Adjust vertical offset

            float moveSpeed = 5f; // Adjust the boss's movement speed
            Vector2 moveDirection = Vector2.Normalize(targetPosition - NPC.Center);
            NPC.velocity = moveDirection * moveSpeed;

            attackTimer++;
            if (attackTimer <= attackDuration)
            {
                // Choose an attack based on a random number
                int attackType = Main.rand.Next(7); // 0 to 6

                switch (attackType)
                {
                    case 0:
                        InfernoBurst(player);
                        break;
                    case 1:
                        AquaSurge(player);
                        break;
                    case 2:
                        if (Main.expertMode)
                        {
                            Terraquake(player);
                        }
                        break;
                    case 3:
                        GaleforceWinds(player);
                        break;
                    case 4:
                        RadiantBeam(player);
                        break;
                    case 5:
                        ShadowsEmbrace(player);
                        break;
                    case 6:
                        PlasmaNova(player);
                        break;
                }
            }
            else
            {
                attackTimer = 0;
            }
            // Update the sprite animation
            AnimateSprite();
        }
        private void AnimateSprite()
        {
            // Animate the sprite frames based on attackTimer
            int frameSpeed = 8; // Adjust the frame speed as needed

            // Calculate the current frame
            int frame = (attackTimer / frameSpeed) % Main.npcFrameCount[NPC.type];

            // Set the frame based on the current frame
            NPC.frame.Y = frame * NPC.frame.Height;
        }

        private void InfernoBurst(Player player)
        {
            if (attackTimer % 30 == 0) // Fires every 30 ticks
            {
                Vector2 targetPosition = player.Center;
                Vector2 fireDirection = Vector2.Normalize(targetPosition - NPC.Center);
                fireDirection *= 10f; // Adjust the speed as needed

                int projectileType = ProjectileID.MolotovCocktail; // Change to the desired projectile type
                int damage = 50; // Adjust damage as needed

                int fireProj = Projectile.NewProjectile(null, NPC.Center, fireDirection, projectileType, damage, 0f, Main.myPlayer);
                Main.projectile[fireProj].hostile = true;
                Main.projectile[fireProj].friendly = false;
                Main.NewText("InfernoBurst");
            }
        }


        private void AquaSurge(Player player)
        {
            if (attackTimer % 60 == 0) // Fires every 60 ticks
            {
                Vector2 targetPosition = player.Center;
                Vector2 waterDirection = Vector2.Normalize(targetPosition - NPC.Center);
                waterDirection *= 8f; // Adjust the speed as needed

                int projectileType = ProjectileID.WaterStream; // Change to the desired projectile type
                int damage = 40; // Adjust damage as needed

                int waterProj = Projectile.NewProjectile(null,NPC.Center, waterDirection, projectileType, damage, 0f, Main.myPlayer);
                Main.projectile[waterProj].hostile = true;
                Main.projectile[waterProj].friendly = false;
                Main.NewText("AquaSurge");
            }
        }


        /*private void Terraquake(Player player)
        {
            if (attackTimer % 45 == 0) // Fires every 45 ticks
            {
                for (int i = 0; i < 8; i++)
                {
                    float angleOffset = MathHelper.TwoPi / i; // Angle between each meteor
                    float angle = angleOffset * i;
                    float playerY = Main.player[NPC.target].Center.Y;
                    Vector2 spawnPosition = new Vector2(Main.player[NPC.target].Center.X + Main.screenWidth / 2f * (float)Math.Cos(angle), playerY - Main.screenHeight + 500f);
                    Vector2 quakeDirection = Vector2.Normalize(player.Center - spawnPosition);
                    quakeDirection *= Main.rand.NextFloat(5f, 10f); // Adjust the speed range

                    int projectileType = ProjectileID.DirtBall; // Change to the desired projectile type
                    int damage = 60; // Adjust damage as needed

                    int dirtProj = Projectile.NewProjectile(null,spawnPosition, quakeDirection, projectileType, damage, 0f, Main.myPlayer);
                    Main.projectile[dirtProj].hostile = true;
                    Main.projectile[dirtProj].friendly = false;
                    Main.NewText("Terraquake");
                }
            }
        }*/

        private void Terraquake(Player player)
        {
            if (attackTimer % 45 == 0) // Fires every 45 ticks
            {
                for (int i = 0; i < 40; i++)
                {
                    // Number of rain to spawn
                    int dirtCount = Main.rand.Next(5, 15);

                    float angleOffset = MathHelper.TwoPi / dirtCount; // Angle between each rain drop
                                                                      // Calculate the angle for the current rain drop
                    float angle = angleOffset * i;

                    // Get the player's Y position
                    float playerY = Main.player[NPC.target].Center.Y;

                    // Calculate the spawn position above the player off the screen
                    Vector2 spawnPosition = new Vector2(Main.player[NPC.target].Center.X + Main.screenWidth / 2f * (float)Math.Cos(angle), playerY - Main.screenHeight + 500f);

                    Vector2 velocity = new Vector2(Main.rand.NextFloat(-3f, 3f), Main.rand.NextFloat(5f, 10f));

                    // Spawn the meteor projectile
                    int projectileIndex = Projectile.NewProjectile(null, spawnPosition, velocity, ProjectileID.DirtBall, 15, 0f, Main.myPlayer);
                    Main.projectile[projectileIndex].hostile = true;
                    Main.projectile[projectileIndex].friendly = false;
                }
                Main.NewText("Terraquake");
            }
        }


        private void GaleforceWinds(Player player)
        {
            if (attackTimer % 90 == 0) // Fires every 90 ticks
            {
                Vector2 windDirection = player.Center - NPC.Center;
                windDirection.Normalize();

                int projectileType = ProjectileID.Typhoon; // Change to the desired projectile type
                int damage = 30; // Adjust damage as needed

                int windProj = Projectile.NewProjectile(null,NPC.Center, windDirection * 10f, projectileType, damage, 0f, Main.myPlayer);
                Main.projectile[windProj].hostile = true;
                Main.projectile[windProj].friendly = false;
                Main.NewText("GaleforceWinds");
            }
        }


        private void RadiantBeam(Player player)
        {
            if (attackTimer % 90 == 0) // Fires every 90 ticks
            {
                Vector2 beamDirection = player.Center - NPC.Center;
                beamDirection.Normalize();

                int projectileType = ProjectileID.LaserMachinegunLaser; // Change to the desired projectile type
                int damage = 70; // Adjust damage as needed

                int beamProj = Projectile.NewProjectile(null,NPC.Center, beamDirection * 12f, projectileType, damage, 0f, Main.myPlayer);
                Main.projectile[beamProj].hostile = true;
                Main.projectile[beamProj].friendly = false;
                Main.NewText("RadiantBeam");
            }
        }


        private void ShadowsEmbrace(Player player)
        {
            if (attackTimer % 120 == 0) // Fires every 120 ticks
            {
                int darknessRadius = 300; // Adjust the area of effect radius
                int darknessDuration = 180; // Adjust the duration of darkness

                Vector2 darknessPosition = NPC.Center + new Vector2(Main.rand.Next(-darknessRadius, darknessRadius + 1), Main.rand.Next(-darknessRadius, darknessRadius + 1));
                Lighting.AddLight(darknessPosition, 0f, 0f, 0.3f); // Add darkness light

                for (int i = 0; i < Main.maxPlayers; i++)
                {
                    if (Main.player[i].active)
                    {
                        if (Vector2.Distance(Main.player[i].Center, darknessPosition) <= darknessRadius)
                        {
                            Main.player[i].AddBuff(BuffID.Darkness, darknessDuration);
                            Main.NewText("ShadowsEmbrace");
                        }
                    }
                }
            }
        }


        private void PlasmaNova(Player player)
        {
            if (attackTimer % 120 == 0) // Fires every 120 ticks
            {
                Vector2 novaDirection = Vector2.Normalize(player.Center - NPC.Center);
                novaDirection *= 8f; // Adjust the speed as needed

                int projectileType = ProjectileID.PinkLaser; // Change to the desired projectile type
                int damage = 60; // Adjust damage as needed

                int plasmaProj = Projectile.NewProjectile(null,NPC.Center, novaDirection, projectileType, damage, 0f, Main.myPlayer);
                Main.projectile[plasmaProj].hostile = true;
                Main.projectile[plasmaProj].friendly = false;
                Main.NewText("PlasmaNova");
            }
        }

    }
}
