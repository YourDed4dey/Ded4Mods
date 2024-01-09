using System.Collections.Generic;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace DedsBosses.Content.DamageClasses
{
    public class LifetakerDamageClass : DamageClass
	{
		public override StatInheritanceData GetModifierInheritance(DamageClass damageClass) {
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

		public override bool GetEffectInheritance(DamageClass damageClass) {
			return false;
		}

		public override void SetDefaultStats(Player player) {
            //player.GetCritChance<LifetakerDamageClass>() += 4;
            //player.GetArmorPenetration<LifetakerDamageClass>() += 10;
        }

        public override bool UseStandardCritCalcs => true;

		/*public override bool ShowStatTooltipLine(Player player, string lineName) {
			if (lineName == "Damage")
				return false;

			return true;
		}*/
	}
}