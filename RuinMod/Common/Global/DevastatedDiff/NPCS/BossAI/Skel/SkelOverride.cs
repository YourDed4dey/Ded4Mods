/*using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using RuinMod.Common.Systems.DiffSystem;
using static Terraria.ModLoader.PlayerDrawLayer;

namespace RuinMod.Common.Global.DevastatedDiff.NPCS.BossAI.Skel
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
            if (RuinWorld.devastated)
            {
                    int defDefense = npc.defDefense;
                    int type = npc.type;
                    int width = npc.width;
                    int height = npc.height;
                    int whoAmI = npc.whoAmI;
                    int target = npc.target;

                if (npc.life <= 250 && npc.localAI[0] == 0.0f)
                {
                    npc.localAI[0] = 1f; //Dungeon Guardian AI
                    npc.ai[1] = 2f; //Dungeon Guardian AI
                    Main.NewText("Skeletron transformed into a Dungeon Guardian!", Color.Purple);

                    /*for (int i = 0; i < 2; i++)
                    {
                        int X = (int)(npc.position.X + (double)Main.rand.Next(npc.width - 40) + Main.rand.Next(npc.width - 17) + Main.rand.Next(npc.width - 1));
                        int Y = (int)(npc.position.Y + (double)Main.rand.Next(npc.height - 40) + Main.rand.Next(npc.height - 17) + Main.rand.Next(npc.height - 1));

                        int DungNpc = NPC.NewNPC(npc.GetSource_FromAI(), X, Y, NPCID.DungeonGuardian, 5);
                        Main.npc[DungNpc].lifeMax = 150;
                        Main.npc[DungNpc].life = 150;
                    }*/
                /*}

               /* if (npc.localAI[0] == 1f)// && npc.ai[1] == 2f)
                {
                    Vector2 position = npc.Center;
                    Vector2 targetPosition = Main.player[npc.target].Center;
                    Vector2 direction = targetPosition - position;
                    direction.Normalize();
                    float speed = 20f;

                    int type = ProjectileID.SuperStar
                    int damage = 9999;

                    for (int i = 0; i < 10; i++)
                    {
                        int projtype = Projectile.NewProjectile(null, position, direction * speed, ProjectileID.Bone, damage, 0, Main.myPlayer);
                        Main.projectile[projtype].hostile = true;
                        Main.projectile[projtype].friendly = false;
                        Main.projectile[projtype].tileCollide = false;
                    }
                }*/

                /*npc.reflectsProjectiles = false;
                npc.defense = defDefense;
                    if (npc.ai[0] == 0f && Main.netMode != NetmodeID.MultiplayerClient)
                    {
                    npc.TargetClosest();
                    npc.ai[0] = 1f;
                        if (type != 68)
                        {
                            int num148 = NPC.NewNPC(npc.GetSource_FromAI(), (int)(npc.position.X + (float)(width / 2)), (int)npc.position.Y + height / 2, 36, whoAmI);
                            Main.npc[num148].ai[0] = -1f;
                            Main.npc[num148].ai[1] = whoAmI;
                            Main.npc[num148].target = target;
                            Main.npc[num148].netUpdate = true;
                            num148 = NPC.NewNPC(npc.GetSource_FromAI(), (int)(npc.position.X + (float)(width / 2)), (int)npc.position.Y + height / 2, 36, whoAmI);
                            Main.npc[num148].ai[0] = 1f;
                            Main.npc[num148].ai[1] = whoAmI;
                            Main.npc[num148].ai[3] = 150f;
                            Main.npc[num148].target = target;
                            Main.npc[num148].netUpdate = true;
                        }
                    }
                    /*if ((type == 68 || Main.netMode == 1) && localAI[0] == 0f)
                    {
                        localAI[0] = 1f;
                        SoundEngine.PlaySound(15, (int)position.X, (int)position.Y, 0);
                    }*/
                    /*if (Main.player[target].dead || Math.Abs(npc.position.X - Main.player[target].position.X) > 2000f || Math.Abs(npc.position.Y - Main.player[target].position.Y) > 2000f)
                    {
                    npc.TargetClosest();
                        if (Main.player[target].dead || Math.Abs(npc.position.X - Main.player[target].position.X) > 2000f || Math.Abs(npc.position.Y - Main.player[target].position.Y) > 2000f)
                        {
                        npc.ai[1] = 3f;
                        }
                    }
                    /*if ((type == 68 || Main.dayTime) && this.ai[1] != 3f && this.ai[1] != 2f)
                    {
                        this.ai[1] = 2f;
                        SoundEngine.PlaySound(15, (int)position.X, (int)position.Y, 0);
                    }*/
                    /*int num149 = 0;
                    if (Main.expertMode)
                    {
                        for (int num150 = 0; num150 < 200; num150++)
                        {
                            if (Main.npc[num150].active && Main.npc[num150].type == type + 1)
                            {
                                num149++;
                            }
                        }
                    npc.defense += num149 * 25;
                        if ((num149 < 2 || (double)npc.life < (double)npc.lifeMax * 0.75) && npc.ai[1] == 0f)
                        {
                            float num151 = 80f;
                            if (num149 == 0)
                            {
                                num151 /= 2f;
                            }
                            if (Main.getGoodWorld)
                            {
                                num151 *= 0.8f;
                            }
                            if (Main.netMode != NetmodeID.MultiplayerClient && npc.ai[2] % num151 == 0f)
                            {
                                Vector2 center3 = npc.Center;
                                float num152 = Main.player[target].position.X + (float)(Main.player[target].width / 2) - center3.X;
                                float num153 = Main.player[target].position.Y + (float)(Main.player[target].height / 2) - center3.Y;
                                float num154 = (float)Math.Sqrt(num152 * num152 + num153 * num153);
                                if (Collision.CanHit(center3, 1, 1, Main.player[target].position, Main.player[target].width, Main.player[target].height))
                                {
                                    float num155 = 3f;
                                    if (num149 == 0)
                                    {
                                        num155 += 2f;
                                    }
                                    float num156 = Main.player[target].position.X + (float)Main.player[target].width * 0.5f - center3.X + (float)Main.rand.Next(-20, 21);
                                    float num157 = Main.player[target].position.Y + (float)Main.player[target].height * 0.5f - center3.Y + (float)Main.rand.Next(-20, 21);
                                    float num158 = (float)Math.Sqrt(num156 * num156 + num157 * num157);
                                    num158 = num155 / num158;
                                    num156 *= num158;
                                    num157 *= num158;
                                    Vector2 vector19 = new Vector2(num156 * 1f + (float)Main.rand.Next(-50, 51) * 0.01f, num157 * 1f + (float)Main.rand.Next(-50, 51) * 0.01f);
                                    vector19.Normalize();
                                    vector19 *= num155;
                                    vector19 += npc.velocity;
                                    num156 = vector19.X;
                                    num157 = vector19.Y;
                                    int attackDamage_ForProjectiles = npc.GetAttackDamage_ForProjectiles(17f, 17f);
                                    int num159 = 270;
                                    center3 += vector19 * 5f;
                                    int num160 = Projectile.NewProjectile(npc.GetSource_FromAI(), center3.X, center3.Y, num156, num157, num159, attackDamage_ForProjectiles, 0f, Main.myPlayer, -1f);
                                    Main.projectile[num160].timeLeft = 300;
                                }
                            }
                        }
                    }
                    if (npc.ai[1] == 0f)
                    {
                    npc.damage = npc.defDamage;
                    npc.ai[2] += 1f;
                        if (npc.ai[2] >= 800f)
                        {
                        npc.ai[2] = 0f;
                        npc.ai[1] = 1f;
                        npc.TargetClosest();
                        npc.netUpdate = true;
                        }
                        npc.rotation = npc.velocity.X / 15f;
                        float num161 = 0.02f;
                        float num162 = 2f;
                        float num163 = 0.05f;
                        float num164 = 8f;
                        if (Main.expertMode)
                        {
                            num161 = 0.03f;
                            num162 = 4f;
                            num163 = 0.07f;
                            num164 = 9.5f;
                        }
                        if (Main.getGoodWorld)
                        {
                            num161 += 0.01f;
                            num162 += 1f;
                            num163 += 0.05f;
                            num164 += 2f;
                        }
                        if (npc.position.Y > Main.player[target].position.Y - 250f)
                        {
                            if (npc.velocity.Y > 0f)
                            {
                            npc.velocity.Y *= 0.98f;
                            }
                        npc.velocity.Y -= num161;
                            if (npc.velocity.Y > num162)
                            {
                            npc.velocity.Y = num162;
                            }
                        }
                        else if (npc.position.Y < Main.player[target].position.Y - 250f)
                        {
                            if (npc.velocity.Y < 0f)
                            {
                            npc.velocity.Y *= 0.98f;
                            }
                        npc.velocity.Y += num161;
                            if (npc.velocity.Y < 0f - num162)
                            {
                            npc.velocity.Y = 0f - num162;
                            }
                        }
                        if (npc.position.X + (float)(width / 2) > Main.player[target].position.X + (float)(Main.player[target].width / 2))
                        {
                            if (npc.velocity.X > 0f)
                            {
                            npc.velocity.X *= 0.98f;
                            }
                        npc.velocity.X -= num163;
                            if (npc.velocity.X > num164)
                            {
                            npc.velocity.X = num164;
                            }
                        }
                        if (npc.position.X + (float)(width / 2) < Main.player[target].position.X + (float)(Main.player[target].width / 2))
                        {
                            if (npc.velocity.X < 0f)
                            {
                            npc.velocity.X *= 0.98f;
                            }
                        npc.velocity.X += num163;
                            if (npc.velocity.X < 0f - num164)
                            {
                            npc.velocity.X = 0f - num164;
                            }
                        }
                    }
                    else if (npc.ai[1] == 1f)
                    {
                        if (Main.getGoodWorld)
                        {
                            if (num149 > 0)
                            {
                            npc.reflectsProjectiles = true;
                            }
                            else if (Main.netMode != NetmodeID.MultiplayerClient && npc.ai[2] % 200f == 0f && NPC.CountNPCS(32) < 6)
                            {
                                int num165 = 1;
                                for (int num166 = 0; num166 < num165; num166++)
                                {
                                    int num167 = 1000;
                                    for (int num168 = 0; num168 < num167; num168++)
                                    {
                                        int num169 = (int)(npc.Center.X / 16f) + Main.rand.Next(-50, 51);
                                        int num170;
                                        for (num170 = (int)(npc.Center.Y / 16f) + Main.rand.Next(-50, 51); num170 < Main.maxTilesY - 10 && !WorldGen.SolidTile(num169, num170); num170++)
                                        {
                                        }
                                        num170--;
                                        if (!WorldGen.SolidTile(num169, num170))
                                        {
                                            int num171 = NPC.NewNPC(npc.GetSource_FromAI(), num169 * 16 + 8, num170 * 16, 32);
                                            if (Main.netMode == NetmodeID.Server && num171 < 200)
                                            {
                                                NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, num171);
                                            }
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    npc.defense -= 10;
                    npc.ai[2] += 1f;
                        if (npc.ai[2] == 2f)
                        {
                            //SoundEngine.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
                        }
                        if (npc.ai[2] >= 400f)
                        {
                        npc.ai[2] = 0f;
                        npc.ai[1] = 0f;
                        }
                        npc.rotation += (float)npc.direction * 0.3f;
                        Vector2 vector20 = new Vector2(npc.position.X + (float)width * 0.5f, npc.position.Y + (float)height * 0.5f);
                        float num172 = Main.player[target].position.X + (float)(Main.player[target].width / 2) - vector20.X;
                        float num173 = Main.player[target].position.Y + (float)(Main.player[target].height / 2) - vector20.Y;
                        float num174 = (float)Math.Sqrt(num172 * num172 + num173 * num173);
                        float num175 = 1.5f;
                    npc.damage = npc.GetAttackDamage_LerpBetweenFinalValues(npc.defDamage, (float)npc.defDamage * 1.3f);
                        if (Main.expertMode)
                        {
                            num175 = 3.5f;
                            if (num174 > 150f)
                            {
                                num175 *= 1.05f;
                            }
                            if (num174 > 200f)
                            {
                                num175 *= 1.1f;
                            }
                            if (num174 > 250f)
                            {
                                num175 *= 1.1f;
                            }
                            if (num174 > 300f)
                            {
                                num175 *= 1.1f;
                            }
                            if (num174 > 350f)
                            {
                                num175 *= 1.1f;
                            }
                            if (num174 > 400f)
                            {
                                num175 *= 1.1f;
                            }
                            if (num174 > 450f)
                            {
                                num175 *= 1.1f;
                            }
                            if (num174 > 500f)
                            {
                                num175 *= 1.1f;
                            }
                            if (num174 > 550f)
                            {
                                num175 *= 1.1f;
                            }
                            if (num174 > 600f)
                            {
                                num175 *= 1.1f;
                            }
                            switch (num149)
                            {
                                case 0:
                                    num175 *= 1.1f;
                                    break;
                                case 1:
                                    num175 *= 1.05f;
                                    break;
                            }
                        }
                        if (Main.getGoodWorld)
                        {
                            num175 *= 1.3f;
                        }
                        num174 = num175 / num174;
                    npc.velocity.X = num172 * num174;
                    npc.velocity.Y = num173 * num174;
                    }
                    else if (npc.ai[1] == 2f)
                    {
                    npc.damage = 1000;
                    npc.defense = 9999;
                        npc.rotation += (float)npc.direction * 0.3f;
                        Vector2 vector21 = new Vector2(npc.position.X + (float)width * 0.5f, npc.position.Y + (float)height * 0.5f);
                        float num176 = Main.player[target].position.X + (float)(Main.player[target].width / 2) - vector21.X;
                        float num177 = Main.player[target].position.Y + (float)(Main.player[target].height / 2) - vector21.Y;
                        float num178 = (float)Math.Sqrt(num176 * num176 + num177 * num177);
                        num178 = 8f / num178;
                    npc.velocity.X = num176 * num178;
                    npc.velocity.Y = num177 * num178;
                    }
                    else if (npc.ai[1] == 3f)
                    {
                    npc.velocity.Y += 0.1f;
                        if (npc.velocity.Y < 0f)
                        {
                        npc.velocity.Y *= 0.95f;
                        }
                    npc.velocity.X *= 0.95f;
                    npc.EncourageDespawn(50);
                    }
                    if (npc.ai[1] != 2f && npc.ai[1] != 3f && type != 68 && (num149 != 0 || !Main.expertMode))
                    {
                        /*int num179 = Dust.NewDust(new Vector2(npc.position.X + (float)(width / 2) - 15f - npc.velocity.X * 5f, npc.position.Y + (float)height - 2f), 30, 10, DustID.Blood, (0f - npc.velocity.X) * 0.2f, 3f, 0, default(Color), 2f);
                        Main.dust[num179].noGravity = true;
                        Main.dust[num179].velocity.X *= 1.3f;
                        Main.dust[num179].velocity.X += npc.velocity.X * 0.4f;
                        Main.dust[num179].velocity.Y += 2f + npc.velocity.Y;
                        for (int num180 = 0; num180 < 2; num180++)
                        {
                            num179 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + 120f), width, 60, DustID.Blood, npc.velocity.X, npc.velocity.Y, 0, default(Color), 2f);
                            Main.dust[num179].noGravity = true;
                            Dust dust = Main.dust[num179];
                            dust.velocity -= npc.velocity;
                            Main.dust[num179].velocity.Y += 5f;
                        }*/
                    /*}
            }
            else if (Main.GameMode == GameModeID.Normal)
            {
                npc.aiStyle = NPCAIStyleID.SkeletronHead;
            }
            else if (Main.GameMode == GameModeID.Expert)
            {
                npc.aiStyle = NPCAIStyleID.SkeletronHead;
            }
            else if (Main.GameMode == GameModeID.Master)
            {
                npc.aiStyle = NPCAIStyleID.SkeletronHead;
            }
            return false;

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
                Texture2D texture2D = ModContent.Request<Texture2D>("RuinMod/Assets/Textures/DevaDiff/Devastated/NPC_35_Deva").Value;
                Color alpha1 = npc.GetAlpha(drawColor);
                Color color1 = Lighting.GetColor((int)(npc.position.X + npc.width * 0.5) / 16, (int)((npc.position.Y + npc.height * 0.5) / 16.0));
                Texture2D texture = TextureAssets.Npc[npc.type].Value;
                int height = TextureAssets.Npc[npc.type].Value.Height / Main.npcFrameCount[NPCID.SkeletronHead];
                Rectangle r = new Rectangle(0, height * (int)npc.frameCounter, texture.Width, height);
                Vector2 origin = r.Size() / 2f;
                spriteBatch.Draw(texture2D, npc.Center - screenPos + new Vector2(0.0f, npc.gfxOffY), new Rectangle?(npc.frame), alpha1, npc.rotation, npc.frame.Size() / 2f, npc.scale, effects, 0.0f);
                return false;
            }
            return true;
        }
    }
}*/
