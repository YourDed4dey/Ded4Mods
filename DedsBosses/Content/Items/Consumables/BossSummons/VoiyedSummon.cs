using DedsBosses.Content.NPCs.Bosses.VoiyedBoss;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace DedsBosses.Content.Items.Consumables.BossSummons
{
    public class VoiyedSummon : ModItem
    {
        public override void SetStaticDefaults()
        {
            /*DisplayName.SetDefault("Voiyed Summon");
            Tooltip.SetDefault("Summons the Voiyed boss");*/
            ItemID.Sets.SortingPriorityBossSpawns[Type] = 12; // This helps sort inventory know that this is a boss summoning Item.
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 20;
            Item.maxStack = 9999;
            Item.useTime = 45;
            Item.useAnimation = 45;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.consumable = true;
            Item.rare = ModContent.RarityType<Rarities.VoiyedRarity>();
            Item.value = Item.sellPrice(0, 0, 0, 0);
        }

        public override bool CanUseItem(Player player)
        {
            // Ensure the boss is not already alive
            return !NPC.AnyNPCs(ModContent.NPCType<Voiyed>());
        }
        public override bool? UseItem(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                // If the player using the item is the client
                // (explicitely excluded serverside here)
                SoundEngine.PlaySound(SoundID.Roar, player.position);

                int type = ModContent.NPCType<Voiyed>();

                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    // If the player is not in multiplayer, spawn directly
                    NPC.SpawnOnPlayer(player.whoAmI, type);
                }
                else
                {
                    // If the player is in multiplayer, request a spawn
                    // This will only work if NPCID.Sets.MPAllowedEnemies[type] is true, which we set in MinionBossBody
                    NetMessage.SendData(MessageID.SpawnBossUseLicenseStartEvent, number: player.whoAmI, number2: type);
                }
            }

            return true;
        }
    }
}
