﻿using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using DedsBosses.Content.Projectiles.ProjectilesAllClasses.LifetakerClass.Level3.Spinning;
using DedsBosses.Content.Projectiles.ProjectilesAllClasses.LifetakerClass.Level3.Throwable;
using DedsBosses.Content.DamageClasses;

namespace DedsBosses.Content.Weapons.LifetakerClass.Level3
{
    public class TrueScytheOfSovereignty : ModItem
    {
        int spinScythe = ModContent.ProjectileType<SpinningTrueScytheOfSovereignty>();
        int throwScythe = ModContent.ProjectileType<ThrowableTrueScytheOfSovereignty>();
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 52;
            Item.height = 52;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 60;
            Item.useAnimation = 60;
            Item.autoReuse = true;
            Item.noUseGraphic = true;
            Item.channel = true;

            Item.DamageType = ModContent.GetInstance<LifetakerDamageClass>();
            Item.damage = 55;
            Item.knockBack = 3f;
            Item.noMelee = true;
            Item.shoot = spinScythe;
            Item.shootSpeed = 2f; //Throwable Proj speed
            Item.ArmorPenetration += 1;

            Item.rare = ItemRarityID.Yellow;

            Item.UseSound = SoundID.Item104;
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.altFunctionUse == 2)
            {
                int proj = Projectile.NewProjectile(source, position, velocity, throwScythe, damage, knockback, player.whoAmI);
                Main.projectile[proj].friendly = true;
                Main.projectile[proj].hostile = false;

                return false;
            }
            return true;
        }
    }
}