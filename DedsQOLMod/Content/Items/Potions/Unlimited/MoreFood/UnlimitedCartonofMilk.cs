using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.MoreFood
{
    internal class UnlimitedCartonofMilk : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.MilkCarton);
            //DisplayName.SetDefault("Unlimited Carton of Milk");
            //Tooltip.SetDefault("Minor improvements to all stats\n'For strong, healthy bones'\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99; ItemID.Sets.ItemIconPulse[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.MilkCarton);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.MilkCarton, 30)
                .Register();
        }
    }
}
