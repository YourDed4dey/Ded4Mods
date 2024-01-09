using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.Buffs
{
    internal class UnlimitedSummoningPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.SummoningPotion;
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.SummoningPotion);
            //DisplayName.SetDefault("Unlimited Summoning Potion");
            //Tooltip.SetDefault("Increases your max number of minions by 1\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.SummoningPotion);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.SummoningPotion, 30)
                .Register();
        }
    }
}
