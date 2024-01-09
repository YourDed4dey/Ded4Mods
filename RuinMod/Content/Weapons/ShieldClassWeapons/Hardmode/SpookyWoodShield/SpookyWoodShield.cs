using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using RuinMod.Content.Classes.ShieldClass;
using RuinMod.Content.Weapons.ShieldClassWeapons.Hardmode.ShieldOfTimber;
using System.Collections.Generic;

namespace RuinMod.Content.Weapons.ShieldClassWeapons.Hardmode.SpookyWoodShield
{
    [AutoloadEquip(EquipType.Shield)]
    internal class SpookyWoodShield : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Spooky Wood Shield");
            //Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            Item.width = 42;
            Item.height = 46;
            Item.accessory = true;
            Item.rare = ItemRarityID.Yellow;

            Item.damage = 28;
            Item.DamageType = GetInstance<ShieldClassDamage>();
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            float DashKeys = SpookyWoodShieldDash.DashVelocity;
            int index = tooltips.FindIndex(tip => tip.Name.StartsWith("Tooltip"));
            if (index > -1)
            {
                tooltips.Insert(index, new(Mod, "KeybindTooltip", $"Current Dash= {DashKeys}\n1 defense\nAllows the player to dash into the enemy\nDouble tap a direction"));
            }
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<SpookyWoodShieldDash>().DashAccessoryEquipped = true;
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
                .AddIngredient(ItemID.SpookyWood, 60)
                .AddTile(TileID.WorkBenches) //.AddTile(TileID.DemonAltar)
                .Register();
        }
    }
}
