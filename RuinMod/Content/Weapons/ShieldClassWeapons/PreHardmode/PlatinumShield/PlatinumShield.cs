using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using RuinMod.Content.Classes.ShieldClass;
using RuinMod.Content.Weapons.ShieldClassWeapons.PreHardmode.GoldShield;
using RuinMod.Content.Weapons.ShieldClassWeapons.PreHardmode.WoodShield;
using System.Collections.Generic;

namespace RuinMod.Content.Weapons.ShieldClassWeapons.PreHardmode.PlatinumShield
{
    [AutoloadEquip(EquipType.Shield)]
    internal class PlatinumShield : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Platinum Shield");
            //Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            Item.width = 42;
            Item.height = 46;
            Item.accessory = true;
            Item.rare = ItemRarityID.White;

            Item.damage = 18;
            Item.DamageType = GetInstance<ShieldClassDamage>();
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            float DashKeys = GoldShieldDash.DashVelocity;
            int index = tooltips.FindIndex(tip => tip.Name.StartsWith("Tooltip"));
            if (index > -1)
            {
                tooltips.Insert(index, new(Mod, "KeybindTooltip", $"Current Dash= {DashKeys}\n4 defense\nAllows the player to dash into the enemy\nDouble tap a direction"));
            }
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<GoldShieldDash>().DashAccessoryEquipped = true;
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
                .AddIngredient(ItemID.PlatinumBar, 15)
                .AddTile(TileID.Anvils) //.AddTile(TileID.DemonAltar)
                .Register();
        }
    }
}
