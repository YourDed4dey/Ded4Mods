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

namespace RuinMod.Content.Consumables.BossSummons.SuspiciousLookingSkull
{
    internal class SuspiciousLookingSkull : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Suspicious Looking Skull");
            //Tooltip.SetDefault("Summons The Mechanical Brain \nNot consumable");

            ItemID.Sets.SortingPriorityBossSpawns[Type] = 12;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 18;
            Item.maxStack = 1;
            Item.value = 0;
            Item.rare = ItemRarityID.Orange;

            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.consumable = false;
        }
        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(ModContent.NPCType<NPCS.Bosses.MechBrain.MechBrain>());
        }

        public override bool? UseItem(Player player)
        {
            /*if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                if (Main.dayTime == false)
                {
                    if (player.whoAmI == Main.myPlayer)
                    {

                        SoundEngine.PlaySound(SoundID.Roar, player.position);

                        int type = ModContent.NPCType<NPCS.Bosses.MechBrain.MechBrain>();

                        if (Main.netMode != NetmodeID.MultiplayerClient)
                        {
                            NPC.SpawnOnPlayer(player.whoAmI, type);
                        }
                        else
                        {
                            NetMessage.SendData(MessageID.SpawnBoss, number: player.whoAmI, number2: type);
                        }
                    }
                }
            }*/
            /*if (Main.dayTime == false)
            {
                if (player.whoAmI == Main.myPlayer)
                {
                    SoundEngine.PlaySound(SoundID.Roar, player.position);

                    int type = ModContent.NPCType<NPCS.Bosses.MechBrain.MechBrain>();

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
                .AddIngredient(ItemID.MechanicalSkull, 1)
                .AddIngredient(ItemID.MechanicalEye, 1)
                .AddIngredient(ItemID.AdamantiteBar, 10)
                .AddIngredient(ItemID.SoulofNight, 5)
                .AddIngredient(ItemID.SoulofLight, 5)
                .AddTile(TileID.MythrilAnvil)
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.MechanicalSkull, 1)
                .AddIngredient(ItemID.MechanicalEye, 1)
                .AddIngredient(ItemID.TitaniumBar, 10)
                .AddIngredient(ItemID.SoulofNight, 5)
                .AddIngredient(ItemID.SoulofLight, 5)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}*/

