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

namespace RuinMod.Content.Armor.Accesories.GamerClassAccesories.Hardmode.GamingEmblem
{
    internal class GamingEmblem : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Gaming Emblem");
            //Tooltip.SetDefault("15% increased gamer damage");
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;
            Item.accessory = true;
            Item.rare = ItemRarityID.LightRed;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(GetInstance<GamerClassDamage>()) += 0.15f;
        }
    }
}*/
