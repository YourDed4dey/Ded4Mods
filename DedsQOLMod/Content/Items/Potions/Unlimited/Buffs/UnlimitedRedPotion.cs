using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.Buffs
{
    internal class UnlimitedRedPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.RedPotion;
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.RedPotion);
            //DisplayName.SetDefault("Unlimited Red Potion");
            //Tooltip.SetDefault("'Only for those who are worthy'\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.RedPotion);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.RedPotion, 30)
                .Register();
        }
    }
}
