using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.MoreFood
{
    internal class UnlimitedPeachSangria : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.PeachSangria);
            //DisplayName.SetDefault("Unlimited Peach Sangria");
            //Tooltip.SetDefault("Minor improvements to all stats\n'Life's a peach'\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.PeachSangria);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.PeachSangria, 30)
                .Register();
        }
    }
}
