/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using RuinMod.Content.Projectiles.ChainClass.SsargsSuffering;
using RuinMod.Content.Classes.ChainClass;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace RuinMod.Content.Weapons.ChainClassWeapons.Pre_Hardmode.SsargsSuffering;

internal class SsargsSuffering : ModItem
{
    public override void SetStaticDefaults()
    {
        //DisplayName.SetDefault("Ssarg's Suffering");
        //Tooltip.SetDefault("Has a chance to poison enemies\n'The vines of the jungle protect you'");
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
        Item.damage = 12;
        Item.knockBack = 5f;
        Item.shoot = ModContent.ProjectileType<SsargsSufferingProjectile>();
        Item.shootSpeed = 8f;
        Item.ArmorPenetration += -1;


        Item.value = Item.buyPrice(gold: 79);
        Item.rare = ItemRarityID.Orange;
    }

}*/
