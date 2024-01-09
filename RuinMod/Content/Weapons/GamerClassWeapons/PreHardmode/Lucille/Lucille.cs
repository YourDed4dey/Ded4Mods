/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using RuinMod.Content.Classes.GamerClass;
using System.Collections.Generic;
using System.Linq;
using RuinMod.Content.Rarity;

namespace RuinMod.Content.Weapons.GamerClassWeapons.PreHardmode.Lucille
{
    internal class Lucille : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Lucille");
            //Tooltip.SetDefault("'Lucille is thirsty! She is a vampire bat!'");
        }

        public override void SetDefaults()
        {
            Item.width = 65;
            Item.height = 63;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.autoReuse = true;

            Item.damage = 18;
            Item.ArmorPenetration += 1;
            Item.DamageType = ModContent.GetInstance<GamerClassDamage>();
            Item.crit += 8;
            Item.knockBack = 3.5f;

            Item.rare = ModContent.RarityType<GamerClassRarity>();

            Item.UseSound = SoundID.Item1;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(10))
            {
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Blood);
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddRecipeGroup(RecipeGroupID.Wood, 140)
                .AddIngredient(ItemID.Chain, 25)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}*/
