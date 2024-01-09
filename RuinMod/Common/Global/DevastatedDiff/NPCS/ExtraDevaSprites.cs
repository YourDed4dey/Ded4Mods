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
    internal class ExtraDevaSprites : GlobalNPC
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModContent.GetInstance<RuinModConfig>().RuinModDevaSpritesToggle;
        }

        public override bool PreDraw(NPC npc, SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            if (RuinWorld.devastated)
            {
                if(npc.type == NPCID.SkeletronHead)
                {
                    Vector2 vector5 = new Vector2(npc.position.X + (float)npc.width * 0.5f - 5f * npc.ai[0], npc.position.Y + 20f);
                    for (int j = 0; j < 2; j++)
                    {
                        float num6 = Main.npc[(int)npc.ai[1]].position.X + (float)(Main.npc[(int)npc.ai[1]].width / 2) - vector5.X;
                        float num7 = Main.npc[(int)npc.ai[1]].position.Y + (float)(Main.npc[(int)npc.ai[1]].height / 2) - vector5.Y;
                        float num8 = 0f;
                        if (j == 0)
                        {
                            num6 -= 200f * npc.ai[0];
                            num7 += 130f;
                            num8 = (float)Math.Sqrt(num6 * num6 + num7 * num7);
                            num8 = 92f / num8;
                            vector5.X += num6 * num8;
                            vector5.Y += num7 * num8;
                        }
                        else
                        {
                            num6 -= 50f * npc.ai[0];
                            num7 += 80f;
                            num8 = (float)Math.Sqrt(num6 * num6 + num7 * num7);
                            num8 = 60f / num8;
                            vector5.X += num6 * num8;
                            vector5.Y += num7 * num8;
                        }
                        float rotation5 = (float)Math.Atan2(num7, num6) - 1.57f;
                        Color color5 = Lighting.GetColor((int)vector5.X / 16, (int)(vector5.Y / 16f));
                        Texture2D texture2D = ModContent.Request<Texture2D>("RuinMod/Assets/Textures/DevaDiff/Devastated/Arm_Bone_Deva").Value;
                        spriteBatch.Draw(texture2D, new Vector2(vector5.X - screenPos.X, vector5.Y - screenPos.Y), new Rectangle(0, 0, TextureAssets.BoneArm.Width(), TextureAssets.BoneArm.Height()), color5, rotation5, new Vector2((float)TextureAssets.BoneArm.Width() * 0.5f, (float)TextureAssets.BoneArm.Height() * 0.5f), 1f, SpriteEffects.None, 0f);
                        if (j == 0)
                        {
                            vector5.X += num6 * num8 / 2f;
                            vector5.Y += num7 * num8 / 2f;
                        }
                        else if (npc.active)
                        {
                            vector5.X += num6 * num8 - 16f;
                            vector5.Y += num7 * num8 - 6f;
                            int num9 = Dust.NewDust(new Vector2(vector5.X, vector5.Y), 30, 10, DustID.Blood, num6 * 0.02f, num7 * 0.02f, 0, default(Color), 2f);
                            Main.dust[num9].noGravity = true;
                        }
                    }
                }
            }
            return true;
        }
    }
}*/
