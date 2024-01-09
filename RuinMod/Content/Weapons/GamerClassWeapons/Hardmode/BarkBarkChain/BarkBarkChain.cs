/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using RuinMod.Content.Projectiles.ChainClass.BarkBarkChain;
using RuinMod.Content.Classes.GamerClass;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using RuinMod.Content.Rarity;

namespace RuinMod.Content.Weapons.GamerClassWeapons.Hardmode.BarkBarkChain;

internal class BarkBarkChain : ModItem
{
    public override void SetStaticDefaults()
    {
        //DisplayName.SetDefault("Woof-Woof-Bark-Bark");
        //Tooltip.SetDefault("'High velocity dogs make a chain around your enemies'");
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

        Item.DamageType = ModContent.GetInstance<GamerClassDamage>();
        Item.damage = 300;
        Item.knockBack = 5f;
        Item.shoot = ModContent.ProjectileType<BarkBarkChainProjectile>();
        Item.shootSpeed = 8f;
        Item.ArmorPenetration += -1;

        Item.rare = ModContent.RarityType<GamerClassRarity>();
    }

}*/
