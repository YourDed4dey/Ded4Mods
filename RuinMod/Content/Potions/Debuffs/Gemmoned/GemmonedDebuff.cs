using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;
using static Terraria.ModLoader.PlayerDrawLayer;
using Microsoft.Xna.Framework;

namespace RuinMod.Content.Potions.Debuffs.Gemmoned
{
    internal class GemmonedDebuff : ModBuff
    {
        public static bool GemmonedDebuff1;
        public static bool Disco;
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Gemmoned");

            Main.debuff[Type] = true;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            GemmonedDebuff1 = true;
            Disco = true;
            if (Disco == true && npc.boss == false && npc.type == NPCID.EaterofWorldsHead == false && npc.type == NPCID.EaterofWorldsBody == false && npc.type == NPCID.EaterofWorldsTail == false)
            {
                npc.color = Main.DiscoColor;
            }
        }
    }
}
