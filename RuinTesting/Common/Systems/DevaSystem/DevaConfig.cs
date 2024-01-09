/*using System.ComponentModel;
using System.Runtime.Serialization;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace RuinTesting.Common.Systems.DevaSystem
{
    class DevaConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;
        public static DevaConfig Instance => ModContent.GetInstance<DevaConfig>();

        private const string ModName = "RuinTesting";

        [Label($"$Mods.{ModName}.Config.MasoBossRecolors")]
        [DefaultValue(true)]
        [ReloadRequired]
        public bool BossRecolors;
    }
}*/