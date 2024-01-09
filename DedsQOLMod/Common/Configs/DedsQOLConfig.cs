using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader.Config;

namespace DedsQOLMod.Common.Configs
{
    public class DedsQOLConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [DefaultValue(false)]
        [ReloadRequired]
        public bool NpcAndProjDamageTextToggle;

        [DefaultValue(false)]
        [ReloadRequired]
        public bool PlayerLifeRegenerationTextToggle;
    }
}
