﻿using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.Buffs
{
    internal class UnlimitedBuilderPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.BuilderPotion;
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.BuilderPotion);
            //DisplayName.SetDefault("Unlimited Builder Potion");
            //Tooltip.SetDefault("Increases placement speed and range\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99; ItemID.Sets.ItemIconPulse[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.BuilderPotion);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.BuilderPotion, 30)
                .Register();
        }
    }
}
