using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.MoreFood
{
    internal class UnlimitedFrozenBananaDaiquiri : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.BananaDaiquiri);
            //DisplayName.SetDefault("Unlimited Frozen Banana Daiquiri");
            //Tooltip.SetDefault("Minor improvements to all stats\n'Yellow and mellow'\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.BananaDaiquiri);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.BananaDaiquiri, 30)
                .Register();
        }
    }
}
