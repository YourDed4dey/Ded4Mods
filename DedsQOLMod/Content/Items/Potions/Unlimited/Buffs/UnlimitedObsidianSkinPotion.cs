using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.Buffs
{
    internal class UnlimitedObsidianSkinPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.ObsidianSkinPotion;
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.ObsidianSkinPotion);
            //DisplayName.SetDefault("Unlimited Obsidian Skin Potion");
            //Tooltip.SetDefault("Provides immunity to lava\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99; ItemID.Sets.ItemIconPulse[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ObsidianSkinPotion);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.ObsidianSkinPotion, 30)
                .Register();
        }
    }
}
