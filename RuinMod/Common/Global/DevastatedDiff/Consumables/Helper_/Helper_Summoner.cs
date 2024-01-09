/*using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using RuinMod.Common.Systems.DiffSystem;
using System.Collections.Generic;
using System.Linq;
using RuinMod.Content.Weapons.ShieldClassWeapons.PreHardmode.StarShield;

namespace RuinMod.Common.Global.DevastatedDiff.Consumables.Helper_
{
    public class Helper_Summoner : ModItem
    {
        //public override string Texture => "Terraria/Images/Item_" + ItemID.BabyBirdStaff;
        public override void SetStaticDefaults()
        {
            ////DisplayName.SetDefault("Helper!");
            ////Tooltip.SetDefault("Informs on good gear for summoner users\n'Is it too hard ;('");
        }
        public override void SetDefaults()
        {
            Item.height = 42;
            Item.width = 54;
            Item.maxStack = 1;
            Item.consumable = false;
            Item.rare = ItemRarityID.Cyan;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.HoldUp;

        }

        public override bool CanUseItem(Player player) => RuinWorld.devastated;

        private string GetBuildText(params int[] args)
        {
            string text = "";
            foreach (int itemType in args)
                text += $"[i:{itemType}]";
            return text;
        }

        private string GetBuildTextRandom(params int[] args)
        {
            List<int> choices = new List<int>();
            int maxSize = args.Length - 1;
            for (int i = 0; i < args[0]; i++)
            {
                int attempt = Main.rand.Next(maxSize) + 1;
                if (choices.Contains(args[attempt]))
                {
                    for (int j = 0; j < maxSize; j++)
                    {
                        if (++attempt >= maxSize)
                            attempt = 1;
                        if (!choices.Contains(args[attempt]))
                            break;
                    }
                }
                choices.Add(args[attempt]);
            }
            return GetBuildText(choices.ToArray());
        }

        private int GetBossHelp(ref string build, Player player)
        {
            int summonType = -1;
            if (!NPC.downedSlimeKing)
            {
                summonType = ItemID.SlimeCrown;
                build = GetBuildText(
                    Main.rand.Next(new int[] { ItemID.FlinxFurCoat }),
                    Main.rand.Next(new int[] { ItemID.HermesBoots, ItemID.SailfishBoots, ItemID.FlurryBoots, ItemID.SandBoots }),
                    //ItemID.CreativeWings,
                    //ItemID.ShinyRedBalloon,
                    ItemID.FeralClaws,
                    ItemID.BandofRegeneration,
                    ItemID.SharkToothNecklace,
                    ModContent.ItemType<StarShield>(),
                    Main.rand.Next(new int[] { ItemID.ThornWhip, ItemID.FlinxStaff, ItemID.BlandWhip, ItemID.BabyBirdStaff, ItemID.AbigailsFlower, ItemID.SlimeStaff, ItemID.VampireFrogStaff })
                );
            }
            else if (!NPC.downedBoss1)
            {
                summonType = ItemID.SuspiciousLookingEye;
                build = GetBuildText(
                    Main.rand.Next(new int[] { ItemID.HermesBoots, ItemID.SailfishBoots, ItemID.FlurryBoots, ItemID.SandBoots }),
                    Main.rand.Next(new int[] { ItemID.CloudinaBottle, ItemID.TsunamiInABottle, ItemID.SandstorminaBottle, ItemID.BlizzardinaBottle })
                ) + GetBuildTextRandom(
                    3,
                    ItemID.CharmofMyths,
                    ItemID.CrossNecklace,
                    ItemID.SharkToothNecklace
                );
            }
            else if (!NPC.downedBoss2)
            {
                summonType = WorldGen.crimson ? ItemID.BloodySpine : ItemID.WormFood;
                build = GetBuildText(
                    Main.rand.NextBool() ? ItemID.EoCShield :
                    ItemID.SpectreBoots,
                    Main.rand.Next(new int[] { ItemID.BalloonHorseshoeFart, ItemID.BalloonHorseshoeSharkron, ItemID.WhiteHorseshoeBalloon })
                ) + GetBuildTextRandom(
                    2,
                    ItemID.CharmofMyths
                );
            }
            else if (!NPC.downedQueenBee)
            {
                summonType = ItemID.Abeemination;
                build = GetBuildText(
                    ItemID.EoCShield,
                    ItemID.SpectreBoots,
                    ItemID.Bezoar,
                    Main.rand.Next(new int[] { ItemID.BalloonHorseshoeFart, ItemID.BalloonHorseshoeSharkron, ItemID.WhiteHorseshoeBalloon }),
                    Main.rand.Next(new int[] {
                                ItemID.WormScarf
                    })
                );
            }
            else if (!NPC.downedBoss3)
            {
                summonType = ItemID.SkeletronMask;
                build = GetBuildText(
                    ItemID.EoCShield,
                    ItemID.LightningBoots,
                    ItemID.BalloonHorseshoeFart
                ) + GetBuildTextRandom(
                    2,
                    ItemID.CharmofMyths
                    );
            }
            else if (!NPC.downedDeerclops)
            {
                summonType = ItemID.DeerThing;
                build = GetBuildText(
                    ItemID.LightningBoots,
                    ItemID.BalloonHorseshoeFart
                ) + GetBuildTextRandom(
                    2,
                    ItemID.HandWarmer,
                    ItemID.CharmofMyths,
                    ItemID.CrossNecklace
                );
            }
            else if (!Main.hardMode)
            {
                summonType = ItemID.GuideVoodooDoll;
                build = GetBuildText(
                    ItemID.EoCShield
                ) + GetBuildTextRandom(
                    2,
                    ItemID.CharmofMyths,
                    ItemID.CrossNecklace
                );
            }
            else if (!NPC.downedQueenSlime)
            {
                summonType = ItemID.QueenSlimeCrystal;
                build = GetBuildText(
                    ItemID.EoCShield,
                    ItemID.FrozenWings
                ) + GetBuildTextRandom(
                    3,
                    ItemID.AnkhShield,
                    Main.rand.Next(new int[] { ItemID.WarriorEmblem, ItemID.RangerEmblem, ItemID.SorcererEmblem, ItemID.SummonerEmblem })
                );
            }
            else if (!NPC.downedMechBoss1)
            {
                summonType = ItemID.MechanicalWorm;
                build = GetBuildText(
                    Main.rand.Next(new int[] { ItemID.LeafWings, ItemID.FrozenWings })
                ) + GetBuildTextRandom(
                    4,
                    ItemID.EoCShield,
                    ItemID.CharmofMyths,
                    Main.rand.Next(new int[] { ItemID.WarriorEmblem, ItemID.RangerEmblem, ItemID.SorcererEmblem, ItemID.SummonerEmblem })
                );
            }
            else if (!NPC.downedMechBoss2)
            {
                summonType = ItemID.MechanicalEye;
                build = GetBuildText(
                    Main.rand.Next(new int[] { ItemID.LeafWings, ItemID.FrozenWings })
                ) + GetBuildTextRandom(
                    4,
                    ItemID.EoCShield,
                    ItemID.CharmofMyths,
                    ItemID.FrogLeg,
                    Main.rand.Next(new int[] { ItemID.WarriorEmblem, ItemID.RangerEmblem, ItemID.SorcererEmblem, ItemID.SummonerEmblem })
                );
            }
            else if (!NPC.downedMechBoss3)
            {
                summonType = ItemID.MechanicalSkull;
                build = GetBuildText(
                    Main.rand.Next(new int[] { ItemID.LeafWings, ItemID.FrozenWings })
                ) + GetBuildTextRandom(
                    4,
                    ItemID.EoCShield,
                    ItemID.CharmofMyths,
                    ItemID.FrogLeg,
                    Main.rand.Next(new int[] { ItemID.WarriorEmblem, ItemID.RangerEmblem, ItemID.SorcererEmblem, ItemID.SummonerEmblem })
                );
            }
            else if (!NPC.downedPlantBoss)
            {
                summonType = ItemID.PlanteraMask;
                build = GetBuildText(
                    Main.rand.Next(new int[] { ItemID.FlameWings })
                ) + GetBuildTextRandom(
                    4,
                    ItemID.CharmofMyths,
                    ItemID.CrossNecklace,
                    ItemID.AvengerEmblem
                );
            }
            else if (!NPC.downedGolemBoss)
            {
                summonType = ItemID.LihzahrdPowerCell;
                build = GetBuildText(
                    Main.rand.Next(new int[] { ItemID.SpookyWings, ItemID.FestiveWings, ItemID.Hoverboard })
                ) + GetBuildTextRandom(
                    3,
                    Main.rand.Next(new int[] { ItemID.Tabi }),
                    ItemID.CharmofMyths,
                    ItemID.WormScarf,
                    ItemID.AvengerEmblem
                );
            }
            else if (!NPC.downedFishron)
            {
                summonType = ItemID.TruffleWorm;
                build = GetBuildText(
                    Main.rand.Next(new int[] { ItemID.SteampunkWings, ItemID.BetsyWings, ItemID.Hoverboard })
                ) + GetBuildTextRandom(
                    3,
                    Main.rand.Next(new int[] { ItemID.Tabi }),
                    ItemID.DestroyerEmblem
                );
            }
            else if (!NPC.downedEmpressOfLight)
            {
                summonType = ItemID.EmpressButterfly;
                build = GetBuildText(
                    Main.rand.Next(new int[] { ItemID.BetsyWings, ItemID.FishronWings })
                ) + GetBuildTextRandom(
                    4,
                    ItemID.CharmofMyths
                );
            }
            else if (!NPC.downedAncientCultist)
            {
                summonType = ItemID.BossMaskCultist;
                build = GetBuildText(
                    Main.rand.NextBool() ? ItemID.BetsyWings : ItemID.FishronWings
                ) + GetBuildTextRandom(
                    4,
                    Main.rand.Next(new int[] { ItemID.Tabi }),
                    ItemID.CharmofMyths,
                    ItemID.DestroyerEmblem
                );
            }
            else if (!NPC.downedMoonlord)
            {
                summonType = ItemID.CelestialSigil;
                build = GetBuildText(
                ) + " " + GetBuildText(
                    Main.rand.Next(new int[] { ItemID.BetsyWings, ItemID.FishronWings, ItemID.RainbowWings })
                ) + GetBuildTextRandom(
                    4,
                    Main.rand.Next(new int[] { ItemID.Tabi }),
                    ItemID.AnkhShield
                );
            }

            build += $" [i:{summonType}]";

            return summonType;
        }

        public override bool? UseItem(Player player)
        {
            if (player.ItemTimeIsZero)
            {
                string dialogue = "";
                GetBossHelp(ref dialogue, player);
                if (player.whoAmI == Main.myPlayer)
                    Main.NewText(dialogue);

                SoundEngine.PlaySound(SoundID.Frog, player.Center);
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