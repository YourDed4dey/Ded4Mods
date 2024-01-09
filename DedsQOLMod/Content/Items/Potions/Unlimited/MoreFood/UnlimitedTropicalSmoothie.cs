using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.MoreFood
{
    internal class UnlimitedTropicalSmoothie : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.TropicalSmoothie);
            //DisplayName.SetDefault("Unlimited Tropical Smoothie");
            //Tooltip.SetDefault("Minor improvements to all stats\n'Real smooth'\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.TropicalSmoothie);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.TropicalSmoothie, 30)
                .Register();
        }
    }
}
