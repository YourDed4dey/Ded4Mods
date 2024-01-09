using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.Buffs
{
    internal class UnlimitedBattlePotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.BattlePotion;
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.BattlePotion);
            //DisplayName.SetDefault("Unlimited Battle Potion");
            //Tooltip.SetDefault("Increases enemy spawn rate\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.BattlePotion);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.BattlePotion, 30)
                .Register();
        }
    }
}
