/*using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.Mana
{
    internal class UnlimitedManaPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.ManaPotion;
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.ManaPotion);
            //DisplayName.SetDefault("Unlimited Mana Potion");
            //Tooltip.SetDefault("[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99; ItemID.Sets.ItemIconPulse[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ManaPotion);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.ManaPotion, 30)
                .Register();
        }
    }
}*/
