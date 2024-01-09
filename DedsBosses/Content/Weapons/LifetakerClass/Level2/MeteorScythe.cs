using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using DedsBosses.Content.Projectiles.ProjectilesAllClasses.LifetakerClass.Level2.Spinning;
using DedsBosses.Content.Projectiles.ProjectilesAllClasses.LifetakerClass.Level2.Throwable;
using DedsBosses.Content.DamageClasses;
using System;

namespace DedsBosses.Content.Weapons.LifetakerClass.Level2
{
    public class MeteorScythe : ModItem
    {
        int spinScythe = ModContent.ProjectileType<SpinningMeteorScythe>();
        int throwScythe = ModContent.ProjectileType<ThrowableMeteorScythe>();
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 52;
            Item.height = 46;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 60;
            Item.useAnimation = 60;
            Item.autoReuse = true;
            Item.noUseGraphic = true;
            Item.channel = true;

            Item.DamageType = ModContent.GetInstance<LifetakerDamageClass>();
            Item.damage = 24;
            Item.knockBack = 3f;
            Item.noMelee = true;
            Item.shoot = spinScythe;
            Item.shootSpeed = 2f; //Throwable Proj speed
            Item.ArmorPenetration += 1;

            Item.rare = ItemRarityID.Blue;

            Item.UseSound = SoundID.Item104;
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool? UseItem(Player player)
        {
            // Calculate the angle for the current meteor
            int meteorCount = Main.rand.Next(5, 11);

            float angleOffset = MathHelper.TwoPi / meteorCount; // Angle between each meteor

            // Calculate a random number between 1 and 100
            int chance = Main.rand.Next(1, 101);

            // Set the poison chance percentage (e.g., 5% chance)
            int meteorChance = 80; // Adjust this value as needed

            if (chance <= meteorChance)
            {
                for (int i = 0; i < meteorCount; i++)
                {
                    // Calculate the spawn position above the player off the screen
                    Vector2 spawnPosition = new Vector2(Main.MouseWorld.X + Main.rand.NextFloat(10f, 15f), player.Center.Y - Main.screenHeight + 500f);

                    Vector2 velocity = new Vector2(Main.rand.NextFloat(-3f, 3f), Main.rand.NextFloat(10f, 15f));

                    // Spawn the meteor projectile
                    int projectileType = Main.rand.Next(new int[] { ProjectileID.Meteor1, ProjectileID.Meteor2, ProjectileID.Meteor3 });
                    int projectileIndex = Projectile.NewProjectile(null, spawnPosition, velocity, projectileType, Item.damage, 0f, Main.myPlayer);
                }
            }

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