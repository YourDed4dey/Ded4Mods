/*using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics.PackedVector;
using static MonoMod.Cil.RuntimeILReferenceBag.FastDelegateInvokers;
using static System.Formats.Asn1.AsnWriter;
using static Terraria.ModLoader.PlayerDrawLayer;
using System.Collections.Generic;
using RuinMod.Common.Systems.DiffSystem;

namespace RuinMod.Common.Global.DevastatedDiff.NPCS.BossAI.EOW
{
    internal class EOWHeadOverride : GlobalNPC
    {
        public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
        {
            return entity.type == NPCID.EaterofWorldsHead || entity.type == NPCID.EaterofWorldsBody || entity.type == NPCID.EaterofWorldsTail;
        }
        public override bool PreAI(NPC npc)
        {
            DoWormAIFazin(npc);
            if (RuinWorld.devastated)
                return false;


            else return true;
        }
        public static int GetEaterOfWorldsSegmentsCount()
        {
            if (!Main.expertMode)
            {
                return 65;
            }
            else if (!RuinWorld.devastated)
            {
                if (Main.hardMode)
                {
                    return 110;
                }
                return 90;
            }
            return 70;
        }
        /*public override void SetDefaults(NPC npc)
        {
            if (RuinWorld.devastated)
            {
                if (npc.type == NPCID.EaterofWorldsHead || npc.type == NPCID.EaterofWorldsBody || npc.type == NPCID.EaterofWorldsTail)
                {
                    npc.alpha = 1;

                    npc.scale += 0.1f;
                }
            }
        }*/
        /*public static bool DoWormAIFazin(NPC npc)
        {
            if (RuinWorld.devastated)
            {
                npc.ai[3]++;
                if (npc.ai[3] <= 600)
                {
                    npc.dontTakeDamage = true;
                }
                else
                {
                    npc.dontTakeDamage = false;
                }

                npc.alpha = 1;

                int type = npc.type;
                int width = npc.width;
                int height = npc.height;
                int alpha = npc.alpha;
                int realLife = npc.realLife;
                int whoAmI = npc.whoAmI;
                int target = npc.target;

                if (npc.type == NPCID.EaterofWorldsHead)
                {
                    npc.reflectsProjectiles = true;
                }

                if (Main.netMode != NetmodeID.MultiplayerClient && Main.expertMode)
                {
                    if (npc.type == NPCID.EaterofWorldsBody && ((double)(npc.position.Y / 16f) < Main.worldSurface || Main.getGoodWorld))
                    {
                        int num7 = (int)(npc.Center.X / 16f);
                        int num8 = (int)(npc.Center.Y / 16f);
                        if (WorldGen.InWorld(num7, num8) && Main.tile[num7, num8].WallType == 0)
                        {
                            int num9 = 900;
                            if (Main.getGoodWorld)
                            {
                                num9 /= 2;
                            }
                            if (Main.rand.NextBool(num9))
                            {
                                npc.TargetClosest();
                                if (Collision.CanHitLine(npc.Center, 1, 1, Main.player[npc.target].Center, 1, 1))
                                {
                                    int normalthingything1 = NPC.NewNPC(npc.GetSource_FromAI(), (int)(npc.position.X + npc.width / 2 + npc.velocity.X), (int)(npc.position.Y + npc.height / 2 + npc.velocity.Y), 666, 0, 0f, 1f);
                                }
                            }
                        }
                    }
                    else if (npc.type == NPCID.EaterofWorldsHead)
                    {
                        int num10 = 90;
                        num10 += (int)(npc.life / (float)npc.lifeMax * 60f * 5f);
                        if (Main.rand.NextBool(num10))
                        {
                            npc.TargetClosest();
                            if (Collision.CanHitLine(npc.Center, 1, 1, Main.player[npc.target].Center, 1, 1))
                            {
                                int x = (int)(npc.position.X + width / 2 + npc.velocity.X);
                                int y = (int)(npc.position.Y + height / 2 + npc.velocity.Y);

                                int numerouno = NPC.NewNPC(npc.GetSource_FromAI(), x, y, 666, 0, 0f, 1f);
                            }
                        }
                    }
                }
                bool flag = false;
                float num11 = 0.2f;
                switch (type)
                {
                    case 513:
                        flag = !Main.player[npc.target].ZoneUndergroundDesert;
                        num11 = 0.1f;
                        break;
                    case 10:
                    case 39:
                    case 95:
                    case 117:
                    case 510:
                        flag = true;
                        break;
                    case 621:
                        flag = false;
                        break;
                }
                if (type >= 13 && type <= 15)
                {
                    realLife = -1;
                }
                else if (npc.ai[3] > 0f)
                {
                    realLife = (int)npc.ai[3];
                }
                if (target < 0 || target == 255 || Main.player[target].dead || flag && Main.player[target].position.Y < Main.worldSurface * 16.0)
                {
                    npc.TargetClosest();
                }
                if (Main.player[target].dead || flag && Main.player[target].position.Y < Main.worldSurface * 16.0)
                {
                    npc.EncourageDespawn(300);
                    if (flag)
                    {
                        npc.velocity.Y += num11;
                    }
                }
                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    if (type == 621 && npc.ai[0] == 0f)
                    {
                        npc.ai[3] = whoAmI;
                        realLife = whoAmI;
                        int num28 = 0;
                        int num29 = whoAmI;
                        int num30 = 16;
                        for (int num31 = 0; num31 < num30; num31++)
                        {
                            int num32 = 622;
                            if (num31 == num30 - 1)
                            {
                                num32 = 623;
                            }
                            num28 = NPC.NewNPC(npc.GetSource_FromAI(), (int)(npc.position.X + width / 2), (int)(npc.position.Y + height), num32, whoAmI);
                            Main.npc[num28].ai[3] = whoAmI;
                            Main.npc[num28].realLife = whoAmI;
                            Main.npc[num28].ai[1] = num29;
                            Main.npc[num28].CopyInteractions(npc);
                            Main.npc[num29].ai[0] = num28;
                            NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, num28);
                            num29 = num28;
                        }
                    }
                    else if ((type == 13 || type == 14) && npc.ai[0] == 0f)
                    {
                        if (type == 13)
                        {
                            if (type < 13 || type > 15)
                            {
                                npc.ai[3] = whoAmI;
                                realLife = whoAmI;
                            }
                            npc.ai[2] = Main.rand.Next(8, 13);
                            if (type == 13)
                            {
                                npc.ai[2] = GetEaterOfWorldsSegmentsCount();
                            }
                            npc.ai[0] = NPC.NewNPC(npc.GetSource_FromAI(), (int)(npc.position.X + width / 2), (int)(npc.position.Y + height), type + 1, whoAmI);
                            Main.npc[(int)npc.ai[0]].CopyInteractions(npc);
                        }
                        else if (type == 14 && npc.ai[2] > 0f)
                        {
                            npc.ai[0] = NPC.NewNPC(npc.GetSource_FromAI(), (int)(npc.position.X + width / 2), (int)(npc.position.Y + height), type, whoAmI);
                            Main.npc[(int)npc.ai[0]].CopyInteractions(npc);
                        }
                        else
                        {
                            npc.ai[0] = NPC.NewNPC(npc.GetSource_FromAI(), (int)(npc.position.X + width / 2), (int)(npc.position.Y + height), type + 1, whoAmI);
                            Main.npc[(int)npc.ai[0]].CopyInteractions(npc);
                        }
                        if (type < 13 || type > 15)
                        {
                            Main.npc[(int)npc.ai[0]].ai[3] = npc.ai[3];
                            Main.npc[(int)npc.ai[0]].realLife = realLife;
                        }
                        Main.npc[(int)npc.ai[0]].ai[1] = whoAmI;
                        Main.npc[(int)npc.ai[0]].ai[2] = npc.ai[2] - 1f;
                        npc.netUpdate = true;
                    }
                    if (type == 13 || type == 14 || type == 15)
                    {
                        if (!Main.npc[(int)npc.ai[1]].active && !Main.npc[(int)npc.ai[0]].active)
                        {
                            npc.life = 0;
                            npc.HitEffect();
                            npc.checkDead();
                            npc.active = false;
                            NetMessage.SendData(MessageID.DamageNPC, -1, -1, null, whoAmI, -1f);
                        }
                        if (type == 13 && !Main.npc[(int)npc.ai[0]].active)
                        {
                            npc.life = 0;
                            npc.HitEffect();
                            npc.checkDead();
                            npc.active = false;
                            NetMessage.SendData(MessageID.DamageNPC, -1, -1, null, whoAmI, -1f);
                        }
                        if (type == 15 && !Main.npc[(int)npc.ai[1]].active)
                        {
                            npc.life = 0;
                            npc.HitEffect();
                            npc.checkDead();
                            npc.active = false;
                            NetMessage.SendData(MessageID.DamageNPC, -1, -1, null, whoAmI, -1f);
                        }
                        if (type == 14 && (!Main.npc[(int)npc.ai[1]].active || Main.npc[(int)npc.ai[1]].aiStyle != npc.aiStyle))
                        {
                            type = 13;
                            int num38 = whoAmI;
                            float num39 = npc.life / (float)npc.lifeMax;
                            float num40 = npc.ai[0];
                            npc.SetDefaultsKeepPlayerInteraction(type);
                            npc.life = (int)(npc.lifeMax * num39);
                            npc.ai[0] = num40;
                            npc.TargetClosest();
                            npc.netUpdate = true;
                            whoAmI = num38;
                            alpha = 0;
                        }
                        if (type == 14 && (!Main.npc[(int)npc.ai[0]].active || Main.npc[(int)npc.ai[0]].aiStyle != npc.aiStyle))
                        {
                            type = 15;
                            int num41 = whoAmI;
                            float num42 = npc.life / (float)npc.lifeMax;
                            float num43 = npc.ai[1];
                            npc.SetDefaultsKeepPlayerInteraction(type);
                            npc.life = (int)(npc.lifeMax * num42);
                            npc.ai[1] = num43;
                            npc.TargetClosest();
                            npc.netUpdate = true;
                            whoAmI = num41;
                            alpha = 0;
                        }
                    }
                    if (!npc.active && Main.netMode == NetmodeID.Server)
                    {
                        NetMessage.SendData(MessageID.DamageNPC, -1, -1, null, whoAmI, -1f);
                    }
                }
                int num44 = (int)(npc.position.X / 16f) - 1;
                int num45 = (int)((npc.position.X + width) / 16f) + 2;
                int num46 = (int)(npc.position.Y / 16f) - 1;
                int num47 = (int)((npc.position.Y + height) / 16f) + 2;
                if (num44 < 0)
                {
                    num44 = 0;
                }
                if (num45 > Main.maxTilesX)
                {
                    num45 = Main.maxTilesX;
                }
                if (num46 < 0)
                {
                    num46 = 0;
                }
                if (num47 > Main.maxTilesY)
                {
                    num47 = Main.maxTilesY;
                }
                bool flag2 = false;
                if (!flag2)
                {
                    Vector2 vector2 = default;
                    for (int num48 = num44; num48 < num45; num48++)
                    {
                        for (int num49 = num46; num49 < num47; num49++)
                        {
                            /*if (Main.tile[num48, num49] == null || ((!Main.tile[num48, num49].nactive() || (!Main.tileSolid[Main.tile[num48, num49].TileType] && (!Main.tileSolidTop[Main.tile[num48, num49].type] || Main.tile[num48, num49].frameY != 0))) && Main.tile[num48, num49].liquid <= 64))
                            {
                                continue;
                            }*/
                            /*vector2.X = num48 * 16;
                            vector2.Y = num49 * 16;
                            if (npc.position.X + width > vector2.X && npc.position.X < vector2.X + 16f && npc.position.Y + height > vector2.Y && npc.position.Y < vector2.Y + 16f)
                            {
                                flag2 = true;
                                /*if (Main.rand.NextBool(100) && type != 117 && Main.tile[num48, num49].nactive() && Main.tileSolid[Main.tile[num48, num49].TileType])
                                {
                                    WorldGen.KillTile(num48, num49, fail: true, effectOnly: true);
                                }*/
                            /*}
                        }
                    }
                }
                if (!flag2 && type == 13)
                {
                    Rectangle rectangle = new Rectangle((int)npc.position.X, (int)npc.position.Y, width, height);
                    int num50 = 1000;
                    bool flag3 = true;
                    for (int num51 = 0; num51 < 255; num51++)
                    {
                        if (Main.player[num51].active)
                        {
                            Rectangle rectangle2 = new Rectangle((int)Main.player[num51].position.X - num50, (int)Main.player[num51].position.Y - num50, num50 * 2, num50 * 2);
                            if (rectangle.Intersects(rectangle2))
                            {
                                flag3 = false;
                                break;
                            }
                        }
                    }
                    if (flag3)
                    {
                        flag2 = true;
                    }
                }
                float num52 = 11f;
                float num53 = 0.085f;
                if (type == 13)
                {
                    num52 = 13f;
                    num53 = 0.12f;
                    if (Main.expertMode)
                    {
                        num52 = 15f;
                        num53 = 0.18f;
                    }
                    if (Main.getGoodWorld)
                    {
                        num52 += 4f;
                        num53 += 0.05f;
                    }
                }
                Vector2 vector5 = new Vector2(npc.position.X + width * 0.5f, npc.position.Y + height * 0.5f);
                float num55 = Main.player[target].position.X + Main.player[target].width / 2;
                float num56 = Main.player[target].position.Y + Main.player[target].height / 2;
                num55 = (int)(num55 / 16f) * 16;
                num56 = (int)(num56 / 16f) * 16;
                vector5.X = (int)(vector5.X / 16f) * 16;
                vector5.Y = (int)(vector5.Y / 16f) * 16;
                num55 -= vector5.X;
                num56 -= vector5.Y;
                float num68 = (float)Math.Sqrt(num55 * num55 + num56 * num56);
                if (npc.ai[1] > 0f && npc.ai[1] < Main.npc.Length)
                {
                    try
                    {
                        vector5 = new Vector2(npc.position.X + width * 0.5f, npc.position.Y + height * 0.5f);
                        num55 = Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2 - vector5.X;
                        num56 = Main.npc[(int)npc.ai[1]].position.Y + Main.npc[(int)npc.ai[1]].height / 2 - vector5.Y;
                    }
                    catch
                    {
                    }
                    npc.rotation = (float)Math.Atan2(num56, num55) + 1.57f;
                    num68 = (float)Math.Sqrt(num55 * num55 + num56 * num56);
                    int num69 = width;
                    if (type >= 13 && type <= 15)
                    {
                        num69 = (int)(num69 * npc.scale);
                    }
                    if (Main.getGoodWorld && type >= 13 && type <= 15)
                    {
                        num69 = 62;
                    }
                    num68 = (num68 - num69) / num68;
                    num55 *= num68;
                    num56 *= num68;
                    npc.velocity = Vector2.Zero;
                    npc.position.X += num55;
                    npc.position.Y += num56;
                }
                else
                {
                    if (!flag2)
                    {
                        npc.TargetClosest();
                    }
                    else
                    {
                        num68 = (float)Math.Sqrt(num55 * num55 + num56 * num56);
                        float num71 = Math.Abs(num55);
                        float num72 = Math.Abs(num56);
                        float num73 = num52 / num68;
                        num55 *= num73;
                        num56 *= num73;
                        bool flag4 = false;
                        if (type == 13 && (!Main.player[target].ZoneCorrupt && !Main.player[target].ZoneCrimson || Main.player[target].dead))
                        {
                            flag4 = true;
                        }
                        if (flag4)
                        {
                            bool flag5 = true;
                            for (int num74 = 0; num74 < 255; num74++)
                            {
                                if (Main.player[num74].active && !Main.player[num74].dead && Main.player[num74].ZoneCorrupt)
                                {
                                    flag5 = false;
                                }
                            }
                            if (flag5)
                            {
                                if (Main.netMode != NetmodeID.MultiplayerClient && (double)(npc.position.Y / 16f) > (Main.rockLayer + Main.maxTilesY) / 2.0)
                                {
                                    npc.active = false;
                                    int num75 = (int)npc.ai[0];
                                    while (num75 > 0 && num75 < 200 && Main.npc[num75].active && Main.npc[num75].aiStyle == npc.aiStyle)
                                    {
                                        int num76 = (int)Main.npc[num75].ai[0];
                                        Main.npc[num75].active = false;
                                        npc.life = 0;
                                        if (Main.netMode == NetmodeID.Server)
                                        {
                                            NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, num75);
                                        }
                                        num75 = num76;
                                    }
                                    if (Main.netMode == NetmodeID.Server)
                                    {
                                        NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, whoAmI);
                                    }
                                }
                                num55 = 0f;
                                num56 = num52;
                            }
                        }
                        bool flag6 = false;
                        if (!flag6)
                        {
                            if (npc.velocity.X > 0f && num55 > 0f || npc.velocity.X < 0f && num55 < 0f || npc.velocity.Y > 0f && num56 > 0f || npc.velocity.Y < 0f && num56 < 0f)
                            {
                                if (npc.velocity.X < num55)
                                {
                                    npc.velocity.X += num53;
                                }
                                else if (npc.velocity.X > num55)
                                {
                                    npc.velocity.X -= num53;
                                }
                                if (npc.velocity.Y < num56)
                                {
                                    npc.velocity.Y += num53;
                                }
                                else if (npc.velocity.Y > num56)
                                {
                                    npc.velocity.Y -= num53;
                                }
                                if ((double)Math.Abs(num56) < (double)num52 * 0.2 && (npc.velocity.X > 0f && num55 < 0f || npc.velocity.X < 0f && num55 > 0f))
                                {
                                    if (npc.velocity.Y > 0f)
                                    {
                                        npc.velocity.Y += num53 * 2f;
                                    }
                                    else
                                    {
                                        npc.velocity.Y -= num53 * 2f;
                                    }
                                }
                                if ((double)Math.Abs(num55) < (double)num52 * 0.2 && (npc.velocity.Y > 0f && num56 < 0f || npc.velocity.Y < 0f && num56 > 0f))
                                {
                                    if (npc.velocity.X > 0f)
                                    {
                                        npc.velocity.X += num53 * 2f;
                                    }
                                    else
                                    {
                                        npc.velocity.X -= num53 * 2f;
                                    }
                                }
                            }
                            else if (num71 > num72)
                            {
                                if (npc.velocity.X < num55)
                                {
                                    npc.velocity.X += num53 * 1.1f;
                                }
                                else if (npc.velocity.X > num55)
                                {
                                    npc.velocity.X -= num53 * 1.1f;
                                }
                                if ((double)(Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y)) < (double)num52 * 0.5)
                                {
                                    if (npc.velocity.Y > 0f)
                                    {
                                        npc.velocity.Y += num53;
                                    }
                                    else
                                    {
                                        npc.velocity.Y -= num53;
                                    }
                                }
                            }
                            else
                            {
                                if (npc.velocity.Y < num56)
                                {
                                    npc.velocity.Y += num53 * 1.1f;
                                }
                                else if (npc.velocity.Y > num56)
                                {
                                    npc.velocity.Y -= num53 * 1.1f;
                                }
                                if ((double)(Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y)) < (double)num52 * 0.5)
                                {
                                    if (npc.velocity.X > 0f)
                                    {
                                        npc.velocity.X += num53;
                                    }
                                    else
                                    {
                                        npc.velocity.X -= num53;
                                    }
                                }
                            }
                        }
                    }
                    npc.rotation = (float)Math.Atan2(npc.velocity.Y, npc.velocity.X) + 1.57f;
                    if (type == 13)
                    {
                        if (flag2)
                        {
                            if (npc.localAI[0] != 1f)
                            {
                                npc.netUpdate = true;
                            }
                            npc.localAI[0] = 1f;
                        }
                        else
                        {
                            if (npc.localAI[0] != 0f)
                            {
                                npc.netUpdate = true;
                            }
                            npc.localAI[0] = 0f;
                        }
                        if ((npc.velocity.X > 0f && npc.oldVelocity.X < 0f || npc.velocity.X < 0f && npc.oldVelocity.X > 0f || npc.velocity.Y > 0f && npc.oldVelocity.Y < 0f || npc.velocity.Y < 0f && npc.oldVelocity.Y > 0f) && !npc.justHit)
                        {
                            npc.netUpdate = true;
                        }
                    }
                }
                if (alpha > 0 && npc.life > 0)
                {
                    for (int num80 = 0; num80 < 2; num80++)
                    {
                        /*int num81 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), width, height, DustID.Demonite, 0f, 0f, 100, default(Color), 2f);
                        Main.dust[num81].noGravity = true;
                        Main.dust[num81].noLight = true;*/
                    /*}
                }
                if ((npc.position - npc.oldPosition).Length() > 2f)
                {
                    alpha -= 42;
                    if (alpha < 0)
                    {
                        alpha = 0;
                    }
                }
            }
            else if (Main.GameMode == GameModeID.Normal)
            {
                npc.aiStyle = NPCAIStyleID.Worm;
            }
            else if (Main.GameMode == GameModeID.Expert)
            {
                npc.aiStyle = NPCAIStyleID.Worm;
            }
            else if (Main.GameMode == GameModeID.Master)
            {
                npc.aiStyle = NPCAIStyleID.Worm;
            }
            return false;
        }
        /*public override bool PreDraw(NPC npc, SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            if (RuinWorld.devastated == true)
            {
                if (npc.type == NPCID.EaterofWorldsHead)
                {
                    SpriteEffects effects = SpriteEffects.None;
                    Texture2D texture1 = ModContent.Request<Texture2D>("RuinMod/Assets/Textures/DevaDiff/Devastated/NPC_13_Deva").Value;
                    Vector2 origin = new Vector2(TextureAssets.Npc[13].Value.Width / 2, TextureAssets.Npc[15].Value.Height / 2);
                    Vector2 position = npc.Center - screenPos - new Vector2(texture1.Width, texture1.Height) * npc.scale / 2f + (origin * npc.scale + new Vector2(0.0f, npc.gfxOffY));
                    spriteBatch.Draw(texture1, position, new Rectangle?(npc.frame), npc.GetAlpha(drawColor), npc.rotation, origin, npc.scale, effects, 0.0f);
                    return false;
                }
                if (npc.type == NPCID.EaterofWorldsBody)
                {
                    SpriteEffects effects = SpriteEffects.None;
                    Texture2D texture1 = ModContent.Request<Texture2D>("RuinMod/Assets/Textures/DevaDiff/Devastated/NPC_14_Deva").Value;
                    Vector2 origin = new Vector2(TextureAssets.Npc[13].Value.Width / 2, TextureAssets.Npc[15].Value.Height / 2);
                    Vector2 position = npc.Center - screenPos - new Vector2(texture1.Width, texture1.Height) * npc.scale / 2f + (origin * npc.scale + new Vector2(0.0f, npc.gfxOffY));
                    spriteBatch.Draw(texture1, position, new Rectangle?(npc.frame), npc.GetAlpha(drawColor), npc.rotation, origin, npc.scale, effects, 0.0f);
                    return false;
                }
                if (npc.type == NPCID.EaterofWorldsTail)
                {
                    SpriteEffects effects = SpriteEffects.None;
                    Texture2D texture1 = ModContent.Request<Texture2D>("RuinMod/Assets/Textures/DevaDiff/Devastated/NPC_15_Deva").Value;
                    Vector2 origin = new Vector2(TextureAssets.Npc[13].Value.Width / 2, TextureAssets.Npc[15].Value.Height / 2);
                    Vector2 position = npc.Center - screenPos - new Vector2(texture1.Width, texture1.Height) * npc.scale / 2f + (origin * npc.scale + new Vector2(0.0f, npc.gfxOffY));
                    spriteBatch.Draw(texture1, position, new Rectangle?(npc.frame), npc.GetAlpha(drawColor), npc.rotation, origin, npc.scale, effects, 0.0f);
                    return false;
                }
            }
            return base.PreDraw(npc, spriteBatch, screenPos, drawColor);
        }
    }
}*/