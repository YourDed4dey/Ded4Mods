using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using RuinMod.Content.Classes.ShieldClass;
using RuinMod.Common.Systems;
using System.Collections.Generic;
using RuinMod.Content.Potions.Buffs.BlueDemon;
using RuinMod.Content.Potions.Debuffs.ShieldSickness;

namespace RuinMod.Content.Weapons.ShieldClassWeapons.Hardmode.ShroomiteShield
{
    [AutoloadEquip(EquipType.Shield)]
    internal class ShroomiteShield : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Shroomite Shield");
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
            float DashKeys = ShroomiteShieldDash.DashVelocity;
            int index = tooltips.FindIndex(tip => tip.Name.StartsWith("Tooltip"));
            if (index > -1)
            {
                tooltips.Insert(index, new(Mod, "KeybindTooltip", $"Press '{key}' to activate Special Ability\n[c/FFFF00:Special Ability: Costs 180 mana and increases shield dash]\nCurrent Dash= {DashKeys}\n8 defense\nAllows the player to dash into the enemy\nDouble tap a direction"));
            }
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<ShroomiteShieldDash>().DashAccessoryEquipped = true;
            player.statDefense += 8;

            if (player.whoAmI == Main.myPlayer)
            {
                if (RuinKeybinds.SpecialAbilityKeybind.JustPressed)
                {
                    if (player.statMana >= 180)
                    {
                        player.statMana -= 180;
                        ShroomiteShieldDash.DashVelocity += 5f;
                    }
                    else
                    {
                        player.AddBuff(ModContent.BuffType<Shield_Sickness>(), 60 * 10);
                    }

                    if(ShroomiteShieldDash.DashVelocity >= 63f)
                    {
                        ShroomiteShieldDash.DashVelocity = 22f;
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
                .AddIngredient(ItemID.ShroomiteBar, 15)
                .AddTile(TileID.MythrilAnvil) //.AddTile(TileID.DemonAltar)
                .Register();
        }
    }
}
