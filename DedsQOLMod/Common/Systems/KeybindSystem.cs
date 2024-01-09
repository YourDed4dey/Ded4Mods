using Terraria.ModLoader;

namespace DedsQOLMod.Common.Systems
{
    public class KeybindSystem : ModSystem
    {
        public static ModKeybind AutoRecallKeybind { get; private set; }

        public override void Load()
        {
            AutoRecallKeybind = KeybindLoader.RegisterKeybind(Mod, "Recall", "NumPad5");
        }

        public override void Unload()
        {
            AutoRecallKeybind = null;
        }
    }
}
