using DedsBosses.Content.NPCs.Bosses.VoiyedBoss;
using Microsoft.Xna.Framework;
using ReLogic.OS.Windows;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace DedsBosses.Common.Systems
{
    public class VoiyedNightMessage : ModSystem
    {
        private int bossSpawnTime = 3600; // 1 minute (60 seconds * 60 ticks per second)
        private bool bossShouldSpawn = false;
        // Create a new player instance for summoning the boss
        readonly Player dummyPlayer = new Player();

        public override void PostUpdateWorld()
        {
            //  Check if it's the appropriate time for the night message and boss spawning

            //  So basically how time works is that there is 2 different times. One for day and one for night.
            //  Day has up to 15 hours/ irl minutes (54000 ticks) so thats the max ticks for day
            //  Night has 9 hours/ irl minutes (32400 ticks) so thats the max ticks for night

            //  So down here its just 0-60 ticks (1 second). The 0 in "Main.dayTime" would be 4:30am and 
            //  the 0 in "!Main.dayTime" is 7:30pm
            if (Main.dayTime && Main.time >= 0 && Main.time < 60 /* 4:30am */|| !Main.dayTime && Main.time >= 0 && Main.time < 60 /* 7:30am */)
            {
                if (Main.hardMode && NPC.downedPlantBoss && !DownedBossSystem.downedVoiyedBoss && !bossShouldSpawn && !NPC.AnyNPCs(ModContent.NPCType<Voiyed>()))
                {
                    // Add a 20% chance for the night message to appear
                    if (Main.rand.NextFloat() < .00333333333) // 20% chance
                    {
                        //int timeDisplay = (int)(Main.time / 60 / 60);

                        // Display the night message along with the time
                        //Main.NewText($"You gaze into the void, and the void gazes back... ({timeDisplay})", 44, 249, 127);
                        Main.NewText($"You gaze into the void, and the void gazes back...", 44, 249, 127);
                        //44, 249, 127); //Green Chat Color (Normal, Vanilla One)
                        //175, 75, 255); //Purple Chat Color (Normal, Vanilla One)

                        if (Main.netMode == NetmodeID.Server)
                        {
                            string message = "You gaze into the void, and the void gazes back...";
                            NetworkText networkText = NetworkText.FromLiteral(message);
                            ChatHelper.BroadcastChatMessage(networkText, new Color(44, 249, 127));
                        }

                        // Set the time when the boss should spawn
                        bossSpawnTime = (int)(Main.time + 3600); // 1 minute delay
                        bossShouldSpawn = true;
                    }
                }
            }

            // Check if the boss spawn time has passed and spawn the boss
            if (Main.time >= bossSpawnTime && bossShouldSpawn)
            {
                SoundEngine.PlaySound(SoundID.Roar, dummyPlayer.position);

                int type = ModContent.NPCType<Voiyed>();

                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    NPC.SpawnOnPlayer(dummyPlayer.whoAmI, type);
                }
                else
                {
                    NetMessage.SendData(MessageID.SpawnBossUseLicenseStartEvent, number: dummyPlayer.whoAmI, number2: type);
                }

                bossShouldSpawn = false;
            }
        }
    }
}
