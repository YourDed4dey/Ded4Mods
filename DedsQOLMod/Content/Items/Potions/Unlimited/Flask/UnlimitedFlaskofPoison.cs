using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.Flask
{
    internal class UnlimitedFlaskofPoison : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.FlaskofPoison;
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.FlaskofPoison);
            //DisplayName.SetDefault("Unlimited Flask of Poison");
            //Tooltip.SetDefault("Melee and Whip attacks poison enemies\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99; ItemID.Sets.ItemIconPulse[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.FlaskofPoison);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.FlaskofPoison, 30)
                .Register();
        }
    }
}
