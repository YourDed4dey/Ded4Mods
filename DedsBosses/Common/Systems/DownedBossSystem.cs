using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DedsBosses.Common.Systems
{
	//    NPC.SetEventFlagCleared(ref DownedBossSystem.downedVoiyedBoss, -1);
	public class DownedBossSystem : ModSystem
	{
		public static bool downedVoiyedBoss = false;

		public override void ClearWorld() 
		{
			downedVoiyedBoss = false;
		}
		public override void SaveWorldData(TagCompound tag) {
			if (downedVoiyedBoss) 
			{
				tag["downedVoiyedBoss"] = true;
			}
		}

		public override void LoadWorldData(TagCompound tag) 
		{
			downedVoiyedBoss = tag.ContainsKey("downedVoiyedBoss");
		}

		public override void NetSend(BinaryWriter writer) {
			var flags = new BitsByte();
			flags[0] = downedVoiyedBoss;
			writer.Write(flags);
		}

		public override void NetReceive(BinaryReader reader) {
			BitsByte flags = reader.ReadByte();
			downedVoiyedBoss = flags[0];
		}
	}
}