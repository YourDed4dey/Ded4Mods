using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using RuinMod.Content.Classes.ShieldClass;
using RuinMod.Content.Weapons.ShieldClassWeapons.Endgame.LuminiteShield;
using System.Collections.Generic;
using RuinMod.Common.Systems;
using RuinMod.Content.Projectiles.ShieldClass.LuminiteShield;
using Microsoft.Xna.Framework;
using System;

namespace RuinMod.Content.Weapons.ShieldClassWeapons.Endgame.MeowShield
{
    [AutoloadEquip(EquipType.Shield)]
    internal class MeowShield : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Meow Shield");
            //Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            Item.width = 42;
            Item.height = 46;
            Item.accessory = true;
            Item.rare = ItemRarityID.Red;

            Item.damage = 110;
            Item.DamageType = GetInstance<ShieldClassDamage>();
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            var keys = RuinKeybinds.SpecialAbilityKeybind.GetAssignedKeys();
            string key = keys.Count == 0 ? "<NOT BOUND>" : keys[0];
            float DashKeys = MeowShieldDash.DashVelocity;
            int index = tooltips.FindIndex(tip => tip.Name.StartsWith("Tooltip"));
            if (index > -1)
            {
                tooltips.Insert(index, new(Mod, "KeybindTooltip", $"Press '{key}' to activate Special Ability\n[c/FFFF00:Special Ability: Shoots Cats]\nCurrent Dash= {DashKeys}\n10 defense\nAllows the player to dash into the enemy\nDouble tap a direction"));
            }
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<MeowShieldDash>().DashAccessoryEquipped = true;
            player.statDefense += 10;

            if (player.whoAmI == Main.myPlayer)
            {
                if (RuinKeybinds.SpecialAbilityKeybind.JustPressed)
                {

                    Vector2 position = player.Center;
                    float speed = 10f;
                    Vector2 targetPosition = Main.MouseWorld;
                    Vector2 direction = targetPosition - position;
                    direction.Normalize();
                    Vector2 velocity = direction * speed;
                    float shieldDamage = player.GetCritChance<ShieldClassDamage>() += 1f;
                    float num = 110f * shieldDamage;

                    const int NumProjectiles = 1;

                    for (int e = 0; e < NumProjectiles; e++)
                    {
                        Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(18));

                        newVelocity *= 1f - Main.rand.NextFloat(0.3f);

                        int type = Projectile.NewProjectile(null, position, newVelocity, ProjectileID.Meowmere, (int)(num), 0f, player.whoAmI);
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
    }
}
