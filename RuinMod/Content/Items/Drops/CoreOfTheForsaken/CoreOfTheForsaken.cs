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

namespace RuinMod.Content.Items.Drops.CoreOfTheForsaken
{
    internal class CoreOfTheForsaken : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Core of the Forsaken");
            //Tooltip.SetDefault("'Hungry souls listen to your command'");
        }
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 25;
            Item.useTime = 25;

            Item.maxStack = 1;

            Item.rare = ItemRarityID.Purple;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.SoulofNight, 15)
                .AddIngredient(ModContent.ItemType<CoreOfLife.CoreOfLife>(), 1)
                .AddIngredient(ItemID.SoulofLight, 15)
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }
}*/
