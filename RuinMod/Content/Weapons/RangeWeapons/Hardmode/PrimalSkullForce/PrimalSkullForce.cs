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
using RuinMod.Content.Projectiles.Ranged.MiniSkull;

namespace RuinMod.Content.Weapons.RangeWeapons.Hardmode.PrimalSkullForce
{
    internal class PrimalSkullForce : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Primal Skull Force");
            //Tooltip.SetDefault("'Forces of mechanical power shoot trough this gun'");
        }

        public override void SetDefaults()
        {
            Item.width = 31;
            Item.height = 20;
            Item.scale += .5f;

            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useTime = 5;
            Item.useAnimation = 5;

            Item.autoReuse = true;
            Item.channel = true;

            Item.shootSpeed = 14f; //9f or 20
            Item.shoot = ModContent.ProjectileType<MiniSkullProjectile>();

            Item.DamageType = DamageClass.Ranged;
            Item.damage = 35;
            Item.knockBack = 5f;
            Item.noMelee = true;
            Item.useAmmo = ItemType<Items.Ammo.MiniSkull.MiniSkull>();
            Item.UseSound = SoundID.Item12;

            Item.rare = ItemRarityID.Pink;
        }
        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= .80f;
        }
    }
}
