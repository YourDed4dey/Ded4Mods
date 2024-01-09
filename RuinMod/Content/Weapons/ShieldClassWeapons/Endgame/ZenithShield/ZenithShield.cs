using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using RuinMod.Content.Classes.ShieldClass;
using RuinMod.Content.Weapons.ShieldClassWeapons.Hardmode.ShieldOfLife;
using RuinMod.Content.Weapons.ShieldClassWeapons.Hardmode.InfluxShield;
using RuinMod.Content.Weapons.ShieldClassWeapons.Hardmode.Horseman_sShield;
using RuinMod.Content.Weapons.ShieldClassWeapons.Hardmode.SeedShield;
using RuinMod.Content.Weapons.ShieldClassWeapons.PreHardmode.StarShield;
using RuinMod.Content.Weapons.ShieldClassWeapons.PreHardmode.BeeShield;
using RuinMod.Content.Weapons.ShieldClassWeapons.PreHardmode.EnchantedShield;
using RuinMod.Content.Weapons.ShieldClassWeapons.PreHardmode.CopperShield;
using RuinMod.Content.Weapons.ShieldClassWeapons.Endgame.StellarShield;
using System.Collections.Generic;
using RuinMod.Common.Systems;
using RuinMod.Content.Projectiles.ShieldClass.Hearted;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace RuinMod.Content.Weapons.ShieldClassWeapons.Endgame.ZenithShield
{
    [AutoloadEquip(EquipType.Shield)]
    internal class ZenithShield : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Zenith Shield");
            //Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            Item.width = 42;
            Item.height = 46;
            Item.accessory = true;
            Item.rare = ItemRarityID.Red;

            Item.damage = 190;
            Item.crit += 10;
            Item.DamageType = GetInstance<ShieldClassDamage>();
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            var keys = RuinKeybinds.SpecialAbilityKeybind.GetAssignedKeys();
            string key = keys.Count == 0 ? "<NOT BOUND>" : keys[0];
            float DashKeys = ZenithShieldDash.DashVelocity;
            int index = tooltips.FindIndex(tip => tip.Name.StartsWith("Tooltip"));
            if (index > -1)
            {
                tooltips.Insert(index, new(Mod, "KeybindTooltip", $"Corrupts, poisons, oils, burns, makes\nenemies bleed and god persecutes enemies on hit\nShoots a blast of stars when hitting an npc\nFruits appear in your cursor when hitting an enemy\nBecome immune after striking an enemy\nFaster regeneration\nLife steals 25 health per hit on enemies\nPress '{key}' to activate Special Ability\n[c/FFFF00:Special Ability: Shoots a Hearted sword,]\n[c/FFFF00:Influx waver sword, pumpkins, nuts, stars,]\n[c/FFFF00:friendly bees, and a enchanted beam]\nCurrent Dash= {DashKeys}\n15 defense\nAllows the player to dash into the enemy\nDouble tap a direction"));
            }
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<ZenithShieldDash>().DashAccessoryEquipped = true;
            player.statDefense += 15;

            player.lifeRegen += 25;

            if (player.whoAmI == Main.myPlayer)
            {
                if (RuinKeybinds.SpecialAbilityKeybind.JustPressed)
                {
                    Vector2 position = player.Center;
                    Vector2 targetPosition = Main.MouseWorld;
                    Vector2 direction = targetPosition - position;
                    direction.Normalize();
                    float speed = 15f;

                    float shieldDamage = player.GetCritChance<ShieldClassDamage>() += 1f;
                    float num = 190f * shieldDamage;

                    int type = Projectile.NewProjectile(null, position, direction * speed, ProjectileType<HeartedProjectile>(), (int)(num), 0, Main.myPlayer);
                    Main.projectile[type].hostile = false;
                    Main.projectile[type].friendly = true;
                    Main.projectile[type].penetrate = 8;
                    Main.projectile[type].timeLeft = 15 * 60;
                    int type1 = Projectile.NewProjectile(null, position, direction * speed, ProjectileID.InfluxWaver, (int)(num), 0, Main.myPlayer);
                    Main.projectile[type1].hostile = false;
                    Main.projectile[type1].friendly = true;
                    Main.projectile[type1].penetrate = 8;
                    Main.projectile[type1].timeLeft = 15 * 60;
                    int type2 = Projectile.NewProjectile(null, position, direction * speed, ProjectileID.FlamingJack, (int)(num), 0, Main.myPlayer);
                    Main.projectile[type2].hostile = false;
                    Main.projectile[type2].friendly = true;
                    Main.projectile[type2].penetrate = 8;
                    Main.projectile[type2].timeLeft = 15 * 60;
                    int type3 = Projectile.NewProjectile(null, position, direction * speed, ProjectileID.SeedlerNut, (int)(num), 0, Main.myPlayer);
                    Main.projectile[type3].hostile = false;
                    Main.projectile[type3].friendly = true;
                    Main.projectile[type3].penetrate = 8;
                    Main.projectile[type3].timeLeft = 15 * 60;
                    int type4 = Projectile.NewProjectile(null, position, direction * speed, ProjectileID.Starfury, (int)(num), 0, Main.myPlayer);
                    Main.projectile[type4].hostile = false;
                    Main.projectile[type4].friendly = true;
                    Main.projectile[type4].penetrate = 8;
                    Main.projectile[type4].timeLeft = 15 * 60;
                    int type5 = Projectile.NewProjectile(null, position, direction * speed, ProjectileID.Bee, (int)(num), 0, Main.myPlayer);
                    Main.projectile[type5].hostile = false;
                    Main.projectile[type5].friendly = true;
                    Main.projectile[type5].penetrate = 8;
                    Main.projectile[type5].timeLeft = 15 * 60;
                    int type6 = Projectile.NewProjectile(null, position, direction * speed, ProjectileID.EnchantedBeam, (int)(num), 0, Main.myPlayer);
                    Main.projectile[type6].hostile = false;
                    Main.projectile[type6].friendly = true;
                    Main.projectile[type6].penetrate = 8;
                    Main.projectile[type6].timeLeft = 15 * 60;
                }
            }
            player.onHitDodge = true;
        }
        public override bool CanEquipAccessory(Player player, int slot, bool modded)
        {
            if (Item.shieldSlot > 0)
                return false;

            else
                return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemType<ShieldOfLife>(), 1) //
                .AddIngredient(ItemType<MeowShield.MeowShield>(), 1) //
                .AddIngredient(ItemType<StellarShield.StellarShield>(), 1) //
                .AddIngredient(ItemType<InfluxShield>(), 1) //
                .AddIngredient(ItemType<Horseman_sShield>(), 1) //
                .AddIngredient(ItemType<SeedShield>(), 1) //
                .AddIngredient(ItemType<StarShield>(), 1) //
                .AddIngredient(ItemType<BeeShield>(), 1) //
                .AddIngredient(ItemType<EnchantedShield>(), 1) //
                .AddIngredient(ItemType<CopperShield>(), 1)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }

        // Below is code for the visuals

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
    }
}
