using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using DedsQOLMod.Content.Projectiles.FireCircle;
using System;
using System.Linq;
using Terraria.DataStructures;

namespace DedsQOLMod.Content.Weapons.MageClass.PreHardmode.GemmySpellBooks
{
    public class GemmyFireSpellBook : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 300;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 75;
            Item.width = 24;
            Item.height = 30;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.autoReuse = false;
            Item.UseSound = SoundID.Item8;
            Item.shoot = ModContent.ProjectileType<CircleOfFire>();
            Item.shootSpeed = 2f;
            Item.value = Item.sellPrice(silver: 5);
            Item.rare = ItemRarityID.Purple;
            Item.expert = true;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(4, 4);
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            damage = 1;
        }
        /*public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int proj = Projectile.NewProjectile(source, position, velocity, ProjectileID.Fireball, damage, knockback, player.whoAmI);
            Main.projectile[proj].friendly = true; 
            Main.projectile[proj].hostile = false;
            Main.projectile[proj].timeLeft = 200;
            return false;
        }*/
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            // Find and kill any existing projectiles of the same type owned by the player
            int projType = ModContent.ProjectileType<CircleOfFire>();
            for (int i = 0; i < Main.projectile.Length; i++)
            {
                Projectile proj = Main.projectile[i];

                if (proj.active && proj.type == projType && proj.owner == player.whoAmI)
                {
                    proj.Kill();
                }
            }

            // Create a new projectile
            int projIndex = Projectile.NewProjectile(source,position, velocity, projType, damage, knockback, player.whoAmI);

            return false;
        }
        public override bool CanUseItem(Player player)
        {
            //&& Main.projectile.Count(proj => proj.active && proj.type == ModContent.ProjectileType<CircleOfFire>()) < 2
            return player.statMana >= Item.mana;
        }
    }
}
