using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace RuinTesting.Content.Consumables
{
    public class VoiyedSummon : ModItem
    {
        /*public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Voiyed Summon");
            Tooltip.SetDefault("Summons the Voiyed boss");
        }*/

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 20;
            Item.maxStack = 20;
            Item.useTime = 45;
            Item.useAnimation = 45;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.consumable = true;
            Item.rare = ModContent.RarityType<Rarities.VoiyedRarity>();
            Item.value = Item.sellPrice(silver: 50);
        }

        public override bool CanUseItem(Player player)
        {
            // Ensure the boss is not already alive
            return !NPC.AnyNPCs(ModContent.NPCType<NPCs.Bosses.VoiyedBoss.Voiyed>());
        }
        public override bool? UseItem(Player player)
        {
            // Ensure the boss is not already alive
            if (!NPC.AnyNPCs(ModContent.NPCType<NPCs.Bosses.VoiyedBoss.Voiyed>()))
            {
                // Spawn the boss off-screen
                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    // Check if the boss is already alive before spawning
                    if (NPC.CountNPCS(ModContent.NPCType<NPCs.Bosses.VoiyedBoss.Voiyed>()) == 0)
                    {
                        // Define an offset for the off-screen spawn position
                        int offsetX = 1000; // Adjust this value as needed to position the boss further off-screen
                        int offsetY = -600; // Adjust this value as needed to position the boss above the screen

                        // Calculate the off-screen spawn position
                        int spawnX = (int)player.position.X + offsetX;
                        int spawnY = (int)player.position.Y + offsetY;

                        // Spawn the boss
                        //NPC.NewNPC(null, spawnX, spawnY, ModContent.NPCType<NPCs.Bosses.Voiyed>());
                        NPC.NewNPC(null, spawnX, spawnY, ModContent.NPCType<NPCs.Bosses.VoiyedBoss.Voiyed>());

                    }
                }
                SoundEngine.PlaySound(SoundID.Roar, player.Center);
                return true; // Consume the item
            }
            else
            {
                return false; // Do not consume the item if the boss is already alive or it's daytime
            }
        }
    }
}
