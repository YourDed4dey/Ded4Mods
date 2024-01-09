using System;
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
using RuinMod.Content.Projectiles.Ranged.VortexStar;

namespace RuinMod.Content.Weapons.RangeWeapons.Hardmode.VortexCannon
{
    internal class VortexTriCannon : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Vortex TriCannon");
            //Tooltip.SetDefault("'Send your financial worries to space!'");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.SuperStarCannon);
            Item.useTime = 6;
            Item.useAnimation = 6;

            Item.damage = 82;

            Item.shootSpeed = 20f;
            Item.shoot = ModContent.ProjectileType<VortexStar>();

            Item.rare = ItemRarityID.Red;
            Item.value = 0;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            const int NumProjectiles = 2;

            for (int i = 0; i < NumProjectiles; i++)
            {
                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(15));

                newVelocity *= 1f - Main.rand.NextFloat(0.3f);

                Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
            }

            return false;
        }


        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.SuperStarCannon)
                .AddIngredient(ItemID.LunarBar, 25)
                .AddIngredient(ItemID.FragmentVortex, 10)
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }

        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= .52f;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-2f, -2f);
        }
    }
}
