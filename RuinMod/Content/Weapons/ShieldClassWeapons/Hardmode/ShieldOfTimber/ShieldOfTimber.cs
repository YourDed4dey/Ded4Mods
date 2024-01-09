using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using RuinMod.Content.Classes.ShieldClass;
using RuinMod.Content.Weapons.ShieldClassWeapons.PreHardmode.WoodShield;
using RuinMod.Content.Weapons.ShieldClassWeapons.PreHardmode.RichMahoganyShield;
using RuinMod.Content.Weapons.ShieldClassWeapons.PreHardmode.EbonwoodShield;
using RuinMod.Content.Weapons.ShieldClassWeapons.PreHardmode.ShadewoodShield;
using RuinMod.Content.Weapons.ShieldClassWeapons.PreHardmode.BorealWoodShield;
using RuinMod.Content.Weapons.ShieldClassWeapons.PreHardmode.PalmWoodShield;
using RuinMod.Content.Weapons.ShieldClassWeapons.Hardmode.PearlwoodShield;
using RuinMod.Content.Weapons.ShieldClassWeapons.Hardmode.SpookyWoodShield;
//using RuinMod.Content.Items.Drops.EssencesOrSoulsOrFragments.Souls.SoulOfBlight;
using RuinMod.Common.Systems;
using RuinMod.Content.Potions.Debuffs.ShieldSickness;
using Microsoft.Xna.Framework;
using RuinMod.Content.Weapons.ShieldClassWeapons.Hardmode.ShieldOfLife;
using System.Collections.Generic;

namespace RuinMod.Content.Weapons.ShieldClassWeapons.Hardmode.ShieldOfTimber
{
    [AutoloadEquip(EquipType.Shield)]
    internal class ShieldOfTimber : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Shield of Timber");
            //Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            Item.width = 52;
            Item.height = 48;
            Item.accessory = true;
            Item.rare = ItemRarityID.Yellow;

            Item.damage = 84;
            Item.DamageType = GetInstance<ShieldClassDamage>();
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            float DashKeys = ShieldOfTimberDash.DashVelocity;
            int index = tooltips.FindIndex(tip => tip.Name.StartsWith("Tooltip"));
            if (index > -1)
            {
                tooltips.Insert(index, new(Mod, "KeybindTooltip", $"Fruits appear in your cursor when hitting an enemy\nCurrent Dash= {DashKeys}\n9 defense\nAllows the player to dash into the enemy\nDouble tap a direction"));
            }
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<ShieldOfTimberDash>().DashAccessoryEquipped = true;
            player.statDefense += 9;
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
                .AddIngredient(ItemType<WoodShield>(), 1)
                .AddIngredient(ItemType<RichMahoganyShield>(), 1)
                .AddIngredient(ItemType<EbonwoodShield>(), 1)
                .AddIngredient(ItemType<ShadewoodShield>(), 1)
                .AddIngredient(ItemType<BorealWoodShield>(), 1)
                .AddIngredient(ItemType<PalmWoodShield>(), 1)
                .AddIngredient(ItemType<PearlwoodShield.PearlwoodShield>(), 1)
                .AddIngredient(ItemType<SpookyWoodShield.SpookyWoodShield>(), 1)
                .AddIngredient(ItemID.SoulofMight, 5)
                .AddIngredient(ItemID.SoulofSight, 5)
                .AddIngredient(ItemID.SoulofFright, 5)
                //.AddIngredient(ItemType<SoulOfBlight>(), 5)
                .AddTile(TileID.MythrilAnvil) //.AddTile(TileID.DemonAltar)
                .Register();
        }
    }
}
