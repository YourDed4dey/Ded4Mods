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

namespace RuinMod.Content.Consumables.Pets.OcramsEye
{
    internal class EyeSpeculum : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Eye Speculum");
            //Tooltip.SetDefault("Summons an eye that always watches");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);

            Item.rare = ItemRarityID.Master;
            Item.shoot = ModContent.ProjectileType<OcramsEyeProjectile>();
            Item.buffType = ModContent.BuffType<OcramsEyeBuff>();
            Item.master = true;
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
