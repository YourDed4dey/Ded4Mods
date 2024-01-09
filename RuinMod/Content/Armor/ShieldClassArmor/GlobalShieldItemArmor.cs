using RuinMod.Content.Armor.ShieldClassArmor.PreHardmode.GuardArmor;
using RuinMod.Content.Classes.ShieldClass;
using System.Collections.Generic;
using System.ComponentModel;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RuinMod.Content.Armor.ShieldClassArmor
{
    internal class GlobalShieldItemArmor : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (item.type == ItemID.SilverHelmet) tooltips.Add(new(Mod, "", "5% increased contact damage and critical strike chance\nIncreased contact damage armor penetration by 1"));
            if (item.type == ItemID.SilverChainmail) tooltips.Add(new(Mod, "", "10% increased contact damage and critical strike chance\nIncreased contact damage armor penetration by 1"));
            if (item.type == ItemID.SilverGreaves) tooltips.Add(new(Mod, "", "5% increased contact damage and critical strike chance\nIncreased contact damage armor penetration by 1"));

            //

            if (item.type == ItemID.TungstenHelmet) tooltips.Add(new(Mod, "", "5% increased contact damage and critical strike chance\nIncreased contact damage armor penetration by 1"));
            if (item.type == ItemID.TungstenChainmail) tooltips.Add(new(Mod, "", "5% increased contact damage and critical strike chance\nIncreased contact damage armor penetration by 1"));
            if (item.type == ItemID.TungstenGreaves) tooltips.Add(new(Mod, "", "5% increased contact damage and critical strike chance"));

            //

            if (item.type == ItemID.GladiatorHelmet) tooltips.Add(new(Mod, "", "10% increased contact damage and critical strike chance\nIncreased contact damage armor penetration by 1"));
            if (item.type == ItemID.GladiatorBreastplate) tooltips.Add(new(Mod, "", "15% increased contact damage and critical strike chance\nIncreased contact damage armor penetration by 3"));
            if (item.type == ItemID.GladiatorLeggings) tooltips.Add(new(Mod, "", "5% increased contact damage and critical strike chance\nIncreased contact damage armor penetration by 1"));
        }
        public override void UpdateEquip(Item item, Player player)
        {
            if (item.type == ItemID.SilverHelmet)
            {
                player.GetCritChance(ModContent.GetInstance<ShieldClassDamage>()) += 0.05f;
                player.GetDamage(ModContent.GetInstance<ShieldClassDamage>()) += 0.05f;
                player.GetArmorPenetration(ModContent.GetInstance<ShieldClassDamage>()) += 1f;
            }
            if (item.type == ItemID.SilverChainmail)
            {
                player.GetCritChance(ModContent.GetInstance<ShieldClassDamage>()) += 0.10f;
                player.GetDamage(ModContent.GetInstance<ShieldClassDamage>()) += 0.10f;
                player.GetArmorPenetration(ModContent.GetInstance<ShieldClassDamage>()) += 1f;
            }
            if (item.type == ItemID.SilverGreaves)
            {
                player.GetCritChance(ModContent.GetInstance<ShieldClassDamage>()) += 0.05f;
                player.GetDamage(ModContent.GetInstance<ShieldClassDamage>()) += 0.05f;
                player.GetArmorPenetration(ModContent.GetInstance<ShieldClassDamage>()) += 1f;
            }

            //


            if (item.type == ItemID.TungstenHelmet)
            {
                player.GetCritChance(ModContent.GetInstance<ShieldClassDamage>()) += 0.05f;
                player.GetDamage(ModContent.GetInstance<ShieldClassDamage>()) += 0.05f;
                player.GetArmorPenetration(ModContent.GetInstance<ShieldClassDamage>()) += 1f;
            }
            if (item.type == ItemID.TungstenChainmail)
            {
                player.GetCritChance(ModContent.GetInstance<ShieldClassDamage>()) += 0.05f;
                player.GetDamage(ModContent.GetInstance<ShieldClassDamage>()) += 0.05f;
                player.GetArmorPenetration(ModContent.GetInstance<ShieldClassDamage>()) += 1f;
            }
            if (item.type == ItemID.TungstenGreaves)
            {
                player.GetCritChance(ModContent.GetInstance<ShieldClassDamage>()) += 0.05f;
                player.GetDamage(ModContent.GetInstance<ShieldClassDamage>()) += 0.05f;
            }

            //

            if (item.type == ItemID.GladiatorHelmet)
            {
                player.GetCritChance(ModContent.GetInstance<ShieldClassDamage>()) += 0.10f;
                player.GetDamage(ModContent.GetInstance<ShieldClassDamage>()) += 0.10f;
                player.GetArmorPenetration(ModContent.GetInstance<ShieldClassDamage>()) += 1f;
            }
            if (item.type == ItemID.GladiatorBreastplate)
            {
                player.GetCritChance(ModContent.GetInstance<ShieldClassDamage>()) += 0.15f;
                player.GetDamage(ModContent.GetInstance<ShieldClassDamage>()) += 0.15f;
                player.GetArmorPenetration(ModContent.GetInstance<ShieldClassDamage>()) += 3f;
            }
            if (item.type == ItemID.GladiatorLeggings)
            {
                player.GetCritChance(ModContent.GetInstance<ShieldClassDamage>()) += 0.05f;
                player.GetDamage(ModContent.GetInstance<ShieldClassDamage>()) += 0.05f;
                player.GetArmorPenetration(ModContent.GetInstance<ShieldClassDamage>()) += 1f;
            }
        }
    }
}
