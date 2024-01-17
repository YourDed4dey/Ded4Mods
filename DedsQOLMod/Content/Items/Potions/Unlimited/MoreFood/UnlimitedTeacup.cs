using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.MoreFood
{
    internal class UnlimitedTeacup : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.Teacup);
            //DisplayName.SetDefault("Unlimited Teacup");
            //Tooltip.SetDefault("Minor improvements to all stats\n'A must-have for tea parties'\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99; ItemID.Sets.ItemIconPulse[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Teacup);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Teacup, 30)
                .Register();
        }
    }
}
