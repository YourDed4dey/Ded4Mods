using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.Buffs
{
    internal class UnlimitedTitanPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.TitanPotion;
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.TitanPotion);
            //DisplayName.SetDefault("Unlimited Titan Potion");
            //Tooltip.SetDefault("Increases knockback\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.TitanPotion);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.TitanPotion, 30)
                .Register();
        }
    }
}
