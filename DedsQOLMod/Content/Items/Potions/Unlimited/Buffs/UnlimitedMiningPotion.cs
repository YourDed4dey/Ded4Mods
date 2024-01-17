using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.Buffs
{
    internal class UnlimitedMiningPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.MiningPotion;
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.MiningPotion);
            //DisplayName.SetDefault("Unlimited Mining Potion");
            //Tooltip.SetDefault("Increases mining speed by 25%\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99; ItemID.Sets.ItemIconPulse[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.MiningPotion);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.MiningPotion, 30)
                .Register();
        }
    }
}
