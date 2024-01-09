/*using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria.ModLoader;

namespace RuinMod.Common.Systems.BossChecklist
{
    internal class MechBrainBossChecklistIntegrationSystem : ModSystem
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
            string bossName = "Mechanical Brain";

            int bossType = ModContent.NPCType<Content.NPCS.Bosses.MechBrain.MechBrain>();

            float weight = 11.001f;

            Func<bool> downed = () => DownedBossSystem.downedMechBrain;

            Func<bool> available = () => true;

            List<int> collection = new List<int>()
            {
                ModContent.ItemType<Content.Items.Drops.MechBrainDrops.MechanicalBrainRelic.MechanicalBrainRelic>(),
                ModContent.ItemType<Content.Consumables.Pets.OcramsEye.EyeSpeculum>(),
                ModContent.ItemType<Content.Items.Drops.MechBrainDrops.MechanicalBrainTrophy.MechanicalBrainTrophy>(),
                ModContent.ItemType<Content.Armor.VanityArmor.MechanicalBrainMask.MechanicalBrainMask>()
            };

            int summonItem = ModContent.ItemType<Content.Consumables.BossSummons.SuspiciousLookingSkull.SuspiciousLookingSkull>();

            string spawnInfo = $"Use [i:{summonItem}] at night to spawn";

            string despawnInfo = null;

            var customBossPortrait = (SpriteBatch sb, Rectangle rect, Color color) =>
            {
                Texture2D texture = ModContent.Request<Texture2D>("RuinMod/Assets/Textures/NPCS/Bosses/MechBrain/MechanicalBrainStage1").Value;
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
