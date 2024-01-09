using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using RuinMod.Content.Classes.ShieldClass;
using RuinMod.Content.Weapons.ShieldClassWeapons.Hardmode.SpookyWoodShield;
using System.Collections.Generic;
using RuinMod.Common.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace RuinMod.Content.Weapons.ShieldClassWeapons.Hardmode.TerraShield
{
    [AutoloadEquip(EquipType.Shield)]
    internal class TerraShield : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Terra Shield");
            //Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            Item.width = 42;
            Item.height = 46;
            Item.accessory = true;
            Item.rare = ItemRarityID.Yellow;

            Item.damage = 70;
            Item.DamageType = GetInstance<ShieldClassDamage>();
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            var keys = RuinKeybinds.SpecialAbilityKeybind.GetAssignedKeys();
            string key = keys.Count == 0 ? "<NOT BOUND>" : keys[0];
            float DashKeys = TerraShieldDash.DashVelocity;
            int index = tooltips.FindIndex(tip => tip.Name.StartsWith("Tooltip"));
            if (index > -1)
            {
                tooltips.Insert(index, new(Mod, "KeybindTooltip", $"Corrupts, poisons, oils, burns, makes\nenemies bleed and god persecutes enemies on hit\nBecome immune after striking an enemy\nFaster regeneration\nLife steals 10 health per hit on enemies\nPress '{key}' to activate Special Ability\n[c/FFFF00:Special Ability: Shoots a Terra Blade sword]\nCurrent Dash= {DashKeys}\n10 defense\nAllows the player to dash into the enemy\nDouble tap a direction"));
            }
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<TerraShieldDash>().DashAccessoryEquipped = true;
            player.statDefense += 10;

            player.lifeRegen += 18;

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
                    float num = 70f * shieldDamage;

                    int type = Projectile.NewProjectile(null, position, direction * speed, ProjectileID.TerraBeam, (int)(num), 0, Main.myPlayer);
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
                .AddIngredient(ItemType<TrueLunarShield.TrueLunarShield>(), 1)
                .AddIngredient(ItemType<TrueAegisShield.TrueAegisShield>(), 1)
                .AddIngredient(ItemType<BrokenHeroShield.BrokenHeroShield>(), 1)
                .AddTile(TileID.MythrilAnvil) //.AddTile(TileID.DemonAltar)
                .Register();
        }
    }
}
