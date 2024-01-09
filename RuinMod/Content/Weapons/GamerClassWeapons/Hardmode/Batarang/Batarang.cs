/*using System;
using Microsoft.Xna.Framework;
using RuinMod.Content.Classes.GamerClass;
using RuinMod.Content.Projectiles.GamerClass.Batarang;
using RuinMod.Content.Rarity;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RuinMod.Content.Weapons.GamerClassWeapons.Hardmode.Batarang
{
    internal class Batarang : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Batarang");
            //Tooltip.SetDefault("'Now you only need the armor'");
        }

        public override void SetDefaults()
        {
            Item.width = 50;
            Item.height = 22;
            Item.noUseGraphic = true;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.autoReuse = true;

            Item.useAnimation = 14;
            Item.useTime = 14;

            Item.DamageType = ModContent.GetInstance<GamerClassDamage>();
            Item.damage = 45;
            Item.shoot = ModContent.ProjectileType<BatarangProjectile>();
            Item.noMelee = true;
            Item.knockBack = 6.5f;
            Item.crit -= 4;
            Item.ArmorPenetration = 5;
            Item.shootSpeed = 16f;
            Item.UseSound = SoundID.Item7;

            Item.rare = ModContent.RarityType<GamerClassRarity>();
        }
    }
}*/
