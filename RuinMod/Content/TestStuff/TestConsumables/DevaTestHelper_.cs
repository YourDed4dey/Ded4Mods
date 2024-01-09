/*using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using RuinMod.Common.Systems.DiffSystem;

namespace RuinMod.Content.TestStuff.TestConsumables
{
    public class DevaTestHelper_ : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.BlackLens;
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Deva Testing");
            //Tooltip.SetDefault("Testy");
        }
        public override void SetDefaults()
        {
            Item.maxStack = 1;
            Item.consumable = true;
            Item.rare = ItemRarityID.Cyan;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.HoldUp;

        }
        public override bool CanUseItem(Player player)
        {
            if (RuinWorld.devastated)
            {
                NPC.downedSlimeKing = false;
                NPC.downedBoss1 = false;
                NPC.downedBoss2 = false;
                NPC.downedQueenBee = false;
                NPC.downedBoss3 = false;
                NPC.downedDeerclops = false;
                Main.hardMode = false;
                NPC.downedQueenSlime = false;
                NPC.downedMechBoss1 = false;
                NPC.downedMechBoss2 = false;
                NPC.downedMechBoss3 = false;
                NPC.downedPlantBoss = false;
                NPC.downedGolemBoss = false;
                NPC.downedFishron = false;
                NPC.downedEmpressOfLight = false;
                NPC.downedAncientCultist = false;
                NPC.downedMoonlord = false;
            }

            return true;
        }
    }
}*/