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
    public class ShadowbladeScythe : ModItem
    {
        int spinScythe = ModContent.ProjectileType<SpinningShadowbladeScythe>();
        int throwScythe = ModContent.ProjectileType<ThrowableShadowbladeScythe>();
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
            Item.damage = 27;
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

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int numProjectiles = 2;

            if (player.altFunctionUse == 2)
            {
                for (int i = 0; i < numProjectiles; i++)
                {
                    Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(30));

                    newVelocity *= 1f - Main.rand.NextFloat(.6f);

                    int proj = Projectile.NewProjectile(source, position, newVelocity, throwScythe, damage, knockback, player.whoAmI);
                    Main.projectile[proj].friendly = true;
                    Main.projectile[proj].hostile = false;
                }

                return false;
            }
            return true;
        }
    }
}