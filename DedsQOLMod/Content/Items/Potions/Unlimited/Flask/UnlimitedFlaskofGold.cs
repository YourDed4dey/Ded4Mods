using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.Flask
{
    internal class UnlimitedFlaskofGold : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.FlaskofGold;
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.FlaskofGold);
            //DisplayName.SetDefault("Unlimited Flask of Gold");
            //Tooltip.SetDefault("Melee and Whip attacks make enemies drop more gold\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99; ItemID.Sets.ItemIconPulse[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.FlaskofGold);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.FlaskofGold, 30)
                .Register();
        }
    }
}
