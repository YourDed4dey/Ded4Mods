/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RuinTesting.Common.Systems.DiffSystem;
using ReLogic.Content;
using Terraria.GameContent;

namespace RuinTesting.Common.Global.DevastatedDiff
{
    public class DevastatedNPCS : GlobalNPC
    {
        public override bool PreDraw(NPC npc, SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            if (RuinWorld.devastated == true)
            {
                if (npc.type == NPCID.EyeofCthulhu)
                {
                    //TextureAssets.Npc[NPCID.EyeofCthulhu] = ModContent.Request<Texture2D>("RuinTesting/Assets/Textures/DevaDiff/Devastated/NPC_4_Deva");
                }
            }
            else
            {
                if (npc.type == NPCID.EyeofCthulhu)
                {
                    //TextureAssets.Npc[NPCID.EyeofCthulhu] = ModContent.Request<Texture2D>("RuinTesting/Assets/Textures/DevaDiff/Vanilla/NPC_4");
                }
            }
            return true;
        }
        public override void SetDefaults(NPC npc)
        {
            if (RuinWorld.devastated == true)
            {
                if (npc.type == NPCID.EyeofCthulhu)
                {
                    npc.lifeMax = 400;
                }
            }
            else
            {
                if (npc.type == NPCID.EyeofCthulhu)
                {
                    npc.lifeMax = 2800;
                }
            }
        }
    }
}*/