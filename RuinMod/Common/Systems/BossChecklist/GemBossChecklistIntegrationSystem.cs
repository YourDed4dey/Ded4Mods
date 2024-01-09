/*using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria.ModLoader;

namespace RuinMod.Common.Systems.BossChecklist
{
    internal class GemBossChecklistIntegrationSystem : ModSystem
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

            if (bossChecklistMod.Version < new Version(1, 4, 0)) // Version of BossChecklist Mod
            {
                return;
            }
            string bossName = "Gemmonide";

            int bossType = ModContent.NPCType<Content.NPCS.Bosses.GemBoss.GemBoss>();

            float weight = 5.5f;

            Func<bool> downed = () => DownedBossSystem.downedGemBoss;

            Func<bool> available = () => true;

            List<int> collection = new List<int>()
            {
                ModContent.ItemType<Content.Items.Drops.GemBossDrops.GemBossRelic.GemBossRelic>(),
                ModContent.ItemType<Content.Consumables.Pets.GemBossPet.GemBossPetItem>(),
                ModContent.ItemType<Content.Items.Drops.GemBossDrops.GemBossTrophy.GemBossTrophy>(),
                ModContent.ItemType<Content.Armor.VanityArmor.GemBossMask.GemBossMask>()
            };

            int summonItem = ModContent.ItemType<Content.Consumables.BossSummons.Gemminode.Gemminode>();

            string spawnInfo = $"Use [i:{summonItem}]";

            string despawnInfo = null;

            var customBossPortrait = (SpriteBatch sb, Rectangle rect, Color color) =>
            {
                Texture2D texture = ModContent.Request<Texture2D>("RuinMod/Assets/Textures/NPCS/Bosses/GemBoss/GemBossTexture").Value;
                Vector2 centered = new Vector2(rect.X + rect.Width / 2 - texture.Width / 2, rect.Y + rect.Height / 2 - texture.Height / 2);
                sb.Draw(texture, centered, color);
            };

            bossChecklistMod.Call(
                "AddBoss",
                Mod,
                bossName,
                bossType,
                weight,
                downed,
                available,
                collection,
                summonItem,
                spawnInfo,
                despawnInfo,
                customBossPortrait
            );
        }
    }
}*/
