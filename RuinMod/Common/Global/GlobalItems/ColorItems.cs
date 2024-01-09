using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RuinMod.Common.Global.GlobalItems
{
    internal class ColorItems : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation) => entity.type == ItemID.SoulofFright || entity.type == ItemID.SoulofMight || entity.type == ItemID.SoulofSight || entity.type == ItemID.SoulofFlight || entity.type == ItemID.SoulofNight || entity.type == ItemID.SoulofLight || entity.type == ItemID.Zenith || entity.type == ItemID.FragmentNebula || entity.type == ItemID.FragmentSolar || entity.type == ItemID.FragmentStardust || entity.type == ItemID.FragmentVortex;

        public override Color? GetAlpha(Item item, Color lightColor)
        {
            return Color.Lerp(lightColor, Color.White, 0.4f);
        }
        public override bool PreDrawInWorld(Item item, SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
            Texture2D texture = Terraria.GameContent.TextureAssets.Item[item.type].Value;

            Rectangle frame;

            if (Main.itemAnimations[item.type] != null)
            {
                // In case this item is animated, this picks the correct frame
                frame = Main.itemAnimations[item.type].GetFrame(texture, Main.itemFrameCounter[whoAmI]);
            }
            else
            {
                frame = texture.Frame();
            }

            Vector2 frameOrigin = frame.Size() / 2f;
            Vector2 offset = new Vector2(item.width / 2 - frameOrigin.X, item.height - frame.Height);
            Vector2 drawPos = item.position - Main.screenPosition + frameOrigin + offset;

            float time = Main.GlobalTimeWrappedHourly;
            float timer = item.timeSinceItemSpawned / 240f + time * 0.04f;

            time %= 4f;
            time /= 2f;

            if (time >= 1f)
            {
                time = 2f - time;
            }

            time = time * 0.5f + 0.5f;

            for (float i = 0f; i < 1f; i += 0.25f)
            {
                float radians = (i + timer) * MathHelper.TwoPi;

                spriteBatch.Draw(texture, drawPos + new Vector2(0f, 8f).RotatedBy(radians) * time, frame, new Color(90, 70, 255, 50), rotation, frameOrigin, scale, SpriteEffects.None, 0);
            }

            for (float i = 0f; i < 1f; i += 0.34f)
            {
                float radians = (i + timer) * MathHelper.TwoPi;

                spriteBatch.Draw(texture, drawPos + new Vector2(0f, 4f).RotatedBy(radians) * time, frame, new Color(140, 120, 255, 77), rotation, frameOrigin, scale, SpriteEffects.None, 0);
            }

            return true;
        }
    }
}
