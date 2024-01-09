/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using RuinMod.Content.Projectiles.ChainClass.HerosChain;
using RuinMod.Content.Classes.ChainClass;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace RuinMod.Content.Weapons.ChainClassWeapons.Hardmode.HerosChain;

internal class HerosChain : ModItem
{
    public override void SetStaticDefaults()
    {
        //DisplayName.SetDefault("Hero's Chain");
        //Tooltip.SetDefault("'A unknown hero rests in this chain'");
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 52;
        Item.height = 34;

        Item.useStyle = ItemUseStyleID.Shoot;
        Item.useTime = 0;
        Item.useAnimation = 0;
        Item.autoReuse = true;
        Item.noUseGraphic = true;
        Item.channel = true;

        Item.DamageType = ModContent.GetInstance<ChainClassDamage>();
        Item.damage = 30;
        Item.knockBack = 5f;
        Item.shoot = ModContent.ProjectileType<HerosChainProjectile>();
        Item.shootSpeed = 12f; //8f
        Item.ArmorPenetration += -1;


        Item.value = Item.buyPrice(gold: 79);
        Item.rare = ItemRarityID.Pink;
    }

}*/
