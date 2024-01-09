using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.Buffs
{
    internal class UnlimitedHunterPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.HunterPotion;
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.HunterPotion);
            //DisplayName.SetDefault("Unlimited Hunter Potion");
            //Tooltip.SetDefault("Shows the location of enemies\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.HunterPotion);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.HunterPotion, 30)
                .Register();
        }
    }
}
