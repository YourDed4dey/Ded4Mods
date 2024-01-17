using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.MoreBuffs
{
    internal class UnlimitedRagePotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.RagePotion;
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.RagePotion);
            //DisplayName.SetDefault("Unlimited Rage Potion");
            //Tooltip.SetDefault("Increases critical chance by 10%\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99; ItemID.Sets.ItemIconPulse[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.RagePotion);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.RagePotion, 30)
                .Register();
        }
    }
}
