/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.ModLoader.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace RuinMod.Content.TestStuff.TestConsumables
{
    internal class TestBossSummon : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.SuspiciousLookingTentacle;
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Pain");
            //Tooltip.SetDefault("Summons all vanilla bosses");

            ItemID.Sets.SortingPriorityBossSpawns[Type] = 12;

        }

        public override void SetDefaults()
        {
            Item.maxStack = 20;
            Item.value = 100;
            Item.rare = ItemRarityID.Red;
            Item.color = Color.Purple;

            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.consumable = false;
        }
           

        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(NPCID.EyeofCthulhu);
        }

        public override bool? UseItem(Player player)
        {
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                NPC.SpawnOnPlayer(player.whoAmI, NPCID.EyeofCthulhu);

                NPC.SpawnOnPlayer(player.whoAmI, NPCID.SkeletronHead);

                NPC.SpawnOnPlayer(player.whoAmI, NPCID.KingSlime);

                NPC.SpawnOnPlayer(player.whoAmI, NPCID.WallofFlesh);

                NPC.SpawnOnPlayer(player.whoAmI, NPCID.Retinazer);

                NPC.SpawnOnPlayer(player.whoAmI, NPCID.Spazmatism);

                NPC.SpawnOnPlayer(player.whoAmI, NPCID.SkeletronPrime);

                NPC.SpawnOnPlayer(player.whoAmI, NPCID.TheDestroyerBody);

                NPC.SpawnOnPlayer(player.whoAmI, NPCID.QueenBee);

                NPC.SpawnOnPlayer(player.whoAmI, NPCID.Golem);

                NPC.SpawnOnPlayer(player.whoAmI, NPCID.Plantera);

                NPC.SpawnOnPlayer(player.whoAmI, NPCID.BrainofCthulhu);

                NPC.SpawnOnPlayer(player.whoAmI, NPCID.DukeFishron);

                NPC.SpawnOnPlayer(player.whoAmI, NPCID.MartianSaucer);

                NPC.SpawnOnPlayer(player.whoAmI, NPCID.MoonLordCore);

                NPC.SpawnOnPlayer(player.whoAmI, NPCID.CultistBoss);

                NPC.SpawnOnPlayer(player.whoAmI, NPCID.HallowBoss);

                NPC.SpawnOnPlayer(player.whoAmI, NPCID.QueenSlimeBoss);
            }
            return true;
        }
    }
}*/

