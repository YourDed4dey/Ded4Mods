/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using RuinMod.Assets.Textures.BossBars;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using System;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.GameContent.Bestiary;
using RuinMod.Assets.Music;
using System.Collections.Generic;

namespace RuinMod.Content.NPCS.Bosses.SkullOfRedemption
{
    internal class SkullOfRedemptionHand : ModNPC
    {
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

		public static int BodyType()
        {
            return ModContent.NPCType<SkullOfRedemption>();
        }
		public bool HasPosition => PositionIndex > -1;

		public const float RotationTimerMax = 360;
		public ref float RotationTimer => ref NPC.ai[2];


		public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Skull of Redemption Hand");
            Main.npcFrameCount[Type] = 1;


			NPCID.Sets.DontDoHardmodeScaling[Type] = true;
			NPCID.Sets.CantTakeLunchMoney[Type] = true;
		}

        public override void SetDefaults()
        {
			NPC.width = 56;
			NPC.height = 76;
            NPC.aiStyle = -1;
            NPC.lifeMax = 7000;
            NPC.damage = 150;
			NPC.defense = 40;
			NPC.netAlways = true;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.knockBackResist = 0.8f;
			NPC.rotation = 0;
		}

		public override bool CanHitPlayer(Player target, ref int cooldownSlot)
		{
			cooldownSlot = ImmunityCooldownID.Bosses;
			return true;
		}
		public override void AI()
		{
			NPC.rotation += 0.1f * (float)NPC.direction;
			NPC.spriteDirection = NPC.direction;

			if (Despawn())
            {
				return;
            }

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
			float rad = (float)PositionIndex / SkullOfRedemption.MinionCount() * MathHelper.TwoPi;

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
	}
}*/
