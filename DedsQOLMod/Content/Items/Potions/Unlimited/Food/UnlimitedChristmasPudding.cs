using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.Food
{
    internal class UnlimitedChristmasPudding : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.ChristmasPudding);
            //DisplayName.SetDefault("Unlimited Christmas Pudding");
            //Tooltip.SetDefault("Major improvements to all stats\n'A cozy treat by the fireplace.'\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99; ItemID.Sets.ItemIconPulse[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ChristmasPudding);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.ChristmasPudding, 30)
                .Register();
        }
    }
}
