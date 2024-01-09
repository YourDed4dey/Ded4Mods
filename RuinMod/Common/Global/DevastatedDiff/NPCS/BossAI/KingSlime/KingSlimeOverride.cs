/*using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using RuinMod.Common.Systems.DiffSystem;
using RuinMod.Common.Global.DevastatedDiff.Projectiles.HostileAI.CandySpike;
using RuinMod.Common.Global.DevastatedDiff.Potions.Debuffs.BadSugarRush;

namespace RuinMod.Common.Global.DevastatedDiff.NPCS.BossAI.KingSlime
{
    internal class KingSlimeOverride : GlobalNPC
    {

        public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
        {
            return entity.type == NPCID.KingSlime;
        }

        public override bool PreAI(NPC npc)
        {
            BuffedKingAI(npc);
            if (RuinWorld.devastated)
                return false;


            else return true;
        }

        public override void OnKill(NPC npc)
        {
            if (RuinWorld.devastated)
            {
                for (int i = 0; i < 5; i++)
                {
                    int X = (int)(npc.position.X + (double)Main.rand.Next(npc.width - 32) + Main.rand.Next(npc.width - 30) + Main.rand.Next(npc.width - 25));
                    int Y = (int)(npc.position.Y + (double)Main.rand.Next(npc.height - 32));

                    NPC.NewNPC(npc.GetSource_FromAI(), X, Y, NPCID.HoppinJack, 5);
                }
            }
        }

        public override void OnHitPlayer(NPC npc, Player target, Player.HurtInfo hurtInfo)
        {
            if (RuinWorld.devastated)
            {
                if (!target.HasBuff(ModContent.BuffType<BadSugarRush>()))
                {
                    target.AddBuff(ModContent.BuffType<BadSugarRush>(), 60 * 3);
                }

                if (!target.HasBuff(BuffID.Poisoned))
                {
                    target.AddBuff(BuffID.Poisoned, 60 * 3);
                }

                if (!target.HasBuff(BuffID.Confused))
                {
                    target.AddBuff(BuffID.Confused, 60 * 3);
                }
            }
        }

        public static bool BuffedKingAI(NPC npc)
        {
            if (RuinWorld.devastated)
            {
                //float kitingOffsetX = Utils.Clamp(Main.player[npc.target].velocity.X * 16, -600, 600);
                //Vector2 position = npc.Top + new Vector2(kitingOffsetX + Main.rand.Next(-600, 600), Main.rand.Next(-150, 600)); //npc.Center

                /*if (Main.hardMode)
                {
                    if (Main.player[npc.target].HasBuff(ModContent.BuffType<BadSugarRush>()))
                    {

                    }
                }*/

                /*if (npc.life <= 50)
                {
                    npc.reflectsProjectiles = true;
                }

                else
                {
                    npc.reflectsProjectiles = false;
                }

                if (npc.life <= 935)
                {
                    float kitingOffsetX = Utils.Clamp(Main.player[npc.target].velocity.X * 16, -600, 600);
                    Vector2 position = npc.Top + new Vector2(kitingOffsetX + Main.rand.Next(-600, 600), Main.rand.Next(-150, 600)); //npc.Center

                    Vector2 targetPosition = Main.player[npc.target].Center;
                    Vector2 direction = targetPosition - position;
                    direction.Normalize();
                    float speed = 10f;

                    int type = ModContent.ProjectileType<CandySpikeProjectile>(); // ProjectileID.SpikedSlimeSpike
                    Vector2 velocity = direction * speed;
                    int damage = 5;


                    const int NumProjectilesHard = 1;

                    for (int i = 0; i < NumProjectilesHard; i++)
                    {
                        Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(30)); //15

                        newVelocity *= 1f - Main.rand.NextFloat(0.3f);

                        Projectile.NewProjectile(null, position, newVelocity, type, damage, 0, Main.myPlayer);
                    }
                }

                float num42Y1 = -150f;

                Vector2 position1 = npc.Center;

                //Vector2 targetPositionLeft = npc.Center + Vector2.UnitX * num42X1;
                Vector2 targetPosition1 = npc.Center + Vector2.UnitY * num42Y1;
                Vector2 direction1 = targetPosition1 - position1;
                direction1.Normalize();
                float speed1 = 10f;

                int type1 = ModContent.ProjectileType<CandySpikeProjectile>(); // ProjectileID.SpikedSlimeSpike
                Vector2 velocity1 = direction1 * speed1;
                int damage1 = 15;


                const int NumProjectilesHard1 = 1;

                for (int i = 0; i < NumProjectilesHard1; i++)
                {
                    Vector2 newVelocity1 = velocity1.RotatedByRandom(MathHelper.ToRadians(30)); //15

                    newVelocity1 *= 1f - Main.rand.NextFloat(0.3f);

                    Projectile.NewProjectile(null, position1, newVelocity1, type1, damage1, 0, Main.myPlayer);
                }
                float num741 = 1f;
                bool flag95 = false;
                bool flag103 = false;
                npc.aiAction = 0;
                if (npc.ai[3] == 0f && npc.life > 0)
                {
                    npc.ai[3] = npc.lifeMax;
                }
                if (npc.localAI[3] == 0f && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    npc.ai[0] = -100f;
                    npc.localAI[3] = 1f;
                    npc.TargetClosest();
                    npc.netUpdate = true;
                }
                if (Main.player[npc.target].dead)
                {
                    npc.TargetClosest();
                    if (Main.player[npc.target].dead)
                    {
                        npc.timeLeft = 0;
                        if (Main.player[npc.target].Center.X < npc.Center.X)
                        {
                            npc.direction = 1;
                        }
                        else
                        {
                            npc.direction = -1;
                        }
                    }
                }
                if (!Main.player[npc.target].dead && npc.ai[2] >= 300f && npc.ai[1] < 5f && npc.velocity.Y == 0f)
                {
                    npc.ai[2] = 0f;
                    npc.ai[0] = 0f;
                    npc.ai[1] = 5f;
                    if (Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        npc.TargetClosest(faceTarget: false);
                        Point point8 = npc.Center.ToTileCoordinates();
                        Point point9 = Main.player[npc.target].Center.ToTileCoordinates();
                        Vector2 vector165 = Main.player[npc.target].Center - npc.Center;
                        int num744 = 10;
                        int num745 = 0;
                        int num746 = 7;
                        int num747 = 0;
                        bool flag2 = false;
                        if (vector165.Length() > 2000f)
                        {
                            flag2 = true;
                            num747 = 100;
                        }
                        while (!flag2 && num747 < 100)
                        {
                            num747++;
                            int num748 = Main.rand.Next(point9.X - num744, point9.X + num744 + 1);
                            int num749 = Main.rand.Next(point9.Y - num744, point9.Y + 1);
                            /*if ((num749 >= point9.Y - num746 && num749 <= point9.Y + num746 && num748 >= point9.X - num746 && num748 <= point9.X + num746) || (num749 >= point8.Y - num745 && num749 <= point8.Y + num745 && num748 >= point8.X - num745 && num748 <= point8.X + num745) || Main.tile[num748, num749].nactive())
                            {
                                continue;
                            }*/
                            /*int num751 = num749;
                            int num752 = 0;
                            /*if (Main.tile[num748, num751].nactive() && Main.tileSolid[Main.tile[num748, num751].TileType] && !Main.tileSolidTop[Main.tile[num748, num751].TileType])
                            {
                                num752 = 1;
                            }
                            else
                            {
                                for (; num752 < 150 && num751 + num752 < Main.maxTilesY; num752++)
                                {
                                    int num753 = num751 + num752;
                                    if (Main.tile[num748, num753].nactive() && Main.tileSolid[Main.tile[num748, num753].TileType] && !Main.tileSolidTop[Main.tile[num748, num753].TileType])
                                    {
                                        num752--;
                                        break;
                                    }
                                }
                            }*/
                            /*num749 += num752;
                            bool flag28 = true;
                            /*if (flag28 && Main.tile[num748, num749].lava())
                            {
                                flag28 = false;
                            }*/
                           /*if (flag28 && !Collision.CanHitLine(npc.Center, 0, 0, Main.player[npc.target].Center, 0, 0))
                            {
                                flag28 = false;
                            }
                            if (flag28)
                            {
                                npc.localAI[1] = num748 * 16 + 8;
                                npc.localAI[2] = num749 * 16 + 16;
                                break;
                            }
                        }
                        if (num747 >= 100)
                        {
                            Vector2 bottom = Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].Bottom;
                            npc.localAI[1] = bottom.X;
                            npc.localAI[2] = bottom.Y;
                        }
                    }
                }
                if (!Collision.CanHitLine(npc.Center, 0, 0, Main.player[npc.target].Center, 0, 0))
                {
                    npc.ai[2] += 1f;
                }
                if (Math.Abs(npc.Top.Y - Main.player[npc.target].Bottom.Y) > 320f)
                {
                    npc.ai[2] += 1f;
                }
                Dust dust24;
                if (npc.ai[1] == 5f)
                {
                    flag95 = true;
                    npc.aiAction = 1;
                    npc.ai[0] += 1f;
                    num741 = MathHelper.Clamp((60f - npc.ai[0]) / 60f, 0f, 1f);
                    num741 = 0.5f + num741 * 0.5f;
                    if (npc.ai[0] >= 60f)
                    {
                        flag103 = true;
                    }
                    if (npc.ai[0] == 60f)
                    {
                        //Gore.NewGoreDirect(npc.Center + new Vector2(-40f, (0f - (float)npc.height) / 2f), npc.velocity, 734);
                    }
                    if (npc.ai[0] >= 60f && Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        npc.Bottom = new Vector2(npc.localAI[1], npc.localAI[2]);
                        npc.ai[1] = 6f;
                        npc.ai[0] = 0f;
                        npc.netUpdate = true;
                    }
                    if (Main.netMode == NetmodeID.MultiplayerClient && npc.ai[0] >= 120f)
                    {
                        npc.ai[1] = 6f;
                        npc.ai[0] = 0f;
                    }
                    if (!flag103)
                    {
                        for (int num755 = 0; num755 < 10; num755++)
                        {
                            int num756 = Dust.NewDust(npc.position + Vector2.UnitX * -20f, npc.width + 40, npc.height, DustID.LifeDrain, npc.velocity.X, npc.velocity.Y, 150, new Color(78, 136, 255, 80), 2f);
                            Main.dust[num756].noGravity = true;
                            dust24 = Main.dust[num756];
                            dust24.velocity *= 0.5f;

                            if (npc.life >= 6000)
                            {
                                npc.life += 0;
                                Main.player[npc.target].AddBuff(BuffID.Obstructed, 60 * 15);
                            }
                            else
                            {
                                npc.life += 1;
                                npc.HealEffect(1);
                            }

                            if (npc.lifeMax >= 6000)
                            {
                                npc.lifeMax += 0;
                            }
                            else
                            {
                                npc.lifeMax += 1;
                            }

                            //Main.player[npc.target].statLife -= 1;
                            Main.player[npc.target].statDefense -= 1;
                            //Main.player[npc.target].statMana -= 1;
                            Main.player[npc.target].AddBuff(BuffID.Confused, 60 * 3);
                            Main.player[npc.target].AddBuff(BuffID.Poisoned, 60 * 3);

                            if (Main.player[npc.target].statMana <= 1)
                            {
                                Main.player[npc.target].statMana -= 0;
                            }
                            else
                            {
                                Main.player[npc.target].statMana -= 1;
                            }

                            if (Main.player[npc.target].statLife <= 50)
                            {
                                Main.player[npc.target].statLife -= 0;
                            }
                            else
                            {
                                Main.player[npc.target].statLife -= 1;
                            }
                        }
                    }
                }
                else if (npc.ai[1] == 6f)
                {
                    flag95 = true;
                    npc.aiAction = 0;
                    npc.ai[0] += 1f;
                    num741 = MathHelper.Clamp(npc.ai[0] / 30f, 0f, 1f);
                    num741 = 0.5f + num741 * 0.5f;
                    if (npc.ai[0] >= 30f && Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        npc.ai[1] = 0f;
                        npc.ai[0] = 0f;
                        npc.netUpdate = true;
                        npc.TargetClosest();
                    }
                    if (Main.netMode == NetmodeID.MultiplayerClient && npc.ai[0] >= 60f)
                    {
                        npc.ai[1] = 0f;
                        npc.ai[0] = 0f;
                        npc.TargetClosest();
                    }
                    for (int num757 = 0; num757 < 10; num757++)
                    {
                        int num758 = Dust.NewDust(npc.position + Vector2.UnitX * -20f, npc.width + 40, npc.height, DustID.LifeDrain, npc.velocity.X, npc.velocity.Y, 150, new Color(78, 136, 255, 80), 2f);
                        Main.dust[num758].noGravity = true;
                        dust24 = Main.dust[num758];
                        dust24.velocity *= 2f;

                        if (npc.life >= 6000)
                        {
                            npc.life += 0;
                            Main.player[npc.target].AddBuff(BuffID.Obstructed, 60 * 15);
                        }
                        else
                        {
                            npc.life += 1;
                            npc.HealEffect(1);
                        }

                        if (npc.lifeMax >= 6000)
                        {
                            npc.lifeMax += 0;
                        }
                        else
                        {
                            npc.lifeMax += 1;
                        }

                        //Main.player[npc.target].statLife -= 1;
                        Main.player[npc.target].statDefense -= 1;
                        //Main.player[npc.target].statMana -= 1;
                        Main.player[npc.target].AddBuff(BuffID.Confused, 60 * 3);
                        Main.player[npc.target].AddBuff(BuffID.Poisoned, 60 * 3);

                        if (Main.player[npc.target].statMana <= 1)
                        {
                            Main.player[npc.target].statMana -= 0;
                        }
                        else
                        {
                            Main.player[npc.target].statMana -= 1;
                        }

                        if (Main.player[npc.target].statLife <= 50)
                        {
                            Main.player[npc.target].statLife -= 0;
                        }
                        else
                        {
                            Main.player[npc.target].statLife -= 1;
                        }
                    }
                }
                npc.dontTakeDamage = npc.hide = flag103;
                if (npc.velocity.Y == 0f)
                {
                    npc.velocity.X *= 0.8f;
                    if (npc.velocity.X > -0.1 && npc.velocity.X < 0.1)
                    {
                        npc.velocity.X = 0f;
                    }
                    if (!flag95)
                    {
                        npc.ai[0] += 2f;
                        if (npc.life < npc.lifeMax * 0.8)
                        {
                            npc.ai[0] += 1f;
                        }
                        if (npc.life < npc.lifeMax * 0.6)
                        {
                            npc.ai[0] += 1f;
                        }
                        if (npc.life < npc.lifeMax * 0.4)
                        {
                            npc.ai[0] += 2f;
                        }
                        if (npc.life < npc.lifeMax * 0.2)
                        {
                            npc.ai[0] += 3f;
                        }
                        if (npc.life < npc.lifeMax * 0.1)
                        {
                            npc.ai[0] += 4f;
                        }
                        if (npc.ai[0] >= 0f)
                        {
                            npc.netUpdate = true;
                            npc.TargetClosest();
                            if (npc.ai[1] == 3f)
                            {
                                npc.velocity.Y = -13f;
                                npc.velocity.X += 3.5f * npc.direction;
                                npc.ai[0] = -200f;
                                npc.ai[1] = 0f;
                            }
                            else if (npc.ai[1] == 2f)
                            {
                                npc.velocity.Y = -6f;
                                npc.velocity.X += 4.5f * npc.direction;
                                npc.ai[0] = -120f;
                                npc.ai[1] += 1f;
                            }
                            else
                            {
                                npc.velocity.Y = -8f;
                                npc.velocity.X += 4f * npc.direction;
                                npc.ai[0] = -120f;
                                npc.ai[1] += 1f;
                            }
                        }
                        else if (npc.ai[0] >= -30f)
                        {
                            npc.aiAction = 1;
                        }
                    }
                }
                else if (npc.target < 255 && (npc.direction == 1 && npc.velocity.X < 3f || npc.direction == -1 && npc.velocity.X > -3f))
                {
                    if (npc.direction == -1 && npc.velocity.X < 0.1 || npc.direction == 1 && npc.velocity.X > -0.1)
                    {
                        npc.velocity.X += 0.2f * npc.direction;
                    }
                    else
                    {
                        npc.velocity.X *= 0.93f;
                    }
                }
                int num759 = Dust.NewDust(npc.position, npc.width, npc.height, DustID.SomethingRed, npc.velocity.X, npc.velocity.Y, 255, new Color(0, 80, 255, 80), npc.scale * 1.2f);
                Main.dust[num759].noGravity = true;
                dust24 = Main.dust[num759];
                dust24.velocity *= 0.5f;
                if (npc.life <= 0)
                {
                    //return;
                }
                float num760 = npc.life / (float)npc.lifeMax;
                num760 = num760 * 0.5f + 0.75f;
                num760 *= num741;
                if (num760 != npc.scale)
                {
                    npc.position.X = npc.position.X + npc.width / 2;
                    npc.position.Y = npc.position.Y + npc.height;
                    npc.scale = num760;
                    npc.width = (int)(98f * npc.scale);
                    npc.height = (int)(92f * npc.scale);
                    npc.position.X = npc.position.X - npc.width / 2;
                    npc.position.Y = npc.position.Y - npc.height;
                }
                if (Main.netMode == NetmodeID.MultiplayerClient)
                {
                    //return;
                }
                int num763 = (int)(npc.lifeMax * 0.05);
                if (!(npc.life + num763 < npc.ai[3]))
                {
                    //return;
                }
                npc.ai[3] = npc.life;
                int num764 = Main.rand.Next(1, 4);
                /*for (int num765 = 0; num765 < num764; num765++)
                {
                    int x = (int)(npc.position.X + Main.rand.Next(npc.width - 32));
                    int y = (int)(npc.position.Y + Main.rand.Next(npc.height - 32));
                    /*int num766 = 1;
                    if (Main.expertMode && Main.rand.NextBool(4))
                    {
                        num766 = 535;
                    }*/
                    //int num768 = NPC.NewNPC((int)x, (int)y, (int)num766);
                    /*for (int i = 0; i < 3; i++) //This just spawns random entities, works good for like a hard asf boss
                    {
                        int num768 = NPC.NewNPC(npc.GetSource_FromAI(), x, y, NPCID.HoppinJack);

                        Main.npc[num768].SetDefaults(num768);
                        Main.npc[num768].velocity.X = (float)Main.rand.Next(-15, 16) * 0.1f;
                        Main.npc[num768].velocity.Y = (float)Main.rand.Next(-30, 1) * 0.1f;
                        Main.npc[num768].ai[0] = -1000 * Main.rand.Next(3);
                        Main.npc[num768].ai[1] = 0f;
                        if (Main.netMode == NetmodeID.Server && num768 < 200)
                        {
                            NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, num768);
                        }
                    }
                    //int num768 = NPC.NewNPC(npc.GetSource_FromAI(), x, y, NPCID.HoppinJack);

                    int num766 = 304;
                    for (int i = 0; i < 3; i++)
                    {
                        int num768 = NPC.NewNPC(null, (int)x, (int)y, (int)num766);

                        Main.npc[num768].SetDefaults(num766);
                        Main.npc[num768].velocity.X = (float)Main.rand.Next(-15, 16) * 0.1f;
                        Main.npc[num768].velocity.Y = (float)Main.rand.Next(-30, 1) * 0.1f;
                        Main.npc[num768].ai[0] = -1000 * Main.rand.Next(3);
                        Main.npc[num768].ai[1] = 0f;
                        if (Main.netMode == NetmodeID.Server && num768 < 200)
                        {
                            NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, num768);
                        }
                    }
                }*/
            /*}
            else if (Main.GameMode == GameModeID.Normal)
            {
                npc.aiStyle = NPCAIStyleID.KingSlime;
            }
            else if (Main.GameMode == GameModeID.Expert)
            {
                npc.aiStyle = NPCAIStyleID.KingSlime;
            }
            else if (Main.GameMode == GameModeID.Master)
            {
                npc.aiStyle = NPCAIStyleID.KingSlime;
            }

            return false;
        }
        /*public override bool PreDraw(NPC npc, SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            if (RuinWorld.devastated == true)
            {
                SpriteEffects effects = SpriteEffects.None;
                //if (npc.rotation < 180)
                //{
                    //effects = SpriteEffects.FlipHorizontally;
                //}
                Texture2D texture2D = ModContent.Request<Texture2D>("RuinMod/Assets/Textures/DevaDiff/Devastated/NPC_50_Deva").Value;
                Color alpha1 = npc.GetAlpha(drawColor);
                Color color1 = Lighting.GetColor((int)(npc.position.X + npc.width * 0.5) / 16, (int)((npc.position.Y + npc.height * 0.5) / 16.0));
                Texture2D texture = TextureAssets.Npc[npc.type].Value;
                int height = TextureAssets.Npc[npc.type].Value.Height / Main.npcFrameCount[NPCID.KingSlime];
                Rectangle r = new Rectangle(0, height * (int)npc.frameCounter, texture.Width, height);
                Vector2 origin = r.Size() / 2f;
                spriteBatch.Draw(texture2D, npc.Center - screenPos + new Vector2(0.0f, npc.gfxOffY), new Rectangle?(npc.frame), alpha1, npc.rotation, npc.frame.Size() / 2f, npc.scale, effects, 0.0f);
                return false;
            }
            return true;
        }*/
    /*}
}*/
