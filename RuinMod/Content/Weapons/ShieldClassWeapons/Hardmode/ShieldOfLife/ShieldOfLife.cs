using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using RuinMod.Content.Classes.ShieldClass;
using RuinMod.Content.Weapons.ShieldClassWeapons.Hardmode.SeedShield;
using System.Collections.Generic;
using RuinMod.Common.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using RuinMod.Content.Projectiles.ShieldClass.Hearted;
using RuinMod.Content.Items.Drops.EssencesOrSoulsOrFragments.Fragments.FaithfulFragment;

namespace RuinMod.Content.Weapons.ShieldClassWeapons.Hardmode.ShieldOfLife
{
    [AutoloadEquip(EquipType.Shield)]
    internal class ShieldOfLife : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Shield Of Life");
            //Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 28;
            Item.accessory = true;
            Item.rare = ItemRarityID.Yellow;

            Item.damage = 92;
            Item.DamageType = GetInstance<ShieldClassDamage>();
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            var keys = RuinKeybinds.SpecialAbilityKeybind.GetAssignedKeys();
            string key = keys.Count == 0 ? "<NOT BOUND>" : keys[0];
            float DashKeys = ShieldOfLifeDash.DashVelocity;
            int index = tooltips.FindIndex(tip => tip.Name.StartsWith("Tooltip"));
            if (index > -1)
            {
                tooltips.Insert(index, new(Mod, "KeybindTooltip", $"Corrupts, poisons, oils, burns, makes\nenemies bleed and god persecutes enemies on hit\nFruits appear in your cursor when hitting an enemy\nBecome immune after striking an enemy\nFaster regeneration\nLife steals 20 health per hit on enemies\nPress '{key}' to activate Special Ability\n[c/FFFF00:Special Ability: Shoots a Hearted sword]\nCurrent Dash= {DashKeys}\n10 defense\nAllows the player to dash into the enemy\nDouble tap a direction"));
            }
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<ShieldOfLifeDash>().DashAccessoryEquipped = true;
            player.statDefense += 10;

            player.lifeRegen += 20;

            if (player.whoAmI == Main.myPlayer)
            {
                if (RuinKeybinds.SpecialAbilityKeybind.JustPressed)
                {
                    Vector2 position = player.Center;
                    Vector2 targetPosition = Main.MouseWorld;
                    Vector2 direction = targetPosition - position;
                    direction.Normalize();
                    float speed = 10f;

                    float shieldDamage = player.GetCritChance<ShieldClassDamage>() += 1f;
                    float num = 92f * shieldDamage;

                    int type = Projectile.NewProjectile(null, position, direction * speed, ProjectileType<HeartedProjectile>(), (int)(num), 0, Main.myPlayer);
                    Main.projectile[type].hostile = false;
                    Main.projectile[type].friendly = true;
                    Main.projectile[type].penetrate = 8;
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
                .AddIngredient(ItemType<TerraShield.TerraShield>(), 1)
                .AddIngredient(ItemType<ShieldOfTimber.ShieldOfTimber>(), 1)
                .AddIngredient(ItemType<FaithfulFragment>(), 15)
                .AddTile(TileID.LunarCraftingStation) //.AddTile(TileID.DemonAltar)
                .Register();
        }
    }
}
