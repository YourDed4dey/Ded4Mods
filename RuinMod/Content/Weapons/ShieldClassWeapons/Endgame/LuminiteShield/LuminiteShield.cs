using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using RuinMod.Content.Classes.ShieldClass;
using RuinMod.Common.Systems;
using RuinMod.Content.Weapons.ShieldClassWeapons.Hardmode.ShroomiteShield;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using RuinMod.Content.Projectiles.ShieldClass.LuminiteShield;

namespace RuinMod.Content.Weapons.ShieldClassWeapons.Endgame.LuminiteShield
{
    [AutoloadEquip(EquipType.Shield)]
    internal class LuminiteShield : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Luminite Shield");
            //Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            Item.width = 42;
            Item.height = 46;
            Item.accessory = true;
            Item.rare = ItemRarityID.Red;

            Item.damage = 88;
            Item.DamageType = GetInstance<ShieldClassDamage>();
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            var keys = RuinKeybinds.SpecialAbilityKeybind.GetAssignedKeys();
            string key = keys.Count == 0 ? "<NOT BOUND>" : keys[0];
            float DashKeys = LuminiteShieldDash.DashVelocity;
            int index = tooltips.FindIndex(tip => tip.Name.StartsWith("Tooltip"));
            if (index > -1)
            {
                tooltips.Insert(index, new(Mod, "KeybindTooltip", $"Press '{key}' to activate Special Ability\n[c/FFFF00:Special Ability: Shoots a Luminite Shield]\nCurrent Dash= {DashKeys}\n10 defense\nAllows the player to dash into the enemy\nDouble tap a direction"));
            }
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<LuminiteShieldDash>().DashAccessoryEquipped = true;
            player.statDefense += 10;

            if (player.whoAmI == Main.myPlayer)
            {
                if (RuinKeybinds.SpecialAbilityKeybind.JustPressed)
                {
                    Vector2 position = player.Center;
                    Vector2 targetPosition = Main.MouseWorld;
                    Vector2 direction = targetPosition - position;
                    direction.Normalize();
                    float speed = 22f;
                    float shieldDamage = player.GetCritChance<ShieldClassDamage>() += 1f;
                    float num = 88f * shieldDamage;

                    int type = Projectile.NewProjectile(null, position, direction * speed, ProjectileType<LuminiteShieldProjectile>(), (int)(num), 0, Main.myPlayer);
                    Main.projectile[type].hostile = false;
                    Main.projectile[type].friendly = true;
                    Main.projectile[type].penetrate = 2;
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
                .AddIngredient(ItemID.LunarBar, 15)
                .AddTile(TileID.LunarCraftingStation) //.AddTile(TileID.DemonAltar)
                .Register();
        }
    }
}
