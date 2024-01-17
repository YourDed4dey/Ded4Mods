using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.Buffs
{
    internal class UnlimitedFeatherfallPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.FeatherfallPotion;
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.FeatherfallPotion);
            //DisplayName.SetDefault("Unlimited Featherfall Potion");
            //Tooltip.SetDefault("Slows falling speed\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99; ItemID.Sets.ItemIconPulse[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.FeatherfallPotion);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.FeatherfallPotion, 30)
                .Register();
        }
    }
}
