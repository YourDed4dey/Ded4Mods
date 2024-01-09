/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using RuinMod.Content.Projectiles.ChainClass.WoodenChain;
using RuinMod.Content.Classes.ChainClass;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace RuinMod.Content.Weapons.ChainClassWeapons.Pre_Hardmode.WoodenChain;

internal class WoodenChain : ModItem
{
    public override void SetStaticDefaults()
    {
        //DisplayName.SetDefault("Wooden Chain");
        //Tooltip.SetDefault("'The culmination of wooden strings'");
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 84;
        Item.height = 42;

        Item.useStyle = ItemUseStyleID.Shoot;
        Item.useTime = 0;
        Item.useAnimation = 0;
        Item.autoReuse = true;
        Item.noUseGraphic = true;
        Item.channel = true;

        Item.DamageType = ModContent.GetInstance<ChainClassDamage>();
        Item.damage = 5;
        Item.knockBack = 5f;
        Item.shoot = ModContent.ProjectileType<WoodenChainProjectile>();
        Item.shootSpeed = 4f;


        Item.value = Item.buyPrice(silver: 23);
        Item.rare = ItemRarityID.White;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ModContent.ItemType<WoodenString.WoodenString>(), 1)
            .AddIngredient(ModContent.ItemType<RichMahoganyWoodenString.RichMahoganyWoodenString>(), 1)
            .AddIngredient(ModContent.ItemType<ShadeWoodenString.ShadeWoodenString>(), 1)
            .AddIngredient(ModContent.ItemType<BorealWoodenString.BorealWoodenString>(), 1)
            .AddIngredient(ModContent.ItemType<PalmWoodenString.PalmWoodenString>(), 1)
            .AddIngredient(ItemID.TissueSample, 20)
            .AddTile(TileID.WorkBenches)
            .Register();

        CreateRecipe()
            .AddIngredient(ModContent.ItemType<WoodenString.WoodenString>(), 1)
            .AddIngredient(ModContent.ItemType<RichMahoganyWoodenString.RichMahoganyWoodenString>(), 1)
            .AddIngredient(ModContent.ItemType<EbonWoodenString.EbonWoodenString>(), 1)
            .AddIngredient(ModContent.ItemType<BorealWoodenString.BorealWoodenString>(), 1)
            .AddIngredient(ModContent.ItemType<PalmWoodenString.PalmWoodenString>(), 1)
            .AddIngredient(ItemID.ShadowScale, 20)
            .AddTile(TileID.Anvils)
            .Register();
    }
}*/

