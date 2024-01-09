﻿using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.Flask
{
    internal class UnlimitedFlaskofCursedFlames : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.FlaskofCursedFlames;
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.FlaskofCursedFlames);
            //DisplayName.SetDefault("Unlimited Flask of Cursed Flames");
            //Tooltip.SetDefault("Melee and Whip attacks inflict enemies with cursed flames\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.FlaskofCursedFlames);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.FlaskofCursedFlames, 30)
                .Register();
        }
    }
}
