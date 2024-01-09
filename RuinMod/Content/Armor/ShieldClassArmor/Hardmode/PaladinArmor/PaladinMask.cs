using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;
using Terraria.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria.ModLoader.IO;
using Mono.Cecil;
using Terraria.DataStructures;
using Terraria.Localization;
using RuinMod.Common.Systems;
using RuinMod.Content.Classes.ShieldClass;

namespace RuinMod.Content.Armor.ShieldClassArmor.Hardmode.PaladinArmor
{
    [AutoloadEquip(EquipType.Head)]
    internal class PaladinMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Paladin Mask");
            //Tooltip.SetDefault("20% increased contact damage and critical strike chance\nIncreased contact damage armor penetration by 7");
            //CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
        }

        public override void SetDefaults() //Item Stats
        {
            Item.width = 24;
            Item.height = 24;
            Item.rare = ItemRarityID.Yellow;
            Item.defense = 26;
            Item.wornArmor = true;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<PaladinPlateMail>() && legs.type == ItemType<PaladinGreaves>(); //What makes armor set bonus work
        }

        public override void UpdateArmorSet(Player player) //Armor set bonuses
        {
            player.setBonus = Language.GetTextValue("Mods.RuinMod.ItemSetBonus.PaladinSet"); // "Reduces damage taken by 25%"
            player.endurance += 0.25f;
        }

        public override void UpdateEquip(Player player) //Individual armor piece bonus
        {
            player.GetCritChance(ModContent.GetInstance<ShieldClassDamage>()) += 0.2f;
            player.GetDamage(ModContent.GetInstance<ShieldClassDamage>()) += 0.2f;
            player.GetArmorPenetration(ModContent.GetInstance<ShieldClassDamage>()) += 7f;
        }
    }
}