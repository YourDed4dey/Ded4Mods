using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RuinTesting.Common.Systems
{
    public class RuinTestingDeadPlayer : ModPlayer
    {
        public bool IsSpectating;
        public int SpectateTarget;
        public Vector2 SpectateCameraPosition;

        public override void ResetEffects()
        {
            IsSpectating = false;
        }

        public override void PreUpdate()
        {
            // Check if the player is dead and not spectating
            if (Player.dead && !IsSpectating)
            {
                // Get the nearest alive player
                int nearestPlayerIndex = GetNearestAlivePlayer();
                if (nearestPlayerIndex != -1)
                {
                    // Set the dead player to spectate the nearest alive player
                    IsSpectating = true;
                    SpectateTarget = nearestPlayerIndex;
                }
            }

            // Camera tracking for the spectating player
            if (IsSpectating)
            {
                Player targetPlayer = Main.player[SpectateTarget];
                if (targetPlayer.active && !targetPlayer.dead)
                {
                    // Set the camera position to follow the alive player being spectated
                    SpectateCameraPosition = targetPlayer.Center - new Vector2(Main.screenWidth / 2, Main.screenHeight / 2);
                }
            }
        }

        public override void ModifyScreenPosition()
        {
            // Use the stored SpectateCameraPosition for the dead player's camera
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
    }
}
