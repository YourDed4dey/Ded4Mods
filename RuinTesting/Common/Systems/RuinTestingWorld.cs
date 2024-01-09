/*using RuinTesting;
using RuinTesting.Common.Systems.Terraria_GenPasses;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace RuinTesting.Common.Systems
{
    public class RuinTestingWorld : ModSystem
    {
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int shiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
            if (shiniesIndex != -1)
            {
                tasks.Insert(shiniesIndex + 1, new SnowCabinGenPass("Snow Cabin Pass", 320f));  
            }
        }
    }
}*/
