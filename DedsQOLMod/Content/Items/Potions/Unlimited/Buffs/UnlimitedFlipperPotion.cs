using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.Buffs
{
    internal class UnlimitedFlipperPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.FlipperPotion;
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.FlipperPotion);
            //DisplayName.SetDefault("Unlimited Flipper Potion");
            //Tooltip.SetDefault("Lets you move swiftly in liquids\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99; ItemID.Sets.ItemIconPulse[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.FlipperPotion);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.FlipperPotion, 30)
                .Register();
        }
    }
}
