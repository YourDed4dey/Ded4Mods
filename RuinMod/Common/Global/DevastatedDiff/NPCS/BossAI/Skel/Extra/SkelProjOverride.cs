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
    internal class SkelProjOverride : GlobalProjectile
    {
        public override void OnHitPlayer(Projectile projectile, Player target, int damage, bool crit)
        {
            if (RuinWorld.devastated)
            {
                if (projectile.type == ProjectileID.Skull)
                {
                    if (!target.HasBuff(BuffID.Poisoned))
                    {
                        target.AddBuff(BuffID.Poisoned, 60 * 6 / 2);
                    }

                    if (!target.HasBuff(BuffID.Confused))
                    {
                        target.AddBuff(BuffID.Confused, 60 * 10 / 2);
                    }

                    if (!target.HasBuff(BuffID.Bleeding))
                    {
                        target.AddBuff(BuffID.Bleeding, 60 * 8 / 2);
                    }
                }
            }
        }
    }
}*/
