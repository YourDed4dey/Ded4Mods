using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;
using static Terraria.ModLoader.PlayerDrawLayer;
using Microsoft.Xna.Framework;

namespace RuinMod.Content.Potions.Debuffs.God_sPersecution
{
    internal class God_sPersecution : ModBuff
    {
        public int lifeRegenExpectedLossPerSecond = -1;
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("God's Persecution");

            Main.debuff[Type] = true;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
        }
        
        public override void Update(NPC npc, ref int buffIndex)
        {
            int num = lifeRegenExpectedLossPerSecond;

            if (Main.rand.Next(4) < 3)
            {
                Dust dust18 = Dust.NewDustDirect(new Vector2(npc.position.X - 2f, npc.position.Y - 2f), npc.width + 4, npc.height + 4, DustID.HallowedWeapons, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 1.5f);
                dust18.noGravity = true;
                dust18.velocity.X = 1.8f;
                dust18.velocity.Y -= 0.5f;
                if (Main.rand.NextBool(4))
                {
                    dust18.noGravity = false;
                    dust18.scale = 0.5f;
                }
            }
            Lighting.AddLight((int)(npc.position.X / 16f), (int)(npc.position.Y / 16f + 1f), 1f, 0.3f, 0.1f);
            if (npc.lifeRegen > 0)
            {
                npc.lifeRegen = 0;
            }
            npc.lifeRegen -= 84;
            if (num < 10)
            {
                num = 10;
            }
        }
    }
}
