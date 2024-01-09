/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using RuinMod.Content.Projectiles.ChainClass.ChainOfSecrets;
using RuinMod.Content.Classes.ChainClass;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace RuinMod.Content.Weapons.ChainClassWeapons.Hardmode.ChainOfSecrets;

internal class ChainOfSecrets : ModItem
{
    public override void SetStaticDefaults()
    {
        //DisplayName.SetDefault("Chain of Secrets");
        //Tooltip.SetDefault("'Untold secrets await the awakening'\nInflicts 'Cursed Inferno' debuff on enemies for 5 seconds");
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 74;
        Item.height = 26;

        Item.useStyle = ItemUseStyleID.Shoot;
        Item.useTime = 0;
        Item.useAnimation = 0;
        Item.autoReuse = true;
        Item.noUseGraphic = true;
        Item.channel = true;

        Item.DamageType = ModContent.GetInstance<ChainClassDamage>();
        Item.damage = 250;
        Item.knockBack = 5f;
        Item.crit = 14;
        Item.shoot = ModContent.ProjectileType<ChainProjectile>();
        Item.shootSpeed = 8f;
        Item.ArmorPenetration += -1;


        Item.value = Item.buyPrice(gold: 79);
        Item.rare = ItemRarityID.Red;
    }

}*/
