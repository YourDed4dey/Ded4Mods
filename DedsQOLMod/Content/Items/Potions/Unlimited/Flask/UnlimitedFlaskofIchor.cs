using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.Flask
{
    internal class UnlimitedFlaskofIchor : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.FlaskofIchor;
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.FlaskofIchor);
            //DisplayName.SetDefault("Unlimited Flask of Ichor");
            //Tooltip.SetDefault("Melee and Whip attacks decrease enemies defense\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.FlaskofIchor);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.FlaskofIchor, 30)
                .Register();
        }
    }
}
