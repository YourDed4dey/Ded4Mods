using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace CAMMod
{
    internal class GlobalRecipe : ModSystem
    {
        public override void AddRecipes()
        {
            Recipe AncientManipulator = Recipe.Create(ItemID.LunarCraftingStation, 1);
            AncientManipulator
            .AddIngredient(ItemID.WorkBench, 1)
            .AddIngredient(ItemID.MythrilAnvil, 1)
            .AddIngredient(ItemID.AdamantiteForge, 1)
            .Register();

            Recipe AncientManipulator1 = Recipe.Create(ItemID.LunarCraftingStation, 1);
            AncientManipulator1
            .AddIngredient(ItemID.WorkBench, 1)
            .AddIngredient(ItemID.OrichalcumAnvil, 1)
            .AddIngredient(ItemID.AdamantiteForge, 1)
            .Register();

            Recipe AncientManipulator2 = Recipe.Create(ItemID.LunarCraftingStation, 1);
            AncientManipulator2
            .AddIngredient(ItemID.WorkBench, 1)
            .AddIngredient(ItemID.MythrilAnvil, 1)
            .AddIngredient(ItemID.TitaniumForge, 1)
            .Register();

            Recipe AncientManipulator3 = Recipe.Create(ItemID.LunarCraftingStation, 1);
            AncientManipulator3
            .AddIngredient(ItemID.WorkBench, 1)
            .AddIngredient(ItemID.OrichalcumAnvil, 1)
            .AddIngredient(ItemID.TitaniumForge, 1)
            .Register();
        }
    }
}
