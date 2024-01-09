using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent;
using Terraria.UI.Chat;
using Terraria.DataStructures;
using DedsQOLMod.Common.Configs;

namespace DedsQOLMod.Common.Systems
{
    public class LifeRegenPlayer : ModPlayer
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModContent.GetInstance<DedsQOLConfig>().PlayerLifeRegenerationTextToggle;
        }
        public override void DrawEffects(PlayerDrawSet drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {
            if (Main.netMode == NetmodeID.Server) return; // Don't run on servers
            if (Main.LocalPlayer.mouseInterface) return; // Don't show text during mouse interactions

            string damageText = "Life Regeneration: " + Player.lifeRegen;

            Vector2 textPosition = Player.Center - Main.screenPosition;
            textPosition.Y -= Player.height;

            ChatManager.DrawColorCodedStringWithShadow(Main.spriteBatch, FontAssets.ItemStack.Value, damageText, textPosition, Color.White, 0f, Vector2.Zero, Vector2.One);
        }
    }
}
