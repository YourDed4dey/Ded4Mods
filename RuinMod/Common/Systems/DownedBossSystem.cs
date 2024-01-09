/*using log4net.Repository.Hierarchy;
using RuinMod.Content.Consumables.BossSummons.Gemminode;
using RuinMod.Content.Consumables.BossSummons.SuspiciousLookingSkull;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using System.Reflection;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader.Config;
using RuinMod.Content.NPCS.Bosses.MechBrain;

namespace RuinMod.Common.Systems
{
	public class DownedBossSystem : ModSystem
	{
		public static bool downedMechBrain = false;
		public static bool downedGemBoss = false;

        public override void OnWorldLoad()
		{
            downedMechBrain = false;
            downedGemBoss = false;
        }

		public override void OnWorldUnload()
		{
            downedMechBrain = false;
            downedGemBoss = false;
        }
		public override void SaveWorldData(TagCompound tag)
		{
			if (downedMechBrain)
			{
				tag["downedMechBrain"] = true;
			}

			if (downedGemBoss) {
			tag["downedGemBoss"] = true;
			}
		}

		public override void LoadWorldData(TagCompound tag)
		{
			downedMechBrain = tag.ContainsKey("downedMechBrain");
            downedGemBoss = tag.ContainsKey("downedGemBoss");
		}

		public override void NetSend(BinaryWriter writer)
		{
			var flags = new BitsByte();
			flags[1] = downedMechBrain;
			flags[1] = downedGemBoss;
			writer.Write(flags);
		}

		public override void NetReceive(BinaryReader reader)
		{
			BitsByte flags = reader.ReadByte();
            downedMechBrain = flags[1];
            downedGemBoss = flags[1];
		}
    }
}*/