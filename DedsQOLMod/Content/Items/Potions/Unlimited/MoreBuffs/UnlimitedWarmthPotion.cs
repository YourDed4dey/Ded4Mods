﻿using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.MoreBuffs
{
    internal class UnlimitedWarmthPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.WarmthPotion;
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.WarmthPotion);
            //DisplayName.SetDefault("Unlimited Warmth Potion");
            //Tooltip.SetDefault("Reduces damage from cold sources\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.WarmthPotion);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.WarmthPotion, 30)
                .Register();
        }
    }
}
