using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Mono.Cecil;


namespace RuinMod.Content.Weapons.MeleeWeapons.Hardmode.StarIndignation
{
    internal class StarIndignation : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Star Indignation");
        }
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Starfury);
            Item.width = 50;
            Item.height = 50;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 16;
            Item.useAnimation = 16;
            Item.autoReuse = true;

            Item.DamageType = DamageClass.Melee;
            Item.damage = 100;
            Item.crit = 12;
            Item.knockBack = 5f;
            Item.ArmorPenetration += 5;

            Item.shoot = ProjectileID.SuperStar;
            Item.shootSpeed = 18f;

            Item.value = 0;
            Item.rare = ItemRarityID.Pink;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.controlUseItem == true)
            {
                int proj = Projectile.NewProjectile(source, Main.MouseWorld, velocity, ProjectileID.SuperStar, damage, knockback, player.whoAmI);
                Main.projectile[proj].timeLeft = 1;

                float maxSpeed = 12f;
                float speed = 12f;
                Vector2 direction = Main.MouseWorld - Main.projectile[proj].Center;

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

                Main.projectile[proj].rotation += 0.1f * (float)Main.projectile[proj].direction;
                Main.projectile[proj].spriteDirection = Main.projectile[proj].direction;
            }

            
            return true;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(3))
            {
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.YellowStarDust);
            }
        }
    }
}
