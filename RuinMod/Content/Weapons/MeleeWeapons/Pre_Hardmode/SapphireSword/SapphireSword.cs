/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;

namespace RuinMod.Content.Weapons.MeleeWeapons.Pre_Hardmode.SapphireSword;

internal class SapphireSword : ModItem
{
    public override void SetStaticDefaults()
    {
        //DisplayName.SetDefault("Sapphire Sword");
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.CloneDefaults(ItemID.PlatinumBroadsword);
        Item.width = 40;
        Item.height = 40;
        Item.rare = ItemRarityID.Blue;
        Item.value = 0;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.Sapphire, 13)
            .AddTile(TileID.Anvils)
            .Register();
    }

}*/