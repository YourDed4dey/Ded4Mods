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

namespace RuinMod.Content.Weapons.MagicWeapons.PreHardmode.EmeraldSpellBook
{
    internal class EmeraldSpellBook : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Emerald Spell Book");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 26;

            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useTime = 26;
            Item.useAnimation = 26;

            Item.autoReuse = true;

            Item.shootSpeed = 9f;
            Item.shoot = ProjectileType<Projectiles.NothingProjectile>();

            Item.DamageType = DamageClass.Magic;
            Item.damage = 25;
            Item.knockBack = 5f;
            Item.noMelee = true;

            Item.rare = ItemRarityID.Blue;
            Item.mana = 10;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            //int proj = Projectile.NewProjectile(source, position, velocity, ProjectileID.SaucerLaser, damage, knockback, player.whoAmI);
            int proj = Projectile.NewProjectile(source, position, velocity, ProjectileID.BrainScramblerBolt, damage, knockback, player.whoAmI);
            Main.projectile[proj].friendly = true;
            Main.projectile[proj].hostile = false;

            return true;
        }
    }
}*/
