using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DedsQOLMod.Common.Systems
{
    public class DownedBossSystem : ModSystem
	{
		public static bool downedGemBoss = false;

		public override void ClearWorld() 
		{
            downedGemBoss = false;
		}
		public override void SaveWorldData(TagCompound tag) {
			if (downedGemBoss) 
			{
				tag["downedGemBoss"] = true;
			}
		}

		public override void LoadWorldData(TagCompound tag) 
		{
            downedGemBoss = tag.ContainsKey("downedGemBoss");
		}

		public override void NetSend(BinaryWriter writer) {
			var flags = new BitsByte();
			flags[0] = downedGemBoss;
			writer.Write(flags);
		}

		public override void NetReceive(BinaryReader reader) {
			BitsByte flags = reader.ReadByte();
            downedGemBoss = flags[0];
		}
	}
}