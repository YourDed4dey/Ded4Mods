/*using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using RuinMod.Common.Systems.DiffSystem;

namespace RuinMod.Common.Global.DevastatedDiff.NPCS
{
    internal class NPCSDevaSprites : GlobalNPC
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModContent.GetInstance<RuinModConfig>().RuinModDevaSpritesToggle;
        }
        public override bool PreDraw(NPC npc, SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            if (RuinWorld.devastated == true)
            {
                if (npc.type == NPCID.KingSlime)
                {
                    SpriteEffects effects = SpriteEffects.None;
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

                if(npc.type == NPCID.SkeletronPrime)
                {
                    SpriteEffects effects = SpriteEffects.None;
                    if (npc.rotation < 180)
                    {
                        effects = SpriteEffects.FlipHorizontally;
                    }
                    Texture2D texture2D = ModContent.Request<Texture2D>("RuinMod/Assets/Textures/DevaDiff/Devastated/NPC_127_Deva").Value;
                    Color alpha1 = npc.GetAlpha(drawColor);
                    Color color1 = Lighting.GetColor((int)(npc.position.X + npc.width * 0.5) / 16, (int)((npc.position.Y + npc.height * 0.5) / 16.0));
                    Texture2D texture = TextureAssets.Npc[npc.type].Value;
                    int height = TextureAssets.Npc[npc.type].Value.Height / Main.npcFrameCount[NPCID.SkeletronPrime];
                    Rectangle r = new Rectangle(0, height * (int)npc.frameCounter, texture.Width, height);
                    Vector2 origin = r.Size() / 2f;
                    spriteBatch.Draw(texture2D, npc.Center - screenPos + new Vector2(0.0f, npc.gfxOffY), new Rectangle?(npc.frame), alpha1, npc.rotation, npc.frame.Size() / 2f, npc.scale, effects, 0.0f);
                    return false;
                }
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
                /*if (npc.type == NPCID.VileSpit)
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
                }*/
                /*if(npc.type == NPCID.EyeofCthulhu)
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
                if(npc.type == NPCID.BrainofCthulhu)
                {
                    SpriteEffects effects = SpriteEffects.None;
                    if (npc.rotation < 180)
                    {
                        effects = SpriteEffects.FlipHorizontally;
                    }
                    Texture2D texture2D = ModContent.Request<Texture2D>("RuinMod/Assets/Textures/DevaDiff/Devastated/NPC_266_Deva").Value;
                    Color alpha1 = npc.GetAlpha(drawColor);
                    Color color1 = Lighting.GetColor((int)(npc.position.X + npc.width * 0.5) / 16, (int)((npc.position.Y + npc.height * 0.5) / 16.0));
                    Texture2D texture = TextureAssets.Npc[npc.type].Value;
                    int height = TextureAssets.Npc[npc.type].Value.Height / Main.npcFrameCount[NPCID.BrainofCthulhu];
                    Rectangle r = new Rectangle(0, height * (int)npc.frameCounter, texture.Width, height);
                    Vector2 origin = r.Size() / 2f;
                    spriteBatch.Draw(texture2D, npc.Center - screenPos + new Vector2(0.0f, npc.gfxOffY), new Rectangle?(npc.frame), alpha1, npc.rotation, npc.frame.Size() / 2f, npc.scale, effects, 0.0f);
                    return false;
                }
                if(npc.type == NPCID.SkeletronHead || npc.type == NPCID.DungeonGuardian)
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
                if(npc.type == NPCID.SkeletronHand)
                {
                    SpriteEffects effects = SpriteEffects.None;
                    if (npc.rotation < 180)
                    {
                        effects = SpriteEffects.FlipHorizontally;
                    }
                    Texture2D texture2D = ModContent.Request<Texture2D>("RuinMod/Assets/Textures/DevaDiff/Devastated/NPC_36_Deva").Value;
                    Color alpha1 = npc.GetAlpha(drawColor);
                    Color color1 = Lighting.GetColor((int)(npc.position.X + npc.width * 0.5) / 16, (int)((npc.position.Y + npc.height * 0.5) / 16.0));
                    Texture2D texture = TextureAssets.Npc[npc.type].Value;
                    int height = TextureAssets.Npc[npc.type].Value.Height / Main.npcFrameCount[NPCID.SkeletronHand];
                    Rectangle r = new Rectangle(0, height * (int)npc.frameCounter, texture.Width, height);
                    Vector2 origin = r.Size() / 2f;
                    spriteBatch.Draw(texture2D, npc.Center - screenPos + new Vector2(0.0f, npc.gfxOffY), new Rectangle?(npc.frame), alpha1, npc.rotation, npc.frame.Size() / 2f, npc.scale, effects, 0.0f);
                    return false;
                }
            }
            return true;
        }
    }
}*/
