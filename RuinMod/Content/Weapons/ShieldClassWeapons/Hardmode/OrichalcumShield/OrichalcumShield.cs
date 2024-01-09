using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using RuinMod.Content.Classes.ShieldClass;
using RuinMod.Content.Weapons.ShieldClassWeapons.Hardmode.MythrilShield;
using System.Collections.Generic;

namespace RuinMod.Content.Weapons.ShieldClassWeapons.Hardmode.OrichalcumShield
{
    [AutoloadEquip(EquipType.Shield)]
    internal class OrichalcumShield : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Orichalcum Shield");
            //Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            Item.width = 42;
            Item.height = 46;
            Item.accessory = true;
            Item.rare = ItemRarityID.LightRed;

            Item.damage = 38;
            Item.DamageType = GetInstance<ShieldClassDamage>();
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            float DashKeys = MythrilShieldDash.DashVelocity;
            int index = tooltips.FindIndex(tip => tip.Name.StartsWith("Tooltip"));
            if (index > -1)
            {
                tooltips.Insert(index, new(Mod, "KeybindTooltip", $"Current Dash= {DashKeys}\n7 defense\nAllows the player to dash into the enemy\nDouble tap a direction"));
            }
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<MythrilShieldDash>().DashAccessoryEquipped = true;
            player.statDefense += 7;
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
                .AddIngredient(ItemID.OrichalcumBar, 15)
                .AddTile(TileID.MythrilAnvil) //.AddTile(TileID.DemonAltar)
                .Register();
        }
    }
}
