/*using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using RuinMod.Common.Systems.DiffSystem;
using RuinMod.Common.Global.DevastatedDiff.NPCS.BossAI.EOC.Extra;

namespace RuinMod.Common.Global.DevastatedDiff.NPCS.BossAI.EOC;

public class EOCOverride : GlobalNPC
{
    private static bool Spawnedminions;
    public override bool InstancePerEntity => true;
    public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
    {
        return entity.type == NPCID.EyeofCthulhu;
    }
    public override bool PreAI(NPC npc)
    {
        BuffedEyeofCthulhuAI(npc);
        if (RuinWorld.devastated)
            return false;


        else return true;
    }
    public static bool BuffedEyeofCthulhuAI(NPC npc)
    {
        if (RuinWorld.devastated)
        {
            if (!Spawnedminions && !NPC.AnyNPCs(ModContent.NPCType<EOCServant>()) && npc.ai[1] == 1.0 == false)
            {
                SpawnMinions(npc);
                Spawnedminions = true;
            }
            Spawnedminions = false;
            float num1 = npc.life / (float)npc.lifeMax;
            bool flag1 = false;
            bool flag2 = (double)num1 < 0.75;
            bool flag3 = (double)num1 < 0.64999997615814209;
            bool flag4 = (double)num1 < 0.550000011920929;
            bool flag5 = (double)num1 < 0.40000000596046448;
            float num2 = flag1 ? 15f : 20f;
            float num3 = 0.0f;
            if (Main.dayTime)
            {
                num3 += 12f;
                npc.damage += 200;
            }
            if (npc.target < 0 || npc.target == byte.MaxValue || Main.player[npc.target].dead || !Main.player[npc.target].active)
                npc.TargetClosest();
            if ((double)Vector2.Distance(Main.player[npc.target].Center, npc.Center) > 3200.0)
                npc.TargetClosest();
            Player player = Main.player[npc.target];
            npc.spriteDirection = 1;
            if (player.Center.X > npc.Center.X)
            {
                npc.spriteDirection = 0;
            }
            int num4 = Main.player[npc.target].dead ? 1 : 0;
            float x = npc.position.X + npc.width / 2 - Main.player[npc.target].position.X - Main.player[npc.target].width / 2;
            float num5 = (float)Math.Atan2(npc.position.Y + (double)npc.height - 59.0 - Main.player[npc.target].position.Y - Main.player[npc.target].height / 2, (double)x) + 1.57079637f;
            if ((double)num5 < 0.0)
                num5 += 6.28318548f;
            else if ((double)num5 > 6.2831854820251465)
                num5 -= 6.28318548f;
            float num6 = 0.0f;
            if (npc.ai[0] == 0.0 && npc.ai[1] == 0.0)
                num6 = 0.02f;
            if (npc.ai[0] == 0.0 && npc.ai[1] == 2.0 && npc.ai[2] > 40.0)
                num6 = 0.05f;
            if (npc.ai[0] == 3.0 && npc.ai[1] == 0.0)
                num6 = 0.05f;
            if (npc.ai[0] == 3.0 && npc.ai[1] == 2.0 && npc.ai[2] > 40.0)
                num6 = 0.08f;
            if (npc.ai[0] == 3.0 && npc.ai[1] == 4.0 && npc.ai[2] > (double)num2)
                num6 = 0.15f;
            if (npc.ai[0] == 3.0 && npc.ai[1] == 5.0)
                num6 = 0.05f;
            float num7 = num6 * 1.5f;
            if (npc.rotation < (double)num5)
            {
                if ((double)num5 - npc.rotation > 3.1415927410125732)
                    npc.rotation -= num7;
                else
                    npc.rotation += num7;
            }
            else if (npc.rotation > (double)num5)
            {
                if (npc.rotation - (double)num5 > 3.1415927410125732)
                    npc.rotation += num7;
                else
                    npc.rotation -= num7;
            }
            if (npc.rotation > (double)num5 - (double)num7 && npc.rotation < (double)num5 + (double)num7)
                npc.rotation = num5;
            if (npc.rotation < 0.0)
                npc.rotation += 6.28318548f;
            else if (npc.rotation > 6.2831854820251465)
                npc.rotation -= 6.28318548f;
            if (npc.rotation > (double)num5 - (double)num7 && npc.rotation < (double)num5 + (double)num7)
                npc.rotation = num5;
            if (Main.rand.NextBool(5))
            {
                int index = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + npc.height * 0.25f), npc.width, (int)(npc.height * 0.5), DustID.Blood, npc.velocity.X, 2f);
                Dust dust = Main.dust[index];
                dust.velocity.X *= 0.5f;
                dust.velocity.Y *= 0.1f;
            }
            if (num4 != 0)
            {
                npc.velocity.Y -= 0.04f;
                if (npc.timeLeft > 10)
                    npc.timeLeft = 10;
            }
            else if (npc.ai[0] == 0.0)
            {
                if (npc.ai[1] == 0.0)
                {
                    float num8 = 7f;
                    float num9 = 0.15f;
                    float num10 = num8 + 5f * num3;
                    float moveSpeed = num9 + 0.1f * num3;
                    if (flag1)
                    {
                        num10 += (float)(8.0 * (1.0 - (double)num1));
                        moveSpeed += (float)(0.17000000178813934 * (1.0 - (double)num1));
                    }
                    if (Main.getGoodWorld)
                    {
                        ++num10;
                        moveSpeed += 0.05f;
                    }
                    Vector2 vector2_1 = Main.player[npc.target].Center - Vector2.UnitY * 200f;
                    Vector2 desiredVelocity = npc.DirectionTo(vector2_1) * num10;
                    npc.SimpleFlyMovement(desiredVelocity, moveSpeed);
                    ++npc.ai[2];
                    float num11 = (float)(180.0 - (flag1 ? 200.0 * (1.0 - (double)num1) : 0.0));
                    if (npc.ai[2] >= (double)num11)
                    {
                        npc.ai[1] = 1f;
                        npc.ai[2] = 0.0f;
                        npc.ai[3] = 0.0f;
                        npc.TargetClosest();
                        npc.netUpdate = true;
                    }
                    else if (npc.WithinRange(vector2_1, 500f))
                    {
                        if (!Main.player[npc.target].dead)
                            ++npc.ai[3];
                        float num12 = 40f;
                        if (Main.getGoodWorld)
                            num12 *= 0.8f;
                        if (npc.ai[3] >= (double)num12)
                        {
                            npc.ai[3] = 0.0f;
                            npc.rotation = num5;
                            Vector2 vector2_2 = npc.DirectionTo(Main.player[npc.target].Center) * 6f;
                            Vector2 Position = npc.Center + vector2_2 * 10f;
                            if (Main.netMode != NetmodeID.MultiplayerClient && NPC.CountNPCS(5) < 12)
                            {
                                int number = NPC.NewNPC(npc.GetSource_FromAI(), (int)Position.X, (int)Position.Y, ModContent.NPCType<EOCServantAttacker>());
                                Main.npc[number].velocity = vector2_2;
                                if (Main.netMode == NetmodeID.Server && number < 200)
                                    NetMessage.SendData(MessageID.SyncNPC, number: number);
                            }
                            SoundEngine.PlaySound(in SoundID.NPCHit1, new Vector2?(Position));
                            for (int index = 0; index < 10; ++index)
                                Dust.NewDust(Position, 20, 20, DustID.Blood, vector2_2.X * 0.4f, vector2_2.Y * 0.4f);
                        }
                    }
                }
                else if (npc.ai[1] == 1.0)
                {
                    npc.rotation = num5;
                    float num13 = 9.25f + 5f * num3;
                    if (flag1)
                        num13 += (float)(8.5 * (1.0 - (double)num1));
                    if (Main.getGoodWorld)
                        ++num13;
                    npc.velocity = npc.DirectionTo(Main.player[npc.target].Center) * num13;
                    npc.ai[1] = 2f;
                    npc.netUpdate = true;
                    if (npc.netSpam > 10)
                        npc.netSpam = 10;
                }
                else if (npc.ai[1] == 2.0)
                {
                    ++npc.ai[2];
                    if (npc.ai[2] >= 40.0)
                    {
                        NPC npc1 = npc;
                        npc1.velocity = npc1.velocity * 0.975f;
                        if (Main.getGoodWorld)
                        {
                            NPC npc2 = npc;
                            npc2.velocity = npc2.velocity * 0.99f;
                        }
                        if (npc.velocity.X > -0.1 && npc.velocity.X < 0.1)
                            npc.velocity.X = 0.0f;
                        if (npc.velocity.Y > -0.1 && npc.velocity.Y < 0.1)
                            npc.velocity.Y = 0.0f;
                    }
                    else
                        npc.rotation = npc.velocity.ToRotation() - 1.57079637f;
                    int num14 = 90;
                    if (flag1)
                        num14 -= (int)Math.Round(120.0 * (1.0 - (double)num1));
                    if (Main.getGoodWorld)
                        num14 -= 15;
                    if (npc.ai[2] >= (double)num14)
                    {
                        ++npc.ai[3];
                        npc.ai[2] = 0.0f;
                        npc.TargetClosest();
                        npc.rotation = num5;
                        if (npc.ai[3] >= 3.0)
                        {
                            npc.ai[1] = 0.0f;
                            npc.ai[3] = 0.0f;
                        }
                        else
                            npc.ai[1] = 1f;
                    }
                }
                if (flag2)
                {
                    npc.ai[0] = 1f;
                    npc.ai[1] = 0.0f;
                    npc.ai[2] = 0.0f;
                    npc.ai[3] = 0.0f;
                    npc.TargetClosest();
                    npc.netUpdate = true;
                    if (npc.netSpam > 10)
                        npc.netSpam = 10;
                }
            }
            else if (npc.ai[0] == 1.0 || npc.ai[0] == 2.0)
            {
                if (npc.ai[0] == 1.0)
                {
                    npc.ai[2] += 0.005f;
                    if (npc.ai[2] > 0.5)
                        npc.ai[2] = 0.5f;
                }
                else
                {
                    npc.ai[2] -= 0.005f;
                    if (npc.ai[2] < 0.0)
                        npc.ai[2] = 0.0f;
                }
                npc.rotation += npc.ai[2];
                ++npc.ai[1];
                if (npc.ai[1] % 20.0 == 0.0)
                {
                    Vector2 vector2 = Main.rand.NextVector2CircularEdge(5.65f, 5.65f);
                    Vector2 Position = npc.Center + vector2 * 10f;
                    if (Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        int number = NPC.NewNPC(npc.GetSource_FromAI(), (int)Position.X, (int)Position.Y, ModContent.NPCType<EOCServantAttacker>());
                        Main.npc[number].velocity.X = vector2.X;
                        Main.npc[number].velocity.Y = vector2.Y;
                        if (Main.netMode == NetmodeID.Server && number < 200)
                            NetMessage.SendData(MessageID.SyncNPC, number: number);
                    }
                    for (int index = 0; index < 10; ++index)
                        Dust.NewDust(Position, 20, 20, DustID.Blood, vector2.X * 0.4f, vector2.Y * 0.4f);
                }
                if (npc.ai[1] == 100.0)
                {
                    ++npc.ai[0];
                    npc.ai[1] = 0.0f;
                    if (npc.ai[0] == 3.0)
                    {
                        npc.ai[2] = 0.0f;
                    }
                    else
                    {
                        SoundEngine.PlaySound(in SoundID.NPCHit1, new Vector2?(npc.position));
                        if (Main.netMode != NetmodeID.Server)
                        {
                            for (int index = 0; index < 2; ++index)
                            {
                                Gore.NewGore(npc.GetSource_FromAI(), npc.position, new Vector2(Main.rand.Next(-30, 31) * 0.2f, Main.rand.Next(-30, 31) * 0.2f), 8);
                                Gore.NewGore(npc.GetSource_FromAI(), npc.position, new Vector2(Main.rand.Next(-30, 31) * 0.2f, Main.rand.Next(-30, 31) * 0.2f), 7);
                                Gore.NewGore(npc.GetSource_FromAI(), npc.position, new Vector2(Main.rand.Next(-30, 31) * 0.2f, Main.rand.Next(-30, 31) * 0.2f), 6);
                            }
                        }
                        for (int index = 0; index < 20; ++index)
                            Dust.NewDust(npc.position, npc.width, npc.height, DustID.Blood, Main.rand.Next(-30, 31) * 0.2f, Main.rand.Next(-30, 31) * 0.2f);
                        SoundEngine.PlaySound(in SoundID.Roar, new Vector2?(npc.position));
                    }
                }
                Dust.NewDust(npc.position, npc.width, npc.height, DustID.Blood, Main.rand.Next(-30, 31) * 0.2f, Main.rand.Next(-30, 31) * 0.2f);
                NPC npc3 = npc;
                npc3.velocity = npc3.velocity * 0.98f;
                if (npc.velocity.X > -0.1 && npc.velocity.X < 0.1)
                    npc.velocity.X = 0.0f;
                if (npc.velocity.Y > -0.1 && npc.velocity.Y < 0.1)
                    npc.velocity.Y = 0.0f;
            }
            else
            {
                npc.defense = 0;
                npc.damage = (int)(npc.defDamage * (flag5 ? 1.3999999761581421 : 1.2000000476837158));
                if (npc.ai[1] == 0.0 & flag5)
                    npc.ai[1] = 5f;
                if (npc.ai[1] == 0.0)
                {
                    float num15 = (float)(5.5 + 3.5 * (0.75 - (double)num1));
                    float num16 = (float)(0.059999998658895493 + 0.02500000037252903 * (0.75 - (double)num1));
                    float num17 = num15 + 4f * num3;
                    float moveSpeed = num16 + 0.04f * num3;
                    if (flag1)
                    {
                        num17 += (float)(5.0 * (0.75 - (double)num1));
                        moveSpeed += (float)(0.039999999105930328 * (0.75 - (double)num1));
                    }
                    Vector2 vector2 = Main.player[npc.target].Center - Vector2.UnitY * 120f;
                    float num18 = npc.Distance(vector2);
                    if ((double)num18 > 400.0)
                    {
                        num17 += 1.25f;
                        moveSpeed += 0.075f;
                        if ((double)num18 > 600.0)
                        {
                            num17 += 1.25f;
                            moveSpeed += 0.075f;
                            if ((double)num18 > 800.0)
                            {
                                num17 += 1.25f;
                                moveSpeed += 0.075f;
                            }
                        }
                    }
                    if (Main.getGoodWorld)
                    {
                        ++num17;
                        moveSpeed += 0.1f;
                    }
                    Vector2 desiredVelocity = npc.DirectionTo(vector2) * num17;
                    npc.SimpleFlyMovement(desiredVelocity, moveSpeed);
                    ++npc.ai[2];
                    float num19 = (float)(200.0 - (flag1 ? 200.0 * (0.75 - (double)num1) : 0.0));
                    if (npc.ai[2] >= (double)num19)
                    {
                        npc.ai[1] = 1f;
                        npc.ai[2] = 0.0f;
                        npc.ai[3] = 0.0f;
                        if (flag4)
                            npc.ai[1] = 3f;
                        npc.TargetClosest();
                        npc.netUpdate = true;
                    }
                }
                else if (npc.ai[1] == 1.0)
                {
                    SoundEngine.PlaySound(in SoundID.ForceRoar, new Vector2?(npc.position));
                    npc.rotation = num5;
                    float num20 = (float)(6.1999998092651367 + 4.0 * (0.75 - (double)num1)) + 4f * num3;
                    if (flag1)
                        num20 += (float)(5.5 * (0.75 - (double)num1));
                    if (npc.ai[3] == 1.0)
                        num20 *= 1.25f;
                    if (npc.ai[3] == 2.0)
                        num20 *= 1.45f;
                    if (Main.getGoodWorld)
                        num20 *= 1.6f;
                    npc.velocity = npc.DirectionTo(Main.player[npc.target].Center) * num20;
                    npc.ai[1] = 2f;
                    npc.netUpdate = true;
                    if (npc.netSpam > 10)
                        npc.netSpam = 10;
                }
                else if (npc.ai[1] == 2.0)
                {
                    float num21 = 60f;
                    ++npc.ai[2];
                    if (npc.ai[2] >= (double)num21)
                    {
                        NPC npc4 = npc;
                        npc4.velocity = npc4.velocity * 0.96f;
                        if (npc.velocity.X > -0.1 && npc.velocity.X < 0.1)
                            npc.velocity.X = 0.0f;
                        if (npc.velocity.Y > -0.1 && npc.velocity.Y < 0.1)
                            npc.velocity.Y = 0.0f;
                    }
                    else
                        npc.rotation = npc.velocity.ToRotation() - 1.57079637f;
                    int num22 = 80;
                    if (flag1)
                        num22 -= (int)Math.Round(40.0 * (0.75 - (double)num1));
                    if (npc.ai[2] >= (double)num22)
                    {
                        ++npc.ai[3];
                        npc.ai[2] = 0.0f;
                        npc.TargetClosest();
                        npc.rotation = num5;
                        if (npc.ai[3] >= 3.0)
                        {
                            npc.ai[1] = 0.0f;
                            npc.ai[3] = 0.0f;
                            if (Main.netMode != NetmodeID.MultiplayerClient & flag3)
                            {
                                npc.ai[1] = 3f;
                                npc.ai[3] += Main.rand.Next(1, 4);
                            }
                            npc.netUpdate = true;
                            if (npc.netSpam > 10)
                                npc.netSpam = 10;
                        }
                        else
                            npc.ai[1] = 1f;
                    }
                }
                else if (npc.ai[1] == 3.0)
                {
                    if (npc.ai[3] == 4.0 & flag5 && npc.Center.Y > (double)Main.player[npc.target].Center.Y)
                    {
                        npc.TargetClosest();
                        npc.ai[1] = 0.0f;
                        npc.ai[2] = 0.0f;
                        npc.ai[3] = 0.0f;
                        npc.netUpdate = true;
                        if (npc.netSpam > 10)
                            npc.netSpam = 10;
                    }
                    else if (Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        float num23 = 18f + (flag1 ? (float)(5.0 * (0.64999997615814209 - (double)num1)) : (float)(3.5 * (0.64999997615814209 - (double)num1))) + 10f * num3;
                        Vector2 vector2 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                        float num24 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 - vector2.X;
                        float num25 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 - vector2.Y;
                        float num26 = Math.Abs(Main.player[npc.target].velocity.X) + Math.Abs(Main.player[npc.target].velocity.Y) / 4f;
                        float num27 = num26 + (10f - num26);
                        if ((double)num27 < 5.0)
                            num27 = 5f;
                        if ((double)num27 > 15.0)
                            num27 = 15f;
                        if (npc.ai[2] == -1.0)
                        {
                            num27 *= 4f;
                            num23 *= 1.3f;
                        }
                        float num28 = num24 - Main.player[npc.target].velocity.X * num27;
                        float num29 = num25 - (float)(Main.player[npc.target].velocity.Y * (double)num27 / 4.0);
                        float num30 = num28 * (float)(1.0 + Main.rand.Next(-10, 11) * 0.0099999997764825821);
                        float num31 = num29 * (float)(1.0 + Main.rand.Next(-10, 11) * 0.0099999997764825821);
                        float num32 = (float)Math.Sqrt((double)num30 * (double)num30 + (double)num31 * (double)num31);
                        double num33 = (double)num32;
                        float num34 = num23 / num32;
                        npc.velocity.X = num30 * num34;
                        npc.velocity.Y = num31 * num34;
                        npc.velocity.X += Main.rand.Next(-20, 21) * 0.1f;
                        npc.velocity.Y += Main.rand.Next(-20, 21) * 0.1f;
                        if (num33 < 100.0)
                        {
                            if ((double)Math.Abs(npc.velocity.X) > (double)Math.Abs(npc.velocity.Y))
                            {
                                float num35 = Math.Abs(npc.velocity.X);
                                float num36 = Math.Abs(npc.velocity.Y);
                                if (npc.Center.X > (double)Main.player[npc.target].Center.X)
                                    num36 *= -1f;
                                if (npc.Center.Y > (double)Main.player[npc.target].Center.Y)
                                    num35 *= -1f;
                                npc.velocity.X = num36;
                                npc.velocity.Y = num35;
                            }
                        }
                        else if ((double)Math.Abs(npc.velocity.X) > (double)Math.Abs(npc.velocity.Y))
                        {
                            float num37 = (float)(((double)Math.Abs(npc.velocity.X) + (double)Math.Abs(npc.velocity.Y)) / 2.0);
                            float num38 = num37;
                            if (npc.Center.X > (double)Main.player[npc.target].Center.X)
                                num38 *= -1f;
                            if (npc.Center.Y > (double)Main.player[npc.target].Center.Y)
                                num37 *= -1f;
                            npc.velocity.X = num38;
                            npc.velocity.Y = num37;
                        }
                        npc.ai[1] = 4f;
                        npc.netUpdate = true;
                        if (npc.netSpam > 10)
                            npc.netSpam = 10;
                    }
                }
                else if (npc.ai[1] == 4.0)
                {
                    if (npc.ai[2] == 0.0)
                        SoundEngine.PlaySound(in SoundID.ForceRoar, new Vector2?(npc.position));
                    float num39 = num2;
                    ++npc.ai[2];
                    if (npc.ai[2] == (double)num39 && (double)Vector2.Distance(npc.position, Main.player[npc.target].position) < 200.0)
                        --npc.ai[2];
                    if (npc.ai[2] >= (double)num39)
                    {
                        NPC npc5 = npc;
                        npc5.velocity = npc5.velocity * 0.95f;
                        if (npc.velocity.X > -0.1 && npc.velocity.X < 0.1)
                            npc.velocity.X = 0.0f;
                        if (npc.velocity.Y > -0.1 && npc.velocity.Y < 0.1)
                            npc.velocity.Y = 0.0f;
                    }
                    else
                        npc.rotation = npc.velocity.ToRotation() - 1.57079637f;
                    float num40 = num39 + 13f;
                    if (npc.ai[2] >= (double)num40)
                    {
                        npc.netUpdate = true;
                        if (npc.netSpam > 10)
                            npc.netSpam = 10;
                        ++npc.ai[3];
                        npc.ai[2] = 0.0f;
                        float num41 = flag1 ? (double)num1 < 0.05000000074505806 ? 1f : (double)num1 < 0.10000000149011612 ? 2f : (double)num1 < 0.15000000596046448 ? 3f : (double)num1 < 0.25 ? 4f : 5f : (double)num1 < 0.20000000298023224 ? 4f : 5f;
                        if (npc.ai[3] >= (double)num41)
                        {
                            npc.ai[1] = 0.0f;
                            npc.ai[3] = 0.0f;
                        }
                        else
                            npc.ai[1] = 3f;
                    }
                }
                else if (npc.ai[1] == 5.0)
                {
                    /*float num42Y = -400f; //600f
                    float num42X = 300f;

                    float num42YL = -400;
                    float num42XL = -300f;

                    float num43 = flag1 ? (float)(6.0 * (0.40000000596046448 - (double)num1)) : (float)(4.0 * (0.40000000596046448 - (double)num1));
                    float num44 = flag1 ? (float)(0.15000000596046448 * (0.40000000596046448 - (double)num1)) : (float)(0.10000000149011612 * (0.40000000596046448 - (double)num1));
                    float num45 = 8f + num43;
                    float moveSpeed = 0.25f + num44;
                    Vector2 vector2_3 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                    Vector2 position1 = Main.player[npc.target].position;
                    int num46 = Main.player[npc.target].width / 2;
                    Vector2 position2 = Main.player[npc.target].position;
                    int num47 = Main.player[npc.target].height / 2;
                    Vector2 destinationRight = Main.player[npc.target].Center + Vector2.UnitY * num42Y + Vector2.UnitX * num42X;
                    Vector2 destinationLeft = Main.player[npc.target].Center + Vector2.UnitY * num42YL + Vector2.UnitX * num42XL;
                    Vector2 desiredVelocity = npc.DirectionTo(destinationRight) * num45;
                    npc.SimpleFlyMovement(desiredVelocity, moveSpeed);

                    Vector2 desiredVelocityL = npc.DirectionTo(destinationLeft) * num45;
                    npc.SimpleFlyMovement(desiredVelocityL, moveSpeed);*/
                    /*if (npc.ai[2] == 0.0)
                        SoundEngine.PlaySound(in SoundID.ForceRoar, new Vector2?(npc.position));
                    float num39 = num2;
                    ++npc.ai[2];
                    if (npc.ai[2] == (double)num39 && (double)Vector2.Distance(npc.position, Main.player[npc.target].position) < 200.0)
                        --npc.ai[2];
                    if (npc.ai[2] >= (double)num39)
                    {
                        NPC npc5 = npc;
                        npc5.velocity = npc5.velocity * 0.95f;
                        if (npc.velocity.X > -0.1 && npc.velocity.X < 0.1)
                            npc.velocity.X = 0.0f;
                        if (npc.velocity.Y > -0.1 && npc.velocity.Y < 0.1)
                            npc.velocity.Y = 0.0f;
                    }
                    else
                        npc.rotation = npc.velocity.ToRotation() - 1.57079637f;
                    float num40 = num39 + 13f;
                    if (npc.ai[2] >= (double)num40)
                    {
                        npc.netUpdate = true;
                        if (npc.netSpam > 10)
                            npc.netSpam = 10;
                        ++npc.ai[3];
                        npc.ai[2] = 0.0f;
                        float num41 = flag1 ? (double)num1 < 0.05000000074505806 ? 1f : (double)num1 < 0.10000000149011612 ? 2f : (double)num1 < 0.15000000596046448 ? 3f : (double)num1 < 0.25 ? 4f : 5f : (double)num1 < 0.20000000298023224 ? 4f : 5f;
                        if (npc.ai[3] >= (double)num41)
                        {
                            npc.ai[1] = 0.0f;
                            npc.ai[3] = 0.0f;
                        }
                        else
                            npc.ai[1] = 3f;
                    }
                    Vector2 vector2_4 = Main.rand.NextVector2CircularEdge(5.65f, 5.65f);
                    Vector2 Position = npc.Center + vector2_4 * 10f;
                    if (Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        int number = NPC.NewNPC(npc.GetSource_FromAI(), (int)Position.X, (int)Position.Y, ModContent.NPCType<EOCServantAttacker>());
                        Main.npc[number].velocity.X = vector2_4.X;
                        Main.npc[number].velocity.Y = vector2_4.Y;
                        if (Main.netMode == NetmodeID.Server && number < 200)
                            NetMessage.SendData(MessageID.SyncNPC, number: number);
                    }
                    SoundEngine.PlaySound(in SoundID.NPCDeath13, new Vector2?(npc.position));
                    for (int index = 0; index < 10; ++index)
                        Dust.NewDust(Position, 20, 20, DustID.Blood, vector2_4.X * 0.4f, vector2_4.Y * 0.4f);
                    npc.netUpdate = true;
                    if (npc.netSpam > 10)
                        npc.netSpam = 10;
                }
                else if (npc.ai[1] == 6.0)
                {
                    if (Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        float num50 = 22f + (flag1 ? (float)(6.0 * (0.40000000596046448 - (double)num1)) : (float)(4.0 * (0.40000000596046448 - (double)num1))) + 10f * num3;
                        npc.velocity = npc.DirectionTo(Main.player[npc.target].Center) * num50;
                        npc.ai[1] = 7f;
                        npc.netUpdate = true;
                        if (npc.netSpam > 10)
                            npc.netSpam = 10;
                    }
                }
                else if (npc.ai[1] == 7.0)
                {
                    if (npc.ai[2] == 0.0)
                        SoundEngine.PlaySound(in SoundID.Roar, new Vector2?(npc.position));
                    float num51 = (float)Math.Round((double)num2 * 2.5);
                    ++npc.ai[2];
                    if (npc.ai[2] == (double)num51 && (double)Vector2.Distance(npc.position, Main.player[npc.target].position) < 200.0)
                        --npc.ai[2];
                    if (npc.ai[2] >= (double)num51)
                    {
                        NPC npc6 = npc;
                        npc6.velocity = npc6.velocity * 0.95f;
                        if (npc.velocity.X > -0.1 && npc.velocity.X < 0.1)
                            npc.velocity.X = 0.0f;
                        if (npc.velocity.Y > -0.1 && npc.velocity.Y < 0.1)
                            npc.velocity.Y = 0.0f;
                    }
                    else
                        npc.rotation = npc.velocity.ToRotation() - 1.57079637f;
                    float num52 = num51 + 13f;
                    if (npc.ai[2] >= (double)num52)
                    {
                        npc.netUpdate = true;
                        if (npc.netSpam > 10)
                            npc.netSpam = 10;
                        npc.ai[2] = 0.0f;
                        npc.ai[1] = 0.0f;
                    }
                }
            }
        }
        else if (Main.GameMode == GameModeID.Normal)
        {
            npc.aiStyle = NPCAIStyleID.EyeOfCthulhu;
        }
        else if (Main.GameMode == GameModeID.Expert)
        {
            npc.aiStyle = NPCAIStyleID.EyeOfCthulhu;
        }
        else if (Main.GameMode == GameModeID.Master)
        {
            npc.aiStyle = NPCAIStyleID.EyeOfCthulhu;
        }
        return false;

    }
    public static void SpawnMinions(NPC npc)
    {
        //Vector2 vector2_4 = Main.rand.NextVector2CircularEdge(5.65f, 5.65f);
        //Vector2 Position = npc.Center + vector2_4 * 10f;
        if (Main.netMode == NetmodeID.MultiplayerClient)
        {
            // Because we want to spawn minions, and minions are npcs, we have to do this on the server (or singleplayer, "!= NetmodeID.MultiplayerClient" covers both)
            // This means we also have to sync it after we spawned and set up the minion
            return;
        }

        int count = 60; //80
        var entitySource = npc.GetSource_FromAI();

        for (int i = 0; i < count; i++)
        {
            int index = NPC.NewNPC(entitySource, (int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<EOCServant>(), npc.whoAmI);

            //int index = NPC.NewNPC(entitySource, (int)Position.X, (int)Position.Y, ModContent.NPCType<EOCServant>(), npc.whoAmI);
            NPC minionnpc = Main.npc[index];

            // Now that the minion is spawned, we need to prepare it with data that is necessary for it to work
            // This is not required usually if you simply spawn npcs, but because the minion is tied to the body, we need to pass this information to it

            if (minionnpc.ModNPC is EOCServant minion)
            {
                // This checks if our spawned npc is indeed the minion, and casts it so we can access its variables
                minion.ParentIndex = npc.whoAmI; // Let the minion know who the "parent" is
                minion.PositionIndex = i; // Give it the iteration index so each minion has a separate one, used for movement
            }

            // Finally, syncing, only sync on server and if the npc actually exists (Main.maxnpcs is the index of a dummy npc, there is no point syncing it)
            if (Main.netMode == NetmodeID.Server && index < Main.maxNPCs)
            {
                NetMessage.SendData(MessageID.SyncNPC, number: index);
            }
        }
    }

    /*public override bool PreDraw(NPC npc, SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
    {
        if (RuinWorld.devastated == true)
        {
            SpriteEffects effects = SpriteEffects.None;
            if (npc.rotation < 180)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
            Texture2D texture2D = ModContent.Request<Texture2D>("RuinMod/Assets/Textures/DevaDiff/Devastated/NPC_4_Deva").Value;
            Color alpha1 = npc.GetAlpha(drawColor);
            Color color1 = Lighting.GetColor((int)(npc.position.X + npc.width * 0.5) / 16, (int)((npc.position.Y + npc.height * 0.5) / 16.0));
            Texture2D texture = TextureAssets.Npc[npc.type].Value;
            int height = TextureAssets.Npc[npc.type].Value.Height / Main.npcFrameCount[NPCID.EyeofCthulhu];
            Rectangle r = new Rectangle(0, height * (int)npc.frameCounter, texture.Width, height);
            Vector2 origin = r.Size() / 2f;
            spriteBatch.Draw(texture2D, npc.Center - screenPos + new Vector2(0.0f, npc.gfxOffY), new Rectangle?(npc.frame), alpha1, npc.rotation, npc.frame.Size() / 2f, npc.scale, effects, 0.0f);
            return false;
        }
        return true;
    }*/
/*}*/