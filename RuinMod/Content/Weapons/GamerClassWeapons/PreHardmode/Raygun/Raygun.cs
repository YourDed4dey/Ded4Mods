/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using RuinMod.Content.Classes.GamerClass;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using RuinMod.Content.Rarity;
using RuinMod.Content.Items.Placeables.TV.Tile;

namespace RuinMod.Content.Weapons.GamerClassWeapons.PreHardmode.Raygun;

internal class Raygun : ModItem
{
    public override void SetStaticDefaults()
    {
        //DisplayName.SetDefault("Raygun");
        //Tooltip.SetDefault("'115'");
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 52;
        Item.height = 38;
        Item.scale -= 0.20f;

        Item.useStyle = ItemUseStyleID.Shoot;
        Item.autoReuse = true;
        //Item.channel = true;

        Item.useAnimation = 21;
        Item.useTime = 7;
        Item.reuseDelay = 23;

        Item.DamageType = ModContent.GetInstance<GamerClassDamage>();
        Item.damage = 36;
        Item.shoot = ModContent.ProjectileType<Projectiles.NothingProjectile>();
        //Item.shoot = ProjectileID.GreenLaser;
        Item.crit = -4;
        Item.shootSpeed = 12f;
        Item.knockBack = 2f;
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

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.Glass, 25)
            .AddIngredient(ItemID.HellstoneBar, 15)
            .AddIngredient(ItemID.GoldBar, 30)
            .AddTile<TVTile>()
            .Register();

        CreateRecipe()
            .AddIngredient(ItemID.Glass, 25)
            .AddIngredient(ItemID.HellstoneBar, 15)
            .AddIngredient(ItemID.PlatinumBar, 30)
            .AddTile<TVTile>()
            .Register();
    }
}*/
