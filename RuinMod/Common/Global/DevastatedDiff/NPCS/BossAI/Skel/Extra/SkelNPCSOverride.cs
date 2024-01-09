/*using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using RuinMod.Common.Systems.DiffSystem;

namespace RuinMod.Common.Global.DevastatedDiff.NPCS.BossAI.Skel.Extra
{
    internal class SkelNPCSOverride : GlobalNPC
    {
        public override void OnHitPlayer(NPC npc, Player target, int damage, bool crit)
        {
            if (RuinWorld.devastated)
            {
                if (npc.type == NPCID.SkeletronHand)
                {
                    if (!target.HasBuff(BuffID.Poisoned))
                    {
                        target.AddBuff(BuffID.Poisoned, 60 * 6 / 2);
                    }

                    if (!target.HasBuff(BuffID.Confused))
                    {
                        target.AddBuff(BuffID.Confused, 60 * 10 / 2);
                    }
                }
            }
        }
    }
}*/
