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

namespace RuinMod.Content.Weapons.MagicWeapons.Hardmode.BookOfBreath
{
    internal class BookOfBreath : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Book of Breath ");
            //Tooltip.SetDefault("'The Breath of Spazmatism is in this book'");
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 32;

            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useTime = 15;
            Item.useAnimation = 15;

            Item.autoReuse = true;
            Item.channel = true;

            Item.shootSpeed = 9f;
            Item.shoot = ProjectileID.CursedFlameFriendly;

            Item.DamageType = DamageClass.Magic;
            Item.damage = 47;
            Item.knockBack = 5f;
            Item.noMelee = true;
            Item.UseSound = SoundID.Item100;

            Item.rare = ItemRarityID.Pink;
            Item.mana = 25;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
                int proj = Projectile.NewProjectile(source, position, velocity, ProjectileID.EyeFire, 47, knockback, player.whoAmI);
                Main.projectile[proj].friendly = true;
                Main.projectile[proj].hostile = false;

            return true;
        }
    }
}
