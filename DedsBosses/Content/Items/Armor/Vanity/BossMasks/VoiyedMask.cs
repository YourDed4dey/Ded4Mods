﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DedsBosses.Content.Items.Armor.Vanity.BossMasks
{
    // This tells tModLoader to look for a texture called MinionBossMask_Head, which is the texture on the player
    // and then registers this item to be accepted in head equip slots
    [AutoloadEquip(EquipType.Head)]
    public class VoiyedMask : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 22;

            // Common values for every boss mask
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(silver: 75);
            Item.vanity = true;
            Item.maxStack = 1;
        }
    }
}