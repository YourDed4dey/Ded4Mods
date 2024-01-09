/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using RuinMod.Content.Classes.GamerClass;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using RuinMod.Content.Rarity;

namespace RuinMod.Content.Weapons.GamerClassWeapons.Hardmode.RaygunMKII;

internal class RaygunMKII : ModItem
{
    public override void SetStaticDefaults()
    {
        //DisplayName.SetDefault("Raygun MK II");
        //Tooltip.SetDefault("'116?'");
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 122;
        Item.height = 52;
        Item.scale -= 0.40f;

        Item.useStyle = ItemUseStyleID.Shoot;
        Item.autoReuse = true;
        //Item.channel = true;

        Item.useAnimation = 10;
        Item.useTime = 3;
        Item.reuseDelay = 12;

        Item.DamageType = ModContent.GetInstance<GamerClassDamage>();
        Item.damage = 97;
        Item.shoot = ModContent.ProjectileType<Projectiles.NothingProjectile>();
        //Item.shoot = ProjectileID.GreenLaser;
        Item.crit = -4;
        Item.shootSpeed = 22f;
        Item.UseSound = SoundID.Item12;

        Item.rare = ModContent.RarityType<GamerClassRarity>();
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        int proj = Projectile.NewProjectile(source, position, velocity, ProjectileID.GreenLaser, damage, knockback, player.whoAmI);
        Main.projectile[proj].friendly = true;
        Main.projectile[proj].hostile = false;
        Main.projectile[proj].penetrate = 3;
        Main.projectile[proj].scale += 1f;

        return true;
    }
}*/
