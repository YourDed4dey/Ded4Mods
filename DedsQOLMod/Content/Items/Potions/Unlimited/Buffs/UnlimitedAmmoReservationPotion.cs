using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.Buffs
{
    internal class UnlimitedAmmoReservationPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.AmmoReservationPotion;
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.AmmoReservationPotion);
            //DisplayName.SetDefault("Unlimited Ammo Reservation Potion");
            //Tooltip.SetDefault("20% chance to not consume ammo\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.AmmoReservationPotion);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.AmmoReservationPotion, 30)
                .Register();
        }
    }
}
