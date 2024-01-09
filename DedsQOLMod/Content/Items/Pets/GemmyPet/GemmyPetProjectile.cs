﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace DedsQOLMod.Content.Items.Pets.GemmyPet
{
    internal class GemmyPetProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 4;
            Main.projPet[Projectile.type] = true;

            // This code is needed to customize the vanity pet display in the player select screen. Quick explanation:
            // * It uses fluent API syntax, just like Recipe
            // * You start with ProjectileID.Sets.SimpleLoop, specifying the start and end frames aswell as the speed, and optionally if it should animate from the end after reaching the end, effectively "bouncing"
            // * To stop the animation if the player is not highlighted/is standing, as done by most grounded pets, add a .WhenNotSelected(0, 0) (you can customize it just like SimpleLoop)
            // * To set offset and direction, use .WithOffset(x, y) and .WithSpriteDirection(-1)
            // * To further customize the behavior and animation of the pet (as its AI does not run), you have access to a few vanilla presets in DelegateMethods.CharacterPreview to use via .WithCode(). You can also make your own, showcased in MinionBossPetProjectile
            ProjectileID.Sets.CharacterPreviewAnimations[Projectile.type] = ProjectileID.Sets.SimpleLoop(0, Main.projFrames[Projectile.type], 6)
                .WithOffset(-10, -20f)
                .WithSpriteDirection(-1)
                .WithCode(DelegateMethods.CharacterPreview.Float);
        }

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.ZephyrFish); // Copy the stats of the Zephyr Fish

            AIType = ProjectileID.ZephyrFish; // Mimic as the Zephyr Fish during AI.
        }

        public override bool PreAI()
        {
            Player player = Main.player[Projectile.owner];

            player.zephyrfish = false; // Relic from AIType

            return true;
        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];

            // Keep the projectile from disappearing as long as the player isn't dead and has the pet buff.
            if (!player.dead && player.HasBuff(ModContent.BuffType<GemmyPetBuff>()))
            {
                Projectile.timeLeft = 2;
            }

            // Add dust effects
            Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.OrangeTorch); // Change DustID as needed
            dust.scale = 1f; // Adjust the dust scale as needed
            dust.velocity *= 0.2f; // Adjust the dust velocity as needed
            dust.noGravity = true; // Set to true if you want the dust to float
        }
    }
}