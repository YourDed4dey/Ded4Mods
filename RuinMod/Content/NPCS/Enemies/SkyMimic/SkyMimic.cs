using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader.Utilities;
using Terraria.GameContent.ItemDropRules;
using System;
using System.IO;
using Terraria.GameContent.Bestiary;
using Terraria.ModLoader.IO;
using System.Collections.Generic;

namespace RuinMod.Content.NPCS.Enemies.SkyMimic
{
    public class SkyMimic : ModNPC
    {
        public ref float ShootStar => ref NPC.localAI[3];
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Sky Mimic");
            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.BigMimicHallow];
        }

        public override void SetDefaults()
        {
            NPC.CloneDefaults(NPCID.BigMimicHallow);
            NPC.damage = 90;
            NPC.lifeMax = 3500;
            AnimationType = NPCID.BigMimicHallow;
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (NPC.downedPlantBoss)
            {
                return SpawnCondition.Sky.Chance * 0.1f;
            }

            return 0f;
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new List<IBestiaryInfoElement> {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Sky,
                new FlavorTextBestiaryInfoElement("Mimics hit with the blessing power of the stars.\nThey can't be birthed from ordinary chests by force")
            });
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            // using Terraria.GameContent.ItemDropRules; needed for modded items to be able to be part of loot
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Content.Weapons.RangeWeapons.Hardmode.SammyTheBow.SammyTheBow>(), 4, 1, 1)); //25%
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Content.Weapons.MagicWeapons.Hardmode.StarsScreams.StarsScreams>(), 4, 1, 1)); //25%
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Content.Weapons.MeleeWeapons.Hardmode.StarIndignation.StarIndignation>(), 4, 1, 1)); //25%
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Content.Tools.Hooks.Hardmode.StarHook.StarHook>(), 4, 1, 1)); //25%
            //npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Content.Weapons.ChainClassWeapons.Pre_Hardmode.AngelsPain.AngelsPain>(), 4, 1, 1));

            npcLoot.Add(ItemDropRule.Common(ItemID.GreaterHealingPotion, 1, 5, 10));
            npcLoot.Add(ItemDropRule.Common(ItemID.GreaterManaPotion, 1, 5, 15));
            //npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Content.Items.Drops.EssencesOrSoulsOrFragments.Essences.DarkEssence.DarkEssence>(), 1, 1, 10));
        }
        public override void AI()
        {
            NPC.rotation += 0.1f * (float)NPC.direction;
            NPC.spriteDirection = NPC.direction;

                if (NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead || !Main.player[NPC.target].active)
                {
                    NPC.TargetClosest();
                }

                Player player = Main.player[NPC.target];

                if (player.dead)
                {
                    NPC.velocity.Y -= 0.04f;
                    NPC.EncourageDespawn(10);
                    return;
                }

                ShootSomeStars(player);
        }
        private void ShootSomeStars(Player player)
        {
            NPC.rotation += 0.1f * (float)NPC.direction;
            NPC.spriteDirection = NPC.direction;

            Vector2 toPlayer = player.Center - NPC.Center;

            float offsetX = 200f;

            Vector2 abovePlayer = player.Top + new Vector2(NPC.direction * offsetX, -NPC.height);

            Vector2 toAbovePlayer = abovePlayer - NPC.Center;
            Vector2 toAbovePlayerNormalized = toAbovePlayer.SafeNormalize(Vector2.UnitY);

            float changeDirOffset = offsetX * 0.7f;

            if (NPC.direction == -1 && NPC.Center.X - changeDirOffset < abovePlayer.X ||
                NPC.direction == 1 && NPC.Center.X + changeDirOffset > abovePlayer.X)
            {
                NPC.direction *= -1;
            }

            float speed = 8f;
            float inertia = 40f;

            if (NPC.Top.Y > player.Bottom.Y)
            {
                speed = 12f;
            }

            Vector2 moveTo = toAbovePlayerNormalized * speed;
            NPC.velocity = (NPC.velocity * (inertia - 1) + moveTo) / inertia;

            ShootStars(player);

            NPC.damage = NPC.defDamage;

            NPC.alpha = 0;

            NPC.rotation = toPlayer.ToRotation() - MathHelper.PiOver2;
        }
        private void ShootStars(Player player)
        {
            float timerMax = Utils.Clamp((float)NPC.life / NPC.lifeMax, 0.50f, 1f) * 100; //, 0.13f, 1f) * 30;

            ShootStar++;
            if (ShootStar > timerMax)
            {
                ShootStar = 0;
            }

            if (NPC.HasValidTarget && ShootStar == 0 && Main.netMode != NetmodeID.MultiplayerClient)
            {
                //Vector2 position = player.Top+ new Vector2(Main.rand.Next(-100, 100), Main.rand.Next(50, 100));
                Vector2 position = NPC.Center;
                Vector2 targetPosition = Main.player[NPC.target].Center;
                Vector2 direction = targetPosition - position;
                direction.Normalize();
                float speed = 10f;

                //int type = ProjectileID.SuperStar
                int damage = 10;

                int type = Projectile.NewProjectile(null, position, direction * speed, ProjectileID.SuperStar, damage, 0, Main.myPlayer);
                Main.projectile[type].hostile = true;
                Main.projectile[type].friendly = false;
                Main.projectile[type].tileCollide = false;
            }
        }
    }
}
