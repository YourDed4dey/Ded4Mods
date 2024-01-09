﻿using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using RuinMod.Content.Classes.ShieldClass;
using RuinMod.Common.Global.DevastatedDiff.Potions.Debuffs.Oiled;
using RuinMod.Content.Potions.Debuffs.BloodButchered;
using RuinMod.Content.Potions.Debuffs.Corrupted;
using RuinMod.Content.Potions.Debuffs.God_sPersecution;
using RuinMod.Content.Projectiles.ShieldClass.ShieldTimberFruits;
using Terraria.ID;

namespace RuinMod.Content.Weapons.ShieldClassWeapons.Endgame.ZenithShield
{
    public class ZenithShieldDash : ModPlayer
    {
        public const int DashDown = 0;
        public const int DashUp = 1;
        public const int DashRight = 2;
        public const int DashLeft = 3;

        public const int DashCooldown = 50;
        public const int DashDuration = 35;

        public const float DashVelocity = 30f; //5-9 is slow, 10-16 is medium,17-22 is fast, 23-30 is insanely fast, above that is TOO fast

        public int DashDir = -1;

        public bool DashAccessoryEquipped;
        public int DashDelay = 0;
        public int DashTimer = 0;

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
                        float num = 183f * shieldDamage;
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

                        if (Player.whoAmI == Main.myPlayer)
                        {
                            Vector2 position0 = Main.MouseWorld + new Vector2(Main.rand.Next(1, 21) + Main.rand.Next(1, 141));
                            Vector2 position1 = Main.MouseWorld + new Vector2(Main.rand.Next(21, 41) + Main.rand.Next(1, 141));
                            Vector2 position2 = Main.MouseWorld + new Vector2(Main.rand.Next(41, 61) + Main.rand.Next(1, 141));
                            Vector2 position3 = Main.MouseWorld + new Vector2(Main.rand.Next(61, 81) + Main.rand.Next(1, 141));
                            Vector2 position4 = Main.MouseWorld + new Vector2(Main.rand.Next(81, 101) + Main.rand.Next(1, 141));
                            Vector2 position5 = Main.MouseWorld + new Vector2(Main.rand.Next(101, 121) + Main.rand.Next(1, 141));
                            Vector2 position6 = Main.MouseWorld + new Vector2(Main.rand.Next(121, 141) + Main.rand.Next(1, 141));
                            Vector2 targetPosition0 = nPC.Center;
                            Vector2 direction0 = targetPosition0 - position0;
                            direction0.Normalize();
                            float speed0 = 2f;
                            float shieldDamage1 = Player.GetCritChance<ShieldClassDamage>() += 1f;
                            float num1 = 20f * shieldDamage1;

                            Projectile.NewProjectile(null, position0, direction0 * speed0, ModContent.ProjectileType<AppleProjectile>(), (int)(num1), 0, Main.myPlayer);
                            Projectile.NewProjectile(null, position1, direction0 * speed0, ModContent.ProjectileType<BananaProjectile>(), (int)(num1), 0, Main.myPlayer);
                            Projectile.NewProjectile(null, position2, direction0 * speed0, ModContent.ProjectileType<BlackcurrantProjectile>(), (int)(num1), 0, Main.myPlayer);
                            Projectile.NewProjectile(null, position3, direction0 * speed0, ModContent.ProjectileType<BloodOrangeProjectile>(), (int)(num1), 0, Main.myPlayer);
                            Projectile.NewProjectile(null, position4, direction0 * speed0, ModContent.ProjectileType<CherryProjectile>(), (int)(num1), 0, Main.myPlayer);
                            Projectile.NewProjectile(null, position5, direction0 * speed0, ModContent.ProjectileType<DragonFruitProjectile>(), (int)(num1), 0, Main.myPlayer);
                            Projectile.NewProjectile(null, position6, direction0 * speed0, ModContent.ProjectileType<PineappleProjectile>(), (int)(num1), 0, Main.myPlayer);
                        }
                        if (nPC.boss == true)
                        {

                        }
                        else
                        {
                            Player.statLife += 25;
                        }
                        nPC.AddBuff(type: ModContent.BuffType<God_sPersecution>(), time: 60 * 9);
                        nPC.AddBuff(BuffID.Poisoned, time: 60 * 5);
                        nPC.AddBuff(type: ModContent.BuffType<CorruptedDebuff>(), time: 60 * 5);
                        nPC.AddBuff(type: ModContent.BuffType<BloodButcheredDebuff>(), time: 60 * 5);
                        nPC.AddBuff(type: BuffID.OnFire, time: 60 * 5);
                        nPC.AddBuff(type: ModContent.BuffType<Oiled>(), time: 60 * 5);

                        Vector2 position = Player.Center;
                        Vector2 targetPosition = nPC.Center;
                        Vector2 direction = targetPosition - position;
                        direction.Normalize();
                        float speed = 10f;

                        const int NumProjectiles = 8;

                        for (int e = 0; e < NumProjectiles; e++)
                        {
                            Vector2 velocity = direction * speed;
                            Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(18));

                            newVelocity *= 1f - Main.rand.NextFloat(0.3f);

                            int type = Projectile.NewProjectile(null, position, newVelocity, ProjectileID.StarWrath, (int)(num), 0f, Player.whoAmI);
                        }
                        //nPC.AddBuff(ModContent.BuffType<BloodButcheredDebuff>(), time: 60 * 5); //This adds the buff to the npc when hitting an NPC
                    }
                }
                if ((!Player.controlLeft || !(Player.velocity.X < 0f)) && (!Player.controlRight || !(Player.velocity.X > 0f)))
                {
                    Player.velocity.X *= 0.95f;
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