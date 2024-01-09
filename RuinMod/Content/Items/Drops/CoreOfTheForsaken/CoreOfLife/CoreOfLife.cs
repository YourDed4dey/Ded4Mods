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

namespace RuinMod.Content.Items.Drops.CoreOfTheForsaken.CoreOfLife
{
    internal class CoreOfLife : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Core of Life");
            //Tooltip.SetDefault("'This is the beauty of annihilation'");
        }
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 36;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 25;
            Item.useTime = 25;

            Item.maxStack = 1;

            Item.rare = ItemRarityID.Purple;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<CoreOfTheEye.CoreOfTheEye>())
                .AddIngredient(ItemID.WoodenSword, 1)
                .AddIngredient(ItemID.LesserHealingPotion, 30)
                .AddIngredient(ItemID.GoldCrown, 1)
                .AddIngredient(ItemID.Minishark,1)
                .AddIngredient(ModContent.ItemType<CoreOfTheWall.CoreOfTheWall>())
                .AddIngredient(ItemID.Flamarang, 1)
                .AddIngredient(ItemID.MoltenFury, 1)
                .AddIngredient(ItemID.GuideVoodooDoll, 1)
                .AddIngredient(ItemID.BlueMoon, 1)
                .AddIngredient(ItemID.WaterBolt, 1)
                .AddIngredient(ItemID.HellButterfly, 1)
                .AddIngredient(ModContent.ItemType<CoreOfTheFlower.CoreOfTheFlower>())
                .AddIngredient(ItemID.VenusMagnum, 1)
                .AddIngredient(ItemID.DeathSickle, 1)
                .AddIngredient(ItemID.Uzi, 1)
                .AddIngredient(ItemID.KOCannon, 1)
                .AddTile(TileID.DemonAltar)
                .Register();

            /* .AddIngredient(ItemID.SoulofFright, 10)
                .AddIngredient(ItemID.SoulofMight, 10)
                .AddIngredient(ItemID.SoulofSight, 10)
                .AddIngredient(ModContent.ItemType<SoulOfBlight.SoulOfBlight>(), 10)
                .AddIngredient(ModContent.ItemType<DarkEssence.DarkEssence>(), 10)
                .AddIngredient(ItemID.SoulofLight, 10)
                .AddIngredient(ItemID.SoulofNight, 10)
                .AddIngredient(ItemID.SoulofFlight, 10)
        }
    }
}*/
