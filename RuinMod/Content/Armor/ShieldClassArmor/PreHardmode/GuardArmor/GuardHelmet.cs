using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;
using Terraria.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria.ModLoader.IO;
using Mono.Cecil;
using Terraria.DataStructures;
using Terraria.Localization;
using RuinMod.Common.Systems;
using RuinMod.Content.Classes.ShieldClass;
using RuinMod.Content.Weapons.ShieldClassWeapons.PreHardmode.LunarShield;

namespace RuinMod.Content.Armor.ShieldClassArmor.PreHardmode.GuardArmor
{
    [AutoloadEquip(EquipType.Head)]
    internal class GuardHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Guard Mask");
            //Tooltip.SetDefault("6% increased contact damage and critical strike chance\nIncreased contact damage armor penetration by 2");
        }

        public override void SetDefaults() //Item Stats
        {
            Item.width = 22;
            Item.height = 24;
            Item.rare = ItemRarityID.Green;
            Item.defense = 8;
            Item.wornArmor = true;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<GuardChestplate>() && legs.type == ItemType<GuardLeggings>();
        }

        public override void UpdateArmorSet(Player player) //Armor set bonuses
        {
            player.statManaMax2 += 20;
            player.setBonus = Language.GetTextValue("Mods.RuinMod.ItemSetBonus.GuardSet"); // "Maximum mana increased by 20"
        }

        public override void UpdateEquip(Player player) //Individual armor piece bonus
        {
            player.GetCritChance(ModContent.GetInstance<ShieldClassDamage>()) += 0.06f;
            player.GetDamage(ModContent.GetInstance<ShieldClassDamage>()) += 0.06f;
            player.GetArmorPenetration(ModContent.GetInstance<ShieldClassDamage>()) += 2f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.DemoniteBar, 25)
                .AddIngredient(ItemID.ShadowScale, 20)
                .AddTile(TileID.Anvils)
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.CrimtaneBar, 25)
                .AddIngredient(ItemID.TissueSample, 20)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}