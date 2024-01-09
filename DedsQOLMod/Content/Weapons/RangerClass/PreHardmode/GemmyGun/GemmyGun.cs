using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using DedsQOLMod.Content.Projectiles.Gems;
using DedsQOLMod.Common.Global;
using DedsQOLMod.Common.Configs;
using Terraria.Audio;

namespace DedsQOLMod.Content.Weapons.RangerClass.PreHardmode.GemmyGun
{
    public class GemmyGun : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 60;
            Item.height = 20;

            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useTime = 45;
            Item.useAnimation = 45;

            Item.autoReuse = true;
            Item.channel = true;

            Item.shootSpeed = 4.5f; //9f or 20
            Item.shoot = ProjectileID.Bullet;

            Item.DamageType = DamageClass.Ranged;
            Item.damage = 15;
            Item.knockBack = 2f;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Bullet;
            //Item.UseSound = SoundID.Item40; //40 //41
            Item.UseSound = new SoundStyle($"{nameof(DedsQOLMod)}/Assets/Sounds/GemmyGunSound")
            {
                Volume = 0.5f,
                PitchVariance = 0.2f,
                MaxInstances = 3,
            };

            Item.rare = ItemRarityID.Purple;
            Item.master = true;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-8f, -3f);
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int numProjectiles = 3;

            int[] gemProjectiles = new int[]
            {
                ModContent.ProjectileType<Amber>(),
                ModContent.ProjectileType<Amethyst>(),
                ModContent.ProjectileType<Diamond>(),
                ModContent.ProjectileType<Emerald>(),
                ModContent.ProjectileType<Ruby>(),
                ModContent.ProjectileType<Sapphire>(),
                ModContent.ProjectileType<Topaz>()
            };
            int randomProjectileIndex = Main.rand.Next(gemProjectiles.Length);
            int randomProjectileType = gemProjectiles[randomProjectileIndex];

            // Increase numProjectiles based on damage
            if (damage >= 25)
            {
                numProjectiles += 1;
            }
            if (damage >= 29)
            {
                numProjectiles += 1;
            }
            if (damage >= 30)
            {
                numProjectiles += 1;
            }

            // Chance to increase the number of projectiles to 6
            if (Main.rand.NextFloat() <= 0.05f)
            {
                numProjectiles *= 2;
            }

            for (int i = 0; i < numProjectiles; i++)
            {
                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(30));

                newVelocity *= 1f - Main.rand.NextFloat(0.3f);

                int proj = Projectile.NewProjectile(source, position, newVelocity, randomProjectileType, damage, knockback, player.whoAmI);
                Main.projectile[proj].friendly = true;
                Main.projectile[proj].hostile = false;
            }

            return false;
        }
    }
}
