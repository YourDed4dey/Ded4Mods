/*using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace RuinMod.Common.Global.DevastatedDiff.NPCS.BossAI.EOC.Extra
{
    public class EOCServantAttacker : ModNPC
    {
        public override string Texture => "Terraria/Images/NPC_" + NPCID.ServantofCthulhu;
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Servant");
            Main.npcFrameCount[Type] = 2;

            // By default enemies gain health and attack if hardmode is reached. this NPC should not be affected by that
            NPCID.Sets.DontDoHardmodeScaling[Type] = true;
            // Enemies can pick up coins, let's prevent it for this NPC
            NPCID.Sets.CantTakeLunchMoney[Type] = true;

            NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Confused] = true;
            NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Poisoned] = true;

            NPCID.Sets.NPCBestiaryDrawModifiers bestiaryData = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Hide = true
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, bestiaryData);
        }

        public override void SetDefaults()
        {
            NPC.width = 30;
            NPC.height = 32;
            NPC.damage = 12;
            NPC.defense = 0;
            NPC.lifeMax = 60;
            NPC.HitSound = SoundID.NPCHit9;
            NPC.DeathSound = SoundID.NPCDeath11;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.knockBackResist = 0.8f;
            NPC.alpha = 255; // This makes it transparent upon spawning, we have to manually fade it in in AI()
            NPC.netAlways = true;

            NPC.aiStyle = -1;
        }


        public override bool CanHitPlayer(Player target, ref int cooldownSlot)
        {
            cooldownSlot = ImmunityCooldownID.Bosses; // use the boss immunity cooldown counter, to prevent ignoring boss attacks by taking damage from other sources
            return true;
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0)
            {
                // If this NPC dies, spawn some visuals

                int dustType = DustID.Blood; // Some blue dust, read the dust guide on the wiki for how to find the perfect dust

                for (int i = 0; i < 20; i++)
                {
                    Vector2 velocity = NPC.velocity + new Vector2(Main.rand.NextFloat(-2f, 2f), Main.rand.NextFloat(-2f, 2f));
                    Dust dust = Dust.NewDustPerfect(NPC.Center, dustType, velocity, 26, Color.White, Main.rand.NextFloat(1.5f, 2.4f));

                    dust.noLight = true;
                    dust.noGravity = true;
                    dust.fadeIn = Main.rand.NextFloat(0.3f, 0.8f);
                }
            }
        }

        public override void AI()
        {
            NPC.TargetClosest();
            Player player = Main.player[NPC.target];


            FadeIn();
            NPC.ai[3]++;
            if (NPC.ai[3] < 120)
            {
                NPC.rotation = NPC.velocity.ToRotation() - MathHelper.PiOver2;
            }
            else
            {
                NPC.rotation = NPC.AngleTo(player.Center) - MathHelper.PiOver2;
                NPC.velocity = NPC.DirectionTo(player.Center) * 4f;
            }
            if (NPC.ai[3] == 420)
            {
                NPC.active = false;
                NPC.netUpdate = true;
                for (int index = 0; index < 3; ++index)
                {
                    Dust dust = Dust.NewDustDirect(new Vector2(NPC.position.X, NPC.position.Y + 4f), NPC.width, NPC.height, DustID.Blood, Alpha: 100, Scale: 1.4f);
                    dust.velocity *= 0.1f;
                    dust.scale *= (float)(1.0 + Main.rand.Next(20) * 0.0099999997764825821);
                    dust.noGravity = true;
                    if (Main.rand.NextBool(2))
                        dust.fadeIn = 0.5f;
                }
            }
        }



        private void FadeIn()
        {
            // Fade in (we have NPC.alpha = 255 in SetDefaults which means it spawns transparent)
            if (NPC.alpha > 0)
            {
                NPC.alpha -= 10;
                if (NPC.alpha < 0)
                {
                    NPC.alpha = 0;
                }
            }
        }
        public override void FindFrame(int frameHeight = 32)
        {
            NPC.frameCounter++;
            if (NPC.frameCounter == 10)
            {
                NPC.frame.Y += frameHeight;
            }
            else if (NPC.frameCounter == 20)
            {
                NPC.frame.Y = 0;
                NPC.frameCounter = 0;
            }
        }

    }
}*/