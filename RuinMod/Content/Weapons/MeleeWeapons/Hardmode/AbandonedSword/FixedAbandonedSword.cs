/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using RuinMod.Content.Weapons.MeleeWeapons.Hardmode.AbandonedSword;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace RuinMod.Content.Weapons.MeleeWeapons.Hardmode.AbandonedSword;

internal class FixedAbandonedSword : ModItem
{
    public override void SetStaticDefaults()
    {
        //DisplayName.SetDefault("Abandoned Sword");
        //Tooltip.SetDefault("'The soul of the twins rests in this sword'\nLeft click for Spazmatism's cursed flames\nRight click for Retinazer's eye laser");
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 60;
        Item.height = 60;
        Item.scale = 1.5f;

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 20;
        Item.useAnimation = 20;
        Item.autoReuse = true;

        Item.DamageType = DamageClass.Melee;
        Item.damage = 210;
        Item.knockBack = 10f;
        Item.crit = 27;
        Item.shoot = ProjectileID.CursedFlameFriendly; //ProjectileID.InfernoFriendlyBlast; is fucking cool as shit (op tho) ProjectileID.EyeFire; is spaz's second phase (green twin)
        Item.shootSpeed = 12f;
        Item.ArmorPenetration += 10;


        Item.value = Item.buyPrice(gold: 59);
        Item.rare = ItemRarityID.Yellow;

        Item.UseSound = SoundID.Item1;
    }

    public override bool AltFunctionUse(Player player)
    {
        return true;
    }

    public override bool CanUseItem(Player player)
    {
        if (player.altFunctionUse ==2)
        {
            Item.damage = 400;
        } else
        {
            Item.damage = 210;
        }
        return true;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {

        if (player.altFunctionUse == 2)
        {
            int proj = Projectile.NewProjectile(source, position, velocity, ProjectileID.DeathLaser, 210, knockback, player.whoAmI);
            Main.projectile[proj].friendly = true;
            Main.projectile[proj].hostile = false;

            return false;
        }
        return true;
    } 

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ModContent.ItemType<Content.Items.LostFragment.LostFragment>(), 15)
            .AddIngredient(ModContent.ItemType<Weapons.MeleeWeapons.Pre_Hardmode.BrokenAbandonedSword.AbandonedSword>(), 1)
            .AddIngredient(ItemID.ChlorophyteBar, 24)
            .AddIngredient(ItemID.BrokenHeroSword, 1)
            .AddIngredient(ItemID.SoulofSight, 3)
            .AddTile(TileID.MythrilAnvil)
            .Register();
    }

}*/
