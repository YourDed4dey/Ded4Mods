using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RuinTesting.Common.Global
{
    public class LihzahrdAltarPlacementRestriction : GlobalTile
    {
        public override void PlaceInWorld(int i, int j, int type, Item item)
        {
            // Check if the item being placed is Lihzahrd Altar
            if (item.createTile == TileID.LihzahrdAltar)
            {
                int belowTileType = Main.tile[i, j + 1].TileType;

                // Check if the tile below is Lihzahrd Brick
                if (belowTileType != TileID.LihzahrdBrick)
                {
                    // If the tile below is not Lihzahrd Brick, check if the Golem boss has been defeated
                    bool golemDefeated = NPC.downedGolemBoss;
                    if (!golemDefeated)
                    {
                        // Prevent placing Lihzahrd Altar if not on Lihzahrd Brick and Golem has not been defeated
                        WorldGen.KillTile(i, j); // Kill the tile that was just placed
                        return;
                    }
                }
            }
        }
    }
}
