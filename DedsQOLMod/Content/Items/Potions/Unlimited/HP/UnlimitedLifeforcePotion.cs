using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.HP
{
    internal class UnlimitedLifeforcePotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.LifeforcePotion;
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.LifeforcePotion);
            //DisplayName.SetDefault("Unlimited Lifeforce Potion");
            //Tooltip.SetDefault("Increases max life by 20%\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.LifeforcePotion);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.LifeforcePotion, 30)
                .Register();
        }
    }
}
