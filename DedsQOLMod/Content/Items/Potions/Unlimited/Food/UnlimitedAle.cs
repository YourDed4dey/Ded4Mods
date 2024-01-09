using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.Food
{
    internal class UnlimitedAle : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.Ale);
            //DisplayName.SetDefault("Unlimited Ale");
            //Tooltip.SetDefault("Minor improvements to melee stats & lowered defense\n'Down the hatch!'\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Ale);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Ale, 30)
                .Register();
        }
    }
}
