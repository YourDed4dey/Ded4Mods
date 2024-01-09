using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using DedsBosses.Common.Systems;
using DedsBosses.Content.Items.Consumables.BossSummons;

namespace DedsBosses.Content.Testing
{
    internal class FlagsInfo : ModItem
    {
        public override void SetStaticDefaults()
        {

        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.useStyle = ItemUseStyleID.HoldUp; // The style used when holding the Item
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.UseSound = SoundID.Item1;
        }

        public override void ModifyTooltips(System.Collections.Generic.List<TooltipLine> tooltips)
        {
            // Slime King
            AddBossTooltip(tooltips, "[i:"+ ItemID.SlimeCrown+"]Slime King", NPC.downedSlimeKing);

            // Eye of Cthulhu
            AddBossTooltip(tooltips, "[i:"+ ItemID.SuspiciousLookingEye+"]Eye of Cthulhu", NPC.downedBoss1);

            // EOW or BOC
            AddBossTooltip(tooltips, "[i:"+ ItemID.WormFood +"][i:"+ItemID.BloodySpine +"]EOW or BOC", NPC.downedBoss2);

            // Goblin Army
            AddBossTooltip(tooltips, "[i:"+ ItemID.GoblinBattleStandard+"]Goblin Army", NPC.downedGoblins);

            // Queen Bee
            AddBossTooltip(tooltips, "[i:"+ ItemID.Abeemination+"]Queen Bee", NPC.downedQueenBee);

            // Skeletron
            //AddBossTooltip(tooltips, "[i:"+ ModContent.ItemType<SkeletronSummon>()+"]Skeletron", NPC.downedBoss3);

            // Deerclops
            AddBossTooltip(tooltips, "[i:"+ ItemID.DeerThing+"]Deerclops", NPC.downedDeerclops);

            // Wall of Flesh
            AddBossTooltip(tooltips, "[i:"+ ItemID.GuideVoodooDoll+"]Wall of Flesh", Main.hardMode);

            // Pirate Invasion
            AddBossTooltip(tooltips, "[i:"+ ItemID.PirateMap+"]Pirate Invasion", NPC.downedPirates);

            // Queen Slime
            AddBossTooltip(tooltips, "[i:"+ ItemID.QueenSlimeCrystal+"]Queen Slime", NPC.downedQueenSlime);

            // Twins
            AddBossTooltip(tooltips, "[i:"+ ItemID.MechanicalEye+"]Twins", NPC.downedMechBoss2);

            // Destroyer
            AddBossTooltip(tooltips, "[i:"+ ItemID.MechanicalWorm+"]Destroyer", NPC.downedMechBoss1);

            // Skeletron Prime
            AddBossTooltip(tooltips, "[i:"+ ItemID.MechanicalSkull+"]Skeletron Prime", NPC.downedMechBoss3);

            // Plantera
            //AddBossTooltip(tooltips, "[i:"+ ModContent.ItemType<PlanteraSummon>() + "]Plantera", NPC.downedPlantBoss);

            // Voiyed
            AddBossTooltip(tooltips, "[i:"+ ModContent.ItemType<VoiyedSummon>() + "]Voiyed", DownedBossSystem.downedVoiyedBoss);

            // Golem
            AddBossTooltip(tooltips, "[i:"+ ItemID.LihzahrdPowerCell+"]Golem", NPC.downedGolemBoss);

            // Mourning Wood
            AddBossTooltip(tooltips, "[i:"+ ItemID.PumpkinMoonMedallion+"]Mourning Wood", NPC.downedHalloweenTree);

            // Pumpking
            AddBossTooltip(tooltips, "[i:"+ ItemID.PumpkinMoonMedallion + "]Pumpking", NPC.downedHalloweenKing);

            // Everscream
            AddBossTooltip(tooltips, "[i:"+ ItemID.NaughtyPresent+"]Everscream", NPC.downedChristmasTree);

            // Santa-NK1
            AddBossTooltip(tooltips, "[i:"+ ItemID.NaughtyPresent + "]Santa-NK1", NPC.downedChristmasSantank);

            // Ice Queen
            AddBossTooltip(tooltips, "[i:"+ ItemID.NaughtyPresent + "]Ice Queen", NPC.downedChristmasIceQueen);

            // Martian Madness
            AddBossTooltip(tooltips, "[i:"+ ItemID.CosmicCarKey+"]Martian Madness", NPC.downedMartians);

            // Duke Fishron
            AddBossTooltip(tooltips, "[i:"+ ItemID.TruffleWorm+"]Duke Fishron", NPC.downedFishron);

            // Empress of Light
            //AddBossTooltip(tooltips, "[i:"+ ModContent.ItemType<EOLSummon>() + "]Empress of Light", NPC.downedEmpressOfLight);

            // Lunatic Cultist
            //AddBossTooltip(tooltips, "[i:"+ ModContent.ItemType<CultistSummon>() + "]Lunatic Cultist", NPC.downedAncientCultist);

            // Moon Lord
            AddBossTooltip(tooltips, "[i:"+ ItemID.CelestialSigil+"]Moon Lord", NPC.downedMoonlord);
        }

        private void AddBossTooltip(System.Collections.Generic.List<TooltipLine> tooltips, string bossName, bool defeated)
        {
            string defeatedText = defeated ? "Defeated: Yes" : "Defeated: No";

            TooltipLine line = new TooltipLine(Mod, "Defeated" + bossName, bossName + " " + defeatedText);
            line.OverrideColor = defeated ? Microsoft.Xna.Framework.Color.Green : Microsoft.Xna.Framework.Color.Red;

            tooltips.Add(line);
        }
    }
}
