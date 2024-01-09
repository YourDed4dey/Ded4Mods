/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using RuinMod.Content.Classes.GamerClass;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using RuinMod.Content.Rarity;
using RuinMod.Content.Potions.Debuffs.Corrupted;

namespace RuinMod.Content.Weapons.GamerClassWeapons.PreHardmode.WoodenZapinator
{
    internal class WoodenZapinator : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Wooden Zapinator");
            //Tooltip.SetDefault("'Give it your best shot!'");
        }

        public override void SetDefaults()
        {
            Item.width = 48;
            Item.height = 28;
            Item.scale = .8f;

            Item.rare = ModContent.RarityType<GamerClassRarity>();

            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = true;

            Item.useAnimation = 35;
            Item.useTime = 35;

            Item.DamageType = ModContent.GetInstance<GamerClassDamage>();
            Item.damage = 10;

            Item.shoot = AmmoID.Arrow;
            Item.useAmmo = AmmoID.Arrow;

            Item.crit = -4;
            Item.shootSpeed = 10f;
            Item.UseSound = SoundID.Item11;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(105));

            newVelocity *= 1f - Main.rand.NextFloat(0.3f);

            Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);

            return false;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddRecipeGroup(RecipeGroupID.Wood, 20)
                .AddTile(TileID.WorkBenches)
                .Register();
        }

        /*public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if (!target.HasBuff(BuffID.Bleeding))
            {
                target.AddBuff(BuffID.Bleeding, 60 * 6 / 2);
            }
        }
    }
}*/
