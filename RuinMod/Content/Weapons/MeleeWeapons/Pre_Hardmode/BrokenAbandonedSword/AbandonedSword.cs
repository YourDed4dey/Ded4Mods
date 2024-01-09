/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using RuinMod.Content.Weapons.MeleeWeapons.Pre_Hardmode.BrokenAbandonedSword;
using Microsoft.Xna.Framework;

namespace RuinMod.Content.Weapons.MeleeWeapons.Pre_Hardmode.BrokenAbandonedSword;

internal class AbandonedSword : ModItem
{
    public override void SetStaticDefaults()
    {
        //DisplayName.SetDefault("Broken Abandoned Sword");
        //Tooltip.SetDefault("'Fixing this Might be worth it'");
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 40;
        Item.height = 40;

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 10;
        Item.useAnimation = 10;
        Item.autoReuse = true;

        Item.DamageType = DamageClass.Melee;
        Item.damage = 49;
        Item.knockBack = 5f;
        Item.crit = 14;

        Item.value = Item.buyPrice(gold: 3, silver: 28);
        Item.rare = ItemRarityID.LightRed;

        Item.UseSound = SoundID.Item1;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ModContent.ItemType<Content.Items.LostFragment.LostFragment>(), 25)
            .AddIngredient(ModContent.ItemType<Content.Items.LostFragment.Handle.LostFragmentHandle>(), 1)
            .AddTile(TileID.Anvils)
            .Register();
    }

}*/