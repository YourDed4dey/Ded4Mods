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
using RuinMod.Content.Armor.GamerClassArmor.Hardmode.RickSanchezArmor;
using RuinMod.Content.Weapons.GamerClassWeapons.Hardmode.RaygunMKII;
using RuinMod.Content.Armor.Accesories.GamerClassAccesories.Hardmode.GamingEmblem;
using RuinMod.Content.Classes.GamerClass;
using static Terraria.ModLoader.ModContent;

namespace RuinMod.Content.Items.YaquisButterfly
{
    [AutoloadEquip(EquipType.Wings)]
    internal class YaquisGreenButterfly : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Yaqui's Green Butterfly");
            //Tooltip.SetDefault("22% increased gamer damage\r\n7% increased gamer critical strike chance\n17 defense");

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
            player.GetDamage(GetInstance<GamerClassDamage>()) += 0.22f;
            player.GetCritChance(GetInstance<GamerClassDamage>()) += 0.07f;

            player.statDefense += 17;
        }

        public override void AddRecipes()
        {
            //Gamer

            CreateRecipe()
                .AddIngredient(ItemID.GoldButterfly)
                .AddIngredient(ItemType<RickSanchezBody>())
                .AddIngredient(ItemType<RaygunMKII>())
                .AddIngredient(ItemType<GamingEmblem>())
                .AddTile(TileID.DemonAltar)
                .Register();



        }
    }
}*/
