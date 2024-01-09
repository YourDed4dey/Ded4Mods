/*using System.Collections.Generic;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.DataStructures;

namespace RuinMod.Content.Classes.GamerClass
{
    public class GamerClassDamage : DamageClass
    {

        public override void SetStaticDefaults()
        {
            ClassName.SetDefault("gamer damage");
        }
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
            if (damageClass == DamageClass.Melee)
                return true;
            if (damageClass == DamageClass.Magic)
                return true;

            return false;
        }

        public override void SetDefaultStats(Player player)
        {
            player.GetCritChance<GamerClassDamage>() += 4;
            player.GetArmorPenetration<GamerClassDamage>() += 10;
        }
        public override bool UseStandardCritCalcs => true;

        public override bool ShowStatTooltipLine(Player player, string lineName)
        {

            if (lineName == "Speed")
                return false;

            return true;
        }
    }
}*/
