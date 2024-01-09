/*using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using RuinMod.Common.Systems.DiffSystem;
using Microsoft.Xna.Framework.Graphics.PackedVector;
using static MonoMod.Cil.RuntimeILReferenceBag.FastDelegateInvokers;
using static System.Formats.Asn1.AsnWriter;
using static Terraria.ModLoader.PlayerDrawLayer;

namespace RuinMod.Common.Global.DevastatedDiff.NPCS.BossAI.BOC
{
    internal class BOCOverride : GlobalNPC
    {
        public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
        {
            return entity.type == NPCID.BrainofCthulhu;
        }
        public override bool PreAI(NPC npc)
        {
            BuffedBrainAI(npc);
            if (RuinWorld.devastated)
                return false;


            else return true;
        }
        public static int GetBrainOfCthuluCreepersCount()
        {
            if (Main.getGoodWorld)
            {
                return 40;
            }
            if (RuinWorld.devastated)
            {
                return 50;
            }
            return 20;
        }
        public static bool BuffedBrainAI(NPC npc)
        {
            if (RuinWorld.devastated)
            {
                int whoAmI = npc.whoAmI;
                int width = npc.width;
                int height = npc.height;
                float[] localAI = npc.localAI;
                int target = npc.target;
                bool justHit = npc.justHit;

                NPC.crimsonBoss = whoAmI;
                if (Main.netMode != NetmodeID.MultiplayerClient && localAI[0] == 0f)
                {
                    localAI[0] = 1f;
                    int brainOfCthuluCreepersCount = NPC.GetBrainOfCthuluCreepersCount();
                    for (int num837 = 0; num837 < brainOfCthuluCreepersCount; num837++)
                    {
                        float x2 = npc.Center.X;
                        float y4 = npc.Center.Y;
                        x2 += (float)Main.rand.Next(-width, width);
                        y4 += (float)Main.rand.Next(-height, height);
                        int num838 = NPC.NewNPC(npc.GetSource_FromAI(), (int)x2, (int)y4, 267);
                        Main.npc[num838].velocity = new Vector2((float)Main.rand.Next(-30, 31) * 0.1f, (float)Main.rand.Next(-30, 31) * 0.1f);
                        Main.npc[num838].netUpdate = true;
                    }
                }
                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    npc.TargetClosest();
                    int num839 = 6000;
                    if (Math.Abs(npc.Center.X - Main.player[target].Center.X) + Math.Abs(npc.Center.Y - Main.player[target].Center.Y) > (float)num839)
                    {
                        npc.active = false;
                        npc.life = 0;
                        if (Main.netMode == NetmodeID.Server)
                        {
                            NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, whoAmI);
                        }
                    }
                }
                if (npc.ai[0] < 0f)
                {
                    if (Main.getGoodWorld)
                    {
                        //brainOfGravity = whoAmI;
                    }
                    if (localAI[2] == 0f)
                    {
                        //SoundEngine.PlaySound(3, (int)position.X, (int)position.Y);
                        localAI[2] = 1f;
                        //Gore.NewGore(position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 392);
                        //Gore.NewGore(position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 393);
                        //Gore.NewGore(position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 394);
                        //Gore.NewGore(position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 395);
                        for (int num840 = 0; num840 < 20; num840++)
                        {
                            Dust.NewDust(npc.position, width, height, DustID.Blood, (float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f);
                        }
                        //SoundEngine.PlaySound(15, (int)position.X, (int)position.Y, 0);
                    }
                    npc.dontTakeDamage = false;
                    npc.TargetClosest();
                    Vector2 vector104 = new Vector2(npc.Center.X, npc.Center.Y);
                    float num841 = Main.player[target].Center.X - vector104.X;
                    float num842 = Main.player[target].Center.Y - vector104.Y;
                    float num843 = (float)Math.Sqrt(num841 * num841 + num842 * num842);
                    float num844 = 8f;
                    num843 = num844 / num843;
                    num841 *= num843;
                    num842 *= num843;
                    npc.velocity.X = (npc.velocity.X * 50f + num841) / 51f;
                    npc.velocity.Y = (npc.velocity.Y * 50f + num842) / 51f;
                    if (npc.ai[0] == -1f)
                    {
                        if (Main.netMode != NetmodeID.MultiplayerClient)
                        {
                            localAI[1] += 1f;
                            if (justHit)
                            {
                                localAI[1] -= Main.rand.Next(5);
                            }
                            int num845 = 60 + Main.rand.Next(120);
                            if (Main.netMode != NetmodeID.SinglePlayer)
                            {
                                num845 += Main.rand.Next(30, 90);
                            }
                            if (localAI[1] >= (float)num845)
                            {
                                localAI[1] = 0f;
                                npc.TargetClosest();
                                int num846 = 0;
                                Player player2 = Main.player[target];
                                do
                                {
                                    num846++;
                                    int num847 = (int)player2.Center.X / 16;
                                    int num848 = (int)player2.Center.Y / 16;
                                    int minValue = 10;
                                    int num849 = 12;
                                    float num850 = 16f;
                                    int num851 = Main.rand.Next(minValue, num849 + 1);
                                    int num852 = Main.rand.Next(minValue, num849 + 1);
                                    if (Main.rand.NextBool(2))
                                    {
                                        num851 *= -1;
                                    }
                                    if (Main.rand.NextBool(2))
                                    {
                                        num852 *= -1;
                                    }
                                    Vector2 v = new Vector2(num851 * 16, num852 * 16);
                                    if (Vector2.Dot(player2.velocity.SafeNormalize(Vector2.UnitY), v.SafeNormalize(Vector2.UnitY)) > 0f)
                                    {
                                        v += v.SafeNormalize(Vector2.Zero) * num850 * player2.velocity.Length();
                                    }
                                    num847 += (int)(v.X / 16f);
                                    num848 += (int)(v.Y / 16f);
                                    if (num846 > 100 || !WorldGen.SolidTile(num847, num848))
                                    {
                                        npc.ai[3] = 0f;
                                        npc.ai[0] = -2f;
                                        npc.ai[1] = num847;
                                        npc.ai[2] = num848;
                                        npc.netUpdate = true;
                                        npc.netSpam = 0;
                                        break;
                                    }
                                }
                                while (num846 <= 100);
                            }
                        }
                    }
                    else if (npc.ai[0] == -2f)
                    {
                        npc.velocity *= 0.9f;
                        if (Main.netMode != NetmodeID.SinglePlayer)
                        {
                            npc.ai[3] += 15f;
                        }
                        else
                        {
                            npc.ai[3] += 25f;
                        }
                        if (npc.ai[3] >= 255f)
                        {
                            npc.ai[3] = 255f;
                            npc.position.X = npc.ai[1] * 16f - (float)(width / 2);
                            npc.position.Y = npc.ai[2] * 16f - (float)(height / 2);
                            SoundEngine.PlaySound(SoundID.Item8, npc.Center);
                            npc.ai[0] = -3f;
                            npc.netUpdate = true;
                            npc.netSpam = 0;
                        }
                        npc.alpha = (int)npc.ai[3];
                    }
                    else if (npc.ai[0] == -3f)
                    {
                        if (Main.netMode != NetmodeID.SinglePlayer)
                        {
                            npc.ai[3] -= 15f;
                        }
                        else
                        {
                            npc.ai[3] -= 25f;
                        }
                        if (npc.ai[3] <= 0f)
                        {
                            npc.ai[3] = 0f;
                            npc.ai[0] = -1f;
                            npc.netUpdate = true;
                            npc.netSpam = 0;
                        }
                        npc.alpha = (int)npc.ai[3];
                    }
                }
                else
                {
                    npc.TargetClosest();
                    Vector2 vector105 = new Vector2(npc.Center.X, npc.Center.Y);
                    float num853 = Main.player[target].Center.X - vector105.X;
                    float num854 = Main.player[target].Center.Y - vector105.Y;
                    float num855 = (float)Math.Sqrt(num853 * num853 + num854 * num854);
                    float num856 = 1f;
                    if (Main.getGoodWorld)
                    {
                        num856 *= 3f;
                    }
                    if (num855 < num856)
                    {
                        npc.velocity.X = num853;
                        npc.velocity.Y = num854;
                    }
                    else
                    {
                        num855 = num856 / num855;
                        npc.velocity.X = num853 * num855;
                        npc.velocity.Y = num854 * num855;
                    }
                    if (npc.ai[0] == 0f)
                    {
                        if (Main.netMode != NetmodeID.MultiplayerClient)
                        {
                            int num857 = 0;
                            for (int num858 = 0; num858 < 200; num858++)
                            {
                                if (Main.npc[num858].active && Main.npc[num858].type == NPCID.Creeper)
                                {
                                    num857++;
                                }
                            }
                            if (num857 == 0)
                            {
                                npc.ai[0] = -1f;
                                localAI[1] = 0f;
                                npc.alpha = 0;
                                npc.netUpdate = true;
                            }
                            localAI[1] += 1f;
                            if (localAI[1] >= (float)(120 + Main.rand.Next(300)))
                            {
                                localAI[1] = 0f;
                                npc.TargetClosest();
                                int num859 = 0;
                                Player player3 = Main.player[target];
                                do
                                {
                                    num859++;
                                    int num860 = (int)player3.Center.X / 16;
                                    int num861 = (int)player3.Center.Y / 16;
                                    int minValue2 = 12;
                                    int num862 = 40;
                                    float num863 = 16f;
                                    int num864 = Main.rand.Next(minValue2, num862 + 1);
                                    int num865 = Main.rand.Next(minValue2, num862 + 1);
                                    if (Main.rand.NextBool(2))
                                    {
                                        num864 *= -1;
                                    }
                                    if (Main.rand.NextBool(2))
                                    {
                                        num865 *= -1;
                                    }
                                    Vector2 v2 = new Vector2(num864 * 16, num865 * 16);
                                    if (Vector2.Dot(player3.velocity.SafeNormalize(Vector2.UnitY), v2.SafeNormalize(Vector2.UnitY)) > 0f)
                                    {
                                        v2 += v2.SafeNormalize(Vector2.Zero) * num863 * player3.velocity.Length();
                                    }
                                    num860 += (int)(v2.X / 16f);
                                    num861 += (int)(v2.Y / 16f);
                                    if (num859 > 100 || (!WorldGen.SolidTile(num860, num861) && (num859 > 75 || Collision.CanHit(new Vector2(num860 * 16, num861 * 16), 1, 1, Main.player[target].position, Main.player[target].width, Main.player[target].height))))
                                    {
                                        npc.ai[0] = 1f;
                                        npc.ai[1] = num860;
                                        npc.ai[2] = num861;
                                        npc.netUpdate = true;
                                        break;
                                    }
                                }
                                while (num859 <= 100);
                            }
                        }
                    }
                    else if (npc.ai[0] == 1f)
                    {
                        npc.alpha += 5;
                        if (npc.alpha >= 255)
                        {
                            SoundEngine.PlaySound(SoundID.Item8, npc.Center);
                            npc.alpha = 255;
                            npc.position.X = npc.ai[1] * 16f - (float)(width / 2);
                            npc.position.Y = npc.ai[2] * 16f - (float)(height / 2);
                            npc.ai[0] = 2f;
                        }
                    }
                    else if (npc.ai[0] == 2f)
                    {
                        npc.alpha -= 5;
                        if (npc.alpha <= 0)
                        {
                            npc.alpha = 0;
                            npc.ai[0] = 0f;
                        }
                    }
                }
                if (Main.player[target].dead || !Main.player[target].ZoneCrimson)
                {
                    if (localAI[3] < 120f)
                    {
                        localAI[3]++;
                    }
                    if (localAI[3] > 60f)
                    {
                        npc.velocity.Y += (localAI[3] - 60f) * 0.25f;
                    }
                    npc.ai[0] = 2f;
                    npc.alpha = 10;
                }
                else if (localAI[3] > 0f)
                {
                    localAI[3]--;
                }
            }
            else if (Main.GameMode == GameModeID.Normal)
            {
                npc.aiStyle = NPCAIStyleID.BrainOfCthulhu;
            }
            else if (Main.GameMode == GameModeID.Expert)
            {
                npc.aiStyle = NPCAIStyleID.BrainOfCthulhu;
            }
            else if (Main.GameMode == GameModeID.Master)
            {
                npc.aiStyle = NPCAIStyleID.BrainOfCthulhu;
            }
            return false;
        }
        /*public override bool PreDraw(NPC npc, SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            SpriteEffects effects = SpriteEffects.None;
            //if (npc.spriteDirection == 1)
            effects = SpriteEffects.FlipHorizontally;
            float num5 = 0.0f;
            Vector2 origin = new Vector2(TextureAssets.Npc[npc.type].Value.Width / 2, TextureAssets.Npc[npc.type].Value.Height / Main.npcFrameCount[npc.type] / 2);
            Color c1 = npc.GetAlpha(drawColor);
            Color alpha = npc.GetAlpha(drawColor);
            //float num6 = 0.99f;
            //alpha.R = 50;
            //alpha.G = 50;
            //alpha.B = 50;
            //alpha.A = 50;
            if (npc.active && npc.type == NPCID.Creeper)
            {
                
            }
            else
            {
                if (RuinWorld.devastated == true)
                {
                    if (npc.type == NPCID.BrainofCthulhu)
                    {
                        for (int index = 0; index < 4; ++index)
                        {
                            Texture2D texture2D = ModContent.Request<Texture2D>("RuinMod/Assets/Textures/DevaDiff/Devastated/NPC_266_Deva").Value;
                            Vector2 position = npc.position;
                            float num7 = Math.Abs(npc.Center.X - Main.LocalPlayer.Center.X);
                            float num8 = Math.Abs(npc.Center.Y - Main.LocalPlayer.Center.Y);
                            position.X = index == 0 || index == 2 ? Main.LocalPlayer.Center.X + num7 : Main.LocalPlayer.Center.X - num7;
                            position.X -= npc.width / 2;
                            position.Y = index == 0 || index == 1 ? Main.LocalPlayer.Center.Y + num8 : Main.LocalPlayer.Center.Y - num8;
                            position.Y -= npc.height / 5.9f; //2 //5.8f
                            Main.spriteBatch.Draw(texture2D, new Vector2((float)(position.X - (double)screenPos.X + npc.width / 2 - texture2D.Width * (double)npc.scale / 2.0 + origin.X * (double)npc.scale), (float)(position.Y - (double)screenPos.Y + npc.height - texture2D.Height * (double)npc.scale / Main.npcFrameCount[npc.type] + 4.0 + origin.Y * (double)npc.scale) + num5 + npc.gfxOffY), new Rectangle?(npc.frame), alpha, npc.rotation, origin, npc.scale, effects, 0.0f);
                        }
                    }
                }
            }
            return true;
        }*/

        /*public override bool PreDraw(NPC npc, SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            SpriteEffects effects = SpriteEffects.None;
            if (npc.spriteDirection == 1)
                effects = SpriteEffects.FlipHorizontally;
            float num5 = 0.0f;
            Vector2 origin = new Vector2(TextureAssets.Npc[npc.type].Value.Width / 2, TextureAssets.Npc[npc.type].Value.Height / Main.npcFrameCount[npc.type] / 2);
            Color c1 = npc.GetAlpha(drawColor);
            Color alpha = c1;
            //float num6 = 0.99f;
            //alpha.R = (byte)(alpha.R * (double)num6);
            //alpha.G = (byte)(alpha.G * (double)num6);
            //alpha.B = (byte)(alpha.B * (double)num6);
            //alpha.A = 50;
            if (RuinWorld.devastated == true)
            {
                if (npc.type == NPCID.BrainofCthulhu)
                {
                    for (int index = 0; index < 4; ++index)
                    {
                        Texture2D texture2D = ModContent.Request<Texture2D>("RuinMod/Assets/Textures/DevaDiff/Devastated/NPC_266_Deva").Value;
                        Vector2 position = npc.position;
                        float num7 = Math.Abs(npc.Center.X - Main.LocalPlayer.Center.X);
                        float num8 = Math.Abs(npc.Center.Y - Main.LocalPlayer.Center.Y);
                        position.X = index == 0 || index == 2 ? Main.LocalPlayer.Center.X + num7 : Main.LocalPlayer.Center.X - num7;
                        position.X -= npc.width / 2;
                        position.Y = index == 0 || index == 1 ? Main.LocalPlayer.Center.Y + num8 : Main.LocalPlayer.Center.Y - num8;
                        position.Y -= npc.height / 5.9f;
                        Main.spriteBatch.Draw(texture2D, new Vector2((float)(position.X - (double)screenPos.X + npc.width / 2 - TextureAssets.Npc[npc.type].Value.Width * (double)npc.scale / 2.0 + origin.X * (double)npc.scale), (float)(position.Y - (double)screenPos.Y + npc.height - TextureAssets.Npc[npc.type].Value.Height * (double)npc.scale / Main.npcFrameCount[npc.type] + 4.0 + origin.Y * (double)npc.scale) + num5 + npc.gfxOffY), new Rectangle?(npc.frame), alpha, npc.rotation, origin, npc.scale, effects, 0.0f);
                        Vector2 position1 = new Vector2(npc.position.X, npc.position.Y - 300);
                        float num71 = Math.Abs(npc.Center.X - Main.LocalPlayer.Center.X);
                        float num81 = Math.Abs(npc.Center.Y - 300 - Main.LocalPlayer.Center.Y);
                        position1.X = index == 0 || index == 2 ? Main.LocalPlayer.Center.X + num71 : Main.LocalPlayer.Center.X - num71;
                        position1.X -= npc.width / 2;
                        position1.Y = index == 0 || index == 1 ? Main.LocalPlayer.Center.Y + num81 : Main.LocalPlayer.Center.Y - num81;
                        position1.Y -= npc.height / 5.9f;
                        Main.spriteBatch.Draw(texture2D, new Vector2((float)(position1.X - (double)screenPos.X + npc.width / 2 - TextureAssets.Npc[npc.type].Value.Width * (double)npc.scale / 2.0 + origin.X * (double)npc.scale), (float)(position1.Y - (double)screenPos.Y + npc.height - TextureAssets.Npc[npc.type].Value.Height * (double)npc.scale / Main.npcFrameCount[npc.type] + 4.0 + origin.Y * (double)npc.scale) + num5 + npc.gfxOffY), new Rectangle?(npc.frame), alpha, npc.rotation, origin, npc.scale, effects, 0.0f);
                        Vector2 position2 = new Vector2(npc.position.X, npc.position.Y - 300);
                        float num711 = Math.Abs(npc.Center.X + 300 - Main.LocalPlayer.Center.X);
                        float num811 = Math.Abs(npc.Center.Y - Main.LocalPlayer.Center.Y);
                        position2.X = index == 0 || index == 2 ? Main.LocalPlayer.Center.X + num711 : Main.LocalPlayer.Center.X - num711;
                        position2.X -= npc.width / 2;
                        position2.Y = index == 0 || index == 1 ? Main.LocalPlayer.Center.Y + num811 : Main.LocalPlayer.Center.Y - num811;
                        position2.Y -= npc.height / 5.9f;
                        Main.spriteBatch.Draw(texture2D, new Vector2((float)(position2.X - (double)screenPos.X + npc.width / 2 - TextureAssets.Npc[npc.type].Value.Width * (double)npc.scale / 2.0 + origin.X * (double)npc.scale), (float)(position2.Y - (double)screenPos.Y + npc.height - TextureAssets.Npc[npc.type].Value.Height * (double)npc.scale / Main.npcFrameCount[npc.type] + 4.0 + origin.Y * (double)npc.scale) + num5 + npc.gfxOffY), new Rectangle?(npc.frame), alpha, npc.rotation, origin, npc.scale, effects, 0.0f);
                    }
                }
            }
            return true;
        }
    }
}*/
