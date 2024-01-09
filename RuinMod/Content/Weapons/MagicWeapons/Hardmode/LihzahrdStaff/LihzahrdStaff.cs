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
using RuinMod.Content.Projectiles;

namespace RuinMod.Content.Weapons.MagicWeapons.Hardmode.LihzahrdStaff
{
    internal class LihzahrdStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Lihzahrd Staff");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.MeteorStaff);
            Item.width = 34;
            Item.height = 34;
            Item.scale += .5f;

            Item.useStyle = ItemUseStyleID.Thrust;
            Item.useTime = 15;
            Item.useAnimation = 15;

            Item.autoReuse = true;
            Item.channel = true;

            Item.shootSpeed = 15f;
            Item.shoot = ProjectileType<NothingProjectile>();

            Item.DamageType = DamageClass.Magic;
            Item.damage = 50;
            Item.knockBack = 3f;
            //Item.noMelee = true;
            Item.UseSound = SoundID.Item20;

            Item.rare = ItemRarityID.Yellow;
            Item.mana = 10;
            Item.value = 0;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int proj = Projectile.NewProjectile(source, position, velocity, ProjectileID.SalamanderSpit, 50, knockback, player.whoAmI);
            Main.projectile[proj].friendly = true;
            Main.projectile[proj].hostile = false;

            return true;
        }
    }
}*/
