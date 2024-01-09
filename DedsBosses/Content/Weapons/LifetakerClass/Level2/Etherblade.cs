using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using DedsBosses.Content.Projectiles.ProjectilesAllClasses.LifetakerClass.Level2.Spinning;
using DedsBosses.Content.Projectiles.ProjectilesAllClasses.LifetakerClass.Level2.Throwable;
using DedsBosses.Content.DamageClasses;

namespace DedsBosses.Content.Weapons.LifetakerClass.Level2
{
    public class Etherblade : ModItem
    {
        int spinScythe = ModContent.ProjectileType<SpinningEtherblade>();
        int throwScythe = ModContent.ProjectileType<ThrowableEtherblade>();
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
            Item.damage = 26;
            Item.knockBack = 3f;
            Item.noMelee = true;
            Item.shoot = spinScythe;
            Item.shootSpeed = 2f; //Throwable Proj speed
            Item.ArmorPenetration += 1;

            Item.rare = ItemRarityID.Green;

            Item.UseSound = SoundID.Item104;
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool? UseItem(Player player)
        {
            // Calculate the angle for the current meteor
            int starScytheCount = Main.rand.Next(1,1);

            // Calculate a random number between 1 and 100
            int chance = Main.rand.Next(1, 101);

            // Set the poison chance percentage (e.g., 5% chance)
            int starScytheChance = 60; // Adjust this value as needed

            if (chance <= starScytheChance)
            {
                for (int i = 0; i < starScytheCount; i++)
                {
                    // Calculate the spawn position above the player off the screen
                    Vector2 spawnPosition = new Vector2(Main.MouseWorld.X, player.Center.Y - Main.screenHeight + 500f);

                    Vector2 velocity = new Vector2(Main.rand.NextFloat(0f, 1f), Main.rand.NextFloat(5f, 10f));

                    // Spawn the meteor projectile
                    int projectileType = ModContent.ProjectileType<ThrowableEtherblade>();
                    int projectileIndex = Projectile.NewProjectile(null, spawnPosition, velocity, projectileType, Item.damage, 0f, Main.myPlayer);
                    Main.projectile[projectileIndex].timeLeft = 60*60;
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