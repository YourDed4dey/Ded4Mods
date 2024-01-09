/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace RuinMod.Content.Consumables.BossSummons.CorruptedSubstantiality
{
    internal class CorruptedSubstantiality : ModItem
    {

        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Corrupted Substantiality");
            //Tooltip.SetDefault("Summons the Corrupter\n'Your life is on the line, you don't realize the danger you are in...'");
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 16;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Master;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.consumable = true;
            Item.UseSound = SoundID.Roar;
        }

        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(ModContent.NPCType<Content.NPCS.Bosses.Corrupter.Corrupter>());
        }

        public override bool? UseItem(Player player)
        {
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<Content.NPCS.Bosses.Corrupter.Corrupter>());
            }
            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.SlimeCrown, 1)
                .AddIngredient(ItemID.SuspiciousLookingEye, 1)
                .AddIngredient(ItemID.WormFood, 1)
                .AddIngredient(ItemID.BloodySpine, 1)
                .AddIngredient(ItemID.ClothierVoodooDoll, 1)
                .AddIngredient(ItemID.MechanicalWorm, 1)
                .AddIngredient(ItemID.ChlorophyteBar, 20)
                .AddIngredient(ItemID.TruffleWorm, 1)
                .AddIngredient(ModContent.ItemType<Content.Consumables.BossSummons.RedemptionSkull.RedemptionSkull>(), 1)
                .AddTile(TileID.DemonAltar)
                .Register();
        }
    }
}*/

