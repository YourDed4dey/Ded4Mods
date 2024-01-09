/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using System;

namespace RuinMod.Content.Weapons.MeleeWeapons.Pre_Hardmode.StarStruck
{
    internal class StarStruck :ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Star Struck");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.StarWrath);
            Item.width = 46;
            Item.height = 48;

            Item.useTime = 36;
            Item.useAnimation = 36;

            Item.damage = 29;
            Item.shoot = ProjectileID.FallingStar;

            Item.rare = ItemRarityID.Green;
            Item.value = 0;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(3))
            {
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.YellowStarDust);
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.FallenStar, 15)
                .AddIngredient(ItemID.GoldBar, 10)
                .AddIngredient(ItemID.Ruby, 1)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}*/
