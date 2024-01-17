using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.MoreBuffs
{
    internal class UnlimitedFishingPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.FishingPotion;
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.FishingPotion);
            //DisplayName.SetDefault("Unlimited Fishing Potion");
            //Tooltip.SetDefault("Increases fishing power\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99; ItemID.Sets.ItemIconPulse[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.FishingPotion);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.FishingPotion, 30)
                .Register();
        }
    }
}
