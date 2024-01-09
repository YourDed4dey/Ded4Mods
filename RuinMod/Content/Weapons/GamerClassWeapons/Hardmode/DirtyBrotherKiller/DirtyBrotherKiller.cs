/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using RuinMod.Content.Classes.GamerClass;
using System.Collections.Generic;
using System.Linq;
using RuinMod.Content.Rarity;

namespace RuinMod.Content.Weapons.GamerClassWeapons.Hardmode.DirtyBrotherKiller;

internal class DirtyBrotherKiller : ModItem
{
    public override void SetStaticDefaults()
    {
        //DisplayName.SetDefault("Dirty Brother Killer");
        //Tooltip.SetDefault("'You feel like you are going to have a bad time'");
    }

    public override void SetDefaults()
    {
        //Item.CloneDefaults(ItemID.Arkhalis);
        /*Item.width = 60;
        Item.height = 60;
        Item.scale = 1.5f;

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 20;
        Item.useAnimation = 20;
        Item.autoReuse = true;

        Item.DamageType = DamageClass.Melee;
        Item.damage = 210;
        Item.shootSpeed = 12f;
        Item.ArmorPenetration += 10;


        Item.value = Item.buyPrice(gold: 59);
        Item.rare = ItemRarityID.Yellow;

        Item.UseSound = SoundID.Item1;*/
        /*Item.width = 44;
        Item.height = 48;

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 5;
        Item.useAnimation = 5;
        Item.autoReuse = true;

        Item.damage = 200;
        Item.ArmorPenetration += 10;
        Item.DamageType = ModContent.GetInstance<GamerClassDamage>();
        Item.shoot = ModContent.ProjectileType<Projectiles.NothingProjectile>();

        Item.rare = ModContent.RarityType<GamerClassRarity>();

        Item.UseSound = SoundID.Item1;
    }
    public override bool AltFunctionUse(Player player)
    {
        return true;
    }
    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        if (player.altFunctionUse == 2)
        {
            int proj = Projectile.NewProjectile(source, Main.MouseWorld, velocity, ModContent.ProjectileType<Content.Projectiles.MeleeProjectiles.DirtyBrotherKiller.DirtyBrotherKillerSlashProjectile>(), damage, knockback, player.whoAmI);
            Main.projectile[proj].friendly = true;
            Main.projectile[proj].hostile = false;

            float maxSpeed = 0f;
            float speed = 0f;
            Vector2 direction = Main.MouseWorld - Main.projectile[proj].position * speed + Main.projectile[proj].velocity;

            Main.projectile[proj].velocity = direction * speed;

            Main.projectile[proj].velocity = direction * speed;

            if (Main.projectile[proj].velocity.X > maxSpeed)
                Main.projectile[proj].velocity.X = maxSpeed;
            else if (Main.projectile[proj].velocity.X < -maxSpeed)
                Main.projectile[proj].velocity.X = -maxSpeed;
            if (Main.projectile[proj].velocity.Y > maxSpeed)
                Main.projectile[proj].velocity.Y = maxSpeed;
            else if (Main.projectile[proj].velocity.Y < -maxSpeed)
                Main.projectile[proj].velocity.Y = -maxSpeed;
        }

        return true;
    }
}*/
