using DedsBosses.Common.Systems;
using DedsBosses.Content.Items.Consumables.BossSummons;
using DedsBosses.Content.NPCs.Bosses.VoiyedBoss;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria.Localization;
using Terraria.ModLoader;

namespace DedsBosses.Common.Systems
{
    public class ModIntegrationsSystem : ModSystem
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

            string VoiyedinternalName = "Voiyed";

            float Voiyedweight = 12.5f; // Post-Plantera(12f), Pre-Golem(13f)

            Func<bool> Voiyeddowned = () => DownedBossSystem.downedVoiyedBoss;

            Func<bool> Voiyedavailable = () => true;

            int VoiyedbossType = ModContent.NPCType<Voiyed>();

            int VoiyedspawnItem = ModContent.ItemType<VoiyedSummon>();

            LocalizedText VoiyedspawnInfo = Language.GetText("Mods.DedsBosses.SpawnInfo");

            List<int> Voiyedcollectibles = new List<int>()
            {
                /*.ItemType<Content.Items.Placeable.Furniture.MinionBossRelic>(),
                ModContent.ItemType<Content.Pets.MinionBossPet.MinionBossPetItem>(),
                ModContent.ItemType<Content.Items.Placeable.Furniture.MinionBossTrophy>(),
                ModContent.ItemType<Content.Items.Armor.Vanity.MinionBossMask>()*/
            };

            var VoiyedcustomPortrait = (SpriteBatch sb, Rectangle rect, Color color) => {
                Texture2D texture = ModContent.Request<Texture2D>("DedsBosses/Assets/Textures/Bestiary/VoiyedBoss_Preview").Value;
                Vector2 centered = new Vector2(rect.X + (rect.Width / 2) - (texture.Width / 2), rect.Y + (rect.Height / 2) - (texture.Height / 2));
                sb.Draw(texture, centered, color);
            };

            bossChecklistMod.Call(
                "LogBoss",
                Mod,
                VoiyedinternalName,
                Voiyedweight,
                Voiyeddowned,
                VoiyedbossType,
                new Dictionary<string, object>()
                {
                    ["spawnItems"] = VoiyedspawnItem,
                    ["collectibles"] = Voiyedcollectibles,
                    ["customPortrait"] = VoiyedcustomPortrait,
                }
            );
        }
    }
}