/*using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace RuinMod.Content.Tools.Pickaxe.Pre_Hardmode.AbandonedPickaxe
{
    internal class AbandonedPickaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Abandoned Pickaxe");
            //Tooltip.SetDefault("Can mine Meteorite");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.PlatinumPickaxe);
            Item.value = 0;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<Content.Items.LostFragment.LostFragment>(), 23)
                .AddIngredient(ModContent.ItemType<Content.Items.LostFragment.Handle.LostFragmentHandle>(), 1)
                .AddTile(TileID.Anvils)
                .Register();
        }

    }
}*/
