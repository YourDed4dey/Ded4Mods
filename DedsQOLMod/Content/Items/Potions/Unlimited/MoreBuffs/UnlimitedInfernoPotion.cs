using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.MoreBuffs
{
    internal class UnlimitedInfernoPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.InfernoPotion;
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.InfernoPotion);
            //DisplayName.SetDefault("Unlimited Inferno Potion");
            //Tooltip.SetDefault("Ignites nearby enemies\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.InfernoPotion);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.InfernoPotion, 30)
                .Register();
        }
    }
}
