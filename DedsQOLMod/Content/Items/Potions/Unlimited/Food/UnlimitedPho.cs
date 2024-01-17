using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.Food
{
    internal class UnlimitedPho : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.Pho);
            //DisplayName.SetDefault("Unlimited Pho");
            //Tooltip.SetDefault("Medium improvements to all stats\n'Pho sho...'\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99; ItemID.Sets.ItemIconPulse[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Pho);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Pho, 30)
                .Register();
        }
    }
}
