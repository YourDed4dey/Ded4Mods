using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.MoreBuffs
{
    internal class UnlimitedSonarPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.SonarPotion;
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.SonarPotion);
            //DisplayName.SetDefault("Unlimited Sonar Potion");
            //Tooltip.SetDefault("Detects hooked fish\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99; ItemID.Sets.ItemIconPulse[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.SonarPotion);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.SonarPotion, 30)
                .Register();
        }
    }
}
