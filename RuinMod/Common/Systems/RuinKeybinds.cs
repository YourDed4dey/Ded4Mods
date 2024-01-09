using Terraria.ModLoader;

namespace RuinMod.Common.Systems
{
    public class RuinKeybinds : ModSystem
    {
        public static ModKeybind SpecialAbilityKeybind { get; private set; }
        public override void Load()
        {
            SpecialAbilityKeybind = KeybindLoader.RegisterKeybind(Mod, "SpecialAbility", "Z");
        }

        public override void Unload()
        {
            SpecialAbilityKeybind = null;
        }
    }
}