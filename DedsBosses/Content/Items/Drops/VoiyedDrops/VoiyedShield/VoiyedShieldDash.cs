using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.Audio;

namespace DedsBosses.Content.Items.Drops.VoiyedDrops.VoiyedShield
{
    internal class VoiyedShieldDash : ModPlayer
    {
        public const int DashDown = 0;
        public const int DashUp = 1;
        public const int DashRight = 2;
        public const int DashLeft = 3;

        public const int DashCooldown = 50;
        public const int DashDuration = 35;

        public const float DashVelocity = 15f; //5-9 is slow, 10-16 is medium,17-22 is fast, 23-30 is insanely fast, above that is TOO fast

        public int DashDir = -1;

        public bool DashAccessoryEquipped;
        public int DashDelay = 0;
        public int DashTimer = 0;

        private int teleportTimer = 0;
        private int teleportCooldown = 1500; // Cooldown for teleportation attack, 1500 ticks = 25 seconds
        private int teleportDustTimer = 0;
        private const int teleportDustDuration = 180; // 3 seconds (60 ticks per second)
        private bool preparingTeleport = false;
        private Vector2 teleportPosition = Vector2.Zero;
        private float dashSpeed = 20f;

        // Add these fields for the dust trail
        private const int DustInterval = 4; // Adjust the interval as needed
        private int dustTimer = 0;

        public override void ResetEffects()
        {
            DashAccessoryEquipped = false;

            if (Player.controlDown && Player.releaseDown && Player.doubleTapCardinalTimer[DashDown] < 15)
            {
                DashDir = DashDown;
            }
            else if (Player.controlUp && Player.releaseUp && Player.doubleTapCardinalTimer[DashUp] < 15)
            {
                DashDir = DashUp;
            }
            else if (Player.controlRight && Player.releaseRight && Player.doubleTapCardinalTimer[DashRight] < 15)
            {
                DashDir = DashRight;
            }
            else if (Player.controlLeft && Player.releaseLeft && Player.doubleTapCardinalTimer[DashLeft] < 15)
            {
                DashDir = DashLeft;
            }
            else
            {
                DashDir = -1;
            }
        }

        public override void PreUpdateMovement()
        {
            if (CanUseDash() && DashDir != -1 && DashDelay == 0)
            {
                Vector2 newVelocity = Player.velocity;

                switch (DashDir)
                {
                    case DashUp when Player.velocity.Y > -DashVelocity:
                    case DashDown when Player.velocity.Y < DashVelocity:
                        {
                            float dashDirection = DashDir == DashDown ? 1 : -1.3f;
                            newVelocity.Y = dashDirection * DashVelocity;
                            break;
                        }
                    case DashLeft when Player.velocity.X > -DashVelocity:
                    case DashRight when Player.velocity.X < DashVelocity:
                        {
                            float dashDirection = DashDir == DashRight ? 1 : -1;
                            newVelocity.X = dashDirection * DashVelocity;
                            break;
                        }
                    default:
                        return;
                }

                DashDelay = DashCooldown;
                DashTimer = DashDuration;
                Player.velocity = newVelocity;

            }

            if (DashDelay > 0)
                DashDelay--;

            if (DashTimer > 0)
            {
                float shieldDamage = Player.GetCritChance<MeleeDamageClass>() += 1f;
                float shieldCrit = Player.GetCritChance<MeleeDamageClass>() += 4f;
                Player.eocDash = DashTimer;
                Player.armorEffectDrawShadowEOCShield = true;
                Rectangle rectangle = new Rectangle((int)(Player.position.X + Player.velocity.X * 0.5 - 4.0), (int)(Player.position.Y + Player.velocity.Y * 0.5 - 4.0), Player.width + 8, Player.height + 8);
                for (int i = 0; i < 200; i++)
                {
                    NPC nPC = Main.npc[i];
                    if (!nPC.active || nPC.dontTakeDamage || nPC.friendly || nPC.aiStyle == 112 && !(nPC.ai[2] <= 1f) || !Player.CanNPCBeHitByPlayerOrPlayerProjectile(nPC))
                    {
                        continue;
                    }
                    Rectangle rect = nPC.getRect();
                    if (rectangle.Intersects(rect) && (nPC.noTileCollide || Player.CanHit(nPC)))
                    {
                        float num = 50 * shieldDamage;
                        float num2 = 9f;
                        bool crit = false;
                        if (Player.kbGlove)
                        {
                            num2 *= 2f;
                        }
                        if (Player.kbBuff)
                        {
                            num2 *= 1.5f;
                        }
                        if (Main.rand.Next(100) < shieldCrit)
                        {
                            crit = true;
                        }
                        int num3 = Player.direction;
                        if (Player.velocity.X < 0f)
                        {
                            num3 = -1;//Going Left and hitting with something, player knockback 
                        }
                        if (Player.velocity.X > 0f)
                        {
                            num3 = 1; //Going Right and hitting with something. player knockback 
                        }
                        if (Player.whoAmI == Main.myPlayer)
                        {
                            Player.ApplyDamageToNPC(nPC, (int)num, num2, num3, crit); //The 29 here is the DPS (subtract 1 from the amount you want)
                        }
                        Player.eocDash = 10;
                        Player.dashDelay = 30;
                        Player.velocity.X = -num3 * 9;
                        Player.velocity.Y = -4f;
                        Player.GiveImmuneTimeForCollisionAttack(4);
                        Player.eocHit = i;

                        Vector2 position = Player.Center;
                        Vector2 targetPosition = nPC.Center;
                        Vector2 direction = targetPosition - position;
                        direction.Normalize();
                    }

                    // Check if teleportation attack is off cooldown
                    /*if (teleportTimer <= 0)
                    {
                        // Randomly select a position to teleport relative to the player
                        int teleportDirection = Main.rand.Next(4); // 0, 1, 2, or 3

                        switch (teleportDirection)
                        {
                            case 0: // Top left
                                teleportPosition = Main.MouseWorld;
                                break;
                            case 1: // Top right
                                teleportPosition = Main.MouseWorld;
                                break;
                            case 2: // Bottom left
                                teleportPosition = Main.MouseWorld;
                                break;
                            case 3: // Bottom right
                                teleportPosition = Main.MouseWorld;
                                break;
                        }

                        // Set the preparingTeleport flag to true and start the teleportation dust timer
                        preparingTeleport = true;
                        teleportDustTimer = teleportDustDuration;

                        // Set the teleportation cooldown
                        teleportTimer = teleportCooldown;
                    }
                    else
                    {
                        // If the teleportation attack is on cooldown, decrement the timer
                        teleportTimer--;
                    }

                    // Update the teleportation dust behavior
                    if (preparingTeleport)
                    {
                        // Dust will be shown for 3 seconds before the teleportation happens
                        if (teleportDustTimer <= 0)
                        {
                            // Teleport to the destination
                            Player.position = teleportPosition;

                            // Start dashing towards the player
                            Vector2 dashVelocity = nPC.Center - Player.Center;
                            dashVelocity.Normalize();
                            dashVelocity *= dashSpeed;
                            Player.velocity = dashVelocity;

                            // Remove the preparingTeleport flag
                            preparingTeleport = false;

                            SoundEngine.PlaySound(SoundID.Item6, Player.Center);
                        }
                        else
                        {
                            // Create the teleportation indicator dust
                            Dust.NewDust(teleportPosition, (int)Player.position.X, (int)Player.position.Y, DustID.PurpleTorch, Scale: 2f);

                            // Decrement the teleportation dust timer
                            teleportDustTimer--;
                        }
                    }*/
                }
                if ((!Player.controlLeft || !(Player.velocity.X < 0f)) && (!Player.controlRight || !(Player.velocity.X > 0f)))
                {
                    Player.velocity.X *= 0.95f;
                }
                // Check if the player is currently dashing
                if (DashTimer > 0)
                {
                    // ... Your existing code ...

                    // Spawn dust particles at regular intervals
                    if (dustTimer <= 0)
                    {
                        int dustType = DustID.RedTorch; // Change this to the desired dust type
                        Vector2 dustPosition = Player.Center - new Vector2(0, Player.height * .5f); // Adjust the position as needed
                        for (int i = 0; i < 20; i++)
                        {
                            Dust.NewDust(dustPosition, Player.width, Player.height, dustType, Scale: 2f);
                        }

                        // Reset the dust timer
                        dustTimer = DustInterval;
                    }
                    else
                    {
                        dustTimer--;
                    }
                }
                else
                {
                    dustTimer = 0; // Reset the dust timer when not dashing
                }


                DashTimer--;
            }
        }

        private bool CanUseDash()
        {
            return DashAccessoryEquipped
                && !Player.mount.Active;
        }
    }
}
