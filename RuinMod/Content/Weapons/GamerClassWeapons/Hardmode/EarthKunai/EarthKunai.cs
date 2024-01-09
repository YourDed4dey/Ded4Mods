/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using RuinMod.Content.Classes.GamerClass;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using RuinMod.Content.Projectiles.GamerClass.EarthKunai;
using RuinMod.Content.Rarity;

namespace RuinMod.Content.Weapons.GamerClassWeapons.Hardmode.EarthKunai
{
    internal class EarthKunai : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Earth Kunai");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 84;
            Item.height = 76;
            Item.noUseGraphic = true;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.autoReuse = true;

            Item.useAnimation = 20;
            Item.useTime = 10;
            Item.reuseDelay = 32;

            Item.DamageType = ModContent.GetInstance<GamerClassDamage>();
            Item.damage = 167;
            Item.shoot = ModContent.ProjectileType<EarthKunaiProjectile>();
            Item.noMelee = true;
            Item.shootSpeed = 35f;
            Item.UseSound = SoundID.Item12;

            Item.value = Item.buyPrice(gold: 69);
            Item.rare = ModContent.RarityType<GamerClassRarity>();
        }
    }
}*/
