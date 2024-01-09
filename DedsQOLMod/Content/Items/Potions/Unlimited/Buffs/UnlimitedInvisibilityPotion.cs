using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.Buffs
{
    internal class UnlimitedInvisibilityPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.InvisibilityPotion;
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.InvisibilityPotion);
            //DisplayName.SetDefault("Unlimited Invisibility Potion");
            //Tooltip.SetDefault("Grants invisibility and lowers the spawn rate of enemies\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.InvisibilityPotion);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.InvisibilityPotion, 30)
                .Register();
        }
    }
}
