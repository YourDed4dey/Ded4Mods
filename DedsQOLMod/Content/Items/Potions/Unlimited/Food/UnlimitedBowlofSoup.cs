using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.Food
{
    internal class UnlimitedBowlofSoup : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.BowlofSoup);
            //DisplayName.SetDefault("Unlimited Bowl of Soup");
            //Tooltip.SetDefault("Medium improvements to all stats\n'Simple, yet refreshing.'\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.BowlofSoup);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.BowlofSoup, 30)
                .Register();
        }
    }
}
