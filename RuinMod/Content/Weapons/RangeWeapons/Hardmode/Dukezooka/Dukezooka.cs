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
using System.Diagnostics;
using Terraria.Audio;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader.Utilities;
using System.Reflection;

namespace RuinMod.Content.Weapons.RangeWeapons.Hardmode.Dukezooka
{
    internal class Dukezooka : ModItem
    {
        public const int DamageMax = 3000;

        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Duke zooka");
            //Tooltip.SetDefault("'A happy and innocent mini-duke fires at your enemies'\nIncreases damage and use-time on use\nMax damage cap: 3000");
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(20, 2)); // first it the amount of ticks per frame and second is the number of frames 
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
            //Main.itemFrame[Item.type] = 2;
            //Main.itemFrameCounter[Type] = 2;
        }

        public override void SetDefaults()
        {
            Item.width = 70;
            Item.height = 112;

            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useTime = 1;
            Item.useAnimation = 1;

            Item.autoReuse = true;
            Item.channel = true;

            Item.shootSpeed = 17f; //9f or 20
            Item.shoot = AmmoID.Bullet;

            Item.DamageType = DamageClass.Ranged;
            Item.damage = 65;
            Item.knockBack = 5f;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Bullet;
            Item.UseSound = SoundID.Item115;

            Item.rare = ItemRarityID.Yellow;
        }

        public override bool? UseItem(Player player)
        {
            Item.damage++;
            if(Item.damage > DamageMax)
            {
                Item.damage = 65;
                Item.useTime = 1;
                Item.useAnimation = 1;
                Item.crit = 4;
            }

            if (player.controlUseItem == true)
            {
                Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(200, 2));
                Item.useTime += 1;
                Item.useAnimation += 1;
                Item.damage += 45;
                Item.crit += 1;
            }
            return true;
        }
    }
}
