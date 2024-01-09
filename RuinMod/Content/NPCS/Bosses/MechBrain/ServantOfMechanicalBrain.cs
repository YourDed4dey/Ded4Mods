/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using System;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.GameContent.Bestiary;
using RuinMod.Assets.Music;
using System.Collections.Generic;

namespace RuinMod.Content.NPCS.Bosses.MechBrain
{
	internal class ServantOfMechanicalBrain : ModNPC
	{

        public ref float Attack_Lasers => ref NPC.localAI[3];

        public int ParentIndex
		{
			get => (int)NPC.ai[0] - 1;
			set => NPC.ai[0] = value + 1;
		}

		public bool HasParent => ParentIndex > -1;
		public int PositionIndex
		{
			get => (int)NPC.ai[1] - 1;
			set => NPC.ai[1] = value + 1;
		}
		public bool HasPosition => PositionIndex > -1;

		public const float RotationTimerMax = 360;
		public ref float RotationTimer => ref NPC.ai[2];

        public static int BodyType()
        {
            return ModContent.NPCType<MechBrain>();
        }


        public override void SetStaticDefaults()
		{
			////DisplayName.SetDefault("Servant of Mechanical Brain");
            //DisplayName.SetDefault("Mechanical Brain Cell");
			Main.npcFrameCount[Type] = 4;


			NPCID.Sets.DontDoHardmodeScaling[Type] = true;
			NPCID.Sets.CantTakeLunchMoney[Type] = true;
            NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData
            {
                SpecificallyImmuneTo = new int[] {
                    BuffID.Confused
                }
            };
            NPCID.Sets.DebuffImmunitySets.Add(Type, debuffData);
        }

		public override void SetDefaults()
		{
			NPC.width = 69;
			NPC.height = 70;
			NPC.aiStyle = -1;
			NPC.lifeMax = 600;
			NPC.damage = 20;
			NPC.defense = 5;
			NPC.netAlways = true;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.knockBackResist = 0f;

			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;

            AnimationType = NPCID.ServantofCthulhu;
			NPC.rotation = 0;

            if (Main.getGoodWorld || Main.masterMode)
            {
                NPC.scale = .5f;
            }
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new List<IBestiaryInfoElement> {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime,
                new FlavorTextBestiaryInfoElement("Following every command that The Mechanical Brain commands... They are in eternal slavery.")
            });
        }
        public override bool CanHitPlayer(Player target, ref int cooldownSlot)
		{
			cooldownSlot = ImmunityCooldownID.Bosses;
			return true;
		}
        public override void HitEffect(int hitDirection, double damage)
        {
            if (NPC.life <= 0)
            {

                int dustType = 18; 

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
			NPC.rotation += 0.1f * (float)NPC.direction;
			NPC.spriteDirection = NPC.direction;

            if (NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead || !Main.player[NPC.target].active)
            {
                NPC.TargetClosest();
            }

            if (Despawn())
			{
				return;
			}

			if (Main.expertMode)
			{
                Lasers();
            }
			//Lasers();

            MoveInFormation();

		}
        private bool Despawn()
		{
			if (Main.netMode != NetmodeID.MultiplayerClient &&
				(!HasPosition || !HasParent || !Main.npc[ParentIndex].active || Main.npc[ParentIndex].type != BodyType()))
			{
				NPC.active = false;
				NPC.life = 0;
				NetMessage.SendData(MessageID.SyncNPC, number: NPC.whoAmI);
				return true;
			}
			return false;
		}
		private void MoveInFormation()
		{
			NPC parentNPC = Main.npc[ParentIndex];

			// This basically turns the NPCs PositionIndex into a number between 0f and TwoPi to determine where around
			// the main body it is positioned at
			float rad = (float)PositionIndex / MechBrain.MinionCount() * MathHelper.TwoPi;

			// Add some slight uniform rotation to make the eyes move, giving a chance to touch the player and thus helping melee players
			RotationTimer += 0.5f;
			if (RotationTimer > RotationTimerMax)
			{
				RotationTimer = 0;
			}

			// Since RotationTimer is in degrees (0..360) we can convert it to radians (0..TwoPi) easily
			float continuousRotation = MathHelper.ToRadians(RotationTimer);
			rad += continuousRotation;
			if (rad > MathHelper.TwoPi)
			{
				rad -= MathHelper.TwoPi;
			}
			else if (rad < 0)
			{
				rad += MathHelper.TwoPi;
			}

			float distanceFromBody = parentNPC.width + NPC.width;

			// offset is now a vector that will determine the position of the NPC based on its index
			Vector2 offset = Vector2.One.RotatedBy(rad) * distanceFromBody;

			Vector2 destination = parentNPC.Center + offset;
			Vector2 toDestination = destination - NPC.Center;
			Vector2 toDestinationNormalized = toDestination.SafeNormalize(Vector2.Zero);

			float speed = 8f;
			float inertia = 20;

			Vector2 moveTo = toDestinationNormalized * speed;
			NPC.velocity = (NPC.velocity * (inertia - 1) + moveTo) / inertia;
        }

		private void Lasers ()
		{
            float timerMax = Utils.Clamp((float)NPC.life / NPC.lifeMax, 0.33f, 1f) * 90;

            Attack_Lasers++;
            if (Attack_Lasers > timerMax)
            {
                Attack_Lasers = 0;
            }

            if (NPC.HasValidTarget && Attack_Lasers == 0 && Main.netMode != NetmodeID.MultiplayerClient)
            {
                Vector2 position = NPC.Center;
                Vector2 targetPosition = Main.player[NPC.target].Center;
                Vector2 direction = targetPosition - position;
                direction.Normalize();
                float speed = 10f;

                int type = ProjectileID.EyeLaser;
                int damage = 15; //180, 60 is expert (180 is insta death) (30)

                Projectile.NewProjectile(null, position, direction * speed, type, damage, 0, Main.myPlayer);
            }
        }
	}
}*/
