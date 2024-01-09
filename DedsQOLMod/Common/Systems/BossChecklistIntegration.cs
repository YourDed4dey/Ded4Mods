using DedsQOLMod.Content.Items.Consumables.BossSummons;
using DedsQOLMod.Content.NPCs.Bosses.GemBoss;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria.Localization;
using Terraria.ModLoader;

namespace DedsQOLMod.Common.Systems
{
    public class BossChecklistIntegration : ModSystem
    {
        public override void PostSetupContent()
        {
            DoBossChecklistIntegration();
        }

        private void DoBossChecklistIntegration()
        {
            if (!ModLoader.TryGetMod("BossChecklist", out Mod bossChecklistMod))
            {
                return;
            }

            if (bossChecklistMod.Version < new Version(1, 6))
            {
                return;
            }

            string GemmyinternalName = "Gemmy";

            float Gemmyweight = .5f;

            Func<bool> Gemmydowned = () => DownedBossSystem.downedGemBoss;

            Func<bool> Gemmyavailable = () => true;

            int GemmybossType = ModContent.NPCType<GemBoss>();

            int GemmyspawnItem = ModContent.ItemType<Gemminode>();

            LocalizedText GemmyspawnInfo = Language.GetText("Mods.DedsQOLMod.SpawnInfo");

            List<int> Gemmycollectibles = new List<int>()
            {

            };

            var GemmycustomPortrait = (SpriteBatch sb, Rectangle rect, Color color) => {
                Texture2D texture = ModContent.Request<Texture2D>("DedsQOLMod/Assets/Textures/Bestiary/GemmyBoss_Preview").Value;
                Vector2 centered = new Vector2(rect.X + (rect.Width / 2) - (texture.Width / 2), rect.Y + (rect.Height / 2) - (texture.Height / 2));
                sb.Draw(texture, centered, color);
            };

            bossChecklistMod.Call(
                "LogBoss",
                Mod,
                GemmyinternalName,
                Gemmyweight,
                Gemmydowned,
                GemmybossType,
                new Dictionary<string, object>()
                {
                    ["spawnItems"] = GemmyspawnItem,
                    ["collectibles"] = Gemmycollectibles,
                    ["customPortrait"] = GemmycustomPortrait,
                }
            );
        }
    }
}