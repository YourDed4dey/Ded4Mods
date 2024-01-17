using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.Buffs
{
    internal class UnlimitedIronSkinPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.IronskinPotion;
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.IronskinPotion);
            //DisplayName.SetDefault("Unlimited Iron skin Potion");
            //Tooltip.SetDefault("Increase defense by 8\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99; ItemID.Sets.ItemIconPulse[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.IronskinPotion);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.IronskinPotion, 30)
                .Register();
        }
    }
}
