using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.Buffs
{
    internal class UnlimitedSpelunkerPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.SpelunkerPotion;
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.SpelunkerPotion);
            //DisplayName.SetDefault("Unlimited Spelunker Potion");
            //Tooltip.SetDefault("Shows the location of treasure and ore\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99; ItemID.Sets.ItemIconPulse[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.SpelunkerPotion);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.SpelunkerPotion, 30)
                .Register();
        }
    }
}
