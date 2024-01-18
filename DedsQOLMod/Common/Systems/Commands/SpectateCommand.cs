using DedsQOLMod.Common.Configs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace DedsQOLMod.Common.Systems.Commands
{
    public class SpectateCommand : ModCommand
    {
        public override CommandType Type => CommandType.Chat;

        public override string Command => "spectate";

        public override string Usage => "/spectate <playername>";

        public override string Description => "Spectates the chosen player.";

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            if (args.Length < 1)
            {
                caller.Reply("Invalid usage. Correct usage: " + Usage);
                return;
            }

            // Concatenate all the arguments to get the complete player name
            string targetPlayerName = string.Join(" ", args);

            // Get the player index of the target player by their name
            int targetPlayerIndex = -1;
            for (int i = 0; i < Main.player.Length; i++)
            {
                Player player = Main.player[i];
                if (player.active && player.name == targetPlayerName)
                {
                    targetPlayerIndex = i;
                    break;
                }
            }

            // Check if the target player was found and if they are not the same as the player using the command
            if (targetPlayerIndex != -1 && targetPlayerIndex != caller.Player.whoAmI)
            {
                // Get the SpectatePlayer instance of the player using the command
                SpectatePlayer spectatePlayer = caller.Player.GetModPlayer<SpectatePlayer>();

                // Check if the player can spectate the target player based on their team
                if (spectatePlayer.CanSpectatePlayer(targetPlayerIndex))
                {
                    // Allow spectating
                    spectatePlayer.IsSpectating = true;
                    spectatePlayer.SpectateTarget = targetPlayerIndex;

                    caller.Reply("You are now spectating " + targetPlayerName + ".");
                }
                else
                {
                    caller.Reply("You can't spectate " + targetPlayerName + " because they are not in the same team.");
                }
            }
            else if (targetPlayerIndex == caller.Player.whoAmI)
            {
                caller.Reply("You can't spectate yourself.");
            }
            else
            {
                // Inform the player that the target player was not found
                caller.Reply("Player '" + targetPlayerName + "' not found.");
            }
        }
    }

    public class SpectatePlayer : ModPlayer
    {
        public bool IsSpectating;
        public int SpectateTarget;
        public Vector2 SpectateCameraPosition;

        public override void PreUpdate()
        {
            // Spectate Command Logic
            if (IsSpectating)
            {
                Player targetPlayer = Main.player[SpectateTarget];
                if (targetPlayer.active && !targetPlayer.dead)
                {
                    // Set the camera position to follow the alive player being spectated
                    SpectateCameraPosition = targetPlayer.Center - new Vector2(Main.screenWidth / 2, Main.screenHeight / 2);
                }
                else
                {
                    // Stop spectating if the target player is no longer valid (dead)
                    IsSpectating = false;
                    SpectateTarget = -1;

                    // Send a message to the player informing them that the target player is no longer available for spectating
                    Main.NewText("The player you were spectating is no longer available.", Color.Red);
                }
            }
        }

        public override void ModifyScreenPosition()
        {
            if (IsSpectating)
            {
                Main.screenPosition = SpectateCameraPosition;
            }
        }

        public int GetNearestAlivePlayer()
        {
            int nearestPlayerIndex = -1;
            float nearestDistanceSquared = float.MaxValue;

            for (int i = 0; i < Main.maxPlayers; i++)
            {
                Player otherPlayer = Main.player[i];
                if (i != Player.whoAmI && otherPlayer.active && !otherPlayer.dead)
                {
                    float distanceSquared = Vector2.DistanceSquared(Player.Center, otherPlayer.Center);
                    if (distanceSquared < nearestDistanceSquared)
                    {
                        nearestDistanceSquared = distanceSquared;
                        nearestPlayerIndex = i;
                    }
                }
            }

            return nearestPlayerIndex;
        }
        public bool CanSpectatePlayer(int playerIndex)
        {
            // Check if the player is not the same as the player they want to spectate
            if (playerIndex == Player.whoAmI)
            {
                return false; // Don't allow spectating self
            }

            Player targetPlayer = Main.player[playerIndex];

            // Check if both players are in the same team or if team PVP is disabled
            //return (Player.team == targetPlayer.team) || !Main.GameMode.HasFlag(GameModeFlag.TeamPVP);
            return Player.team == targetPlayer.team;
        }
    }

    public class StopSpectateCommand : ModCommand
    {
        public override CommandType Type => CommandType.Chat;

        public override string Command => "stopspectate";

        public override string Usage => "/stopspectate";

        public override string Description => "Stops spectating and returns to normal gameplay.";

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            // Get the DeadPlayer instance of the player using the command
            SpectatePlayer spectatePlayer = caller.Player.GetModPlayer<SpectatePlayer>();

            // Check if the player is currently spectating
            if (spectatePlayer.IsSpectating)
            {
                // Stop spectating
                spectatePlayer.IsSpectating = false;
                spectatePlayer.SpectateTarget = -1;

                caller.Reply("You have stopped spectating and returned to normal gameplay.");
            }
            else
            {
                // Inform the player that they are not currently spectating
                caller.Reply("You are not currently spectating.");
            }
        }
    }
}
