using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.Buffs
{
    internal class UnlimitedArcheryPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.ArcheryPotion;
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.ArcheryPotion);
            //DisplayName.SetDefault("Unlimited Archery Potion");
            //Tooltip.SetDefault("20% increased arrow speed and damage\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ArcheryPotion);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.ArcheryPotion, 30)
                .Register();
        }
    }
}
