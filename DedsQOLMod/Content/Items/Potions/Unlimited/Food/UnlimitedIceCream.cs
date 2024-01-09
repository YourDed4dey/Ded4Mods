using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.Food
{
    internal class UnlimitedIceCream : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.IceCream);
            //DisplayName.SetDefault("Unlimited Ice Cream");
            //Tooltip.SetDefault("Medium improvements to all stats\n'Eat it before it melts!'\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.IceCream);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.IceCream, 30)
                .Register();
        }
    }
}
