using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using RuinMod.Content.Classes.ShieldClass;
using System.Collections.Generic;

namespace RuinMod.Content.Weapons.ShieldClassWeapons.PreHardmode.CopperShield
{
    [AutoloadEquip(EquipType.Shield)]
    internal class CopperShield : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Copper Shield");
            //Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            Item.width = 42;
            Item.height = 46;
            Item.accessory = true;
            Item.rare = ItemRarityID.White;

            Item.damage = 5;
            Item.DamageType = GetInstance<ShieldClassDamage>();
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            float DashKeys = CopperShieldDash.DashVelocity;
            int index = tooltips.FindIndex(tip => tip.Name.StartsWith("Tooltip"));
            if (index > -1)
            {
                tooltips.Insert(index, new(Mod, "KeybindTooltip", $"Current Dash= {DashKeys}\n2 defense\nAllows the player to dash into the enemy\nDouble tap a direction"));
            }
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<CopperShieldDash>().DashAccessoryEquipped = true;
            player.statDefense += 2;
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
                .AddIngredient(ItemID.CopperBar, 15)
                .AddTile(TileID.Anvils) //.AddTile(TileID.DemonAltar)
                .Register();
        }
    }
}
