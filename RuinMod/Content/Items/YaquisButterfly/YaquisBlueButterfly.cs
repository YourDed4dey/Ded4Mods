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
using Terraria.ModLoader.Config;

namespace RuinMod.Content.Items.YaquisButterfly
{
    [AutoloadEquip(EquipType.Wings)]
    internal class YaquisBlueButterfly : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Yaqui's Blue Butterfly");
            //Tooltip.SetDefault("22% increased ranged damage\r\n7% increased ranged critical strike chance\n20% chance to not consume ammo\n24 defense");

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
            player.GetDamage(DamageClass.Ranged) += 0.22f;
            player.GetCritChance(DamageClass.Ranged) += 0.07f;

            player.statDefense += 24;

            player.ammoCost80 = true;
        }
        public override void AddRecipes()
        {
            //Ranged

            CreateRecipe()
                .AddIngredient(ItemID.GoldButterfly)
                .AddIngredient(ItemID.UlyssesButterfly)
                .AddIngredient(ItemID.ShroomiteBreastplate)
                .AddIngredient(ItemID.ChainGun)
                .AddIngredient(ItemID.ReconScope)
                .AddTile(TileID.DemonAltar)
                .Register();
        }
    }
}*/
