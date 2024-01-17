using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.MoreFood
{
    internal class UnlimitedPiñaColada : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.PinaColada);
            //DisplayName.SetDefault("Unlimited Piña Colada");
            //Tooltip.SetDefault("Minor improvements to all stats\n'If you like piña coladas and getting caught in the rain'\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99; ItemID.Sets.ItemIconPulse[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.PinaColada);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.PinaColada, 30)
                .Register();
        }
    }
}
