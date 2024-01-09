/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;
using RuinMod.Content.Projectiles.GamerClass.HallowCannon;
using Terraria.GameContent.Creative;
using RuinMod.Content.Classes.GamerClass;
using RuinMod.Content.Rarity;
using RuinMod.Content.Items.Drops.EssencesOrSoulsOrFragments.Souls.SoulOfBlight;

namespace RuinMod.Content.Weapons.GamerClassWeapons.Hardmode.HallowCannon
{
    internal class HallowCannon : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Hallow Cannon");
            //Tooltip.SetDefault("'To break a few eggs, you have to kill a goblin'");
        }
        public override void SetDefaults()
        {
            Item.width = 76;
            Item.height = 20;

            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useTime = 17;
            Item.useAnimation = 17;

            Item.damage = 50;
            Item.DamageType = GetInstance<GamerClassDamage>();
            Item.knockBack = 2.5f;
            Item.autoReuse = true;
            Item.crit = -4;

            Item.shootSpeed = 11f;
            Item.shoot = ProjectileType<HallowCannonProjectile>();
            Item.useAmmo = AmmoID.Bullet;
            Item.noMelee = true;
            Item.UseSound = SoundID.Item5;

            Item.rare = RarityType<GamerClassRarity>();
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            const int NumProjectiles = 2;

            for (int i = 0; i < NumProjectiles; i++)
            {
                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(5));

                newVelocity *= 1f - Main.rand.NextFloat(0.3f);

                Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
            }
            return false;
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            type = ProjectileType<HallowCannonProjectile>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.HallowedBar, 20)
                .AddIngredient(ItemID.IllegalGunParts, 1)
                .AddIngredient(ItemType<SoulOfBlight>(), 20)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}*/
