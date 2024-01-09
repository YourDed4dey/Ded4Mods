using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace DedsQOLMod.Common.Global
{
    public class GlobalRecipe : ModSystem
    {
        public override void AddRecipes()
        {
            RecipeGroup.RegisterGroup("CopperOrTinBars", new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Copper or Tin Bars", ItemID.CopperBar, ItemID.TinBar));
            RecipeGroup.RegisterGroup("IronOrLeadBars", new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Iron or Lead Bars", ItemID.IronBar, ItemID.LeadBar));
            RecipeGroup.RegisterGroup("SilverOrTungstenBars", new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Silver or Tungsten Bars", ItemID.SilverBar, ItemID.TungstenBar));
            RecipeGroup.RegisterGroup("GoldOrPlatinumBars", new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Gold or Platinum Bars", ItemID.GoldBar, ItemID.PlatinumBar));
            RecipeGroup.RegisterGroup("DemoniteOrCrimtaneBars", new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Demonite or Crimtane Bars", ItemID.DemoniteBar, ItemID.CrimtaneBar));
            
            RecipeGroup.RegisterGroup("CobaltOrPalladiumBars", new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Cobalt or Palladium Bars", ItemID.CobaltBar, ItemID.PalladiumBar));
            RecipeGroup.RegisterGroup("MythrilOrOrichalcumBars", new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Mythril or Orichalcum Bars", ItemID.MythrilBar, ItemID.OrichalcumBar));
            RecipeGroup.RegisterGroup("AdamantiteOrTitaniumBars", new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Adamantite or Titanium Bars", ItemID.AdamantiteBar, ItemID.TitaniumBar));

            RecipeGroup.RegisterGroup("RottenChunkOrVertebrae", new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Rotten chunk or Vertebrae", ItemID.RottenChunk, ItemID.Vertebrae));
            RecipeGroup.RegisterGroup("GoldWatchOrPlatinumWatch", new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Gold watch or Platinum watch", ItemID.GoldWatch, ItemID.PlatinumWatch));
            RecipeGroup.RegisterGroup("Gems", new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Gem", ItemID.Amber, ItemID.Amethyst, ItemID.Diamond, ItemID.Emerald, ItemID.Ruby, ItemID.Sapphire, ItemID.Topaz));

            Recipe AdamantiteOre = Recipe.Create(ItemID.AdamantiteOre, 1);
            AdamantiteOre
            .AddIngredient(ItemID.TitaniumOre, 1)
            .Register();

            Recipe CobaltOre = Recipe.Create(ItemID.CobaltOre, 1);
            CobaltOre
            .AddIngredient(ItemID.PalladiumOre, 1)
            .Register();

            Recipe CopperOre = Recipe.Create(ItemID.CopperOre, 1);
            CopperOre
            .AddIngredient(ItemID.TinOre, 1)
            .Register();

            Recipe CrimtaneOre = Recipe.Create(ItemID.CrimtaneOre, 1);
            CrimtaneOre
            .AddIngredient(ItemID.DemoniteOre, 1)
            .Register();

            Recipe DemoniteOre = Recipe.Create(ItemID.DemoniteOre, 1);
            DemoniteOre
            .AddIngredient(ItemID.CrimtaneOre, 1)
            .Register();

            Recipe GoldOre = Recipe.Create(ItemID.GoldOre, 1);
            GoldOre
            .AddIngredient(ItemID.PlatinumOre, 1)
            .Register();

            Recipe IronOre = Recipe.Create(ItemID.IronOre, 1);
            IronOre
            .AddIngredient(ItemID.LeadOre, 1)
            .Register();

            Recipe LeadOre = Recipe.Create(ItemID.LeadOre, 1);
            LeadOre
            .AddIngredient(ItemID.IronOre, 1)
            .Register();

            Recipe MythrilOre = Recipe.Create(ItemID.MythrilOre, 1);
            MythrilOre
            .AddIngredient(ItemID.OrichalcumOre, 1)
            .Register();

            Recipe OrichalcumOre = Recipe.Create(ItemID.OrichalcumOre, 1);
            OrichalcumOre
            .AddIngredient(ItemID.MythrilOre, 1)
            .Register();

            Recipe PalladiumOre = Recipe.Create(ItemID.PalladiumOre, 1);
            PalladiumOre
            .AddIngredient(ItemID.CobaltOre, 1)
            .Register();

            Recipe PlatinumOre = Recipe.Create(ItemID.PlatinumOre, 1);
            PlatinumOre
            .AddIngredient(ItemID.GoldOre, 1)
            .Register();

            Recipe SilverOre = Recipe.Create(ItemID.SilverOre, 1);
            SilverOre
            .AddIngredient(ItemID.TungstenOre, 1)
            .Register();

            Recipe TinOre = Recipe.Create(ItemID.TinOre, 1);
            TinOre
            .AddIngredient(ItemID.CopperOre, 1)
            .Register();

            Recipe TitaniumOre = Recipe.Create(ItemID.TitaniumOre, 1);
            TitaniumOre
            .AddIngredient(ItemID.AdamantiteOre, 1)
            .Register();

            Recipe TungstenOre = Recipe.Create(ItemID.TungstenOre, 1);
            TungstenOre
            .AddIngredient(ItemID.SilverOre, 1)
            .Register();

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            Recipe AdamantiteBar = Recipe.Create(ItemID.AdamantiteBar, 1);
            AdamantiteBar
            .AddIngredient(ItemID.TitaniumBar, 1)
            .Register();

            Recipe CobaltBar = Recipe.Create(ItemID.CobaltBar, 1);
            CobaltBar
            .AddIngredient(ItemID.PalladiumBar, 1)
            .Register();

            Recipe CopperBar = Recipe.Create(ItemID.CopperBar, 1);
            CopperBar
            .AddIngredient(ItemID.TinBar, 1)
            .Register();

            Recipe CrimtaneBar = Recipe.Create(ItemID.CrimtaneBar, 1);
            CrimtaneBar
            .AddIngredient(ItemID.DemoniteBar, 1)
            .Register();

            Recipe DemoniteBar = Recipe.Create(ItemID.DemoniteBar, 1);
            DemoniteBar
            .AddIngredient(ItemID.CrimtaneBar, 1)
            .Register();

            Recipe GoldBar = Recipe.Create(ItemID.GoldBar, 1);
            GoldBar
            .AddIngredient(ItemID.PlatinumBar, 1)
            .Register();

            Recipe IronBar = Recipe.Create(ItemID.IronBar, 1);
            IronBar
            .AddIngredient(ItemID.LeadBar, 1)
            .Register();

            Recipe LeadBar = Recipe.Create(ItemID.LeadBar, 1);
            LeadBar
            .AddIngredient(ItemID.IronBar, 1)
            .Register();

            Recipe MythrilBar = Recipe.Create(ItemID.MythrilBar, 1);
            MythrilBar
            .AddIngredient(ItemID.OrichalcumBar, 1)
            .Register();

            Recipe OrichalcumBar = Recipe.Create(ItemID.OrichalcumBar, 1);
            OrichalcumBar
            .AddIngredient(ItemID.MythrilBar, 1)
            .Register();

            Recipe PalladiumBar = Recipe.Create(ItemID.PalladiumBar, 1);
            PalladiumBar
            .AddIngredient(ItemID.CobaltBar, 1)
            .Register();

            Recipe PlatinumBar = Recipe.Create(ItemID.PlatinumBar, 1);
            PlatinumBar
            .AddIngredient(ItemID.GoldBar, 1)
            .Register();

            Recipe SilverBar = Recipe.Create(ItemID.SilverBar, 1);
            SilverBar
            .AddIngredient(ItemID.TungstenBar, 1)
            .Register();

            Recipe TinBar = Recipe.Create(ItemID.TinBar, 1);
            TinBar
            .AddIngredient(ItemID.CopperBar, 1)
            .Register();

            Recipe TitaniumBar = Recipe.Create(ItemID.TitaniumBar, 1);
            TitaniumBar
            .AddIngredient(ItemID.AdamantiteBar, 1)
            .Register();

            Recipe TungstenBar = Recipe.Create(ItemID.TungstenBar, 1);
            TungstenBar
            .AddIngredient(ItemID.SilverBar, 1)
            .Register();

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            Recipe HermesBoots = Recipe.Create(ItemID.HermesBoots, 1); HermesBoots
            .AddIngredient(ItemID.Silk, 8)
            .AddIngredient(ItemID.SwiftnessPotion, 3)
            .AddTile(TileID.Loom)
            .Register();

            Recipe Aglet = Recipe.Create(ItemID.Aglet, 1);
            Aglet
            .AddRecipeGroup("GoldOrPlatinumBars", 7)
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
            .AddRecipeGroup("RottenChunkOrVertebrae", 25)
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
            .AddRecipeGroup("CobaltOrPalladiumBars",25)
            .AddTile(TileID.MythrilAnvil)
            .Register();

            Recipe DPSMeter = Recipe.Create(ItemID.DPSMeter, 1);
            DPSMeter
            .AddRecipeGroup("IronOrLeadBars",10)
            .AddIngredient(ItemID.TallyCounter, 1)
            .AddIngredient(ItemID.Wire, 5)
            .AddTile(TileID.Anvils)
            .Register();

            Recipe FastClock = Recipe.Create(ItemID.FastClock, 1);
            FastClock
            .AddIngredient(ItemID.Timer1Second, 1)
            .AddRecipeGroup("IronOrLeadBars", 15)
            .AddRecipeGroup("GoldWatchOrPlatinumWatch", 1)
            .AddTile(TileID.Anvils)
            .Register();

            Recipe FeralClaws = Recipe.Create(ItemID.FeralClaws, 1);
            FeralClaws
            .AddIngredient(ItemID.JungleSpores, 13)
            .AddRecipeGroup("IronOrLeadBars", 1)
            .AddIngredient(ItemID.Vine, 15)
            .AddIngredient(ItemID.JungleGrassSeeds, 1)
            .AddTile(TileID.Anvils)
            .Register();

            Recipe IceSkates = Recipe.Create(ItemID.IceSkates, 1);
            IceSkates
            .AddIngredient(ItemID.WaterWalkingBoots, 1)
            .AddIngredient(ItemID.IceBlock, 15)
            .AddRecipeGroup("SilverOrTungstenBars", 6)
            .AddTile(TileID.Anvils)
            .Register();

            Recipe LifeFruit = Recipe.Create(ItemID.LifeFruit, 1);
            LifeFruit
            .AddIngredient(ItemID.LifeCrystal, 1)
            .AddIngredient(ItemID.SoulofSight, 1)
            .AddIngredient(ItemID.SoulofFright, 1)
            .AddIngredient(ItemID.SoulofMight, 1)
            .AddTile(TileID.DemonAltar)
            .Register();

            Recipe Radar = Recipe.Create(ItemID.Radar, 1);
            Radar
            .AddRecipeGroup("IronOrLeadBars", 10)
            .AddIngredient(ItemID.Wire, 5)
            .AddTile(TileID.Anvils)
            .Register();

            Recipe TallyCounter = Recipe.Create(ItemID.TallyCounter, 1);
            TallyCounter
            .AddRecipeGroup("IronOrLeadBars", 10)
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
            .AddRecipeGroup("SilverOrTungstenBars", 5)
            .AddTile(TileID.Anvils)
            .Register();

            Recipe Mace = Recipe.Create(ItemID.Mace, 1);
            Mace
            .AddRecipeGroup(RecipeGroupID.Wood, 35)
            .AddIngredient(ItemID.StoneBlock, 20)
            .AddRecipeGroup("IronOrLeadBars", 10)
            .AddTile(TileID.Anvils)
            .Register();

            Recipe Spear = Recipe.Create(ItemID.Spear, 1);
            Spear
            .AddRecipeGroup("CopperOrTinBars", 8)
            .AddTile(TileID.Anvils)
            .Register();

            Recipe BandOfRegeneration = Recipe.Create(ItemID.BandofRegeneration, 1);
            BandOfRegeneration
            .AddIngredient(ItemID.LifeCrystal, 3)
            .AddRecipeGroup("IronOrLeadBars", 5)
            .AddTile(TileID.Anvils)
            .Register();
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        }
    }
}
