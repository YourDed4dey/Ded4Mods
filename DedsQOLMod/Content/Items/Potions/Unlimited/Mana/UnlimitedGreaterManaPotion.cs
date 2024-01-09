/*using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.Mana
{
    internal class UnlimitedGreaterManaPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.GreaterManaPotion;
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.GreaterManaPotion);
            //DisplayName.SetDefault("Unlimited Greater Mana Potion");
            //Tooltip.SetDefault("[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.GreaterManaPotion);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.GreaterManaPotion, 30)
                .Register();
        }
    }
}*/
