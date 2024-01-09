/*using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.Mana
{
    internal class UnlimitedLesserManaPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.LesserManaPotion;
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.LesserManaPotion);
            //DisplayName.SetDefault("Unlimited Lesser Mana Potion");
            //Tooltip.SetDefault("[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.LesserManaPotion);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.LesserManaPotion, 30)
                .Register();
        }
    }
}*/
