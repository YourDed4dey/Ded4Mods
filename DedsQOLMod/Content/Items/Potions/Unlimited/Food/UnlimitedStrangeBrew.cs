/*using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.Food
{
    internal class UnlimitedStrangeBrew : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.StrangeBrew;
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.StrangeBrew);
            //DisplayName.SetDefault("Unlimited Strange Brew");
            //Tooltip.SetDefault("'It looks and smells terrible'\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.StrangeBrew);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.StrangeBrew, 30)
                .Register();
        }
    }
}*/
