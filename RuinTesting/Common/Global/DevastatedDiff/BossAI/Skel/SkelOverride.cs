/*using RuinTesting.Common.Systems.DevaSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RuinTesting.Common.Global.DevastatedDiff.BossAI.Skel
{
    internal class SkelOverride : GlobalNPC
    {
        public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
        {
            return entity.type == NPCID.SkeletronHead;
        }
        public override bool PreAI(NPC npc)
        {
            BuffedSkelAI(npc);
            if (RuinWorld.devastated)
                return false;


            else return true;
        }
        public static bool BuffedSkelAI(NPC npc)
        {
            npc.lifeMax += 1;
            npc.life += 1;

            return false;
        }
    }
}*/
