using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.MoreBuffs
{
    internal class UnlimitedLuckPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.LuckPotion;
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.LuckPotion);
            //DisplayName.SetDefault("Unlimited Luck Potion");
            //Tooltip.SetDefault("Increases the Luck of the user\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.LuckPotion);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.LuckPotion, 30)
                .Register();
        }
    }
}
