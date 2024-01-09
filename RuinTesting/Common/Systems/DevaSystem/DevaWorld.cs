/*using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.UI;

namespace RuinTesting.Common.Systems.DevaSystem
{
    public class DevaWorld : ModSystem
    {
        internal enum Downed //to keep them organized and synced, DO NOT rearrange
        {

        }
        public const int MaxCountPreHM = 560;
        public const int MaxCountHM = 240;

        public static bool ShouldBeEternityMode;
        public static bool EternityMode { get; private set; }
        public static bool MasochistModeReal;
        public static bool CanPlayMaso;

        public static bool[] downedBoss = new bool[Enum.GetValues(typeof(Downed)).Length];  
        public static bool downedAnyBoss;

        public override void Unload()
        {
            base.Unload();

            downedBoss = null;
        }

        private void ResetFlags()
        {
            ShouldBeEternityMode = false;
            EternityMode = false;
            CanPlayMaso = false;
            MasochistModeReal = false;

            for (int i = 0; i < downedBoss.Length; i++)
                downedBoss[i] = false;

            downedAnyBoss = false;
        }

        public override void OnWorldLoad()
        {
            ResetFlags();
        }

        public override void OnWorldUnload()
        {
            ResetFlags();
        }

        public override void SaveWorldData(TagCompound tag)
        {

            List<string> downed = new List<string>();
            if (ShouldBeEternityMode) downed.Add("shouldBeEternityMode");
            if (EternityMode) downed.Add("eternity");
            if (CanPlayMaso) downed.Add("CanPlayMaso");
            if (MasochistModeReal) downed.Add("getReal");
            if (downedAnyBoss) downed.Add("downedAnyBoss");

            for (int i = 0; i < downedBoss.Length; i++)
            {
                if (downedBoss[i])
                    downed.Add("downedBoss" + i.ToString());
            }

            tag.Add("downed", downed);
        }

        public override void LoadWorldData(TagCompound tag)
        {
            IList<string> downed = tag.GetList<string>("downed");
            ShouldBeEternityMode = downed.Contains("shouldBeEternityMode");
            EternityMode = downed.Contains("eternity") || downed.Contains("masochist");
            CanPlayMaso = downed.Contains("CanPlayMaso");
            MasochistModeReal = downed.Contains("getReal");
            downedAnyBoss = downed.Contains("downedAnyBoss");

            for (int i = 0; i < downedBoss.Length; i++)
                downedBoss[i] = downed.Contains($"downedBoss{i}");
        }

        public override void NetReceive(BinaryReader reader)
        {

            BitsByte flags = reader.ReadByte();
            EternityMode = flags[0];

            flags = reader.ReadByte();
            MasochistModeReal = flags[1];
            CanPlayMaso = flags[2];
            ShouldBeEternityMode = flags[3];
            downedAnyBoss = flags[4];

            for (int i = 0; i < downedBoss.Length; i++)
            {
                int bits = i % 8;
                if (bits == 0)
                    flags = reader.ReadByte();

                downedBoss[i] = flags[bits];
            }
        }

        public override void NetSend(BinaryWriter writer)
        {
            writer.Write(new BitsByte
            {
                [0] = EternityMode
            });

            writer.Write(new BitsByte
            {
                [1] = MasochistModeReal,
                [2] = CanPlayMaso,
                [3] = ShouldBeEternityMode,
                [4] = downedAnyBoss,
            });

            BitsByte bitsByte = new BitsByte();
            for (int i = 0; i < downedBoss.Length; i++)
            {
                int bit = i % 8;

                if (bit == 0 && i != 0)
                {
                    writer.Write(bitsByte);
                    bitsByte = new BitsByte();
                }

                bitsByte[bit] = downedBoss[i];
            }
            writer.Write(bitsByte);
        }
    }
}*/