/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using RuinMod.Content.Classes.GamerClass;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using RuinMod.Content.Rarity;

namespace RuinMod.Content.Weapons.GamerClassWeapons.Hardmode.ThePortalGun;

internal class ThePortalGun : ModItem
{
    public override void SetStaticDefaults()
    {
        //DisplayName.SetDefault("The Portal Gun");
        //Tooltip.SetDefault("'Snap back to reality'");
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 24;
        Item.height = 18;
        Item.scale += 0.15f;

        Item.useStyle = ItemUseStyleID.Shoot;
        //Item.useTime = 20;
        //Item.useAnimation = 20;
        Item.autoReuse = true;
        Item.channel = true;

        Item.useAnimation = 16;
        Item.useTime = 16;
        Item.reuseDelay = 16;

        Item.DamageType = ModContent.GetInstance<GamerClassDamage>();
        Item.damage = 67;
        Item.crit = -4;
        Item.knockBack = 6.5f;
        Item.shoot = ProjectileID.ChlorophyteBullet;
        Item.shootSpeed = 15f;
        Item.UseSound = SoundID.Item114;

        Item.rare = ModContent.RarityType<GamerClassRarity>();
    }
}*/
