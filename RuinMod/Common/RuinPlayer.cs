/*using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
//using RuinMod.Common.Global.DevastatedDiff.Consumables.DiffToggle;
using RuinMod.Common.Systems;
using Terraria.GameInput;
using RuinMod.Content.Weapons.ShieldClassWeapons.PreHardmode.ReinforcedGem;
using Terraria.ID;
//using RuinMod.Content.Potions.Buffs.SoulBuff;
using RuinMod.Content.Classes.ShieldClass;
using RuinMod.Content.Weapons.ShieldClassWeapons.Hardmode.HallowedShield;
using static Terraria.ModLoader.PlayerDrawLayer;
using RuinMod.Content.Potions.Buffs.BlueDemon;
//using System.Numerics;
using Microsoft.Xna.Framework;
using RuinMod.Content.Projectiles.ShieldClass.LavaShield;
using RuinMod.Content.Potions.Debuffs.ShieldSickness;
//using System.Drawing;
//using Microsoft.Xna.Framework;

namespace RuinMod.Common
{
    internal class RuinPlayer : ModPlayer
    {
        public static bool HellShield;
        public static bool HallowedShieldSpecial;
        public bool HolyBuffIsTrue;
        public static bool SpectreShieldSpecial;
        public bool DemonBuffIsTrue;
        public static bool LuminiteShieldSpecial;
        public static bool ZenithShieldSpecial;
        //int timer;
        /*public override IEnumerable<Item> AddStartingItems(bool mediumCoreDeath)
        {
            if (!mediumCoreDeath)
                yield return createItem(ModContent.ItemType<DevastatedDiff>());

            static Item createItem(int type)
            {
                Item obj = new Item();
                obj.SetDefaults(type);
                return obj;
            }
        }*/

        /*public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (RuinKeybinds.SpecialAbilityKeybind.JustPressed)
            {
                if (HellShield == true)
                {
                    if (Player.statMana > 30)
                    {
                        for (int i = 0; i < 1; i++)
                        {
                            NPC nPC = Main.npc[i];

                            Vector2 position = Player.Center;
                            Vector2 targetPosition = Main.MouseWorld;
                            Vector2 direction = targetPosition - position;
                            direction.Normalize();
                            float speed = 2.5f;

                            int damage = 26;

                            int type = Projectile.NewProjectile(null, position, direction * speed, ModContent.ProjectileType<HellStoneShieldProjectile>(), damage, 0, Main.myPlayer);
                            Main.projectile[type].hostile = false;
                            Main.projectile[type].friendly = true;

                            Player.statMana -= 30;
                        }
                    }
                    else
                    {
                        Player.AddBuff(ModContent.BuffType<Shield_Sickness>(), 60 * 10);
                    }
                }

                if (HallowedShieldSpecial == true)
                {

                }

                if (SpectreShieldSpecial == true)
                {
                    if (Player.statMana > 180)
                    {
                        if (DemonBuffIsTrue == false)
                        {
                            DemonBuffIsTrue = true;
                            Player.statMana -= 180;
                            Player.AddBuff(ModContent.BuffType<BlueDemonBuff>(), timeToAdd: 60 * 19);
                        }
                    }
                    else
                    {
                        Player.AddBuff(ModContent.BuffType<Shield_Sickness>(), 60 * 10);
                    }
                }

                if (LuminiteShieldSpecial == true)
                {

                }

                if (ZenithShieldSpecial == true)
                {

                }
            }
        }*/
        /*public override void OnHitAnything(float x, float y, Entity victim)
        {
            if (HallowedShieldSpecial == true)
            {
                if (HolyBuffIsTrue == false)
                {
                    Player.AddBuff(type: BuffID.ShadowDodge, timeToAdd: 60 * 16);
                    HolyBuffIsTrue = true;
                }
            }
        }

        public override void ResetEffects()
        {
            HellShield = false;
            HallowedShieldSpecial = false;
            SpectreShieldSpecial = false;
            LuminiteShieldSpecial = false;
            ZenithShieldSpecial = false;
        }

        /*public override void PostUpdateMiscEffects()
        {
            if (HolyBuffIsTrue == true)
            {
                //if (timer == 0)
                    //Player.AddBuff(type: BuffID.ShadowDodge, timeToAdd: 60 * 15);
                timer++;
                if (timer >= 60 * 45)
                {
                    timer = 0;
                    HolyBuffIsTrue = false;
                    Dust dust18 = Dust.NewDustDirect(new Microsoft.Xna.Framework.Vector2(Player.position.X - 2f, Player.position.Y - 2f), Player.width + 4, Player.height + 4, DustID.WhiteTorch, Player.velocity.X * 0.4f, Player.velocity.Y * 0.4f, 100, default(Color), 3.5f);
                    dust18.noGravity = true;
                    dust18.velocity.X = 1.8f;
                    dust18.velocity.Y -= 0.5f;
                }
            }

            if (DemonBuffIsTrue == true)
            {
                timer++;
                if (timer >= 60 * 60)
                {
                    timer = 0;
                    DemonBuffIsTrue = false;
                    Dust dust18 = Dust.NewDustDirect(new Microsoft.Xna.Framework.Vector2(Player.position.X - 2f, Player.position.Y - 2f), Player.width + 4, Player.height + 4, DustID.WhiteTorch, Player.velocity.X * 0.4f, Player.velocity.Y * 0.4f, 100, default(Color), 3.5f);
                    dust18.noGravity = true;
                    dust18.velocity.X = 1.8f;
                    dust18.velocity.Y -= 0.5f;
                }
            }
        }
    }
}*/