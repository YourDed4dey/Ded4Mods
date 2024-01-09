/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using RuinMod.Content.Projectiles.SpinningScytheProjectile;
using RuinMod.Content.Projectiles.ThrowableScytheProjectile;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace RuinMod.Content.Weapons.ProjectileWeapons.Hardmode.AbandonedScythe;

internal class AbandonedScythe : ModItem
{
    public const int DamageMax = 450;
    public override void SetStaticDefaults()
    {
        //DisplayName.SetDefault("Abandoned Scythe");
        //Tooltip.SetDefault("Who would abandon this?\nRight click to throw scythe\nInflicts 'Cursed Inferno' debuff on enemies for 3 seconds");
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 32;
        Item.scale = 1.5f;

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 30;
        Item.useAnimation = 30;
        Item.autoReuse = true;
        Item.noUseGraphic = true;
        Item.channel = true;

        Item.DamageType = DamageClass.Melee;
        Item.damage = 50;
        Item.knockBack = 5f;
        Item.crit = 14;
        Item.shoot = ModContent.ProjectileType<SpinningScytheProjectile>();
        Item.shootSpeed = 8f;
        Item.ArmorPenetration += 5;

        Item.rare = ItemRarityID.Yellow;

        Item.UseSound = SoundID.Item104;
    }
    public override bool AltFunctionUse(Player player)
    {
        return true;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        //Vector2 offset = new Vector2(position.X * 3, position.Y * 3);
        //position += offset;

        if (player.altFunctionUse == 2)
        {
            int proj = Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<ThrowableScytheProjectile>(), 210, knockback, player.whoAmI);
            Main.projectile[proj].friendly = true;
            Main.projectile[proj].hostile = false;

            return false;
        }
        return true;
    }
    public override bool? UseItem(Player player)
    {
        Item.damage++;
        if (Item.damage > DamageMax)
        {
            Item.damage = 50;
            Item.crit = 14;
        }

        if (player.controlUseItem == true)
        {
            Item.damage += 15;
            Item.crit += 3;
        }
        return true;
    }
}*/
