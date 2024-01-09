using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RuinMod.Content.Potions.Debuffs.Gemmoned
{
    internal class GemmonedGlobal : GlobalNPC
    {
        public override bool PreAI(NPC npc)
        {
            if(GemmonedDebuff.GemmonedDebuff1 == true && npc.boss == false && npc.type == NPCID.EaterofWorldsHead == false && npc.type == NPCID.EaterofWorldsBody == false && npc.type == NPCID.EaterofWorldsTail == false)
            {
                return false;
            }
            else 
            return true;
        }
        public override void ResetEffects(NPC npc)
        {
            GemmonedDebuff.GemmonedDebuff1 = false;
            GemmonedDebuff.Disco = false;
        }
    }
}
