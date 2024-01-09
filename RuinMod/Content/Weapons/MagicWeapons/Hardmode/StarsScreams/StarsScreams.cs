using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace RuinMod.Content.Weapons.MagicWeapons.Hardmode.StarsScreams
{
    internal class StarsScreams : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Star's Screams");
            //Tooltip.SetDefault("'The screams of the stars help you'");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Starfury);
            Item.width = 32;
            Item.height = 32;
            Item.scale -= 0.30f;

            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.useTime = 3;
            Item.useAnimation = 3;

            Item.autoReuse = true;
            Item.channel = true;

            Item.shootSpeed = 9f;

            Item.DamageType = DamageClass.Magic;
            Item.damage = 57;
            Item.knockBack = 5f;
            Item.noMelee = true;

            Item.rare = ItemRarityID.Pink;
            Item.mana = 5;
            Item.UseSound = null;
            Item.value = 0;
        }
    }
}
