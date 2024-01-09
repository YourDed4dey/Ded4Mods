/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using RuinMod.Content.Projectiles.ChainClass.SsargsSuffering;
using RuinMod.Content.Classes.ChainClass;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace RuinMod.Content.Weapons.ChainClassWeapons.Pre_Hardmode.HerculesChains;

internal class HerculesChains : ModItem
{
    public override void SetStaticDefaults()
    {
        //DisplayName.SetDefault("Hercule's Chains");
        //Tooltip.SetDefault("");
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 14;
        Item.height = 64;

        Item.useStyle = ItemUseStyleID.Shoot;
        Item.useTime = 0;
        Item.useAnimation = 0;
        Item.autoReuse = true;
        Item.noUseGraphic = true;
        Item.channel = true;

        Item.DamageType = ModContent.GetInstance<ChainClassDamage>();
        Item.damage = 21;
        Item.knockBack = 5f;
        Item.shoot = ModContent.ProjectileType<Content.Projectiles.ChainClass.HerculesChains.HerculesChainsProjectile>();
        Item.shootSpeed = 5f;
        Item.ArmorPenetration += -1;


        Item.value = Item.buyPrice(gold: 79);
        Item.rare = ItemRarityID.Orange;
    }

}*/
