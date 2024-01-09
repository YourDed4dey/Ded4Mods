using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using RuinMod.Content.Classes.ShieldClass;
using RuinMod.Content.Weapons.ShieldClassWeapons.Hardmode.AegisShield;
using RuinMod.Content.Weapons.ShieldClassWeapons.Hardmode.ChlorophyteShield;
using RuinMod.Content.Weapons.ShieldClassWeapons.Hardmode.AdamantiteShield;
using System.Collections.Generic;
using RuinMod.Common.Systems;
using Microsoft.Xna.Framework;
using RuinMod.Content.Potions.Debuffs.God_sPersecution;
using RuinMod.Common.Global.DevastatedDiff.Potions.Debuffs.Oiled;
using RuinMod.Content.Potions.Debuffs.BloodButchered;
using RuinMod.Content.Potions.Debuffs.Corrupted;

namespace RuinMod.Content.Weapons.ShieldClassWeapons.Hardmode.TrueAegisShield
{
    [AutoloadEquip(EquipType.Shield)]
    internal class TrueAegisShield : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("True Aegis Shield");
            //Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            Item.width = 42;
            Item.height = 46;
            Item.accessory = true;
            Item.rare = ItemRarityID.Yellow;

            Item.damage = 55;
            Item.DamageType = GetInstance<ShieldClassDamage>();
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            var keys = RuinKeybinds.SpecialAbilityKeybind.GetAssignedKeys();
            string key = keys.Count == 0 ? "<NOT BOUND>" : keys[0];
            float DashKeys = TrueAegisShieldDash.DashVelocity;
            int index = tooltips.FindIndex(tip => tip.Name.StartsWith("Tooltip"));
            if (index > -1)
            {
                tooltips.Insert(index, new(Mod, "KeybindTooltip", $"God persecutes enemies on hit\nBecome immune after striking an enemy\nFaster regeneration\nLife steals 10 health per hit on enemies\nPress '{key}' to activate Special Ability\n[c/FFFF00:Special Ability: Shoots a Excalibur sword]\nCurrent Dash= {DashKeys}\n9 defense\nAllows the player to dash into the enemy\nDouble tap a direction"));
            }
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<TrueAegisShieldDash>().DashAccessoryEquipped = true;
            player.statDefense += 9;

            player.lifeRegen += 15;

            if (player.whoAmI == Main.myPlayer)
            {
                if (RuinKeybinds.SpecialAbilityKeybind.JustPressed)
                {
                    Vector2 position = player.Center;
                    Vector2 targetPosition = Main.MouseWorld;
                    Vector2 direction = targetPosition - position;
                    direction.Normalize();
                    float speed = 16f;

                    float shieldDamage = player.GetCritChance<ShieldClassDamage>() += 1f;
                    float num = 55f * shieldDamage;

                    int type = Projectile.NewProjectile(null, position, direction * speed, ProjectileID.LightBeam, (int)(num), 0, Main.myPlayer);
                    Main.projectile[type].hostile = false;
                    Main.projectile[type].friendly = true;
                    Main.projectile[type].penetrate = 7;
                }
            }
            player.onHitDodge = true;
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
                .AddIngredient(ItemType<AegisShield.AegisShield>(), 1)
                .AddIngredient(ItemType<ChlorophyteShield.ChlorophyteShield>(), 1)
                .AddTile(TileID.MythrilAnvil) //.AddTile(TileID.DemonAltar)
                .Register();
        }
    }
}
