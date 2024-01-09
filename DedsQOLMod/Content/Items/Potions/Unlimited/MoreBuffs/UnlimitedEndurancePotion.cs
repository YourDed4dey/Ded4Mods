using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.MoreBuffs
{
    internal class UnlimitedEndurancePotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.EndurancePotion;
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.EndurancePotion);
            //DisplayName.SetDefault("Unlimited Endurance Potion");
            //Tooltip.SetDefault("Reduces damage taken by 10%\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.EndurancePotion);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.EndurancePotion, 30)
                .Register();
        }
    }
}
