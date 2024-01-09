/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using RuinMod.Common.Systems.DiffSystem;
using Terraria.GameContent;
using ReLogic.Content;
using RuinMod.Common.Global.DevastatedDiff.Potions.Debuffs.Oiled;

namespace RuinMod.Common.Global.DevastatedDiff.NPCS.BossAI.EOW.Extra
{
    internal class EOWNPCSOverride : GlobalNPC
    {
        public override void OnHitPlayer(NPC npc, Player target, int damage, bool crit)
        {
            if (RuinWorld.devastated)
            {
                if (npc.type == NPCID.VileSpit)
                {
                    if (!target.HasBuff(BuffID.CursedInferno))
                    {
                        target.AddBuff(BuffID.CursedInferno, 60 * 6 / 2);
                    }
                }
                if (npc.type == NPCID.VileSpitEaterOfWorlds)
                {
                    if (!target.HasBuff(BuffID.CursedInferno))
                    {
                        target.AddBuff(BuffID.CursedInferno, 60 * 6 / 2);
                    }
                }
                if (npc.type == NPCID.EaterofWorldsHead || npc.type == NPCID.EaterofWorldsBody || npc.type == NPCID.EaterofWorldsTail)
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
                if (npc.type == NPCID.VileSpit)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, DustID.CursedTorch, 0, 0, 0, default, 2f);
                    npc.rotation = (float)Math.Atan2(npc.velocity.Y, npc.velocity.X) + 3f;
                    npc.rotation = npc.velocity.ToRotation();
                }
                if (npc.type == NPCID.VileSpitEaterOfWorlds)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, DustID.CursedTorch, 0, 0, 0, default, 2f);
                    npc.rotation = (float)Math.Atan2(npc.velocity.Y, npc.velocity.X) + 3f;
                    npc.rotation = npc.velocity.ToRotation();
                }
            }
        }
        /*public override bool PreDraw(NPC npc, SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            if (RuinWorld.devastated == true)
            {
                if (npc.type == NPCID.VileSpit)
                {
                    SpriteEffects effects = SpriteEffects.None;
                    if (npc.rotation < 180)
                    {
                        effects = SpriteEffects.FlipHorizontally;
                    }
                    Texture2D texture2D = ModContent.Request<Texture2D>("RuinMod/Assets/Textures/DevaDiff/Devastated/VileSpit_Deva").Value;
                    Color alpha1 = npc.GetAlpha(drawColor);
                    Color color1 = Lighting.GetColor((int)(npc.position.X + npc.width * 0.5) / 16, (int)((npc.position.Y + npc.height * 0.5) / 16.0));
                    Texture2D texture = TextureAssets.Npc[npc.type].Value;
                    int height = TextureAssets.Npc[npc.type].Value.Height / Main.npcFrameCount[NPCID.VileSpit];
                    Rectangle r = new Rectangle(0, height * (int)npc.frameCounter, texture.Width, height);
                    Vector2 origin = r.Size() / 2f;
                    spriteBatch.Draw(texture2D, npc.Center - screenPos + new Vector2(0.0f, npc.gfxOffY), new Rectangle?(npc.frame), alpha1, npc.rotation, npc.frame.Size() / 2f, npc.scale, effects, 0.0f);
                    return false;
                }
                if (npc.type == NPCID.VileSpitEaterOfWorlds)
                {
                    SpriteEffects effects = SpriteEffects.None;
                    if (npc.rotation < 180)
                    {
                        effects = SpriteEffects.FlipHorizontally;
                    }
                    Texture2D texture2D = ModContent.Request<Texture2D>("RuinMod/Assets/Textures/DevaDiff/Devastated/VileSpit_Deva").Value;
                    Color alpha1 = npc.GetAlpha(drawColor);
                    Color color1 = Lighting.GetColor((int)(npc.position.X + npc.width * 0.5) / 16, (int)((npc.position.Y + npc.height * 0.5) / 16.0));
                    Texture2D texture = TextureAssets.Npc[npc.type].Value;
                    int height = TextureAssets.Npc[npc.type].Value.Height / Main.npcFrameCount[NPCID.VileSpitEaterOfWorlds];
                    Rectangle r = new Rectangle(0, height * (int)npc.frameCounter, texture.Width, height);
                    Vector2 origin = r.Size() / 2f;
                    spriteBatch.Draw(texture2D, npc.Center - screenPos + new Vector2(0.0f, npc.gfxOffY), new Rectangle?(npc.frame), alpha1, npc.rotation, npc.frame.Size() / 2f, npc.scale, effects, 0.0f);
                    return false;
                }
            }
            return true;
        }*/
    /*}
}*/