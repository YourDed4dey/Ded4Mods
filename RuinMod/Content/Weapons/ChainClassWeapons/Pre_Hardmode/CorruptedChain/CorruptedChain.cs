/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using RuinMod.Content.Projectiles.ChainClass.CorruptedChain;
using RuinMod.Content.Classes.ChainClass;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace RuinMod.Content.Weapons.ChainClassWeapons.Pre_Hardmode.CorruptedChain
{
    internal class CorruptedChain : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Corrupted Chain");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 20;

            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useTime = 0;
            Item.useAnimation = 0;
            Item.autoReuse = true;
            Item.noUseGraphic = true;
            Item.channel = true;

            Item.DamageType = ModContent.GetInstance<ChainClassDamage>();
            Item.damage = 9;
            Item.knockBack = 5f;
            Item.shoot = ModContent.ProjectileType<CorruptedChainProjectile>();
            Item.shootSpeed = 12f;


            Item.value = Item.buyPrice(gold: 1);
            Item.rare = ItemRarityID.Blue;
        }
    }
}*/
