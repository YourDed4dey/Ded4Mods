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

namespace RuinMod.Content.Weapons.ChainClassWeapons.Pre_Hardmode.ChainsOfSins
{
    internal class ChainsOfSins : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Chains of Sins");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 20;

            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useTime = 0;
            Item.useAnimation = 0;
            Item.autoReuse = true;
            Item.noUseGraphic = true;
            Item.channel = true;

            Item.DamageType = ModContent.GetInstance<ChainClassDamage>();
            Item.damage = 15;
            Item.knockBack = 5f;
            Item.shoot = ModContent.ProjectileType<Content.Projectiles.ChainClass.ChainsOfSins.ChainsOfSinsProjectile>();
            Item.shootSpeed = 12f; //8f


            Item.value = Item.buyPrice(gold: 1);
            Item.rare = ItemRarityID.Orange;
        }
    }
}*/
