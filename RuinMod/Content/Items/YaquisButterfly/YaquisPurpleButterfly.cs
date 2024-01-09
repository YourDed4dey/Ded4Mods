/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using RuinMod.Content.Classes.GamerClass;

namespace RuinMod.Content.Items.YaquisButterfly
{
    [AutoloadEquip(EquipType.Wings)]
    internal class YaquisPurpleButterfly : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Yaqui's Purple Butterfly");
            //Tooltip.SetDefault("22% increased magic damage\r\n7% increased magic critical strike chance\nProvides same effects as a mana flower\n14 defense");

            ArmorIDs.Wing.Sets.Stats[Item.wingSlot] = new(150, 4f, 1.5f);
        }
        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
            ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            ascentWhenFalling = 0.75f; // Falling glide speed
            ascentWhenRising = 0.8f; // Rising speed
            maxCanAscendMultiplier = .8f;
            maxAscentMultiplier = 2.8f;
            constantAscend = 0.115f;
        }
        public override void SetDefaults()
        {
            Item.width = 50;
            Item.height = 38;

            Item.maxStack = 1;
            Item.rare = ItemRarityID.Red;
            Item.accessory = true;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Magic) += 0.22f;
            player.GetCritChance(DamageClass.Magic) += 0.07f;

            player.statDefense += 14;

            player.manaFlower = true;
        }

        public override void AddRecipes()
        {
            //Mage

            CreateRecipe()
                .AddIngredient(ItemID.GoldButterfly)
                .AddIngredient(ItemID.PurpleEmperorButterfly)
                .AddIngredient(ItemID.SpectreRobe)
                .AddIngredient(ItemID.StaffofEarth)
                .AddIngredient(ItemID.ManaFlower)
                .AddTile(TileID.DemonAltar)
                .Register();



        }
    }
}*/
