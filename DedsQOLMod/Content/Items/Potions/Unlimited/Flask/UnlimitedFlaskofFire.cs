using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.Flask
{
    internal class UnlimitedFlaskofFire : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.FlaskofFire;
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.FlaskofFire);
            //DisplayName.SetDefault("Unlimited Flask of Fire");
            //Tooltip.SetDefault("Melee and Whip attacks set enemies on fire\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99; ItemID.Sets.ItemIconPulse[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.FlaskofFire);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.FlaskofFire, 30)
                .Register();
        }
    }
}
