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

namespace RuinMod.Content.Weapons.RangeWeapons.PreHardmode.SapphireBow
{
    internal class SapphireBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Sapphire Bow");
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 32;

            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useTime = 26;
            Item.useAnimation = 26;

            Item.damage = 23;
            Item.DamageType = DamageClass.Ranged;
            Item.knockBack = 5;
            Item.autoReuse = true;

            Item.shoot = AmmoID.Arrow;
            Item.shootSpeed = 8f;
            Item.useAmmo = AmmoID.Arrow;

            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item5;
        }


        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Sapphire, 13)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}*/
