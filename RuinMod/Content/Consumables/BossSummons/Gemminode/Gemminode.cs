/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.Audio;

namespace RuinMod.Content.Consumables.BossSummons.Gemminode
{
    internal class Gemminode : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Gemminode");
            //Tooltip.SetDefault("Summons Gemmonide\n'I will seek eternal revenge if you kill me...'\nNot consumable");

            ItemID.Sets.SortingPriorityBossSpawns[Type] = 12;

        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 24;
            Item.maxStack = 1;
            Item.value = 0;
            Item.rare = ItemRarityID.Blue;

            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.consumable = false;
        }
        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(ModContent.NPCType<NPCS.Bosses.GemBoss.GemBoss>());
        }

        public override bool? UseItem(Player player)
        {
                if (player.whoAmI == Main.myPlayer)
                {
                    SoundEngine.PlaySound(SoundID.Roar, player.position);

                    int type = ModContent.NPCType<NPCS.Bosses.GemBoss.GemBoss>();

                    if (Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        NPC.SpawnOnPlayer(player.whoAmI, type);
                    }
                    else
                    {
                        NPC.SpawnOnPlayer(player.whoAmI, type);
                        NetMessage.SendData(MessageID.SpawnBoss, number: player.whoAmI, number2: type);
                    }
                }

            return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Amethyst,5)
                .AddIngredient(ItemID.Amber, 5)
                .AddIngredient(ItemID.Sapphire, 5)
                .AddIngredient(ItemID.Topaz, 5)
                .AddIngredient(ItemID.Ruby, 5)
                .AddIngredient(ItemID.Diamond, 5)
                .AddIngredient(ItemID.Emerald, 5)
                .AddTile(TileID.DemonAltar)
                .Register();
        }
    }
}*/
