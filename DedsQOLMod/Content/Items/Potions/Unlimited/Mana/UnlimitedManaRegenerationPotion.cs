using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.Mana
{
    internal class UnlimitedManaRegenerationPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.ManaRegenerationPotion;
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.ManaRegenerationPotion);
            //DisplayName.SetDefault("Unlimited Mana Regeneration Potion");
            //Tooltip.SetDefault("Increased mana regeneration\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ManaRegenerationPotion);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.ManaRegenerationPotion, 30)
                .Register();
        }
    }
}
