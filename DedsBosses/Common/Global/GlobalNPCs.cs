/*using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.UI.Chat;

namespace RuinTesting.Common.Global
{
    internal class RuinTestingGlobalNPCs : GlobalNPC
    {
        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            // Show damage values when hovering over the NPC
            if (Main.LocalPlayer.mouseInterface && Main.LocalPlayer.cursorItemIconID == ItemID.None && Main.LocalPlayer.cursorItemIconText == string.Empty)
            {
                string damageText = "Damage: " + npc.damage;

                // Get the size of the damage text
                Vector2 textSize = FontAssets.ItemStack.Value.MeasureString(damageText);

                // Calculate the position to draw the text (just above the NPC's head)
                Vector2 textPosition = npc.Center - Main.screenPosition;
                textPosition.Y -= npc.height;
                textPosition.X -= textSize.X / 2;

                // Draw the damage text in the chat
                ChatManager.DrawColorCodedStringWithShadow(Main.spriteBatch, FontAssets.ItemStack.Value, damageText, textPosition, Color.White, 0f, Vector2.Zero, Vector2.One);
            }
        }
    }
}*/
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using Terraria.GameContent;
using Terraria.UI.Chat;
using System;
using Terraria.GameContent.ItemDropRules;
using DedsBosses.Common.Systems;

namespace DedsBosses.Common.Global
{
    internal class GlobalNPCs : GlobalNPC
    {
        //public override bool InstancePerEntity => true; // Set this property to true for each NPC instance to have its own separate data

        /*public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            if (Main.netMode == NetmodeID.Server) return; // Don't run on servers
            if (Main.LocalPlayer.mouseInterface) return; // Don't show text during mouse interactions

            string damageText = "Damage: " + npc.damage;

            // Calculate the position to draw the text (just above the NPC's head)
            Vector2 textPosition = npc.Center - Main.screenPosition;
            textPosition.Y -= npc.height;

            // Draw the damage text in the chat
            ChatManager.DrawColorCodedStringWithShadow(Main.spriteBatch, FontAssets.ItemStack.Value, damageText, textPosition, Color.White, 0f, Vector2.Zero, Vector2.One);
        }*/
    }
}   
