﻿/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using RuinMod.Content.Projectiles.ChainClass.WoodenChain.BorealWoodenStringProjectile;
using RuinMod.Content.Classes.ChainClass;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace RuinMod.Content.Weapons.ChainClassWeapons.Pre_Hardmode.WoodenChain.BorealWoodenString;

internal class BorealWoodenString : ModItem
{
    public override void SetStaticDefaults()
    {
        //DisplayName.SetDefault("Boreal Wooden String");
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 74;
        Item.height = 26;

        Item.useStyle = ItemUseStyleID.Shoot;
        Item.useTime = 0;
        Item.useAnimation = 0;
        Item.autoReuse = true;
        Item.noUseGraphic = true;
        Item.channel = true;

        Item.DamageType = ModContent.GetInstance<ChainClassDamage>();
        Item.damage = 2;
        Item.crit = 2;
        Item.shoot = ModContent.ProjectileType<BorealWoodenStringProjectile>();
        Item.shootSpeed = 2f;


        Item.value = Item.buyPrice(silver: 23);
        Item.rare = ItemRarityID.White;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.BorealWood, 16)
            .AddIngredient(ItemID.Chain, 5)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}*/

