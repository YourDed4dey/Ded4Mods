using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using RuinMod.Content.Classes.ShieldClass;
using System.Collections.Generic;

namespace RuinMod.Content.Weapons.ShieldClassWeapons.PreHardmode.DemoniteShield
{
    [AutoloadEquip(EquipType.Shield)]
    internal class DemoniteShield : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Demonite Shield");
            //Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            Item.width = 42;
            Item.height = 46;
            Item.accessory = true;
            Item.rare = ItemRarityID.Blue;

            Item.damage = 27;
            Item.DamageType = GetInstance<ShieldClassDamage>();
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            float DashKeys = DemoniteShieldDash.DashVelocity;
            int index = tooltips.FindIndex(tip => tip.Name.StartsWith("Tooltip"));
            if (index > -1)
            {
                tooltips.Insert(index, new(Mod, "KeybindTooltip", $"Corrupts enemies on hit\nCurrent Dash= {DashKeys}\n5 defense\nAllows the player to dash into the enemy\nDouble tap a direction"));
            }
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<DemoniteShieldDash>().DashAccessoryEquipped = true;
            player.statDefense += 5;
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
                .AddIngredient(ItemID.DemoniteBar, 15)
                .AddIngredient(ItemID.ShadowScale, 10)
                .AddTile(TileID.Anvils) //.AddTile(TileID.DemonAltar)
                .Register();
        }
    }
}
