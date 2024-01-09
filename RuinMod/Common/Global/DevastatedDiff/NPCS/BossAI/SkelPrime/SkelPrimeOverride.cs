/*using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using RuinMod.Common.Systems.DiffSystem;
using RuinMod.Common.Global.DevastatedDiff.Potions.Debuffs.Oiled;
using RuinMod.Content.Potions.Debuffs.Corrupted;

namespace RuinMod.Common.Global.DevastatedDiff.NPCS.BossAI.SkelPrime
{
    internal class SkelPrimeOverride : GlobalNPC
    {
        public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
        {
            return entity.type == NPCID.SkeletronPrime;
        }

        public override bool PreAI(NPC npc)
        {
            BuffedPrimeAI(npc);
            if (RuinWorld.devastated)
                return false;


            else return true;
        }

        public static bool BuffedPrimeAI(NPC npc)
        {
            if (RuinWorld.devastated)
            {
                Vector2 vector14 = npc.Center + npc.velocity * 3f;
                if (Main.rand.NextBool(3))
                {
                    int num30 = Dust.NewDust(vector14 - npc.Size / 2f, npc.width, npc.height, DustID.OrangeTorch, npc.velocity.X, npc.velocity.Y, 100, default, 2f);
                    Main.dust[num30].noGravity = true;
                    Main.dust[num30].position -= npc.velocity;
                }
                npc.aiStyle = NPCAIStyleID.SkeletronPrimeHead;
            }
            else if (Main.GameMode == GameModeID.Normal)
            {
                npc.aiStyle = NPCAIStyleID.SkeletronPrimeHead;
            }
            else if (Main.GameMode == GameModeID.Expert)
            {
                npc.aiStyle = NPCAIStyleID.SkeletronPrimeHead;
            }
            else if (Main.GameMode == GameModeID.Master)
            {
                npc.aiStyle = NPCAIStyleID.SkeletronPrimeHead;
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
            return true;
        }
    }
}*/
