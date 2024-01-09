using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace DedsBosses.Common.Configs
{
    public class DedsBossesConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [DefaultValue(false)]
        [ReloadRequired]
        public bool VoiyedIsPartOfProgressionToggle;
    }
}
