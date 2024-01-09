using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.MoreBuffs
{
    internal class UnlimitedGreaterLuckPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.LuckPotionGreater;
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.LuckPotionGreater);
            //DisplayName.SetDefault("Unlimited Greater Luck Potion");
            //Tooltip.SetDefault("Increases the Luck of the user\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.LuckPotionGreater);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.LuckPotionGreater, 30)
                .Register();
        }
    }
}
