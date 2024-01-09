using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using RuinMod.Content.Classes.ShieldClass;
using System.Collections.Generic;
using RuinMod.Common.Systems;

namespace RuinMod.Content.Weapons.ShieldClassWeapons.PreHardmode.StarShield
{
    [AutoloadEquip(EquipType.Shield)]
    internal class StarShield : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Star Shield");
            //Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            Item.width = 42;
            Item.height = 46;
            Item.accessory = true;
            Item.rare = ItemRarityID.Green;

            Item.damage = 26;
            Item.DamageType = GetInstance<ShieldClassDamage>();
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            float DashKeys = StarShieldDash.DashVelocity;
            int index = tooltips.FindIndex(tip => tip.Name.StartsWith("Tooltip"));
            if (index > -1)
            {
                tooltips.Insert(index, new(Mod, "KeybindTooltip", $"Shoots a star when hitting an npc\nCurrent Dash= {DashKeys}\n4 defense\nAllows the player to dash into the enemy\nDouble tap a direction"));
            }
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<StarShieldDash>().DashAccessoryEquipped = true;
            player.statDefense += 4;
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
                .AddIngredient(ItemID.Starfury)
                .Register();
        }
    }
}
