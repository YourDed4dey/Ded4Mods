/*using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.Bottled
{
    internal class UnlimitedBottledHoney : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.BottledHoney;
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.BottledHoney);
            //DisplayName.SetDefault("Unlimited Bottled Honey");
            //Tooltip.SetDefault("[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.BottledHoney);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.BottledHoney, 30)
                .Register();
        }
    }
}*/
