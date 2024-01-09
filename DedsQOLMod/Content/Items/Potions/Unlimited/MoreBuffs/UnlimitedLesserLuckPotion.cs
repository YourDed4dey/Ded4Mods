using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.MoreBuffs
{
    internal class UnlimitedLesserLuckPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.LuckPotionLesser;
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.LuckPotionLesser);
            //DisplayName.SetDefault("Unlimited Lesser Luck Potion");
            //Tooltip.SetDefault("Increases the Luck of the user\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.LuckPotionLesser);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.LuckPotionLesser, 30)
                .Register();
        }
    }
}
