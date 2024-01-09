/*using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.Bottled
{
    internal class UnlimitedBottledWater : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.BottledWater;
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.BottledWater);
            //DisplayName.SetDefault("Unlimited Bottled Water");
            //Tooltip.SetDefault("[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.BottledWater);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.BottledWater, 30)
                .Register();
        }
    }
}*/
