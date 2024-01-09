/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System;
using RuinMod.Common.Systems.DiffSystem;
using RuinMod.Common.Global.DevastatedDiff.Potions.Debuffs.CursedIchor;

namespace RuinMod.Common.Global.DevastatedDiff.NPCS.BossAI.BOC.Extra
{
    internal class BOCProjOverride : GlobalProjectile
    {
        public override void OnHitPlayer(Projectile projectile, Player target, int damage, bool crit)
        {
            if (RuinWorld.devastated)
            {
                if(projectile.type == ProjectileID.IchorSplash)
                {
                    if (!target.HasBuff(ModContent.BuffType<CursedIchor>()))
                    {
                        target.AddBuff(ModContent.BuffType<CursedIchor>(), 60 * 6);
                    }
                }
            }
        }
    }
}*/
