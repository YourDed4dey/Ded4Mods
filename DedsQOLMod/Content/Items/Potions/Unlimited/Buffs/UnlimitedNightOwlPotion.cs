using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.Buffs
{
    internal class UnlimitedNightOwlPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.NightOwlPotion;
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.NightOwlPotion);
            //DisplayName.SetDefault("Unlimited Night Owl Potion");
            //Tooltip.SetDefault("Increases night vision\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.NightOwlPotion);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.NightOwlPotion, 30)
                .Register();
        }
    }
}
