/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;
using Terraria.Audio;
using RuinMod.Content.Classes.GamerClass;
using RuinMod.Content.Rarity;

namespace RuinMod.Content.Weapons.GamerClassWeapons.PreHardmode.FortnaiScar
{
    internal class FortnaiScar : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Fortnite Scar");
            //Tooltip.SetDefault("'Its the gun from Fortnite!'");
        }

        public override void SetDefaults()
        {
            Item.width = 136;
            Item.height = 52;
            Item.scale -= 0.5f;

            Item.rare = RarityType<GamerClassRarity>();

            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = true;

            Item.useAnimation = 19;
            Item.useTime = 19;

            Item.DamageType = ModContent.GetInstance<GamerClassDamage>();
            Item.damage = 28;

            Item.shoot = AmmoID.Bullet;
            Item.useAmmo = AmmoID.Bullet;

            Item.crit = -4;
            Item.shootSpeed = 11f;
            Item.UseSound = SoundID.Item11;
        }
    }
}*/
