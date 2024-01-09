using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.Buffs
{
    internal class UnlimitedGravitationPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.GravitationPotion;
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.GravitationPotion);
            //DisplayName.SetDefault("Unlimited Gravitation Potion");
            //Tooltip.SetDefault("Allows the control of gravity\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.GravitationPotion);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.GravitationPotion, 30)
                .Register();
        }
    }
}
