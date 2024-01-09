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

namespace RuinMod.Content.Weapons.GamerClassWeapons.PreHardmode.SledgesHammer
{
    internal class SledgesHammer : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Sledge's Hammer");
            //Tooltip.SetDefault("'It can only break wooden walls'");
        }

        public override void SetDefaults()
        {
            Item.width = 65;
            Item.height = 58;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 45;
            Item.useAnimation = 45;
            Item.autoReuse = true;

            Item.damage = 26;
            Item.ArmorPenetration += 1;
            Item.DamageType = ModContent.GetInstance<GamerClassDamage>();
            Item.crit = -4;
            Item.knockBack = 5f;

            Item.rare = ModContent.RarityType<GamerClassRarity>();

            Item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.DemoniteBar, 20)
                .AddTile(TileID.Anvils)
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.CrimtaneBar, 20)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}*/
