/*using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.PlayerDrawLayer;
//using RuinMod.Content.Classes.GamerClass;
using RuinMod.Content.Potions.Debuffs.Corrupted;
using RuinMod.Content.Classes.ShieldClass;
using RuinMod.Content.Potions.Debuffs.BloodButchered;
using Terraria.ID;
using RuinMod.Content.Potions.Debuffs.Gemmoned;
//using RuinMod.Content.Armor.Accesories.PreHardmode.ReinforcedGem;

namespace RuinMod.Content.Weapons.ShieldClassWeapons.PreHardmode.ReinforcedGem
{
    public class ReinforcedGemShieldDash : ModPlayer
    {
        // These indicate what direction is what in the timer arrays used
        public const int DashDown = 0;
        public const int DashUp = 1;
        public const int DashRight = 2;
        public const int DashLeft = 3;

        public const int DashCooldown = 50; // Time (frames) between starting dashes. If this is shorter than DashDuration you can start a new dash before an old one has finished
        public const int DashDuration = 35; // Duration of the dash afterimage effect in frames

        // The initial velocity.  10 velocity is about 37.5 tiles/second or 50 mph
        public const float DashVelocity = 16f; //5-9 is slow, 10-16 is medium,17-22 is fast, 23-30 is insanely fast, above that is TOO fast

        // The direction the player has double tapped.  Defaults to -1 for no dash double tap
        public int DashDir = -1;

        // The fields related to the dash accessory
        public bool DashAccessoryEquipped;
        public int DashDelay = 0; // frames remaining till we can dash again
        public int DashTimer = 0; // frames remaining in the dash

        public override void ResetEffects()
        {
            // Reset our equipped flag. If the accessory is equipped somewhere, ExampleShield.UpdateAccessory will be called and set the flag before PreUpdateMovement
            DashAccessoryEquipped = false;

            // ResetEffects is called not long after player.doubleTapCardinalTimer's values have been set
            // When a directional key is pressed and released, vanilla starts a 15 tick (1/4 second) timer during which a second press activates a dash
            // If the timers are set to 15, then this is the first press just processed by the vanilla logic.  Otherwise, it's a double-tap
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

        // This is the perfect place to apply dash movement, it's after the vanilla movement code, and before the player's position is modified based on velocity.
        // If they double tapped this frame, they'll move fast this frame
        public override void PreUpdateMovement()
        {
            // if the player can use our dash, has double tapped in a direction, and our dash isn't currently on cooldown
            if (CanUseDash() && DashDir != -1 && DashDelay == 0)
            {
                Vector2 newVelocity = Player.velocity;

                switch (DashDir)
                {
                    // Only apply the dash velocity if our current speed in the wanted direction is less than DashVelocity
                    case DashUp when Player.velocity.Y > -DashVelocity:
                    case DashDown when Player.velocity.Y < DashVelocity:
                        {
                            // Y-velocity is set here
                            // If the direction requested was DashUp, then we adjust the velocity to make the dash appear "faster" due to gravity being immediately in effect
                            // This adjustment is roughly 1.3x the intended dash velocity
                            float dashDirection = DashDir == DashDown ? 1 : -1.3f;
                            newVelocity.Y = dashDirection * DashVelocity;
                            break;
                        }
                    case DashLeft when Player.velocity.X > -DashVelocity:
                    case DashRight when Player.velocity.X < DashVelocity:
                        {
                            // X-velocity is set here
                            float dashDirection = DashDir == DashRight ? 1 : -1;
                            newVelocity.X = dashDirection * DashVelocity;
                            break;
                        }
                    default:
                        return; // not moving fast enough, so don't start our dash
                }

                // start our dash
                DashDelay = DashCooldown;
                DashTimer = DashDuration;
                Player.velocity = newVelocity;

                // Here you'd be able to set an effect that happens when the dash first activates
                // Some examples include:  the larger smoke effect from the Master Ninja Gear and Tabi
            }

            if (DashDelay > 0)
                DashDelay--;

            if (DashTimer > 0)
            { // dash is active
              // This is where we set the afterimage effect.  You can replace these two lines with whatever you want to happen during the dash
              // Some examples include:  spawning dust where the player is, adding buffs, making the player immune, etc.
              // Here we take advantage of "player.eocDash" and "player.armorEffectDrawShadowEOCShield" to get the Shield of Cthulhu's afterimage effect
                float shieldDamage = Player.GetCritChance<ShieldClassDamage>() += 1f;
                float shieldCrit = Player.GetCritChance<ShieldClassDamage>() += 4f;
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
                        //float num = 30f * Player.GetCritChance<ShieldClassDamage>() + nPC.defense;
                        float num = 27f * shieldDamage;
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
                        nPC.AddBuff(ModContent.BuffType<GemmonedDebuff>(), time: 60 * 9); //This adds the buff to the npc when hitting an NPC
                    }
                }
                if ((!Player.controlLeft || !(Player.velocity.X < 0f)) && (!Player.controlRight || !(Player.velocity.X > 0f)))
                {
                    Player.velocity.X *= 0.95f;
                }

                // count down frames remaining
                DashTimer--;
            }
        }

        private bool CanUseDash()
        {
            return DashAccessoryEquipped
                && !Player.mount.Active; // player isn't mounted, since dashes on a mount look weird
        }
    }
}*/
