using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.MoreBuffs
{
    internal class UnlimitedCratePotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.CratePotion;
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.CratePotion);
            //DisplayName.SetDefault("Unlimited Crate Potion");
            //Tooltip.SetDefault("Increases chance to get a crate\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.CratePotion);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.CratePotion, 30)
                .Register();
        }
    }
}
