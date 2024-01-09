﻿using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.Food
{
    internal class UnlimitedBunnyStew : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.BunnyStew);
            //DisplayName.SetDefault("Unlimited Bunny Stew");
            //Tooltip.SetDefault("Minor improvements to all stats\n'This one's luck has run out.'\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.BunnyStew);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.BunnyStew, 30)
                .Register();
        }
    }
}
