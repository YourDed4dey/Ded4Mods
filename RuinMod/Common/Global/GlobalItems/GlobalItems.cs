using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
//using RuinMod.Content.Classes.ChainClass;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.ModLoader.IO;
//using RuinMod.Content.Armor.GamerClassArmor.Hardmode.SansArmor;
using ReLogic.Content;
using UtfUnknown.Core.Probers.MultiByte.Chinese;
//using RuinMod.Common.Systems.DiffSystem;
using RuinMod.Content.Classes.ShieldClass;

namespace RuinMod.Common.Global.GlobalItems
{
    internal class GlobalItems :GlobalItem
    {
        public override void SetStaticDefaults()
        {

        }
        public override void SetDefaults(Item item)
        {
            /*if (item.DamageType == DamageClass.Melee)
            {
                item.autoReuse = true;
            }

            if (item.DamageType == DamageClass.Summon)
            {
                item.autoReuse = true;
            }

            if (item.DamageType == DamageClass.SummonMeleeSpeed)
            {
                item.autoReuse = true;
            }*/

            /*if (item.type == ItemID.BouncingShield)
            {
                item.DamageType = ModContent.GetInstance<Content.Classes.GamerClass.GamerClassDamage>();
                item.crit -= 4;
                item.autoReuse = true;
            }*/

            if (item.type == ItemID.EoCShield)
            {
                item.DamageType = ModContent.GetInstance<ShieldClassDamage>();
            }
            /*if (item.type == ItemID.DaedalusStormbow)
            {
                item.useAmmo = AmmoID.FallenStar;
                item.shoot = ProjectileID.SuperStar;
                item.shootSpeed += 5f;
                item.damage += 15;
            }*/

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            if (item.type == ItemID.SuspiciousLookingEye)
            {
                item.consumable = false;
                item.maxStack = 1;
            }


            if (item.type == ItemID.WormFood)
            {
                item.consumable = false;
                item.maxStack = 1;
            }


            if (item.type == ItemID.GoblinBattleStandard)
            {
                item.consumable = false;
                item.maxStack = 1;
            }


            if (item.type == ItemID.MechanicalEye)
            {
                item.consumable = false;
                item.maxStack = 1;
            }


            if (item.type == ItemID.MechanicalSkull)
            {
                item.consumable = false;
                item.maxStack = 1;
            }


            if (item.type == ItemID.MechanicalWorm)
            {
                item.consumable = false;
                item.maxStack = 1;
            }


            if (item.type == ItemID.SlimeCrown)
            {
                item.consumable = false;
                item.maxStack = 1;
            }


            if (item.type == ItemID.SnowGlobe)
            {
                item.consumable = false;
                item.maxStack = 1;
            }


            if (item.type == ItemID.Abeemination)
            {
                item.consumable = false;
                item.maxStack = 1;
            }


            if (item.type == ItemID.PirateMap)
            {
                item.consumable = false;
                item.maxStack = 1;
            }


            if (item.type == ItemID.BloodySpine)
            {
                item.consumable = false;
                item.maxStack = 1;
            }


            if (item.type == ItemID.PumpkinMoonMedallion)
            {
                item.consumable = false;
                item.maxStack = 1;
            }


            if (item.type == ItemID.NaughtyPresent)
            {
                item.consumable = false;
                item.maxStack = 1;
            }


            if (item.type == ItemID.SolarTablet)
            {
                item.consumable = false;
                item.maxStack = 1;
            }


            if (item.type == ItemID.CelestialSigil)
            {
                item.consumable = false;
                item.maxStack = 1;
            }


            if (item.type == ItemID.BloodMoonStarter)
            {
                item.consumable = false;
                item.maxStack = 1;
            }


            if (item.type == ItemID.QueenSlimeCrystal)
            {
                item.consumable = false;
                item.maxStack = 1;
            }


            if (item.type == ItemID.DeerThing)
            {
                item.consumable = false;
                item.maxStack = 1;
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            
        }

        public override void ModifyItemLoot(Item item, ItemLoot itemLoot)
        {
            if (item.type == ItemID.EyeOfCthulhuBossBag)
            {
                //itemLoot.Add(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<Content.Items.Drops.CoreOfTheForsaken.CoreOfTheEye.CoreOfTheEye>(), 100, 1, 1));
            }

            if(item.type == ItemID.QueenBeeBossBag)
            {
                //itemLoot.Add(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<Content.Weapons.GamerClassWeapons.PreHardmode.FortnaiScar.FortnaiScar>(), 4, 1, 1));
            }

            if (item.type == ItemID.TwinsBossBag)
            {
                itemLoot.Add(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<Content.Weapons.MagicWeapons.Hardmode.BookOfBreath.BookOfBreath>(), 4, 1, 1));

                itemLoot.Add(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<Content.Armor.Hardmode.Magic.SpectralArmor.SpectralHeadgear>(), 7, 1, 1));

                itemLoot.Add(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<Content.Armor.Hardmode.Magic.SpectralArmor.SpectralArmor>(), 7, 1, 1));

                itemLoot.Add(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<Content.Armor.Hardmode.Magic.SpectralArmor.SpectralSubligar>(), 7, 1, 1));
            }

            if (item.type == ItemID.SkeletronPrimeBossBag)
            {
                itemLoot.Add(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<Content.Weapons.RangeWeapons.Hardmode.PrimalSkullForce.PrimalSkullForce>(), 4, 1, 1));

                itemLoot.Add(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<Content.Items.Ammo.MiniSkull.MiniSkull>(), 1, 125, 150));

                itemLoot.Add(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<Content.Armor.Hardmode.Ranger.TitanArmor.TitanHelmet>(), 7, 1, 1));

                itemLoot.Add(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<Content.Armor.Hardmode.Ranger.TitanArmor.TitanMail>(), 7, 1, 1));

                itemLoot.Add(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<Content.Armor.Hardmode.Ranger.TitanArmor.TitanLeggings>(), 7, 1, 1));
            }

            if (item.type == ItemID.DestroyerBossBag)
            {
                itemLoot.Add(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<Content.Weapons.SummonerWeapons.Hardmode.ProbeWhip.ProbeWhip>(), 4, 1, 1));

                itemLoot.Add(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<Content.Armor.Hardmode.Summoner.EdgeArmor.EdgeHelmet>(), 7, 1, 1));

                itemLoot.Add(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<Content.Armor.Hardmode.Summoner.EdgeArmor.EdgeChestplate>(), 7, 1, 1));

                itemLoot.Add(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<Content.Armor.Hardmode.Summoner.EdgeArmor.EdgeLeggings>(), 7, 1, 1));
            }

            if (item.type == ItemID.PlanteraBossBag)
            {
                //itemLoot.Add(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<Content.Items.Drops.CoreOfTheForsaken.CoreOfTheFlower.CoreOfTheFlower>(), 100, 1, 1));
            }

            if (item.type == ItemID.GolemBossBag)
            {
                //itemLoot.Add(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<Content.Armor.Hardmode.Melee.DragonArmor.DragonHelmet>(), 7, 1, 1));
                //itemLoot.Add(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<Content.Armor.Hardmode.Melee.DragonArmor.DragonChestplate>(), 7, 1, 1));
                //itemLoot.Add(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<Content.Armor.Hardmode.Melee.DragonArmor.DragonLeggings>(), 7, 1, 1));
            }

            if (item.type == ItemID.FishronBossBag)
            {
                itemLoot.Add(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<Content.Weapons.RangeWeapons.Hardmode.Dukezooka.Dukezooka>(), 4, 1, 1));
            }

            if (item.type == ItemID.CultistBossBag)
            {
                //itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Content.Armor.Accesories.Hardmode.OrbOfPain.OrbOfPain>(), 4, 1, 1));

                //itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<SansHead>(), 7, 1, 1));
                //itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<SansBody>(), 7, 1, 1));
                //itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<SansLegs>(), 7, 1, 1));
            }

            if (item.type == ItemID.WallOfFleshBossBag)
            {
                //itemLoot.Add(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<Content.Armor.Accesories.GamerClassAccesories.Hardmode.GamingEmblem.GamingEmblem>(), 4, 1, 1));
                //itemLoot.Add(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<Content.Items.Drops.CoreOfTheForsaken.CoreOfTheWall.CoreOfTheWall>(), 100, 1, 1));
            }

            if (item.type == ItemID.MoonLordBossBag)
            {
                //itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Content.Weapons.GamerClassWeapons.Hardmode.DirtyBrotherKiller.DirtyBrotherKiller>(), 9, 1, 1));
                //itemLoot.Add(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<Content.Weapons.GamerClassWeapons.Hardmode.BarkBarkChain.BarkBarkChain>(), 9, 1, 1));
                //itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<SansHead>(), 11, 1, 1));
                //itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<SansBody>(), 11, 1, 1));
                //itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<SansLegs>(), 11, 1, 1));
            }
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (item.type == ItemID.SuspiciousLookingEye) tooltips.Add(new(Mod, "", "Not consumable"));

            if (item.type == ItemID.WormFood) tooltips.Add(new(Mod, "", "Not consumable"));

            if (item.type == ItemID.GoblinBattleStandard) tooltips.Add(new(Mod, "", "Not consumable"));

            if (item.type == ItemID.MechanicalEye) tooltips.Add(new(Mod, "", "Not consumable"));

            if (item.type == ItemID.MechanicalSkull) tooltips.Add(new(Mod, "", "Not consumable"));

            if (item.type == ItemID.MechanicalWorm) tooltips.Add(new(Mod, "", "Not consumable"));

            if (item.type == ItemID.SlimeCrown) tooltips.Add(new(Mod, "", "Not consumable"));

            if (item.type == ItemID.SnowGlobe) tooltips.Add(new(Mod, "", "Not consumable"));

            if (item.type == ItemID.Abeemination) tooltips.Add(new(Mod, "", "Not consumable"));

            if (item.type == ItemID.PirateMap) tooltips.Add(new(Mod, "", "Not consumable"));

            if (item.type == ItemID.BloodySpine) tooltips.Add(new(Mod, "", "Not consumable"));

            if (item.type == ItemID.PumpkinMoonMedallion) tooltips.Add(new(Mod, "", "Not consumable"));

            if (item.type == ItemID.NaughtyPresent) tooltips.Add(new(Mod, "", "Not consumable"));

            if (item.type == ItemID.SolarTablet) tooltips.Add(new(Mod, "", "Not consumable"));

            if (item.type == ItemID.CelestialSigil) tooltips.Add(new(Mod, "", "Not consumable"));

            if (item.type == ItemID.BloodMoonStarter) tooltips.Add(new(Mod, "", "Not consumable"));

            if (item.type == ItemID.QueenSlimeCrystal) tooltips.Add(new(Mod, "", "Not consumable"));

            if (item.type == ItemID.DeerThing) tooltips.Add(new(Mod, "", "Not consumable"));

            /*if (RuinWorld.devastated)
            {
                if (item.type == ItemID.DaedalusStormbow) tooltips.RemoveAll(x => x.Name == "Tooltip0" && x.Mod == "Terraria");

                if (item.type == ItemID.DaedalusStormbow) tooltips.Add(new(Mod, "", "Shoots stars from the sky\n[c/FFFF00:The Power of the stars has invaded this item!]"));
            }*/
        }

        /*public override bool Shoot(Item item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if(item.type == ItemID.Starfury)
            {

                int proj = Projectile.NewProjectile(source, Main.MouseWorld, velocity, ProjectileID.Starfury, damage, knockback, player.whoAmI);
                Main.projectile[proj].timeLeft = 1;

                float maxSpeed = 12f;
                float speed = 12f;
                Vector2 direction = Main.MouseWorld - Main.projectile[proj].Center;

                Main.projectile[proj].velocity = direction * speed;

                Main.projectile[proj].velocity = direction * speed;

                if (Main.projectile[proj].velocity.X > maxSpeed)
                    Main.projectile[proj].velocity.X = maxSpeed;
                else if (Main.projectile[proj].velocity.X < -maxSpeed)
                    Main.projectile[proj].velocity.X = -maxSpeed;
                if (Main.projectile[proj].velocity.Y > maxSpeed)
                    Main.projectile[proj].velocity.Y = maxSpeed;
                else if (Main.projectile[proj].velocity.Y < -maxSpeed)
                    Main.projectile[proj].velocity.Y = -maxSpeed;

                Main.projectile[proj].rotation += 0.1f * (float)Main.projectile[proj].direction;
                Main.projectile[proj].spriteDirection = Main.projectile[proj].direction;

                if (Main.projectile[proj].alpha > 70)
                {
                    Main.projectile[proj].alpha -= 15;
                    if (Main.projectile[proj].alpha < 70)
                    {
                        Main.projectile[proj].alpha = 70;
                    }
                }
                if (Main.projectile[proj].localAI[0] == 0f)
                {
                    AdjustMagnitude(ref Main.projectile[proj].velocity);
                    Main.projectile[proj].localAI[0] = 1f;
                }
                Vector2 move = Vector2.Zero;
                float distance = 400f;
                bool target = false;
                for (int k = 0; k < 200; k++)
                {
                    if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5)
                    {
                        Vector2 newMove = Main.npc[k].Center - Main.projectile[proj].Center;
                        float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
                        if (distanceTo < distance)
                        {
                            move = newMove;
                            distance = distanceTo;
                            target = true;
                        }
                    }
                }
                if (target)
                {
                    AdjustMagnitude(ref move);
                    Main.projectile[proj].velocity = (10 * Main.projectile[proj].velocity + move) / 11f;
                    AdjustMagnitude(ref Main.projectile[proj].velocity);
                }
            }
            if (item.type == ItemID.Meowmere)
            {
                int proj = Projectile.NewProjectile(source, Main.MouseWorld, velocity, ProjectileID.RainbowCrystalExplosion, damage, knockback, player.whoAmI);
                Main.projectile[proj].timeLeft = 1;

                float maxSpeed = 12f;
                float speed = 12f;
                Vector2 direction = Main.MouseWorld - Main.projectile[proj].Center;

                Main.projectile[proj].velocity = direction * speed;

                Main.projectile[proj].velocity = direction * speed;

                if (Main.projectile[proj].velocity.X > maxSpeed)
                    Main.projectile[proj].velocity.X = maxSpeed;
                else if (Main.projectile[proj].velocity.X < -maxSpeed)
                    Main.projectile[proj].velocity.X = -maxSpeed;
                if (Main.projectile[proj].velocity.Y > maxSpeed)
                    Main.projectile[proj].velocity.Y = maxSpeed;
                else if (Main.projectile[proj].velocity.Y < -maxSpeed)
                    Main.projectile[proj].velocity.Y = -maxSpeed;

                Main.projectile[proj].rotation += 0.1f * (float)Main.projectile[proj].direction;
                Main.projectile[proj].spriteDirection = Main.projectile[proj].direction;

                if (Main.projectile[proj].alpha > 70)
                {
                    Main.projectile[proj].alpha -= 15;
                    if (Main.projectile[proj].alpha < 70)
                    {
                        Main.projectile[proj].alpha = 70;
                    }
                }
                if (Main.projectile[proj].localAI[0] == 0f)
                {
                    AdjustMagnitude(ref Main.projectile[proj].velocity);
                    Main.projectile[proj].localAI[0] = 1f;
                }
                Vector2 move = Vector2.Zero;
                float distance = 400f;
                bool target = false;
                for (int k = 0; k < 200; k++)
                {
                    if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5)
                    {
                        Vector2 newMove = Main.npc[k].Center - Main.projectile[proj].Center;
                        float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
                        if (distanceTo < distance)
                        {
                            move = newMove;
                            distance = distanceTo;
                            target = true;
                        }
                    }
                }
                if (target)
                {
                    AdjustMagnitude(ref move);
                    Main.projectile[proj].velocity = (10 * Main.projectile[proj].velocity + move) / 11f;
                    AdjustMagnitude(ref Main.projectile[proj].velocity);
                }
            }
            return true;
        }
        private void AdjustMagnitude(ref Vector2 vector)
        {
            float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (magnitude > 6f)
            {
                vector *= 6f / magnitude;
            }
        }*/
    }
}
