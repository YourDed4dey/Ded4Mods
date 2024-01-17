using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.MoreBuffs
{
    internal class UnlimitedWrathPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.WrathPotion;
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.WrathPotion);
            //DisplayName.SetDefault("Unlimited Wrath Potion");
            //Tooltip.SetDefault("Increases damage by 10%\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99; ItemID.Sets.ItemIconPulse[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.WrathPotion);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.WrathPotion, 30)
                .Register();
        }
    }
}
