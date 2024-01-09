using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;
using static Terraria.ModLoader.PlayerDrawLayer;
using Microsoft.Xna.Framework;
using RuinMod.Content.Classes.ShieldClass;

namespace RuinMod.Content.Potions.Debuffs.ShieldSickness
{
    internal class Shield_Sickness : ModBuff
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Shield Sickness");

            Main.debuff[Type] = true;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetCritChance(ModContent.GetInstance<ShieldClassDamage>()) -= 0.65f;
            player.GetDamage(ModContent.GetInstance<ShieldClassDamage>()) -= 0.65f;
        }
    }
}
