using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace RuinMod.Common.Global.DevastatedDiff.Potions.Debuffs.Oiled
{
    internal class Oiled : ModBuff
    {
        public int lifeRegenExpectedLossPerSecond = -1;
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Oiled");

            Main.debuff[Type] = true;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            int num = lifeRegenExpectedLossPerSecond;

            if (player.HasBuff(ModContent.BuffType<Oiled>()) && Main.rand.NextBool(3))
            {
                int num1 = 175;
                Color newColor = new(0, 0, 0, 250);
                Vector2 vector = player.position;
                vector.X -= 2f;
                vector.Y -= 2f;
                if (Main.rand.NextBool(2))
                {
                    Dust dust8 = Dust.NewDustDirect(vector, player.width + 4, player.height + 2, DustID.TintableDust, 0f, 0f, num1, newColor, 1.4f);
                    if (Main.rand.NextBool(2))
                    {
                        dust8.alpha += 25;
                    }
                    if (Main.rand.NextBool(2))
                    {
                        dust8.alpha += 25;
                    }
                    dust8.noLight = true;
                    dust8.velocity *= 0.2f;
                    dust8.velocity.Y += 0.2f;
                    dust8.velocity += player.velocity;
                }
            }
            if (player.HasBuff(ModContent.BuffType<Oiled>()) && (player.HasBuff(BuffID.OnFire)|| (player.HasBuff(BuffID.OnFire3) || (player.HasBuff(BuffID.CursedInferno) || (player.HasBuff(BuffID.Frostburn) || (player.HasBuff(BuffID.Frostburn2) || (player.HasBuff(BuffID.ShadowFlame) /*|| player.HasBuff(ModContent.BuffType<CursedIchor.CursedIchor>())*/)))))))
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                if (Main.hardMode)
                {
                    player.lifeRegen -= 75;
                }
                else
                {
                    player.lifeRegen -= 50;

                }
                if (num < 10)
                {
                    num = 10;
                }
            }
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            int num = lifeRegenExpectedLossPerSecond;

            if (npc.HasBuff(ModContent.BuffType<Oiled>()) && Main.rand.NextBool(3))
            {
                int num1 = 175;
                Color newColor = new(0, 0, 0, 250);
                Vector2 vector = npc.position;
                vector.X -= 2f;
                vector.Y -= 2f;
                if (Main.rand.NextBool(2))
                {
                    Dust dust8 = Dust.NewDustDirect(vector, npc.width + 4, npc.height + 2, DustID.TintableDust, 0f, 0f, num1, newColor, 1.4f);
                    if (Main.rand.NextBool(2))
                    {
                        dust8.alpha += 25;
                    }
                    if (Main.rand.NextBool(2))
                    {
                        dust8.alpha += 25;
                    }
                    dust8.noLight = true;
                    dust8.velocity *= 0.2f;
                    dust8.velocity.Y += 0.2f;
                    dust8.velocity += npc.velocity;
                }
            }
            if (npc.HasBuff(ModContent.BuffType<Oiled>()) && (npc.HasBuff(BuffID.OnFire) || (npc.HasBuff(BuffID.OnFire3) || (npc.HasBuff(BuffID.CursedInferno) || (npc.HasBuff(BuffID.Frostburn) || (npc.HasBuff(BuffID.Frostburn2) || (npc.HasBuff(BuffID.ShadowFlame) /*|| npc.HasBuff(ModContent.BuffType<CursedIchor.CursedIchor>())*/)))))))
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                if (Main.hardMode)
                {
                    npc.lifeRegen -= 75;
                }
                else
                {
                    npc.lifeRegen -= 50;

                }
                if (num < 10)
                {
                    num = 10;
                }
            }
        }
    }
}
