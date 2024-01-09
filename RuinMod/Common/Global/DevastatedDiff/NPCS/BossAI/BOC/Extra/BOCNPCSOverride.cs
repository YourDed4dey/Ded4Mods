/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System;
using RuinMod.Common.Systems.DiffSystem;
using RuinMod.Common.Global.DevastatedDiff.Potions.Debuffs.CursedIchor;
using RuinMod.Common.Global.DevastatedDiff.Potions.Debuffs.Oiled;

namespace RuinMod.Common.Global.DevastatedDiff.NPCS.BossAI.BOC.Extra
{
    internal class BOCNPCSOverride : GlobalNPC
    {
        public override void OnHitPlayer(NPC npc, Player target, int damage, bool crit)
        {
            if (RuinWorld.devastated)
            {
                if (npc.type == NPCID.Creeper)
                {
                    if (!target.HasBuff(BuffID.Ichor))
                    {
                        target.AddBuff(BuffID.Ichor, 60 * 6 / 2);
                    }
                    /*if (!target.HasBuff(ModContent.BuffType<CursedIchor>()))
                    {
                        target.AddBuff(ModContent.BuffType<CursedIchor>(), 60 * 6);
                    }*/
                /*}
                if (npc.type == NPCID.BrainofCthulhu)
                {
                    if (!target.HasBuff(BuffID.Confused))
                    {
                        target.AddBuff(BuffID.Confused, 60 * 20 / 2);
                    }

                    if (!target.HasBuff(ModContent.BuffType<Oiled>()))
                    {
                        target.AddBuff(ModContent.BuffType<Oiled>(), 60 * 20);
                    }
                }
            }
        }
        public override void AI(NPC npc)
        {
            if (RuinWorld.devastated)
            {
                if (npc.type == NPCID.Creeper)
                {
                    float timerMax = Utils.Clamp((float)npc.life / npc.lifeMax, 0.50f, 1f) * 100;

                    npc.ai[3]++;
                    if (npc.ai[3] > timerMax)
                    {
                        npc.ai[3] = 0;
                    }

                    if (npc.HasValidTarget && npc.ai[3] == 0 && Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        //Vector2 position = player.Top+ new Vector2(Main.rand.Next(-100, 100), Main.rand.Next(50, 100));
                        Vector2 position = npc.Center;
                        Vector2 targetPosition = Main.player[npc.target].Center;
                        Vector2 direction = targetPosition - position;
                        direction.Normalize();
                        float speed = 10f;

                        //int type = ProjectileID.SuperStar
                        int damage = 10;

                        int type = Projectile.NewProjectile(null, position, direction * speed, ProjectileID.IchorSplash, damage, 0, Main.myPlayer);
                        Main.projectile[type].hostile = true;
                        Main.projectile[type].friendly = false;
                    }
                    /*Dust.NewDust(npc.position, npc.width, npc.height, DustID.Ichor, 0, 0, 0, default, 2f); //This is cool but it is too much dust
                    npc.rotation = (float)Math.Atan2(npc.velocity.Y, npc.velocity.X) + 3f;
                    npc.rotation = npc.velocity.ToRotation();*/

                    /*if (NPC.crimsonBoss < 0)
                        {
                        npc.active = false;
                        npc.netUpdate = true;
                            return;
                        }
                        if (npc.ai[0] == 0f)
                        {
                        npc.ai[1] = 0f;
                            Vector2 vector106 = new Vector2(npc.Center.X, npc.Center.Y);
                            float num866 = Main.npc[NPC.crimsonBoss].Center.X - vector106.X;
                            float num867 = Main.npc[NPC.crimsonBoss].Center.Y - vector106.Y;
                            float num868 = (float)Math.Sqrt(num866 * num866 + num867 * num867);
                            if (num868 > 90f)
                            {
                                num868 = 8f / num868;
                                num866 *= num868;
                                num867 *= num868;
                            npc.velocity.X = (npc.velocity.X * 15f + num866) / 16f;
                            npc.velocity.Y = (npc.velocity.Y * 15f + num867) / 16f;
                                return;
                            }
                            if (Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y) < 8f)
                            {
                            npc.velocity.Y *= 1.05f;
                            npc.velocity.X *= 1.05f;
                            }
                            if (Main.netMode != NetmodeID.MultiplayerClient && ((Main.expertMode && Main.rand.NextBool(100)) || Main.rand.NextBool(200)))
                            {
                            npc.TargetClosest();
                                vector106 = new Vector2(npc.Center.X, npc.Center.Y);
                                num866 = Main.player[npc.target].Center.X - vector106.X;
                                num867 = Main.player[npc.target].Center.Y - vector106.Y;
                                num868 = (float)Math.Sqrt(num866 * num866 + num867 * num867);
                                num868 = 8f / num868;
                            npc.velocity.X = num866 * num868;
                            npc.velocity.Y = num867 * num868;
                            npc.ai[0] = 1f;
                            npc.netUpdate = true;
                            }
                            return;
                        }
                        if (Main.expertMode)
                        {
                            Vector2 vector107 = Main.player[npc.target].Center - npc.Center;
                            vector107.Normalize();
                            if (Main.getGoodWorld)
                            {
                                vector107 *= 12f;
                            npc.velocity = (npc.velocity * 49f + vector107) / 50f;
                            }
                            else
                            {
                                vector107 *= 9f;
                            npc.velocity = (npc.velocity * 99f + vector107) / 100f;
                            }
                        }
                        Vector2 vector108 = new Vector2(npc.Center.X, npc.Center.Y);
                        float num869 = Main.npc[NPC.crimsonBoss].Center.X - vector108.X;
                        float num870 = Main.npc[NPC.crimsonBoss].Center.Y - vector108.Y;
                        float num871 = (float)Math.Sqrt(num869 * num869 + num870 * num870);
                        if (num871 > 700f)
                        {
                        npc.ai[0] = 0f;
                        }
                        else
                        {
                            if (!npc.justHit)
                            {
                                return;
                            }
                            if (npc.knockBackResist == 0f)
                            {
                            npc.ai[1] += 1f;
                                if (npc.ai[1] > 5f)
                                {
                                npc.ai[0] = 0f;
                                }
                            }
                            else
                            {
                            npc.ai[0] = 0f;
                            }
                        }

                }
            }
        }
    }
}*/
