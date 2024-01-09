/*using RuinTesting;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace RuinTesting.Common.Systems.Terraria_GenPasses
{
    public class SnowCabinGenPass : GenPass
    {
        public SnowCabinGenPass(string name, float weight) : base(name, weight) { }

        // Custom method to find the ground level at the given x coordinate
        private int FindGround(int x, int startY)
        {
            int y = startY;
            while (y < Main.maxTilesY)
            {
                if (WorldGen.SolidTile(x, y))
                {
                    return y;
                }
                y++;
            }
            return startY;
        }
        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Generating Snow Cabin";
            //Snow Cabins
            for (int i = 0; i < 1000; i++) // Replace 1000 with the number of cabins you want to generate
            {
                int x = WorldGen.genRand.Next(0, Main.maxTilesX - RuinTesting.CabinWidth); // Prevent the cabin from being generated at the very edge of the world
                int y = (int)WorldGen.worldSurface; // Set the initial y coordinate to the surface

                // Find the ground level (surface) at the current x coordinate using WorldGen.TileRunner
                WorldGen.TileRunner(x, y, 10, WorldGen.genRand.Next(50, 100), TileID.SnowBlock); // 10 is the maximum distance to search for ground level

                y = FindGround(x, y);

                // Check if the area is valid for generating the cabin
                RuinTesting.PlaceSnowCabin(x, y);
            }
        }
    }
}*/
