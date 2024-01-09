/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
//using RuinMod.Content.Classes.ChainClass;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.WorldBuilding;
using RuinMod.Content.Items.Placeables.ConverterCraftingStation.Tile;
//using RuinMod.Content.Items.Drops.EssencesOrSoulsOrFragments.Souls.SoulOfBlight;

namespace RuinMod.Common.Global.GlobalRecipe
{
    internal class GlobalRecipe : ModSystem
    {
        public override void AddRecipes()
        {
            Recipe AdamantiteOre = Recipe.Create(ItemID.AdamantiteOre, 1);
            AdamantiteOre
            .AddIngredient(ItemID.TitaniumOre, 1)
            .AddTile<ConverterCraftingStationTile>()
            .Register();

            Recipe CobaltOre = Recipe.Create(ItemID.CobaltOre, 1);
            CobaltOre
            .AddIngredient(ItemID.PalladiumOre, 1)
            .AddTile<ConverterCraftingStationTile>()
            .Register();

            Recipe CopperOre = Recipe.Create(ItemID.CopperOre, 1);
            CopperOre
            .AddIngredient(ItemID.TinOre, 1)
            .AddTile<ConverterCraftingStationTile>()
            .Register();

            Recipe CrimtaneOre = Recipe.Create(ItemID.CrimtaneOre, 1);
            CrimtaneOre
            .AddIngredient(ItemID.DemoniteOre, 1)
            .AddTile<ConverterCraftingStationTile>()
            .Register();

            Recipe DemoniteOre = Recipe.Create(ItemID.DemoniteOre, 1);
            DemoniteOre
            .AddIngredient(ItemID.CrimtaneOre, 1)
            .AddTile<ConverterCraftingStationTile>()
            .Register();

            Recipe GoldOre = Recipe.Create(ItemID.GoldOre, 1);
            GoldOre
            .AddIngredient(ItemID.PlatinumOre, 1)
            .AddTile<ConverterCraftingStationTile>()
            .Register();

            Recipe IronOre = Recipe.Create(ItemID.IronOre, 1);
            IronOre
            .AddIngredient(ItemID.LeadOre, 1)
            .AddTile<ConverterCraftingStationTile>()
            .Register();

            Recipe LeadOre = Recipe.Create(ItemID.LeadOre, 1);
            LeadOre
            .AddIngredient(ItemID.IronOre, 1)
            .AddTile<ConverterCraftingStationTile>()
            .Register();

            Recipe MythrilOre = Recipe.Create(ItemID.MythrilOre, 1);
            MythrilOre
            .AddIngredient(ItemID.OrichalcumOre, 1)
            .AddTile<ConverterCraftingStationTile>()
            .Register();

            Recipe OrichalcumOre = Recipe.Create(ItemID.OrichalcumOre, 1);
            OrichalcumOre
            .AddIngredient(ItemID.MythrilOre, 1)
            .AddTile<ConverterCraftingStationTile>()
            .Register();

            Recipe PalladiumOre = Recipe.Create(ItemID.PalladiumOre, 1);
            PalladiumOre
            .AddIngredient(ItemID.CobaltOre, 1)
            .AddTile<ConverterCraftingStationTile>()
            .Register();

            Recipe PlatinumOre = Recipe.Create(ItemID.PlatinumOre, 1);
            PlatinumOre
            .AddIngredient(ItemID.GoldOre, 1)
            .AddTile<ConverterCraftingStationTile>()
            .Register();

            Recipe SilverOre = Recipe.Create(ItemID.SilverOre, 1);
            SilverOre
            .AddIngredient(ItemID.TungstenOre, 1)
            .AddTile<ConverterCraftingStationTile>()
            .Register();

            Recipe TinOre = Recipe.Create(ItemID.TinOre, 1);
            TinOre
            .AddIngredient(ItemID.CopperOre, 1)
            .AddTile<ConverterCraftingStationTile>()
            .Register();

            Recipe TitaniumOre = Recipe.Create(ItemID.TitaniumOre, 1);
            TitaniumOre
            .AddIngredient(ItemID.AdamantiteOre, 1)
            .AddTile<ConverterCraftingStationTile>()
            .Register();

            Recipe TungstenOre = Recipe.Create(ItemID.TungstenOre, 1);
            TungstenOre
            .AddIngredient(ItemID.SilverOre, 1)
            .AddTile<ConverterCraftingStationTile>()
            .Register();

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            Recipe AdamantiteBar = Recipe.Create(ItemID.AdamantiteBar, 1);
            AdamantiteBar
            .AddIngredient(ItemID.TitaniumBar, 1)
            .AddTile<ConverterCraftingStationTile>()
            .Register();

            Recipe CobaltBar = Recipe.Create(ItemID.CobaltBar, 1);
            CobaltBar
            .AddIngredient(ItemID.PalladiumBar, 1)
            .AddTile<ConverterCraftingStationTile>()
            .Register();

            Recipe CopperBar = Recipe.Create(ItemID.CopperBar, 1);
            CopperBar
            .AddIngredient(ItemID.TinBar, 1)
            .AddTile<ConverterCraftingStationTile>()
            .Register();

            Recipe CrimtaneBar = Recipe.Create(ItemID.CrimtaneBar, 1);
            CrimtaneBar
            .AddIngredient(ItemID.DemoniteBar, 1)
            .AddTile<ConverterCraftingStationTile>()
            .Register();

            Recipe DemoniteBar = Recipe.Create(ItemID.DemoniteBar, 1);
            DemoniteBar
            .AddIngredient(ItemID.CrimtaneBar, 1)
            .AddTile<ConverterCraftingStationTile>()
            .Register();

            Recipe GoldBar = Recipe.Create(ItemID.GoldBar, 1);
            GoldBar
            .AddIngredient(ItemID.PlatinumBar, 1)
            .AddTile<ConverterCraftingStationTile>()
            .Register();

            Recipe IronBar = Recipe.Create(ItemID.IronBar, 1);
            IronBar
            .AddIngredient(ItemID.LeadBar, 1)
            .AddTile<ConverterCraftingStationTile>()
            .Register();

            Recipe LeadBar = Recipe.Create(ItemID.LeadBar, 1);
            LeadBar
            .AddIngredient(ItemID.IronBar, 1)
            .AddTile<ConverterCraftingStationTile>()
            .Register();

            Recipe MythrilBar = Recipe.Create(ItemID.MythrilBar, 1);
            MythrilBar
            .AddIngredient(ItemID.OrichalcumBar, 1)
            .AddTile<ConverterCraftingStationTile>()
            .Register();

            Recipe OrichalcumBar = Recipe.Create(ItemID.OrichalcumBar, 1);
            OrichalcumBar
            .AddIngredient(ItemID.MythrilBar, 1)
            .AddTile<ConverterCraftingStationTile>()
            .Register();

            Recipe PalladiumBar = Recipe.Create(ItemID.PalladiumBar, 1);
            PalladiumBar
            .AddIngredient(ItemID.CobaltBar, 1)
            .AddTile<ConverterCraftingStationTile>()
            .Register();

            Recipe PlatinumBar = Recipe.Create(ItemID.PlatinumBar, 1);
            PlatinumBar
            .AddIngredient(ItemID.GoldBar, 1)
            .AddTile<ConverterCraftingStationTile>()
            .Register();

            Recipe SilverBar = Recipe.Create(ItemID.SilverBar, 1);
            SilverBar
            .AddIngredient(ItemID.TungstenBar, 1)
            .AddTile<ConverterCraftingStationTile>()
            .Register();

            Recipe TinBar = Recipe.Create(ItemID.TinBar, 1);
            TinBar
            .AddIngredient(ItemID.CopperBar, 1)
            .AddTile<ConverterCraftingStationTile>()
            .Register();

            Recipe TitaniumBar = Recipe.Create(ItemID.TitaniumBar, 1);
            TitaniumBar
            .AddIngredient(ItemID.AdamantiteBar, 1)
            .AddTile<ConverterCraftingStationTile>()
            .Register();

            Recipe TungstenBar = Recipe.Create(ItemID.TungstenBar, 1);
            TungstenBar
            .AddIngredient(ItemID.SilverBar, 1)
            .AddTile<ConverterCraftingStationTile>()
            .Register();

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            Recipe HermesBoots = Recipe.Create(ItemID.HermesBoots, 1); HermesBoots
            .AddIngredient(ItemID.Silk, 8)
            .AddIngredient(ItemID.SwiftnessPotion, 3)
            .AddTile(TileID.Loom)
            .Register();

            Recipe Aglet = Recipe.Create(ItemID.Aglet, 1);
            Aglet
            .AddIngredient(ItemID.GoldBar, 7)
            .AddTile(TileID.Anvils)
            .Register();

            Recipe Aglet2 = Recipe.Create(ItemID.Aglet, 1);
            Aglet2
            .AddIngredient(ItemID.PlatinumBar, 7)
            .AddTile(TileID.Anvils)
            .Register();

            Recipe Bezoar = Recipe.Create(ItemID.Bezoar, 1);
            Bezoar
            .AddIngredient(ItemID.Stinger, 10)
            .AddTile(TileID.Anvils)
            .Register();

            Recipe Blindfold = Recipe.Create(ItemID.Blindfold, 1);
            Blindfold
            .AddIngredient(ItemID.Silk, 75)
            .AddIngredient(ItemID.RottenChunk, 25)
            .AddTile(TileID.Anvils)
            .Register();

            Recipe Blindfold2 = Recipe.Create(ItemID.Blindfold, 1);
            Blindfold2
            .AddIngredient(ItemID.Silk, 75)
            .AddIngredient(ItemID.Vertebrae, 25)
            .AddTile(TileID.Anvils)
            .Register();

            Recipe CloudinaBottle = Recipe.Create(ItemID.CloudinaBottle, 1);
            CloudinaBottle
            .AddIngredient(ItemID.Bottle, 1)
            .AddIngredient(ItemID.Cloud, 65)
            .AddTile(TileID.Anvils)
            .Register();

            Recipe CobaltShield = Recipe.Create(ItemID.CobaltShield, 1);
            CobaltShield
            .AddIngredient(ItemID.CobaltBar, 25)
            .AddTile(TileID.MythrilAnvil)
            .Register();

            Recipe CobaltShield2 = Recipe.Create(ItemID.CobaltShield, 1);
            CobaltShield2
            .AddIngredient(ItemID.PalladiumBar, 25)
            .AddTile(TileID.MythrilAnvil)
            .Register();

            Recipe DPSMeter = Recipe.Create(ItemID.DPSMeter, 1);
            DPSMeter
            .AddIngredient(ItemID.IronBar, 10)
            .AddIngredient(ItemID.TallyCounter, 5)
            .AddIngredient(ItemID.Wire, 5)
            .AddTile(TileID.Anvils)
            .Register();

            Recipe DPSMeter2 = Recipe.Create(ItemID.DPSMeter, 1);
            DPSMeter2
            .AddIngredient(ItemID.LeadBar, 10)
            .AddIngredient(ItemID.TallyCounter, 5)
            .AddIngredient(ItemID.Wire, 5)
            .AddTile(TileID.Anvils)
            .Register();

            Recipe FastClock = Recipe.Create(ItemID.FastClock, 1);
            FastClock
            .AddIngredient(ItemID.Timer1Second, 1)
            .AddIngredient(ItemID.IronBar, 15)
            .AddIngredient(ItemID.PlatinumWatch, 1)
            .AddTile(TileID.Anvils)
            .Register();

            Recipe FastClock2 = Recipe.Create(ItemID.FastClock, 1);
            FastClock2
            .AddIngredient(ItemID.Timer1Second, 1)
            .AddIngredient(ItemID.IronBar, 15)
            .AddIngredient(ItemID.GoldWatch, 1)
            .AddTile(TileID.Anvils)
            .Register();

            Recipe FastClock3 = Recipe.Create(ItemID.FastClock, 1);
            FastClock3
            .AddIngredient(ItemID.Timer1Second, 1)
            .AddIngredient(ItemID.LeadBar, 15)
            .AddIngredient(ItemID.PlatinumWatch, 1)
            .AddTile(TileID.Anvils)
            .Register();

            Recipe FastClock4 = Recipe.Create(ItemID.FastClock, 1);
            FastClock4
            .AddIngredient(ItemID.Timer1Second, 1)
            .AddIngredient(ItemID.LeadBar, 15)
            .AddIngredient(ItemID.GoldWatch, 1)
            .AddTile(TileID.Anvils)
            .Register();

            Recipe FeralClaws = Recipe.Create(ItemID.FeralClaws, 1);
            FeralClaws
            .AddIngredient(ItemID.JungleSpores, 13)
            .AddIngredient(ItemID.IronBar, 1)
            .AddIngredient(ItemID.Vine, 15)
            .AddIngredient(ItemID.JungleGrassSeeds, 1)
            .AddTile(TileID.Anvils)
            .Register();

            Recipe FeralClaws2 = Recipe.Create(ItemID.FeralClaws, 1);
            FeralClaws2
            .AddIngredient(ItemID.JungleSpores, 13)
            .AddIngredient(ItemID.LeadBar, 1)
            .AddIngredient(ItemID.Vine, 15)
            .AddIngredient(ItemID.JungleGrassSeeds, 1)
            .AddTile(TileID.Anvils)
            .Register();

            Recipe IceSkates = Recipe.Create(ItemID.IceSkates, 1);
            IceSkates
            .AddIngredient(ItemID.WaterWalkingBoots, 1)
            .AddIngredient(ItemID.IceBlock, 15)
            .AddIngredient(ItemID.SilverBar, 6)
            .AddTile(TileID.Anvils)
            .Register();

            Recipe IceSkates2 = Recipe.Create(ItemID.IceSkates, 1);
            IceSkates2
            .AddIngredient(ItemID.WaterWalkingBoots, 1)
            .AddIngredient(ItemID.IceBlock, 15)
            .AddIngredient(ItemID.TungstenBar, 6)
            .AddTile(TileID.Anvils)
            .Register();

            Recipe LifeFruit = Recipe.Create(ItemID.LifeFruit, 1);
            LifeFruit
            .AddIngredient(ItemID.LifeCrystal, 1)
            .AddIngredient(ItemID.SoulofSight, 1)
            .AddIngredient(ItemID.SoulofFright, 1)
            .AddIngredient(ItemID.SoulofMight, 1)
            //.AddIngredient(ModContent.ItemType<SoulOfBlight>(), 1)
            .AddTile(TileID.DemonAltar)
            .Register();

            Recipe Radar = Recipe.Create(ItemID.Radar, 1);
            Radar
            .AddIngredient(ItemID.IronBar, 10)
            .AddIngredient(ItemID.Wire, 5)
            .AddTile(TileID.Anvils)
            .Register();

            Recipe Radar2 = Recipe.Create(ItemID.Radar, 1);
            Radar2
            .AddIngredient(ItemID.LeadBar, 10)
            .AddIngredient(ItemID.Wire, 5)
            .AddTile(TileID.Anvils)
            .Register();

            Recipe TallyCounter = Recipe.Create(ItemID.TallyCounter, 1);
            TallyCounter
            .AddIngredient(ItemID.IronBar, 10)
            .AddIngredient(ItemID.Bone, 5)
            .AddTile(TileID.Anvils)
            .Register();

            Recipe TallyCounter2 = Recipe.Create(ItemID.TallyCounter, 1);
            TallyCounter2
            .AddIngredient(ItemID.LeadBar, 10)
            .AddIngredient(ItemID.Bone, 5)
            .AddTile(TileID.Anvils)
            .Register();

            Recipe RodofDiscord = Recipe.Create(ItemID.RodofDiscord, 1);
            RodofDiscord
            .AddIngredient(ItemID.RainbowRod, 1)
            .AddIngredient(ItemID.SoulofMight, 10)
            .AddIngredient(ItemID.SoulofFright, 10)
            .AddIngredient(ItemID.HallowedBar, 12)
            .AddIngredient(ItemID.Teleporter, 1)
            .AddIngredient(ItemID.TeleportationPotion, 3)
            .AddTile(TileID.MythrilAnvil)
            .Register();

            Recipe WaterWalkingBoots = Recipe.Create(ItemID.WaterWalkingBoots, 1);
            WaterWalkingBoots
            .AddIngredient(ItemID.HermesBoots, 1)
            .AddIngredient(ItemID.WaterWalkingPotion, 5)
            .AddIngredient(ItemID.TungstenBar, 5)
            .AddTile(TileID.Anvils)
            .Register();

            Recipe WaterWalkingBoots2 = Recipe.Create(ItemID.WaterWalkingBoots, 1);
            WaterWalkingBoots2
            .AddIngredient(ItemID.HermesBoots, 1)
            .AddIngredient(ItemID.WaterWalkingPotion, 5)
            .AddIngredient(ItemID.SilverBar, 5)
            .AddTile(TileID.Anvils)
            .Register();

            /*Recipe AvengerEmblem = Recipe.Create(ItemID.AvengerEmblem, 1);
            AvengerEmblem
            .AddIngredient(ModContent.ItemType<Content.Armor.Accesories.ChainClassAccesories.Hardmode.ChainEmblem.ChainEmblem>(), 1)
            .AddIngredient(ItemID.SoulofMight, 5)
            .AddIngredient(ItemID.SoulofSight, 5)
            .AddIngredient(ItemID.SoulofFright, 5)
            .AddTile(TileID.TinkerersWorkbench)
            .Register();*/

            /*Recipe GamerAvengerEmblem = Recipe.Create(ItemID.AvengerEmblem, 1);
            GamerAvengerEmblem
            //.AddIngredient(ModContent.ItemType<Content.Armor.Accesories.GamerClassAccesories.Hardmode.GamingEmblem.GamingEmblem>(), 1)
            .AddIngredient(ItemID.SoulofMight, 5)
            .AddIngredient(ItemID.SoulofSight, 5)
            .AddIngredient(ItemID.SoulofFright, 5)
            .AddTile(TileID.TinkerersWorkbench)
            .Register();

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        }

        public override void PostAddRecipes()
        {
            /*for (int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];

                if(recipe.TryGetResult(ItemID.Drax, out Item Drax))
                {
                    recipe.AddIngredient(ModContent.ItemType<SoulOfBlight>());
                }

                if (recipe.TryGetResult(ItemID.PickaxeAxe, out Item PickaxeAxe))
                {
                    recipe.AddIngredient(ModContent.ItemType<SoulOfBlight>());
                }

                if (recipe.TryGetResult(ItemID.TrueNightsEdge, out Item TrueNightsEdge))
                {
                    recipe.AddIngredient(ModContent.ItemType<SoulOfBlight>(), 20);
                }

                if (recipe.TryGetResult(ItemID.AvengerEmblem, out Item AvengerEmblem))
                {
                    recipe.AddIngredient(ModContent.ItemType<SoulOfBlight>(), 5);
                }

                if (recipe.TryGetResult(ItemID.Zenith, out Item Zenith))
                {
                    //recipe.AddIngredient(ModContent.ItemType<Content.Items.Drops.EssencesOrSoulsOrFragments.Souls.SoulOfStruggle.SoulOfStruggle>(), 10);
                }
            }*/
        /*}
    }
}*/
