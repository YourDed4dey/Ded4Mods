using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using RuinMod.Content.Classes.ShieldClass;
using RuinMod.Common;
using RuinMod.Content.Weapons.ShieldClassWeapons.Hardmode.CobaltShield;
using System.Collections.Generic;

namespace RuinMod.Content.Weapons.ShieldClassWeapons.Hardmode.PearlwoodShield
{
    [AutoloadEquip(EquipType.Shield)]
    internal class PearlwoodShield : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Pearlwood Shield");
            //Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            Item.width = 38;
            Item.height = 44;
            Item.accessory = true;
            Item.rare = ItemRarityID.White;

            Item.damage = 14;
            Item.DamageType = GetInstance<ShieldClassDamage>();
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            float DashKeys = PearlwoodShieldDash.DashVelocity;
            int index = tooltips.FindIndex(tip => tip.Name.StartsWith("Tooltip"));
            if (index > -1)
            {
                tooltips.Insert(index, new(Mod, "KeybindTooltip", $"Current Dash= {DashKeys}\n1 defense\nAllows the player to dash into the enemy\nDouble tap a direction"));
            }
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<PearlwoodShieldDash>().DashAccessoryEquipped = true;
            player.statDefense += 1;
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
                .AddIngredient(ItemID.Pearlwood, 30)
                .AddTile(TileID.WorkBenches) //.AddTile(TileID.Anvils) //.AddTile(TileID.DemonAltar)
                .Register();
        }
    }
}
