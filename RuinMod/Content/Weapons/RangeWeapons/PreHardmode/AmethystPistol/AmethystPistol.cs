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

namespace RuinMod.Content.Weapons.RangeWeapons.PreHardmode.AmethystPistol
{
    internal class AmethystPistol : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Amethyst Pistol");
        }

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 14;
            //Item.scale += .5f;

            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useTime = 15;
            Item.useAnimation = 15;

            Item.damage = 23;
            Item.DamageType = DamageClass.Ranged;
            Item.knockBack = 5;
            Item.autoReuse = true;

            Item.shoot = AmmoID.Bullet;
            Item.shootSpeed = 8f;
            Item.useAmmo = AmmoID.Bullet;

            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item41;
        }


        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Amethyst, 13)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}*/
