/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Mono.Cecil;
using RuinMod.Content.Projectiles.MeleeProjectiles.SwordOfSouls;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.ItemDropRules;
using static System.Formats.Asn1.AsnWriter;

namespace RuinMod.Content.Weapons.MeleeWeapons.Hardmode.SwordOfSouls
{
    internal class SwordOfSouls : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Sword of Souls");
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(10, 4)); // first it the amount of ticks per frame and second is the number of frames 
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
            ItemID.Sets.ItemIconPulse[Item.type] = true;
            ItemID.Sets.ItemNoGravity[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.width = 56;
            Item.height = 64;

            Item.damage = 195;
            Item.crit = 10;
            Item.DamageType = DamageClass.Melee;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.autoReuse = true;
            Item.useTime = 10;
            Item.useAnimation = 10;

            Item.shoot = ModContent.ProjectileType<SwordOfSoulsFrightProjectile>();
            Item.shootSpeed = 10f;

            Item.knockBack = 8f;
            Item.ArmorPenetration = 25;

            Item.rare = ItemRarityID.Purple;
            Item.UseSound = SoundID.Item1;
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            float kitingOffsetX = Utils.Clamp(player.velocity.X * 16, -500, 500);
            position = player.Bottom + new Vector2(kitingOffsetX + Main.rand.Next(-500, 500), Main.rand.Next(-250, 250) + Main.rand.Next(-500, 500));

            type = Main.rand.Next(new int[] { type, ModContent.ProjectileType<SwordOfSoulsLightProjectile>(), ModContent.ProjectileType<SwordOfSoulsNightProjectile>(), ModContent.ProjectileType<SwordOfSoulsBlightProjectile>(), ModContent.ProjectileType<SwordOfSoulsFlightProjectile>(), ModContent.ProjectileType<SwordOfSoulSightProjectile>(), ModContent.ProjectileType<SwordOfSoulsMightProjectile>() });
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<Items.Drops.EssencesOrSoulsOrFragments.Souls.SoulOfStruggle.SoulOfStruggle>(), 5)
                .AddIngredient(ItemID.SoulofFlight, 25)
                .AddIngredient(ItemID.SoulofLight, 25)
                .AddIngredient(ItemID.SoulofNight, 25)
                .AddIngredient(ItemID.SoulofSight, 25)
                .AddIngredient(ItemID.SoulofFright, 25)
                .AddIngredient(ItemID.SoulofMight, 25)
                .AddIngredient(ModContent.ItemType<Items.Drops.EssencesOrSoulsOrFragments.Souls.SoulOfBlight.SoulOfBlight>(), 25)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
        public override Color? GetAlpha(Color lightColor)
        {
            // Makes sure the dropped bag is always visible
            return Color.Lerp(lightColor, Color.White, 0.4f);
        }

        public override void PostUpdate()
        {
            // Spawn some light and dust when dropped in the world
            Lighting.AddLight(Item.Center, Color.White.ToVector3() * 0.4f);

            if (Item.timeSinceItemSpawned % 12 == 0)
            {
                Vector2 center = Item.Center + new Vector2(0f, Item.height * -0.1f);

                // This creates a randomly rotated vector of length 1, which gets it's components multiplied by the parameters
                Vector2 direction = Main.rand.NextVector2CircularEdge(Item.width * 0.6f, Item.height * 0.6f);
                float distance = 0.3f + Main.rand.NextFloat() * 0.5f;
                Vector2 velocity = new Vector2(0f, -Main.rand.NextFloat() * 0.3f - 1.5f);

                Dust dust = Dust.NewDustPerfect(center + direction * distance, DustID.SilverFlame, velocity);
                dust.scale = 0.5f;
                dust.fadeIn = 1.1f;
                dust.noGravity = true;
                dust.noLight = true;
                dust.alpha = 0;
            }
        }

        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
            // Draw the periodic glow effect behind the item when dropped in the world (hence PreDrawInWorld)
            Texture2D texture = TextureAssets.Item[Item.type].Value;

            Rectangle frame;

            if (Main.itemAnimations[Item.type] != null)
            {
                // In case this item is animated, this picks the correct frame
                frame = Main.itemAnimations[Item.type].GetFrame(texture, Main.itemFrameCounter[whoAmI]);
            }
            else
            {
                frame = texture.Frame();
            }

            Vector2 frameOrigin = frame.Size() / 2f;
            Vector2 offset = new Vector2(Item.width / 2 - frameOrigin.X, Item.height - frame.Height);
            Vector2 drawPos = Item.position - Main.screenPosition + frameOrigin + offset;

            float time = Main.GlobalTimeWrappedHourly;
            float timer = Item.timeSinceItemSpawned / 240f + time * 0.04f;

            time %= 4f;
            time /= 2f;

            if (time >= 1f)
            {
                time = 2f - time;
            }

            time = time * 0.5f + 0.5f;

            for (float i = 0f; i < 1f; i += 0.25f)
            {
                float radians = (i + timer) * MathHelper.TwoPi;

                spriteBatch.Draw(texture, drawPos + new Vector2(0f, 8f).RotatedBy(radians) * time, frame, new Color(90, 70, 255, 50), rotation, frameOrigin, scale, SpriteEffects.None, 0);
            }

            for (float i = 0f; i < 1f; i += 0.34f)
            {
                float radians = (i + timer) * MathHelper.TwoPi;

                spriteBatch.Draw(texture, drawPos + new Vector2(0f, 4f).RotatedBy(radians) * time, frame, new Color(140, 120, 255, 77), rotation, frameOrigin, scale, SpriteEffects.None, 0);
            }

            return true;
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(3))
            {
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.BubbleBurst_White);
            }
        }
    }
}*/
