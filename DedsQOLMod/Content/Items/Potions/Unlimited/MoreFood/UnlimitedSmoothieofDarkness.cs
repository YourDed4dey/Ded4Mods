using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.MoreFood
{
    internal class UnlimitedSmoothieofDarkness : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.SmoothieofDarkness);
            //DisplayName.SetDefault("Unlimited Smoothie of Darkness");
            //Tooltip.SetDefault("Minor improvements to all stats\n'Come to the dark side, we have smoothies'\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99; ItemID.Sets.ItemIconPulse[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.SmoothieofDarkness);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.SmoothieofDarkness, 30)
                .Register();
        }
    }
}
