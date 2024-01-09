using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using RuinMod.Content.Classes.ShieldClass;
using RuinMod.Common.Systems;
using RuinMod.Content.Weapons.ShieldClassWeapons.Hardmode.ShroomiteShield;
using System.Collections.Generic;

namespace RuinMod.Content.Weapons.ShieldClassWeapons.Hardmode.Horseman_sShield
{
    [AutoloadEquip(EquipType.Shield)]
    internal class Horseman_sShield : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Horseman's Shield");
            //Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            Item.width = 42;
            Item.height = 46;
            Item.accessory = true;
            Item.rare = ItemRarityID.Yellow;

            Item.damage = 53;
            Item.DamageType = GetInstance<ShieldClassDamage>();
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            float DashKeys = Horseman_sShieldDash.DashVelocity;
            int index = tooltips.FindIndex(tip => tip.Name.StartsWith("Tooltip"));
            if (index > -1)
            {
                tooltips.Insert(index, new(Mod, "KeybindTooltip", $"Shoots pumpkins when hitting an enemy\nCurrent Dash= {DashKeys}\n8 defense\nAllows the player to dash into the enemy\nDouble tap a direction"));
            }
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<Horseman_sShieldDash>().DashAccessoryEquipped = true;
            player.statDefense += 8;
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
