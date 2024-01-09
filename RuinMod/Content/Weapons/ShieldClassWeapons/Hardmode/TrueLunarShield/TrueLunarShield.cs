using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using RuinMod.Content.Classes.ShieldClass;
using RuinMod.Content.Weapons.ShieldClassWeapons.Hardmode.TrueLunarShield;
using RuinMod.Content.Weapons.ShieldClassWeapons.PreHardmode.LunarShield;
//using RuinMod.Content.Items.Drops.EssencesOrSoulsOrFragments.Souls.SoulOfBlight;
using RuinMod.Content.Weapons.ShieldClassWeapons.Hardmode.TrueAegisShield;
using System.Collections.Generic;
using RuinMod.Common.Systems;
using RuinMod.Content.Potions.Debuffs.ShieldSickness;
using RuinMod.Content.Projectiles.ShieldClass.LavaShield;
using Microsoft.Xna.Framework;
using RuinMod.Common.Global.DevastatedDiff.Potions.Debuffs.Oiled;
using RuinMod.Content.Potions.Debuffs.BloodButchered;
using RuinMod.Content.Potions.Debuffs.Corrupted;

namespace RuinMod.Content.Weapons.ShieldClassWeapons.Hardmode.TrueLunarShield
{
    [AutoloadEquip(EquipType.Shield)]
    internal class TrueLunarShield : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("True Lunar Shield");
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
            float DashKeys = TrueLunarShieldDash.DashVelocity;
            int index = tooltips.FindIndex(tip => tip.Name.StartsWith("Tooltip"));
            if (index > -1)
            {
                tooltips.Insert(index, new(Mod, "KeybindTooltip", $"Corrupts, poisons, oils, burns\nand makes enemies bleed on hit\n'Lunatic memories'\nPress '{key}' to activate Special Ability\n[c/FFFF00:Special Ability: Shoots a Night's Edge sword]\nCurrent Dash= {DashKeys}\n9 defense\nAllows the player to dash into the enemy\nDouble tap a direction"));
            }
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<TrueLunarShieldDash>().DashAccessoryEquipped = true;
            player.statDefense += 9;

            if (player.whoAmI == Main.myPlayer)
            {
                if (RuinKeybinds.SpecialAbilityKeybind.JustPressed)
                {
                    Vector2 position = player.Center;
                    Vector2 targetPosition = Main.MouseWorld;
                    Vector2 direction = targetPosition - position;
                    direction.Normalize();
                    float speed = 12f;
                    float shieldDamage = player.GetCritChance<ShieldClassDamage>() += 1f;
                    float num = 28f * shieldDamage;

                    int type = Projectile.NewProjectile(null, position, direction * speed, ProjectileID.NightBeam, (int)(num), 0, Main.myPlayer);
                    Main.projectile[type].hostile = false;
                    Main.projectile[type].friendly = true;
                    Main.projectile[type].penetrate = 28;
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
                .AddIngredient(ItemType<LunarShield>(), 1)
                .AddIngredient(ItemID.SoulofMight, 5)
                .AddIngredient(ItemID.SoulofSight, 5)
                .AddIngredient(ItemID.SoulofFright, 5)
                //.AddIngredient(ItemType<SoulOfBlight>(), 5)
                .AddTile(TileID.MythrilAnvil) //.AddTile(TileID.DemonAltar)
                .Register();
        }
    }
}
