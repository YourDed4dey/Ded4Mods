using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.MoreFood
{
    internal class UnlimitedFruitJuice : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.FruitJuice);
            //DisplayName.SetDefault("Unlimited Fruit Juice");
            //Tooltip.SetDefault("Minor improvements to all stats\n'With %5 real fruit juice!'\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.FruitJuice);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.FruitJuice, 30)
                .Register();
        }
    }
}
