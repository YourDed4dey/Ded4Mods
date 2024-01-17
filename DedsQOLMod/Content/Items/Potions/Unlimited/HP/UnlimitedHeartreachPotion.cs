using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.HP
{
    internal class UnlimitedHeartreachPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.HeartreachPotion;
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.HeartreachPotion);
            //DisplayName.SetDefault("Unlimited Heartreach Potion");
            //Tooltip.SetDefault("Increases pickup range for life hearts\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99; ItemID.Sets.ItemIconPulse[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.HeartreachPotion);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.HeartreachPotion, 30)
                .Register();
        }
    }
}
