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
using RuinMod.Content.Weapons.RangeWeapons.PreHardmode.SapphireBow;

namespace RuinMod.Content.Weapons.RangeWeapons.PreHardmode.AncientArc
{
    internal class AncientArcRed : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Ancient Arc");
            //Tooltip.SetDefault("Arrows turn into columns of bees and flaming arrows\n'Hungry and bloody creatures eat your insides'");
        }
        public override void SetDefaults()
        {
            Item.width = 58;
            Item.height = 60;

            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useTime = 11;
            Item.useAnimation = 11;

            Item.damage = 51;
            Item.DamageType = DamageClass.Ranged;
            Item.knockBack = 5.5f;
            Item.autoReuse = true;

            Item.shoot = AmmoID.Arrow;
            Item.shootSpeed = 8f;
            Item.useAmmo = AmmoID.Arrow;

            Item.rare = ItemRarityID.Orange;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int proj = Projectile.NewProjectile(source, position, velocity, ProjectileID.FlamingArrow, damage, knockback, player.whoAmI);
            Main.projectile[proj].friendly = true;
            Main.projectile[proj].hostile = false;

            return true;
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            velocity = velocity.RotatedByRandom(MathHelper.ToRadians(20));
            type = Main.rand.Next(new int[] { type, ProjectileID.BeeArrow });
            Main.projectile[type].friendly = true;
            Main.projectile[type].timeLeft = 15;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.BeesKnees, 1)
                .AddIngredient(ItemID.MoltenFury, 1)
                .AddIngredient(ItemType<SapphireBow.SapphireBow>(), 1)
                .AddIngredient(ItemID.CrimtaneBar, 11)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}*/
