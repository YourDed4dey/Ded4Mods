using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent;
using Terraria.UI.Chat;
using DedsQOLMod.Common.Configs;

namespace DedsQOLMod.Common.Global
{
    public class NPCDamage : GlobalNPC
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModContent.GetInstance<DedsQOLConfig>().NpcAndProjDamageTextToggle;
        }
        public override bool InstancePerEntity => true; // Set this property to true for each NPC instance to have its own separate data

        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            if (Main.netMode == NetmodeID.Server) return; // Don't run on servers
            if (Main.LocalPlayer.mouseInterface) return; // Don't show text during mouse interactions

            string damageText = "Damage: " + npc.damage;

            // Calculate the position to draw the text (just above the NPC's head)
            Vector2 textPosition = npc.Center - Main.screenPosition;
            textPosition.Y -= npc.height;

            // Draw the damage text in the chat
            ChatManager.DrawColorCodedStringWithShadow(Main.spriteBatch, FontAssets.ItemStack.Value, damageText, textPosition, Color.White, 0f, Vector2.Zero, Vector2.One);
        }
    }
    public class ProjDamage : GlobalProjectile
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModContent.GetInstance<DedsQOLConfig>().NpcAndProjDamageTextToggle;
        }
        public override bool InstancePerEntity => true; // Set this property to true for each NPC instance to have its own separate data
        public override void PostDraw(Projectile projectile, Color lightColor)
        {
            if (Main.netMode == NetmodeID.Server) return; // Don't run on servers
            if (Main.LocalPlayer.mouseInterface) return; // Don't show text during mouse interactions

            string damageText = "Damage: " + projectile.damage;

            Microsoft.Xna.Framework.Vector2 textPosition = projectile.Center - Main.screenPosition;
            textPosition.Y -= projectile.height;

            // Draw the damage text in the chat
            ChatManager.DrawColorCodedStringWithShadow(Main.spriteBatch, FontAssets.ItemStack.Value, damageText, textPosition, Color.White, 0f, Microsoft.Xna.Framework.Vector2.Zero, Microsoft.Xna.Framework.Vector2.One);
        }
    }
}
