/*using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.HP
{
    internal class UnlimitedHealingPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.HealingPotion;
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.HealingPotion);
            //DisplayName.SetDefault("Unlimited Healing Potion");
            //Tooltip.SetDefault("[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99; ItemID.Sets.ItemIconPulse[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.HealingPotion);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.HealingPotion, 30)
                .Register();
        }
    }
}*/
