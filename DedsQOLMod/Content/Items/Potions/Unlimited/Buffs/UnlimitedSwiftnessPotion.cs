using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.Buffs
{
    internal class UnlimitedSwiftnessPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.SwiftnessPotion;
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.SwiftnessPotion);
            //DisplayName.SetDefault("Unlimited Swiftness Potion");
            //Tooltip.SetDefault("25% increased movement speed\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.SwiftnessPotion);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.SwiftnessPotion, 30)
                .Register();
        }
    }
}
