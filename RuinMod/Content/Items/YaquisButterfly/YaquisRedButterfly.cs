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
using RuinMod.Content.Weapons.GamerClassWeapons.Hardmode.ThePortalGun;
using RuinMod.Content.Armor.GamerClassArmor.Hardmode.RickSanchezArmor;
using RuinMod.Content.Weapons.GamerClassWeapons.Hardmode.RaygunMKII;
using RuinMod.Content.Armor.Accesories.GamerClassAccesories.Hardmode.GamingEmblem;
using RuinMod.Content.Classes.GamerClass;
using static Terraria.ModLoader.ModContent;

namespace RuinMod.Content.Items.YaquisButterfly
{
    [AutoloadEquip(EquipType.Wings)]
    internal class YaquisRedButterfly : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Yaqui's Red Butterfly");
            //Tooltip.SetDefault("12% increased melee knockback\n5% increased melee, gamer, ranged, and magic damage and critical strike chance\n100% increased summon damage and critical strike chance\n+1 max minions");

            //ArmorIDs.Wing.Sets.Stats[Item.wingSlot] = new(180, 9f, 2.5f);
            // These wings use the same values as the solar wings
            // Fly time: 180 ticks = 3 seconds
            // Fly speed: 9
            // Acceleration multiplier: 2.5

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
            player.GetDamage(DamageClass.Melee) += 0.05f;
            player.GetCritChance(DamageClass.Melee) += 0.05f;

            player.GetKnockback(DamageClass.Melee) += 0.12f;

            //

            player.GetDamage(DamageClass.Ranged) += 0.05f;
            player.GetCritChance(DamageClass.Ranged) += 0.05f;

            //

            player.GetDamage(DamageClass.Magic) += 0.05f;
            player.GetCritChance(DamageClass.Magic) += 0.05f;

            //

            player.GetDamage(GetInstance<GamerClassDamage>()) += 0.05f;
            player.GetCritChance(GetInstance<GamerClassDamage>()) += 0.05f;

            //

            player.GetDamage(DamageClass.Summon) += 1f;
            player.GetCritChance(DamageClass.Summon) += 1f;

            player.maxMinions += 1;
            player.numMinions += 1;
            player.slotsMinions += 1;
        }

        public override void AddRecipes()
        {
            //All dmg types

            CreateRecipe()
                .AddIngredient(ItemID.GoldButterfly)
                .AddIngredient(ItemID.RedAdmiralButterfly)
                .AddIngredient(ItemID.Bladetongue) //
                .AddIngredient(ItemID.BerserkerGlove) //
                .AddIngredient(ItemID.DaedalusStormbow)//
                .AddIngredient(ItemID.EndlessQuiver)//
                .AddIngredient(ItemID.InfernoFork)//
                .AddIngredient(ItemID.StarVeil)//
                .AddIngredient(ModContent.ItemType<ThePortalGun>())//
                .AddIngredient(ItemID.EmpressBlade)//
                .AddIngredient(ItemID.PygmyNecklace)//
                .AddTile(TileID.DemonAltar)
                .Register();



        }
    }
}*/
