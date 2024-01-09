using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.MoreFood
{
    internal class UnlimitedCoffee : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.CoffeeCup);
            //DisplayName.SetDefault("Unlimited Coffee");
            //Tooltip.SetDefault("Medium improvements to all stats\n'Hello darkness, my old friend'\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.CoffeeCup);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.CoffeeCup, 30)
                .Register();
        }
    }
}
