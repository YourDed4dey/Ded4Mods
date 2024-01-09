﻿using System.Collections.Generic;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.DataStructures;

namespace RuinMod.Content.Classes.ShieldClass
{
    public class ShieldClassDamage : DamageClass
    {
        public override StatInheritanceData GetModifierInheritance(DamageClass damageClass)
        {
            if (damageClass == DamageClass.Generic)
                return StatInheritanceData.Full;

            return new StatInheritanceData(
                damageInheritance: 0f,
                critChanceInheritance: 0f,
                attackSpeedInheritance: 0f,
                armorPenInheritance: 0f,
                knockbackInheritance: 0f
            );
        }

        public override bool GetEffectInheritance(DamageClass damageClass)
        {
            /*if (damageClass == DamageClass.Melee)
                return true;
            if (damageClass == DamageClass.Magic)
                return true;*/

            return false;
        }

        public override void SetDefaultStats(Player player)
        {
            //player.GetDamage<ShieldClassDamage>();
            player.GetCritChance<ShieldClassDamage>() = 0.04f;
            player.GetArmorPenetration<ShieldClassDamage>() += 10f;
        }
        public override bool UseStandardCritCalcs => true;

        public override bool ShowStatTooltipLine(Player player, string lineName)
        {
            if (lineName == "Speed")
                return false;

            return true;
        }
    }
}
