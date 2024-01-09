/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using RuinMod.Content.Projectiles.ChainClass.ChainsOfAmgil;
using RuinMod.Content.Classes.ChainClass;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace RuinMod.Content.Weapons.ChainClassWeapons.Pre_Hardmode.ChainsOfAmgil
{
    internal class ChainsOfAmgil : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Chains of Amgil");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;

            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useTime = 0;
            Item.useAnimation = 0;
            Item.autoReuse = true;
            Item.noUseGraphic = true;
            Item.channel = true;

            Item.DamageType = ModContent.GetInstance<ChainClassDamage>();
            Item.damage = 16;
            Item.knockBack = 5f;
            Item.shoot = ModContent.ProjectileType<ChainsOfAmgilProjectile>();
            Item.shootSpeed = 12f;


            Item.value = Item.buyPrice(gold: 1);
            Item.rare = ItemRarityID.Green;
        }
    }
}*/
