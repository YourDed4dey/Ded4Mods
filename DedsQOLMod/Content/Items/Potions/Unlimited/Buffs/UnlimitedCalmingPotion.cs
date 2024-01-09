﻿using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.Buffs
{
    internal class UnlimitedCalmingPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.CalmingPotion;
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.CalmingPotion);
            //DisplayName.SetDefault("Unlimited Calming Potion");
            //Tooltip.SetDefault("Decreases enemy spawn rate\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.CalmingPotion);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.CalmingPotion, 30)
                .Register();
        }
    }
}
