/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

using RuinMod.Content.Projectiles.ChainClass.ChainOfCosmos;
using RuinMod.Content.Projectiles.ChainClass.ChainOfCosmos.CosmosProjectiles;
using RuinMod.Content.Classes.ChainClass;

namespace RuinMod.Content.Weapons.ChainClassWeapons.Hardmode.ChainOfCosmos;

internal class ChainOfCosmos : ModItem
{
    public override void SetStaticDefaults()
    {
        //DisplayName.SetDefault("Gauntlet of Cosmos");
        //Tooltip.SetDefault("???");
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 60;
        Item.height = 50;

        Item.useStyle = ItemUseStyleID.Shoot;
        Item.useTime = 0;
        Item.useAnimation = 0;
        Item.autoReuse = true;
        Item.noUseGraphic = false;
        Item.channel = true;

        Item.DamageType = ModContent.GetInstance<ChainClassDamage>();
        Item.damage = 550;
        Item.knockBack = 8f;
        Item.crit = 35;
        Item.shoot = ModContent.ProjectileType<ChainOfCosmosProjectile>();
        Item.shootSpeed = 10f;
        Item.ArmorPenetration += -1;


        Item.value = Item.buyPrice(gold: 79);
        Item.rare = ItemRarityID.Red;
        Item.direction = 90;
    }

    public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
    {
        type = Main.rand.Next(new int[] { type, ModContent.ProjectileType<CosmosSsargsSuffering>(),ModContent.ProjectileType<CosmosWoodenChain>(),ModContent.ProjectileType<CosmosAngelsPain>(),ModContent.ProjectileType<CosmosChainOfSecrets>(),ModContent.ProjectileType<ChainOfCosmosProjectile>()});
    }
}*/
