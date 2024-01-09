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

namespace RuinMod.Content.Weapons.GamerClassWeapons.PreHardmode.HammerheadMorty;

internal class HammerheadMorty : ModItem
{
    public override void SetStaticDefaults()
    {
        //DisplayName.SetDefault("Hammerhead Morty");
        //Tooltip.SetDefault("'Aww Jeez!'");
    }

    public override void SetDefaults()
    {
        Item.width = 102;
        Item.height = 84;
        Item.scale -= .5f;

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 40;
        Item.useAnimation = 40;
        Item.autoReuse = true;

        Item.damage = 38;
        Item.ArmorPenetration += 1;
        Item.DamageType = ModContent.GetInstance<GamerClassDamage>();
        Item.crit = -4;
        Item.knockBack = 6.5f;

        Item.rare = ModContent.RarityType<GamerClassRarity>();

        Item.UseSound = SoundID.Item1;
    }
    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.GoldHammer)
            .AddIngredient(ItemID.DemoniteBar, 24)
            .AddTile(TileID.Anvils)
            .Register();

        CreateRecipe()
            .AddIngredient(ItemID.PlatinumHammer)
            .AddIngredient(ItemID.DemoniteBar, 24)
            .AddTile(TileID.Anvils)
            .Register();

        CreateRecipe()
            .AddIngredient(ItemID.GoldHammer)
            .AddIngredient(ItemID.CrimtaneBar, 24)
            .AddTile(TileID.Anvils)
            .Register();

        CreateRecipe()
           .AddIngredient(ItemID.PlatinumHammer)
           .AddIngredient(ItemID.CrimtaneBar, 24)
           .AddTile(TileID.Anvils)
           .Register();
    }
}*/
