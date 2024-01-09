using System.Collections.Generic;
using Terraria.ID;
using Terraria.WorldBuilding;
using Terraria;
using Terraria.ModLoader;
using DedsBosses.Common.Configs;

namespace DedsBosses.Common.Systems
{
    public class DeletingLihzahrdAltars : ModSystem
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModContent.GetInstance<DedsBossesConfig>().VoiyedIsPartOfProgressionToggle;
        }
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                // Find the task that adds the "Lihzahrd Altar" tile during world generation
                if (tasks[i].Name == "Lihzahrd Altar")
                {
                    // Remove the task, preventing the tile from being placed in the world
                    tasks.RemoveAt(i);
                    i--; // After removing the task, you need to decrement i to avoid skipping the next task.
                }
            }
        }

        public override void PostWorldGen()
        {
            int altarType = TileID.LihzahrdAltar; // The type of the "Lihzahrd Altar" tile

            // Loop through all tiles in the world
            for (int x = 0; x < Main.maxTilesX; x++)
            {
                for (int y = 0; y < Main.maxTilesY; y++)
                {
                    Tile tile = Main.tile[x, y];
                    if (tile.TileType == altarType)
                    {
                        // Destroy the "Lihzahrd Altar" tile
                        WorldGen.KillTile(x, y);
                    }
                }
            }
        }
    }
}
