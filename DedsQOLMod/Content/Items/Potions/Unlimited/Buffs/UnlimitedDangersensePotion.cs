using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;


namespace DedsQOLMod.Content.Items.Potions.Unlimited.Buffs
{
    internal class UnlimitedDangersensePotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.TrapsightPotion;
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.TrapsightPotion);
            //DisplayName.SetDefault("Unlimited Dangersense Potion");
            //Tooltip.SetDefault("Allows you to see nearby danger sources\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99; ItemID.Sets.ItemIconPulse[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.TrapsightPotion);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.TrapsightPotion, 30)
                .Register();
        }
    }
}
