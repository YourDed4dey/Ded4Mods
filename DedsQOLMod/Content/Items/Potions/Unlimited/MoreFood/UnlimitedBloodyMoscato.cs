using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.MoreFood
{
    internal class UnlimitedBloodyMoscato : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.BloodyMoscato);
            //DisplayName.SetDefault("Unlimited Bloody Moscato");
            //Tooltip.SetDefault("Minor improvements to all stats\n'Not really blood... or is it?'\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99; ItemID.Sets.ItemIconPulse[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.BloodyMoscato);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.BloodyMoscato, 30)
                .Register();
        }
    }
}
