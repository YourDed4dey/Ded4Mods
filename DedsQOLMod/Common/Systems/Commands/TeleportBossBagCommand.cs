using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace DedsQOLMod.Common.Systems.Commands
{
    public class TeleportBossBagCommand : ModCommand
    {
        public override CommandType Type => CommandType.Chat;

        public override string Command => "tpbossbag";

        public override string Usage => "/tpbossbag";

        public override string Description => "Teleports any existing boss bag on the ground to the player.";

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            // Check if the world is in Expert or above difficulty
            if (Main.expertMode)
            {
                // Flag to track if we found any boss bag on the ground
                bool foundBossBag = false;

                // Loop through all dropped items on the ground
                for (int i = 0; i < Main.item.Length; i++)
                {
                    Item item = Main.item[i];
                    if (item.active && item.type != ItemID.None && item.type < ItemID.Count) // Make sure the item type is within valid bounds
                    {
                        // Check if the item is a boss bag by looking it up in the "ItemID.Sets.BossBag" dictionary
                        if (ItemID.Sets.BossBag[item.type])
                        {
                            // Teleport the boss bag to the player
                            item.position = caller.Player.position;
                            item.velocity = Vector2.Zero;
                            item.noGrabDelay = 0;

                            // Set the flag to true since we found at least one boss bag
                            foundBossBag = true;
                        }
                    }
                }

                // Send a message to the player indicating that the boss bag(s) were teleported
                if (foundBossBag)
                {
                    caller.Reply("Boss bag(s) teleported to you!");
                }
                else
                {
                    caller.Reply("There are no boss bags on the ground.");
                }
            }
            else
            {
                caller.Reply("You can only use this command in Expert or above difficulty.");
            }
        }
    }
}
