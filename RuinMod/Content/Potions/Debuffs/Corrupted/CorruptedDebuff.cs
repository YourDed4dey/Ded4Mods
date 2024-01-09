using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;
using static Terraria.ModLoader.PlayerDrawLayer;
using Microsoft.Xna.Framework;

namespace RuinMod.Content.Potions.Debuffs.Corrupted
{
    internal class CorruptedDebuff : ModBuff
    {
        public int lifeRegenExpectedLossPerSecond = -1;
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Corrupted");

            Main.debuff[Type] = true;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
        }

        /*public override void Update(Player player, ref int buffIndex)
        {
            int num = lifeRegenExpectedLossPerSecond;

            if (Main.rand.Next(4) < 3)
            {
                Dust dust18 = Dust.NewDustDirect(new Vector2(player.position.X - 2f, player.position.Y - 2f), player.width + 4, player.height + 4, DustID.CorruptGibs, player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default(Color), 3.5f);
                dust18.noGravity = true;
                dust18.velocity.X = 1.8f;
                dust18.velocity.Y -= 0.5f;
                if (Main.rand.NextBool(4))
                {
                    dust18.noGravity = false;
                    dust18.scale = 0.5f;
                }
            }
            Lighting.AddLight((int)(player.position.X / 16f), (int)(player.position.Y / 16f + 1f), 1f, 0.3f, 0.1f);
            if (player.lifeRegen > 0)
            {
                player.lifeRegen = 0;
            }
            player.lifeRegen -= 48;
            if (num < 10)
            {
                num = 10;
            }
        }*/

        public override void Update(NPC npc, ref int buffIndex)
        {
            int num = lifeRegenExpectedLossPerSecond;

            if (Main.rand.Next(4) < 3)
            {
                Dust dust18 = Dust.NewDustDirect(new Vector2(npc.position.X - 2f, npc.position.Y - 2f), npc.width + 4, npc.height + 4, DustID.CorruptGibs, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 1.5f);
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
            npc.lifeRegen -= 48;
            if (num < 10)
            {
                num = 10;
            }
        }
    }
}
