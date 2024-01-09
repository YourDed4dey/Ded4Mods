/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using System;

namespace RuinMod.Content.Weapons.MeleeWeapons.Pre_Hardmode.StarButcherer
{
    internal class StarButcherer : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Star Butcherer");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Starfury);
            Item.width = 40;
            Item.height = 48;

            Item.useTime = 25;
            Item.useAnimation = 25;

            Item.damage = 44;

            Item.rare = ItemRarityID.Orange;
            Item.value = 0;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int proj = Projectile.NewProjectile(source, Main.MouseWorld, velocity, ProjectileID.Starfury, damage, knockback, player.whoAmI);
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

            if (Main.projectile[proj].alpha > 70)
            {
                Main.projectile[proj].alpha -= 15;
                if (Main.projectile[proj].alpha < 70)
                {
                    Main.projectile[proj].alpha = 70;
                }
            }
            if (Main.projectile[proj].localAI[0] == 0f)
            {
                AdjustMagnitude(ref Main.projectile[proj].velocity);
                Main.projectile[proj].localAI[0] = 1f;
            }
            Vector2 move = Vector2.Zero;
            float distance = 400f;
            bool target = false;
            for (int k = 0; k < 200; k++)
            {
                if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5)
                {
                    Vector2 newMove = Main.npc[k].Center - Main.projectile[proj].Center;
                    float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
                    if (distanceTo < distance)
                    {
                        move = newMove;
                        distance = distanceTo;
                        target = true;
                    }
                }
            }
            if (target)
            {
                AdjustMagnitude(ref move);
                Main.projectile[proj].velocity = (10 * Main.projectile[proj].velocity + move) / 11f;
                AdjustMagnitude(ref Main.projectile[proj].velocity);
            }
            return true;
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(3))
            {
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.CrimsonPlants);
            }
        }

        private void AdjustMagnitude(ref Vector2 vector)
        {
            float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (magnitude > 6f)
            {
                vector *= 6f / magnitude;
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Starfury, 1)
                .AddIngredient(ItemID.BloodButcherer, 1)
                .AddIngredient(ItemID.HellstoneBar, 15)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}*/
