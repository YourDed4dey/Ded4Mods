using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.HP
{
    internal class UnlimitedRegenerationPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.RegenerationPotion;
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.RegenerationPotion);
            //DisplayName.SetDefault("Unlimited Regeneration Potion");
            //Tooltip.SetDefault("Provides life regeneration\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99; ItemID.Sets.ItemIconPulse[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.RegenerationPotion);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.RegenerationPotion, 30)
                .Register();
        }
    }
}
