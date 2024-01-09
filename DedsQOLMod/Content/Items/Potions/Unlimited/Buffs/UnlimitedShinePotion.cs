using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.Buffs
{
    internal class UnlimitedShinePotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.ShinePotion;
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.ShinePotion);
            //DisplayName.SetDefault("Unlimited Shine Potion");
            //Tooltip.SetDefault("Emits an aura of light\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ShinePotion);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.ShinePotion, 30)
                .Register();
        }
    }
}
