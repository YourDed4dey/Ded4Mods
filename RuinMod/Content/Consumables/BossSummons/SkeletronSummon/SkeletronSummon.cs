/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Audio;

namespace RuinMod.Content.Consumables.BossSummons.SkeletronSummon
{
    internal class SkeletronSummon : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Bone Head");
            //Tooltip.SetDefault("Summons Skeletron\nNot consumable");

            ItemID.Sets.SortingPriorityBossSpawns[Type] = 12;

            NPCID.Sets.MPAllowedEnemies[NPCID.SkeletronHead] = true;

            NPCID.Sets.MPAllowedEnemies[NPCID.DungeonGuardian] = true;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 18;
            Item.maxStack = 1;
            Item.value = 0;
            Item.rare = ItemRarityID.Blue;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.consumable = false;
        }

        public override bool CanUseItem(Player player)
        {
            if(Main.dayTime == true)
            {
                return !NPC.AnyNPCs(NPCID.DungeonGuardian);
            }
            else
            return !NPC.AnyNPCs(NPCID.SkeletronHead);
        }

        public override bool? UseItem(Player player)
        {
            if (Main.dayTime == false)
            {
                if (player.whoAmI == Main.myPlayer)
                {
                    SoundEngine.PlaySound(SoundID.Roar, player.position);

                    int type = NPCID.SkeletronHead;

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
            }
            else if(Main.dayTime == true)
            {
                if (player.whoAmI == Main.myPlayer)
                {
                    SoundEngine.PlaySound(SoundID.Roar, player.position);

                    int type = NPCID.DungeonGuardian;

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
            }

            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Cobweb, 50)
                .AddIngredient(ItemID.Bone, 18)
                .AddTile(TileID.DemonAltar)
                .Register();
        }
    }
}*/

