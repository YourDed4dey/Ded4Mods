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

namespace RuinMod.Content.Weapons.GamerClassWeapons.Hardmode.MasterSword
{
    internal class MasterSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Master Sword");
            //Tooltip.SetDefault("'Cool Sword'");
        }

        public override void SetDefaults()
        {
            Item.width = 86;
            Item.height = 86;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.autoReuse = true;

            Item.damage = 105;
            Item.ArmorPenetration += 7;
            Item.DamageType = ModContent.GetInstance<GamerClassDamage>();
            Item.crit = -4;
            Item.knockBack = 4.5f;

            Item.rare = ModContent.RarityType<GamerClassRarity>();

            Item.UseSound = SoundID.Item1;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(10))
            {
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Shadowflame);
            }
        }
    }
}*/
