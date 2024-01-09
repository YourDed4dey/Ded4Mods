/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace RuinMod.Content.Consumables.BossSummons.RedemptionSkull
{
    internal class RedemptionSkull : ModItem
    {

        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Redemption Skull");
            //Tooltip.SetDefault("Summons the Skull of Redemption\n'Redeem all of your sins'\n[c/00FF46:Music made by Penumbra]");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 18;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Lime;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.consumable = true;
            Item.UseSound = SoundID.Roar;
        }

        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(ModContent.NPCType<Content.NPCS.Bosses.SkullOfRedemption.SkullOfRedemption>());
        }

        public override bool? UseItem(Player player)
        {
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<Content.NPCS.Bosses.SkullOfRedemption.SkullOfRedemption>());
            }
            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.ChlorophyteBar, 15)
                .AddIngredient(ItemID.MechanicalSkull, 1)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    } 
}*/
