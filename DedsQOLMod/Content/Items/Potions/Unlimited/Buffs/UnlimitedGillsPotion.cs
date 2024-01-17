using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.Buffs
{
    internal class UnlimitedGillsPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.GillsPotion;
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.GillsPotion);
            //DisplayName.SetDefault("Unlimited Gills Potion");
            //Tooltip.SetDefault("Breathe water instead of air\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99; ItemID.Sets.ItemIconPulse[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.GillsPotion);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.GillsPotion, 30)
                .Register();
        }
    }
}
