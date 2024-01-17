using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.Buffs
{
    internal class UnlimitedWaterWalkingPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.WaterWalkingPotion;
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.WaterWalkingPotion);
            //DisplayName.SetDefault("Unlimited Water Walking Potion");
            //Tooltip.SetDefault("Allows the ability to walk on water\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99; ItemID.Sets.ItemIconPulse[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.WaterWalkingPotion);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.WaterWalkingPotion, 30)
                .Register();
        }
    }
}
