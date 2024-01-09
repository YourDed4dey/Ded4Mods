/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using RuinMod.Content.Projectiles.ChainClass.AngelsPain;
using RuinMod.Content.Classes.ChainClass;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace RuinMod.Content.Weapons.ChainClassWeapons.Pre_Hardmode.AngelsPain;

internal class AngelsPain : ModItem
{
    public override void SetStaticDefaults()
    {
        //DisplayName.SetDefault("Angel's Pain");
        //Tooltip.SetDefault("'The fury of the stars disposed to your command'");
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 32;

        Item.useStyle = ItemUseStyleID.Shoot;
        Item.useTime = 0;
        Item.useAnimation = 0;
        Item.autoReuse = true;
        Item.noUseGraphic = true;
        Item.channel = true;

        Item.DamageType = ModContent.GetInstance<ChainClassDamage>();
        Item.damage = 18;
        Item.knockBack = 5f;
        Item.shoot = ModContent.ProjectileType<AngelsPainProjectile>();
        Item.shootSpeed = 4f;


        Item.value = Item.buyPrice(gold:1);
        Item.rare = ItemRarityID.Green;
    }
}*/

