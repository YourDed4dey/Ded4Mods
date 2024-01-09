using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.Food
{
    internal class UnlimitedMilkShake : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.Milkshake);
            //DisplayName.SetDefault("Unlimited Milkshake");
            //Tooltip.SetDefault("Major improvements to all stats\n'It brings the boys to the yard!'\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Milkshake);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Milkshake, 30)
                .Register();
        }
    }
}
