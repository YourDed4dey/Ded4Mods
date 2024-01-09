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
using Microsoft.Xna.Framework;
using Terraria.ModLoader.IO;

namespace RuinMod.Content.TestStuff.TestAccesories
{
    [AutoloadEquip(EquipType.Face)]
    internal class TestAccHead : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("test");
            //Tooltip.SetDefault("test");

            ArmorIDs.Face.Sets.DrawInFaceHeadLayer[Item.faceSlot] = true;
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;
            Item.accessory = true;
            Item.rare = ItemRarityID.Pink;
            Item.value = Item.sellPrice(gold: 1);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            
        }
    }
}*/
