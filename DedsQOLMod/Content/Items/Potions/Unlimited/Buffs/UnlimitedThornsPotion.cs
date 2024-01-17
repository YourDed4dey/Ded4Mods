using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.Buffs
{
    internal class UnlimitedThornsPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.ThornsPotion;
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.ThornsPotion);
            //DisplayName.SetDefault("Unlimited Thorns Potion");
            //Tooltip.SetDefault("Attackers also take damage\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99; ItemID.Sets.ItemIconPulse[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ThornsPotion);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.ThornsPotion, 30)
                .Register();
        }
    }
}
