using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.MoreFood
{
    internal class UnlimitedGrapeJuice : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.GrapeJuice);
            //DisplayName.SetDefault("Unlimited Grape Juice");
            //Tooltip.SetDefault("Major improvements to all stats\n'Sugar. Water. Purple'\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.GrapeJuice);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.GrapeJuice, 30)
                .Register();
        }
    }
}
