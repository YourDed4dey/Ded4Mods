/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using RuinMod.Content.Classes.ChainClass;

namespace RuinMod.Content.Classes.ChainClass
{
    internal class ChainclassItem : ModItem
    {
        public virtual void SafeSetDefaults()
        {
            
        }

        public sealed override void SetDefaults()
        {
            SafeSetDefaults();
            // all vanilla damage types must be false for custom damage types to work
            Item.DamageType = DamageClass.Default;
        }

        public override void ModifyWeaponDamage(Player player, ref StatModifier damage)
        {
            damage += ChainclassPlayer.ModPlayer(player).chainclassDamageAdd;
        }

        public override void ModifyWeaponKnockback(Player player, ref StatModifier knockback)
        {
            knockback += ChainclassPlayer.ModPlayer(player).chainclassKnockback;
        }

        public override void ModifyWeaponCrit(Player player, ref float crit)
        {
            crit += ChainclassPlayer.ModPlayer(player).chainclassCrit;
        }

        // Because we want the damage tooltip to show our custom damage, we need to modify it
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Get the vanilla damage tooltip
            TooltipLine tt = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.Mod == "Terraria");
            if (tt != null)
            {
                // We want to grab the last word of the tooltip, which is the translated word for 'damage' (depending on what language the player is using)
                // So we split the string by whitespace, and grab the last word from the returned arrays to get the damage word, and the first to get the damage shown in the tooltip
                string[] splitText = tt.Text.Split(' ');
                string damageValue = splitText.First();
                string damageWord = splitText.Last();
                // Change the tooltip text
                tt.Text = damageValue + " chain " + damageWord;
            }
        }
    }
}*/