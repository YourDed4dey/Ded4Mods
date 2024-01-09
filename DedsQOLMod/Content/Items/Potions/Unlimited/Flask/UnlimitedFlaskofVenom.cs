using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.Flask
{
    internal class UnlimitedFlaskofVenom : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.FlaskofVenom;
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.FlaskofVenom);
            //DisplayName.SetDefault("Unlimited Flask of Venom");
            //Tooltip.SetDefault("Melee and Whip attacks inflict Venom on enemies\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.FlaskofVenom);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.FlaskofVenom, 30)
                .Register();
        }
    }
}
