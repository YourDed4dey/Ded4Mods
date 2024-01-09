using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using DedsBosses.Common.Systems;
using System.IO;
using DedsBosses.Content.NPCs.Friendly.TownNPCs.Summoner;

namespace DedsBosses
{
	public class DedsBosses : Mod
	{
        internal enum MessageType : byte
        {
            TeleportToStatue
        }
        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            MessageType msgType = (MessageType)reader.ReadByte();

            switch (msgType)
            {
                case MessageType.TeleportToStatue:
                    if (Main.npc[reader.ReadByte()].ModNPC is Summoner person && person.NPC.active)
                    {
                        person.StatueTeleport();
                    }

                    break;
            }
        }
    }
}