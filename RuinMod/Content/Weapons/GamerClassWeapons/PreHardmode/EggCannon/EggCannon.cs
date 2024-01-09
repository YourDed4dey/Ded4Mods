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
using RuinMod.Content.Projectiles.GamerClass.EggCannon;
using Terraria.GameContent.Creative;
using RuinMod.Content.Classes.GamerClass;
using RuinMod.Content.Rarity;

namespace RuinMod.Content.Weapons.GamerClassWeapons.PreHardmode.EggCannon
{
    internal class EggCannon : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Egg Cannon");
            //Tooltip.SetDefault("'To kill a goblin, you have to break a few eggs'");
        }
        public override void SetDefaults()
        {
            Item.width = 56;
            Item.height = 20;

            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useTime = 30;
            Item.useAnimation = 30;

            Item.damage = 14;
            Item.DamageType = GetInstance<GamerClassDamage>();
            Item.knockBack = .5f;
            Item.autoReuse = true;
            Item.crit = -4;

            Item.shootSpeed = 7f;
            Item.shoot = ProjectileType<EggCannonProjectile>();
            Item.useAmmo = AmmoID.Bullet;
            Item.noMelee = true;
            Item.UseSound = SoundID.Item5;

            Item.rare = ModContent.RarityType<GamerClassRarity>();
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            type = ProjectileType<EggCannonProjectile>();
        }
    }
}*/
