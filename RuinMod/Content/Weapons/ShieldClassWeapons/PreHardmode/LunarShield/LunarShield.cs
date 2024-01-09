using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using RuinMod.Content.Classes.ShieldClass;
using RuinMod.Common.Systems;
using System.Collections.Generic;
using RuinMod.Content.Potions.Debuffs.ShieldSickness;
using RuinMod.Content.Projectiles.ShieldClass.LavaShield;
using Microsoft.Xna.Framework;

namespace RuinMod.Content.Weapons.ShieldClassWeapons.PreHardmode.LunarShield
{
    [AutoloadEquip(EquipType.Shield)]
    internal class LunarShield : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Lunar Shield");
            //Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.width = 42;
            Item.height = 46;
            Item.accessory = true;
            Item.rare = ItemRarityID.Orange;

            Item.damage = 38;
            Item.DamageType = GetInstance<ShieldClassDamage>();
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            var keys = RuinKeybinds.SpecialAbilityKeybind.GetAssignedKeys();
            string key = keys.Count == 0 ? "<NOT BOUND>" : keys[0];
            float DashKeys = LunarShieldDash.DashVelocity;
            int index = tooltips.FindIndex(tip => tip.Name.StartsWith("Tooltip"));
            if (index > -1)
            {
                tooltips.Insert(index, new(Mod, "KeybindTooltip", $"Corrupts, poisons, oils, burns and makes enemies bleed on hit\n'The incarnation of evil!'\nPress '{key}' to activate Special Ability\n[c/FFFF00:Special Ability: Costs 30 mana and shoots Lava Shields towards the player's cursor]\nCurrent Dash= {DashKeys}\n7 defense\nAllows the player to dash into the enemy\nDouble tap a direction"));
            }
            //tooltips.Insert(index, new(Mod, "KeybindTooltip", $"Press '{RuinKeybinds.SpecialAbilityKeybind.GetAssignedKeys()}' to activate Special Ability"));
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<LunarShieldDash>().DashAccessoryEquipped = true;
            player.statDefense += 7;

            if (player.whoAmI == Main.myPlayer)
            {
                if (RuinKeybinds.SpecialAbilityKeybind.JustPressed)
                {
                    if (player.statMana >= 30)
                    {
                        for (int i = 0; i < 1; i++)
                        {
                            Vector2 position = player.Center;
                            Vector2 targetPosition = Main.MouseWorld;
                            Vector2 direction = targetPosition - position;
                            direction.Normalize();
                            float speed = 2.5f;
                            float shieldDamage = player.GetCritChance<ShieldClassDamage>() += 1f;
                            float num = 38f * shieldDamage;

                            int type = Projectile.NewProjectile(null, position, direction * speed, ModContent.ProjectileType<HellStoneShieldProjectile>(), (int)(num), 0, Main.myPlayer);
                            Main.projectile[type].hostile = false;
                            Main.projectile[type].friendly = true;

                            player.statMana -= 30;
                        }
                    }
                    else
                    {
                        player.AddBuff(ModContent.BuffType<Shield_Sickness>(), 60 * 10);
                    }
                }
            }
        }
        public override bool CanEquipAccessory(Player player, int slot, bool modded)
        {
            if (Item.shieldSlot > 0)
                return false;

            else
                return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemType<DemoniteShield.DemoniteShield>(), 1)
                .AddIngredient(ItemType<MagicShield.MagicShield>(), 1)
                .AddIngredient(ItemType<GrassShield.GrassShield>(), 1)
                .AddIngredient(ItemType<HellStoneShield.HellStoneShield>(), 1)
                .AddTile(TileID.DemonAltar)
                .Register();

            CreateRecipe()
                .AddIngredient(ItemType<CrimtaneShield.CrimtaneShield>(), 1)
                .AddIngredient(ItemType<MagicShield.MagicShield>(), 1)
                .AddIngredient(ItemType<GrassShield.GrassShield>(), 1)
                .AddIngredient(ItemType<HellStoneShield.HellStoneShield>(), 1)
                .AddTile(TileID.DemonAltar)
                .Register();
        }
    }
}
