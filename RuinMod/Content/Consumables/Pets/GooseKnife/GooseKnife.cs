/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace RuinMod.Content.Consumables.Pets.GooseKnife
{
    internal class GooseKnife : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Goose Knife");
            //Tooltip.SetDefault("Summons a goose that may or may not attack you!");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);

            Item.rare = ItemRarityID.Orange;
            Item.shoot = ModContent.ProjectileType<GooseKnifeProjectile>();
            Item.buffType = ModContent.BuffType<GooseKnifeBuff>();
            Item.value = 0;
        }

        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(Item.buffType, 3600);
            }
        }

    }
}*/
