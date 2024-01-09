/*using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
//using RuinTesting.Common.Systems.DiffSystem;
using RuinTesting.Common.Systems.DevaSystem;

namespace RuinTesting.Content.Consumables.DiffToggle
{
    public class DevastatedDiff : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.BlackLens;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Devastated Toggle");
            Tooltip.SetDefault("Enables Devastated mode\nLeft click to enable\nRight click to disable\n'You feel devastated by just looking at it'");
        }
        public override void SetDefaults()
        {
            Item.height = 20;
            Item.width = 20;
            Item.maxStack = 1;
            Item.consumable = false;
            Item.rare = ItemRarityID.Cyan;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.HoldUp;

        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool CanUseItem(Player player)
        {
            if (Main.expertMode)
            {
                int sender = Main.myPlayer;
                if (Main.expertMode)
                {
                    if (player.altFunctionUse == 2)
                    {
                        Main.NewText("Devastated mode is disabled", Color.Purple);
                        if (RuinWorld.devastated)
                        {
                            SoundEngine.PlaySound(SoundID.Roar);
                            RuinWorld.devastated = false;
                        }
                    }
                    else
                    {
                        Main.NewText("Devastated mode is enabled", Color.Purple);
                        if (!RuinWorld.devastated)
                        {
                            SoundEngine.PlaySound(SoundID.Roar);
                            RuinWorld.devastated = true;
                        }
                    }
                }
            }

            return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddTile(TileID.DemonAltar)
                .Register();
        }
    }
}*/