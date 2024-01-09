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

namespace RuinMod.Content.Weapons.RangeWeapons.Hardmode.SammyTheBow
{
    internal class SammyTheBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Sammy The Bow");
            //Tooltip.SetDefault("'I am Sammy, and I am a bow!'");
            //Turns arrows into stars\n
        }

        public override void SetDefaults()
        {
            Item.width = 34;
            Item.height = 96;
            Item.scale -= 0.25f;

            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useTime = 25;
            Item.useAnimation = 25;

            Item.DamageType = DamageClass.Ranged;
            Item.damage = 75;
            Item.autoReuse = true;

            Item.shootSpeed = 10f;
            Item.useAmmo = AmmoID.FallenStar;
            Item.shoot = ProjectileID.SuperStar;

            Item.rare = ItemRarityID.Pink;
            Item.UseSound = SoundID.Item5;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            const int NumProjectiles = 3;

            for (int i = 0; i < NumProjectiles; i++)
            {
                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(15));

                newVelocity *= 1f - Main.rand.NextFloat(0.3f);

                Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
            }
            return false;
        }
    }
}
