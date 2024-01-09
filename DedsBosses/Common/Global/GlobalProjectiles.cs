using System;
using System.Numerics;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.UI.Chat;

namespace DedsBosses.Common.Global
{
    public class GlobalProjectiles : GlobalProjectile
    {
        public Action<Projectile> meteorExplosionDelegate;
        public override bool InstancePerEntity => true;
        public override bool OnTileCollide(Projectile projectile, Microsoft.Xna.Framework.Vector2 oldVelocity)
        {
            DedsBosses modInstance = ModContent.GetInstance<DedsBosses>();
            meteorExplosionDelegate?.Invoke(projectile);
            return base.OnTileCollide(projectile, oldVelocity);
        }
        /*public override void PostDraw(Projectile projectile, Color lightColor)
        {
            if (Main.netMode == NetmodeID.Server) return; // Don't run on servers
            if (Main.LocalPlayer.mouseInterface) return; // Don't show text during mouse interactions

            string damageText = "Damage: " + projectile.damage;

            // Calculate the position to draw the text (just above the NPC's head)
            Microsoft.Xna.Framework.Vector2 textPosition = projectile.Center - Main.screenPosition;
            textPosition.Y -= projectile.height;

            // Draw the damage text in the chat
            ChatManager.DrawColorCodedStringWithShadow(Main.spriteBatch, FontAssets.ItemStack.Value, damageText, textPosition, Color.White, 0f, Microsoft.Xna.Framework.Vector2.Zero, Microsoft.Xna.Framework.Vector2.One);
        }*/
    }
}
