using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;


namespace DedsQOLMod.Content.Items.Potions.Unlimited.Food
{
    internal class UnlimitedSake : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.Sake);
            //DisplayName.SetDefault("Unlimited Sake");
            //Tooltip.SetDefault("Minor improvements to melee stats & lowered defense\n'Drink too much of this, and you become karate master.'\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Sake);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Sake, 30)
                .Register();
        }
    }
}
