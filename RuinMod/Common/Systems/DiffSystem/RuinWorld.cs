/*using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace RuinMod.Common.Systems.DiffSystem
{
    public class RuinWorld : ModSystem
    {
        public static bool devastated = false;

        public override void OnWorldLoad()
        {
            devastated = false;
        }

        public override void OnWorldUnload()
        {
            devastated = false;
        }

        public override void SaveWorldData(TagCompound tag)
        {
            if (devastated)
            {
                tag["devastated"] = true;
            }
        }

        public override void LoadWorldData(TagCompound tag)
        {
            devastated = tag.ContainsKey("devastated");
        }
    }
}*/
