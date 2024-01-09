using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace RuinMod.Common.Global.DevastatedDiff.Potions.Debuffs.BadSugarRush
{
    internal class BadSugarRush : ModBuff
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Sugar Rushed");

            Main.debuff[Type] = true;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (Main.hardMode)
            {
                player.moveSpeed -= .75f;
                player.statDefense -= 18;
                player.lifeRegen -= 8;
            }
            else
            {
                player.moveSpeed -= .5f;
                player.statDefense -= 5;
                player.lifeRegen -= 5;
            }
        }
    }
}
