using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using RuinMod.Content.Classes.ShieldClass;
using RuinMod.Common.Systems;
using System.Collections.Generic;
using RuinMod.Content.Potions.Buffs.BlueDemon;
using RuinMod.Content.Potions.Debuffs.ShieldSickness;
using Microsoft.Xna.Framework;

namespace RuinMod.Content.Weapons.ShieldClassWeapons.Hardmode.InfluxShield
{
    [AutoloadEquip(EquipType.Shield)]
    internal class InfluxShield : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Influx Shield");
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
            float DashKeys = InfluxShieldDash.DashVelocity;
            int index = tooltips.FindIndex(tip => tip.Name.StartsWith("Tooltip"));
            if (index > -1)
            {
                tooltips.Insert(index, new(Mod, "KeybindTooltip", $"Press '{key}' to activate Special Ability\n[c/FFFF00:Special Ability: Shoots a Influx waver sword]\nCurrent Dash= {DashKeys}\n9 defense\nAllows the player to dash into the enemy\nDouble tap a direction"));
            }
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<InfluxShieldDash>().DashAccessoryEquipped = true;
            player.statDefense += 9;

            if (player.whoAmI == Main.myPlayer)
            {
                if (RuinKeybinds.SpecialAbilityKeybind.JustPressed)
                {
                    Vector2 position = player.Center;
                    Vector2 targetPosition = Main.MouseWorld;
                    Vector2 direction = targetPosition - position;
                    direction.Normalize();
                    float speed = 15f;

                    float shieldDamage = player.GetCritChance<ShieldClassDamage>() += 1f;
                    float num = 55f * shieldDamage;

                    int type = Projectile.NewProjectile(null, position, direction * speed, ProjectileID.InfluxWaver, (int)(num), 0, Main.myPlayer);
                    Main.projectile[type].hostile = false;
                    Main.projectile[type].friendly = true;
                    Main.projectile[type].penetrate = 6;
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
    }
}
