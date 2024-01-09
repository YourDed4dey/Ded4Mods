using Microsoft.Xna.Framework;
using System;
using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.Personalities;
using System.Collections.Generic;
using Terraria.ModLoader.IO;
using DedsBosses.Common.Systems;
using DedsBosses.Content.Items.Consumables.BossSummons;
using DedsBosses.Content.NPCs.Bosses.VoiyedBoss;
using DedsBosses.Content.Projectiles.NPCsProjectiles.FriendlyProjectiles.SummonerProjectile;

namespace DedsBosses.Content.NPCs.Friendly.TownNPCs.Summoner
{
    [AutoloadHead]
    internal class Summoner : ModNPC
    {
        public const string ShopName = "Shop";
        public int NumberOfTimesTalkedTo = 0;

        private static int ShimmerHeadIndex;
        private static Profiles.StackedNPCProfile NPCProfile;

        public override void Load()
        {
            // Adds our Shimmer Head to the NPCHeadLoader.
            ShimmerHeadIndex = Mod.AddNPCHeadTexture(Type, Texture + "_Shimmer_Head");
        }
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 25;

            NPCID.Sets.ExtraFramesCount[Type] = 9; // Generally for Town NPCs, but this is how the NPC does extra things such as sitting in a chair and talking to other NPCs. This is the remaining frames after the walking frames.
            NPCID.Sets.AttackFrameCount[Type] = 4; // The amount of frames in the attacking animation.
            NPCID.Sets.DangerDetectRange[Type] = 700; // The amount of pixels away from the center of the NPC that it tries to attack enemies.
            NPCID.Sets.AttackType[Type] = 2; // The type of attack the Town NPC performs. 0 = throwing, 1 = shooting, 2 = magic, 3 = melee
            NPCID.Sets.AttackTime[Type] = 90; // The amount of time it takes for the NPC's attack animation to be over once it starts.
            NPCID.Sets.AttackAverageChance[Type] = 30; // The denominator for the chance for a Town NPC to attack. Lower numbers make the Town NPC appear more aggressive.
            NPCID.Sets.HatOffsetY[Type] = 4; // For when a party is active, the party hat spawns at a Y offset.
            NPCID.Sets.ShimmerTownTransform[NPC.type] = true; // This set says that the Town NPC has a Shimmered form. Otherwise, the Town NPC will become transparent when touching Shimmer like other enemies.

            NPCID.Sets.ShimmerTownTransform[Type] = true; // Allows for this NPC to have a different texture after touching the Shimmer liquid.

            // Influences how the NPC looks in the Bestiary
            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Velocity = 1f, // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
                Direction = 1 // -1 is left and 1 is right. NPCs are drawn facing the left by default but ExamplePerson will be drawn facing the right
                              // Rotation = MathHelper.ToRadians(180) // You can also change the rotation of an NPC. Rotation is measured in radians
                              // If you want to see an example of manually modifying these when the NPC is drawn, see PreDraw
            };

            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

            // Set Example Person's biome and neighbor preferences with the NPCHappiness hook. You can add happiness text and remarks with localization (See an example in ExampleMod/Localization/en-US.lang).
            // NOTE: The following code uses chaining - a style that works due to the fact that the SetXAffection methods return the same NPCHappiness instance they're called on.
            NPC.Happiness
                .SetBiomeAffection<SnowBiome>(AffectionLevel.Like) // 
                .SetBiomeAffection<DesertBiome>(AffectionLevel.Dislike) // 
                .SetBiomeAffection<HallowBiome>(AffectionLevel.Love) // 
                .SetNPCAffection(NPCID.Wizard, AffectionLevel.Love) // Loves living near the Wizard.
                .SetNPCAffection(NPCID.Guide, AffectionLevel.Like) // Likes living near the guide.
                .SetNPCAffection(NPCID.Merchant, AffectionLevel.Dislike) // Dislikes living near the merchant.
                .SetNPCAffection(NPCID.Clothier, AffectionLevel.Hate) // Hates living near the Clothier.
            ; // < Mind the semicolon!

            // This creates a "profile" for ExamplePerson, which allows for different textures during a party and/or while the NPC is shimmered.
            NPCProfile = new Profiles.StackedNPCProfile(
                new Profiles.DefaultNPCProfile(Texture, NPCHeadLoader.GetHeadSlot(HeadTexture), Texture + "_Party"),
                new Profiles.DefaultNPCProfile(Texture + "_Shimmer", ShimmerHeadIndex, Texture + "_Shimmer_Party")
            );
        }
        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 18;
            NPC.height = 40;
            NPC.aiStyle = 7; // Standard town NPC AI
            NPC.damage = 10;
            NPC.defense = 25;
            NPC.lifeMax = 250;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;

            AnimationType = NPCID.Guide;
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the preferred biomes of this town NPC listed in the bestiary.
				// With Town NPCs, you usually set this to what biome it likes the most in regards to NPC happiness.
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheHallow,

				// Sets your NPC's flavor text in the bestiary.
				new FlavorTextBestiaryInfoElement("I come from a very interesting place..."),
            });
        }
        public override void HitEffect(NPC.HitInfo hit)
        {
            int num = NPC.life > 0 ? 1 : 5;

            for (int k = 0; k < num; k++)
            {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Blood);
            }

            // Create gore when the NPC is killed.
            /*if (Main.netMode != NetmodeID.Server && NPC.life <= 0)
            {
                // Retrieve the gore types. This NPC has shimmer and party variants for head, arm, and leg gore. (12 total gores)
                string variant = "";
                if (NPC.IsShimmerVariant) variant += "_Shimmer";
                if (NPC.altTexture == 1) variant += "_Party";
                int hatGore = NPC.GetPartyHatGore();
                int headGore = Mod.Find<ModGore>($"{Name}_Gore{variant}_Head").Type;
                int armGore = Mod.Find<ModGore>($"{Name}_Gore{variant}_Arm").Type;
                int legGore = Mod.Find<ModGore>($"{Name}_Gore{variant}_Leg").Type;

                // Spawn the gores. The positions of the arms and legs are lowered for a more natural look.
                if (hatGore > 0)
                {
                    Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, hatGore);
                }
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, headGore, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position + new Vector2(0, 20), NPC.velocity, armGore);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position + new Vector2(0, 20), NPC.velocity, armGore);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position + new Vector2(0, 34), NPC.velocity, legGore);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position + new Vector2(0, 34), NPC.velocity, legGore);
            }*/
        }
        public override bool CanTownNPCSpawn(int numTownNPCs)
        { // Requirements for the town NPC to spawn.
            for (int k = 0; k < Main.maxPlayers; k++)
            {
                Player player = Main.player[k];
                if (!player.active)
                {
                    continue;
                }

                if (player.statLifeMax >= 200)
                {
                    return true;
                }
            }

            return false;
        }
        public override ITownNPCProfile TownNPCProfile()
        {
            return NPCProfile;
        }
        public override List<string> SetNPCNameList()
        {
            return new List<string>() {
                "Magnus",
                "Lucian",
                "Oberon",
                "Xavian",
                "Alaric",
                "Theron"
            };
        }
        public override string GetChat()
        {
            WeightedRandom<string> chat = new WeightedRandom<string>();

            int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
            if (partyGirl >= 0 && Main.rand.NextBool(4))
            {
                chat.Add(Language.GetTextValue("Mods.DedsBosses.Dialogue.Summoner.PartyGirlDialogue", Main.npc[partyGirl].GivenName));
            }
            // These are things that the NPC has a chance of telling you when you talk to it.
            chat.Add(Language.GetTextValue("Mods.DedsBosses.Dialogue.Summoner.StandardDialogue1"));
            chat.Add(Language.GetTextValue("Mods.DedsBosses.Dialogue.Summoner.StandardDialogue2"));
            chat.Add(Language.GetTextValue("Mods.DedsBosses.Dialogue.Summoner.StandardDialogue3"));
            chat.Add(Language.GetTextValue("Mods.DedsBosses.Dialogue.Summoner.CommonDialogue"), 5.0);
            chat.Add(Language.GetTextValue("Mods.DedsBosses.Dialogue.Summoner.RareDialogue"), 0.1);

            NumberOfTimesTalkedTo++;
            if (NumberOfTimesTalkedTo >= 10)
            {
                //This counter is linked to a single instance of the NPC, so if ExamplePerson is killed, the counter will reset.
                chat.Add(Language.GetTextValue("Mods.DedsBosses.Dialogue.Summoner.TalkALot"));
            }

            return chat; // chat is implicitly cast to a string.
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Language.GetTextValue("LegacyInterface.28");
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shop)
        {
            if (firstButton)
            {
                shop = ShopName; // Name of the shop tab we want to open.
            }
        }
        public override void AddShops()
        {
            // Player needs +200 hp for npc to spawn.
            // When npc spawns and no bosses are defeated he will sell "SlimeCrown"
            // 
            //
            //
            //
            //
            //
            //
            //
            bool findMod = ModLoader.TryGetMod("DedsQOLMod", out Mod dedsQOLMod);
            //dedsQOLMod.TryFind("SkeletronSummon", out ModItem skeletronSummon);
            //dedsQOLMod.TryFind("PlanteraSummon", out ModItem planteraSummon);
            //dedsQOLMod.TryFind("EOLSummon", out ModItem eOLSummon);
            //dedsQOLMod.TryFind("CultistSummon", out ModItem cultistSummon);
            var npcShop = new NPCShop(Type, ShopName);
            if (findMod && dedsQOLMod.TryFind("Gemminode", out ModItem gemminodeSummon))
            {
                npcShop.Add(new Item(gemminodeSummon.Type) { shopCustomPrice = Item.buyPrice(gold: 3) }, Condition.NotDownedKingSlime);
            }
            npcShop.Add(new Item(ItemID.SlimeCrown) { shopCustomPrice = Item.buyPrice(gold: 3) }, Condition.NotDownedKingSlime)
            .Add(new Item(ItemID.SuspiciousLookingEye) { shopCustomPrice = Item.buyPrice(gold: 9) }, Condition.DownedKingSlime, Condition.NotDownedEyeOfCthulhu)
            .Add(new Item(ItemID.WormFood) { shopCustomPrice = Item.buyPrice(gold: 15) }, Condition.DownedEyeOfCthulhu, Condition.NotDownedEaterOfWorlds)
            .Add(new Item(ItemID.BloodySpine) { shopCustomPrice = Item.buyPrice(gold: 15) }, Condition.DownedEyeOfCthulhu, Condition.NotDownedBrainOfCthulhu)
            .Add(new Item(ItemID.Abeemination) { shopCustomPrice = Item.buyPrice(gold: 15) }, Condition.DownedEowOrBoc, Condition.NotDownedQueenBee);
            //.Add(new Item(ModContent.ItemType<SkeletronSummon>()) { shopCustomPrice = Item.buyPrice(gold: 15) }, Condition.DownedQueenBee, Condition.NotDownedSkeletron)
            if (findMod && dedsQOLMod.TryFind("SkeletronSummon", out ModItem skeletronSummon)) 
            {
                npcShop.Add(new Item(skeletronSummon.Type) { shopCustomPrice = Item.buyPrice(gold: 15) }, Condition.DownedQueenBee, Condition.NotDownedSkeletron);
            }
            npcShop.Add(new Item(ItemID.DeerThing) { shopCustomPrice = Item.buyPrice(gold: 15) }, Condition.DownedSkeletron, Condition.NotDownedDeerclops)
            .Add(new Item(ItemID.GuideVoodooDoll) { shopCustomPrice = Item.buyPrice(gold: 24) }, Condition.DownedDeerclops, Condition.PreHardmode)
            .Add(new Item(ItemID.QueenSlimeCrystal) { shopCustomPrice = Item.buyPrice(gold: 18) }, Condition.Hardmode, Condition.NotDownedQueenSlime)
            .Add(new Item(ItemID.MechanicalEye) { shopCustomPrice = Item.buyPrice(gold: 36) }, Condition.DownedQueenSlime, Condition.NotDownedTwins)
            .Add(new Item(ItemID.MechanicalWorm) { shopCustomPrice = Item.buyPrice(gold: 36) }, Condition.DownedQueenSlime, Condition.NotDownedDestroyer)
            .Add(new Item(ItemID.MechanicalSkull) { shopCustomPrice = Item.buyPrice(gold: 36) }, Condition.DownedQueenSlime, Condition.NotDownedSkeletronPrime);
            //.Add(new Item(ModContent.ItemType<PlanteraSummon>()) { shopCustomPrice = Item.buyPrice(gold: 45) }, Condition.DownedMechBossAll, Condition.NotDownedPlantera)
            if (findMod && dedsQOLMod.TryFind("PlanteraSummon", out ModItem planteraSummon))
            {
                npcShop.Add(new Item(planteraSummon.Type) { shopCustomPrice = Item.buyPrice(gold: 45) }, Condition.DownedMechBossAll, Condition.NotDownedPlantera);
            }
            npcShop.Add(new Item(ItemID.LihzahrdPowerCell) { shopCustomPrice = Item.buyPrice(gold: 45) }, Condition.DownedPlantera, Condition.NotDownedGolem)
            .Add(new Item(ItemID.TruffleWorm) { shopCustomPrice = Item.buyPrice(gold: 75) }, Condition.DownedGolem, Condition.NotDownedDukeFishron);
            //.Add(new Item(ModContent.ItemType<EOLSummon>()) { shopCustomPrice = Item.buyPrice(gold: 75) }, Condition.DownedGolem, Condition.NotDownedEmpressOfLight)
            if (findMod && dedsQOLMod.TryFind("EOLSummon", out ModItem eOLSummon))
            {
                npcShop.Add(new Item(eOLSummon.Type) { shopCustomPrice = Item.buyPrice(gold: 75) }, Condition.DownedGolem, Condition.NotDownedEmpressOfLight);
            }
            //.Add(new Item(ModContent.ItemType<CultistSummon>()) { shopCustomPrice = Item.buyPrice(gold: 30) }, Condition.DownedGolem, Condition.NotDownedCultist)
            if (findMod && dedsQOLMod.TryFind("CultistSummon", out ModItem cultistSummon))
            {
                npcShop.Add(new Item(cultistSummon.Type) { shopCustomPrice = Item.buyPrice(gold: 30) }, Condition.DownedGolem, Condition.NotDownedCultist);
            }

            //.Add(<PlanteraSummon>, condition: Condition.DownedMechBossAll) 
            //.Add<Items.Consumables.VoiyedSummon>(Condition.DownedPlantera)
            //.Add<GolemSummon>(DownedBossSystem.downedVoiyedBoss);
            //.Add<CultistSummon>(Condition.DownedGolem);
            //.Add(ItemID.CelestialSigil,  Condition.DownedMoonLord)
            /*bool downedEOC = NPC.downedBoss1;
            bool downedEowOrBoc = NPC.downedBoss2;
            bool downedSkeletron = NPC.downedBoss3;
            bool downedWOF = Main.hardMode;
            bool downedDestroyer = NPC.downedMechBoss1;
            bool downedTwins = NPC.downedMechBoss2;
            bool downedPrime = NPC.downedMechBoss3;
            bool downedAllMechs = NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3;

            if (NPC.downedSlimeKing) 
            {
                npcShop.Add(ItemID.SuspiciousLookingEye);
            }
            if (downedEOC || downedEowOrBoc) 
            {
                npcShop.Add(ItemID.WormFood);
                npcShop.Add(ItemID.BloodySpine);
            }
            if (downedEowOrBoc || NPC.downedQueenBee) 
            {
                npcShop.Add(ItemID.Abeemination);
            }
            if (NPC.downedQueenBee || downedSkeletron) 
            {
                //npcShop.Add<SkeletronSummon>();
            }
            if (downedSkeletron || NPC.downedDeerclops) 
            {
                npcShop.Add(ItemID.DeerThing);
            }
            if (NPC.downedDeerclops || downedWOF) 
            {
                npcShop.Add(ItemID.GuideVoodooDoll);
            }
            if (downedWOF || NPC.downedQueenSlime) 
            {
                npcShop.Add(ItemID.QueenSlimeCrystal);
            }
            if (NPC.downedQueenSlime || downedTwins) 
            {
                npcShop.Add(ItemID.MechanicalEye);
            }
            if (downedTwins || downedDestroyer) 
            {
                npcShop.Add(ItemID.MechanicalWorm);
            }
            if (downedDestroyer || downedPrime) 
            {
                npcShop.Add(ItemID.MechanicalSkull);
            }
            if (downedAllMechs || NPC.downedPlantBoss) 
            {
                //npcShop.Add<PlanteraSummon>();
            }
            if (NPC.downedPlantBoss || DownedBossSystem.downedVoiyedBoss) 
            {
                npcShop.Add<VoiyedSummon>();
            }
            if (DownedBossSystem.downedVoiyedBoss || NPC.downedGolemBoss) 
            {
                npcShop.Add(ItemID.LihzahrdPowerCell);
            }
            if (NPC.downedMoonlord) 
            {
                npcShop.Add(ItemID.CelestialSigil);
            }*/
            //.Add(ItemID.SlimeCrown, condition: Condition.DownedKingSlime)
            if (findMod && dedsQOLMod.TryFind("Gemminode", out ModItem gemminodeSummon2))
            {
                npcShop.Add(new Item(gemminodeSummon2.Type) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.DownedKingSlime);
            }
            npcShop.Add(new Item(ItemID.SlimeCrown) { shopCustomPrice = Item.buyPrice(gold: 2) }, Condition.DownedKingSlime)
            .Add(new Item(ItemID.SuspiciousLookingEye) { shopCustomPrice = Item.buyPrice(gold: 6) }, Condition.DownedEyeOfCthulhu)
            .Add(new Item(ItemID.WormFood) { shopCustomPrice = Item.buyPrice(gold: 10) }, Condition.DownedEowOrBoc)
            .Add(new Item(ItemID.BloodySpine) { shopCustomPrice = Item.buyPrice(gold: 10) }, Condition.DownedEowOrBoc)
            .Add(new Item(ItemID.Abeemination) { shopCustomPrice = Item.buyPrice(gold: 10) }, Condition.DownedQueenBee);
            //.Add(new Item(ModContent.ItemType<SkeletronSummon>()) { shopCustomPrice = Item.buyPrice(gold: 10) },Condition.DownedSkeletron)
            if (findMod && dedsQOLMod.TryFind("SkeletronSummon", out ModItem skeletronSummon2))
            {
                npcShop.Add(new Item(skeletronSummon2.Type) { shopCustomPrice = Item.buyPrice(gold: 10) }, Condition.DownedSkeletron);
            }
            npcShop.Add(new Item(ItemID.DeerThing) { shopCustomPrice = Item.buyPrice(gold: 10) }, Condition.DownedDeerclops)
            .Add(new Item(ItemID.GuideVoodooDoll) { shopCustomPrice = Item.buyPrice(gold: 16) }, Condition.Hardmode)
            .Add(new Item(ItemID.QueenSlimeCrystal) { shopCustomPrice = Item.buyPrice(gold: 12) }, Condition.DownedQueenSlime)
            .Add(new Item(ItemID.MechanicalEye) { shopCustomPrice = Item.buyPrice(gold: 24) }, Condition.DownedTwins)
            .Add(new Item(ItemID.MechanicalWorm) { shopCustomPrice = Item.buyPrice(gold: 24) }, Condition.DownedDestroyer)
            .Add(new Item(ItemID.MechanicalSkull) { shopCustomPrice = Item.buyPrice(gold: 24) }, Condition.DownedSkeletronPrime);
            //.Add(new Item(ModContent.ItemType<PlanteraSummon>()) { shopCustomPrice = Item.buyPrice(gold: 30) }, Condition.DownedPlantera)
            if (findMod && dedsQOLMod.TryFind("PlanteraSummon", out ModItem planteraSummon2))
            {
                npcShop.Add(new Item(planteraSummon2.Type) { shopCustomPrice = Item.buyPrice(gold: 30) }, Condition.DownedPlantera);
            }
            npcShop.Add(new Item(ModContent.ItemType<VoiyedSummon>()) { shopCustomPrice = Item.buyPrice(gold: 30) }, Condition.DownedPlantera)
            .Add(new Item(ItemID.LihzahrdPowerCell) { shopCustomPrice = Item.buyPrice(gold: 30) }, Condition.DownedGolem)
            .Add(new Item(ItemID.TruffleWorm) { shopCustomPrice = Item.buyPrice(gold: 50) }, Condition.DownedDukeFishron);
            //.Add(new Item(ModContent.ItemType<EOLSummon>()) { shopCustomPrice = Item.buyPrice(gold: 50) }, Condition.DownedEmpressOfLight)
            if (findMod && dedsQOLMod.TryFind("EOLSummon", out ModItem eOLSummon2))
            {
                npcShop.Add(new Item(eOLSummon2.Type) { shopCustomPrice = Item.buyPrice(gold: 50) }, Condition.DownedEmpressOfLight);
            }
            //.Add(new Item(ModContent.ItemType<CultistSummon>()) { shopCustomPrice = Item.buyPrice(gold: 20) }, Condition.DownedCultist)
            if (findMod && dedsQOLMod.TryFind("CultistSummon", out ModItem cultistSummon2)) 
            {
                npcShop.Add(new Item(cultistSummon2.Type) { shopCustomPrice = Item.buyPrice(gold: 20) }, Condition.DownedCultist);
            }
            npcShop.Add(new Item(ItemID.CelestialSigil) { shopCustomPrice = Item.buyPrice(platinum: 2) },  Condition.DownedMoonLord);
            //.Add<ExampleItem>()
            //.Add<EquipMaterial>()
            //.Add<BossItem>()
            //.Add(new Item(ModContent.ItemType<Items.Placeable.Furniture.ExampleWorkbench>()) { shopCustomPrice = Item.buyPrice(copper: 15) }) // This example sets a custom price, ExampleNPCShop.cs has more info on custom prices and currency. 
            //.Add<Items.Tools.ExampleHamaxe>()
            /*.Add<Items.Weapons.ExampleSword>(Condition.MoonPhasesQuarter0)
            //.Add<ExampleGun>(Condition.MoonPhasesQuarter1)    
            .Add<Items.Ammo.ExampleBullet>(Condition.MoonPhasesQuarter1)
            //.Add<ExampleStaff>(Condition.MoonPhasesQuarter2)
            .Add<ExampleOnBuyItem>()
            .Add<Items.Weapons.ExampleYoyo>(Condition.IsNpcShimmered); // Let's sell an yoyo if this NPC is shimmered!
        */
            npcShop.Register(); // Name of this shop tab
        }
        public override void ModifyActiveShop(string shopName, Item[] items)
        {
            foreach (Item item in items)
            {
                // Skip 'air' items and null items.
                if (item == null || item.type == ItemID.None)
                {
                    continue;
                }

                // If NPC is shimmered then reduce all prices by 50%.
                if (NPC.IsShimmerVariant)
                {
                    int value = item.shopCustomPrice ?? item.value;
                    item.shopCustomPrice = value / 2;
                }
            }
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            //npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<>()));
        }
        // Make this Town NPC teleport to the King and/or Queen statue when triggered. Return toKingStatue for only King Statues. Return !toKingStatue for only Queen Statues. Return true for both.
        public override bool CanGoToStatue(bool toKingStatue) => true;
        // Make something happen when the npc teleports to a statue. Since this method only runs server side, any visual effects like dusts or gores have to be synced across all clients manually.
        public override void OnGoToStatue(bool toKingStatue)
        {
            if (Main.netMode == NetmodeID.Server)
            {
                ModPacket packet = Mod.GetPacket();
                packet.Write((byte)DedsBosses.MessageType.TeleportToStatue);
                packet.Write((byte)NPC.whoAmI);
                packet.Send();
            }
            else
            {
                StatueTeleport();
            }
        }
        // Create a square of pixels around the NPC on teleport.
        public void StatueTeleport()
        {
            for (int i = 0; i < 30; i++)
            {
                Vector2 position = Main.rand.NextVector2Square(-20, 21);
                if (Math.Abs(position.X) > Math.Abs(position.Y))
                {
                    position.X = Math.Sign(position.X) * 20;
                }
                else
                {
                    position.Y = Math.Sign(position.Y) * 20;
                }

                Dust.NewDustPerfect(NPC.Center + position, DustID.BlueTorch, Vector2.Zero).noGravity = true;
            }
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 8;
            knockback = 4f;
        }
        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 30;
            randExtraCooldown = 30;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            //projType = ModContent.NPCType<ServantOfTheVoiyed>(); //Lightning Aura Cane
            /*if (NPC.IsShimmerVariant)
            {
                projType = ModContent.ProjectileType<SummonerProjectile>();
            }
            else*/

            /*bool downedEOC = NPC.downedBoss1;
            bool downedEOWorBOC = NPC.downedBoss2;
            bool downedSkeletron = NPC.downedBoss3;
            bool downedTwins = NPC.downedMechBoss2;
            bool downedDestroyer = NPC.downedMechBoss1;
            bool downedPrime = NPC.downedMechBoss3;

            //if (!NPC.IsShimmerVariant)
            //{
            if (NPC.downedMoonlord)
            {
                projType = ProjectileID.Beenade;
            }
            else if (NPC.downedAncientCultist)
            {
                projType = ProjectileID.Beenade;
            }
            else if (NPC.downedEmpressOfLight)
            {
                projType = ProjectileID.Beenade;
            }
            else if (NPC.downedFishron)
            {
                projType = ProjectileID.Beenade;
            }
            else if (NPC.downedGolemBoss)
            {
                projType = ProjectileID.Beenade;
            }
            else if (DownedBossSystem.downedVoiyedBoss)
            {
                projType = ModContent.ProjectileType<SummonerProjectile>();
            }
            else if (NPC.downedPlantBoss)
            {
                projType = ProjectileID.Beenade;
            }
            else if (downedPrime)
            {
                projType = ProjectileID.Beenade;
            }
            else if (downedDestroyer)
            {
                projType = ProjectileID.Beenade;
            }
            else if (downedTwins)
            {
                projType = ProjectileID.Beenade;
            }
            else if (NPC.downedQueenSlime)
            {
                projType = ProjectileID.Beenade;
            }
            else if (Main.hardMode)
            {
                projType = ProjectileID.Beenade;
            }
            else if (NPC.downedDeerclops)
            {
                projType = ProjectileID.Beenade;
            }
            else if (downedSkeletron)
            {
                projType = ProjectileID.Beenade;
            }
            else if (NPC.downedQueenBee)
            {
                projType = ProjectileID.Beenade;
            }
            else if (downedEOWorBOC)
            {
                projType = ProjectileID.Beenade;
            }
            else if (downedEOC)
            {
                projType = ProjectileID.StickyGrenade;
            }
            else if (NPC.downedSlimeKing)
            {
                projType = ProjectileID.StickyGrenade;
            }
            else
            {
                projType = ProjectileID.ExplosiveBunny;
                Main.projectile[projType].friendly = true;
                Main.projectile[projType].npcProj = true;
                Main.projectile[projType].hostile = false;
                Main.projectile[projType].owner = NPC.whoAmI;
            }*/
            //}
            if (DownedBossSystem.downedVoiyedBoss)
            {
                projType = ModContent.ProjectileType<SummonerProjectile>();
            }
            else
            {
                projType = ProjectileID.ExplosiveBunny;
                Main.projectile[projType].friendly = true;
                Main.projectile[projType].npcProj = true;
                Main.projectile[projType].hostile = false;
                Main.projectile[projType].owner = NPC.whoAmI;
            }
            attackDelay = 1;
            // Set the owner of the projectile to the summoner NPC index
            /*int projIndex = Projectile.NewProjectile(null,NPC.Center, Vector2.Zero, projType, NPC.damage, 0f, Main.myPlayer, NPC.whoAmI);
            if (projIndex >= 0 && projIndex < Main.maxProjectiles)
            {
                Projectile proj = Main.projectile[projIndex];
                proj.owner = NPC.whoAmI;
            }*/
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 3f;
            randomOffset = 2f;
        }
        public override void LoadData(TagCompound tag)
        {
            NumberOfTimesTalkedTo = tag.GetInt("numberOfTimesTalkedTo");
        }

        public override void SaveData(TagCompound tag)
        {
            tag["numberOfTimesTalkedTo"] = NumberOfTimesTalkedTo;
        }
    }
}
