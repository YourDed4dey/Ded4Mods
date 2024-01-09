using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using RuinMod.Content.Classes.ShieldClass;
using System.Collections.Generic;

namespace RuinMod.Content.Weapons.ShieldClassWeapons.PreHardmode.CactusShield
{
    [AutoloadEquip(EquipType.Shield)]
    internal class CactusShield : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Cactus Shield");
            //Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            Item.width = 38;
            Item.height = 44;
            Item.accessory = true;
            Item.rare = ItemRarityID.White;

            Item.damage = 27;
            Item.DamageType = GetInstance<ShieldClassDamage>();
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            float DashKeys = CactusShieldDash.DashVelocity;
            int index = tooltips.FindIndex(tip => tip.Name.StartsWith("Tooltip"));
            if (index > -1)
            {
                tooltips.Insert(index, new(Mod, "KeybindTooltip", $"Poisons the player when hitting an npc\nCurrent Dash= {DashKeys}\n2 defense\nAllows the player to dash into the enemy\nDouble tap a direction"));
            }
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<CactusShieldDash>().DashAccessoryEquipped = true;
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
                .AddIngredient(ItemID.Cactus, 60)
                .AddIngredient(ItemID.Stinger, 15)
                .AddTile(TileID.LivingLoom) //.AddTile(TileID.Anvils) //.AddTile(TileID.DemonAltar)
                .Register();
        }
    }
}
