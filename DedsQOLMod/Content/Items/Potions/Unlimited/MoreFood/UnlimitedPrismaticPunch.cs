using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Potions.Unlimited.MoreFood
{
    internal class UnlimitedPrismaticPunch : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.PrismaticPunch);
            //DisplayName.SetDefault("Unlimited Prismatic Punch");
            //Tooltip.SetDefault("Medium improvements to all stats\n'Feel the rainbow, taste the crystal!'\n[c/FFFF00:How much can you drink?]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99; ItemID.Sets.ItemIconPulse[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.PrismaticPunch);
            Item.maxStack = 1;
            Item.color = Color.Cyan;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.PrismaticPunch, 30)
                .Register();
        }
    }
}
