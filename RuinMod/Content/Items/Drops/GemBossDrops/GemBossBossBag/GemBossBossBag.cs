﻿/*using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.ItemDropRules;
using Terraria.DataStructures;
using RuinMod.Content.Armor.VanityArmor.GemBossMask;
//using RuinMod.Common.Systems.DiffSystem;
using RuinMod.Content.Weapons.ShieldClassWeapons.PreHardmode.ReinforcedGem;

namespace RuinMod.Content.Items.Drops.GemBossDrops.GemBossBossBag
{
    public class GemBossBossBag : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Treasure Bag (Gemmonide)");
            //Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");

            ItemID.Sets.BossBag[Type] = true;

            ItemID.Sets.PreHardmodeLikeBossBag[Type] = true;

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;

            Main.RegisterItemAnimation(Item.type, new DrawAnimation());
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(10, 6)); //What makes animation work, using Terraria.DataStructures; needed for it to work

            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.maxStack = 999;
            Item.consumable = true;
            Item.width = 32;
            Item.height = 36;
            Item.rare = ItemRarityID.Purple;
            Item.expert = true; // This makes sure that "Expert" displays in the tooltip and the item name color changes
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void ModifyItemLoot(ItemLoot itemLoot)
        {
            itemLoot.Add(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<GemBossMask>(), 7));

            //itemLoot.Add(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<ReinforcedGemShield>(), 4, 1, 1));

            itemLoot.Add(ItemDropRule.NotScalingWithLuck(ItemID.Amethyst, 7, 10, 15));

            itemLoot.Add(ItemDropRule.NotScalingWithLuck(ItemID.Amber, 7, 10, 15));

            itemLoot.Add(ItemDropRule.NotScalingWithLuck(ItemID.Sapphire, 7, 10, 15));

            itemLoot.Add(ItemDropRule.NotScalingWithLuck(ItemID.Topaz, 7, 10, 15));

            itemLoot.Add(ItemDropRule.NotScalingWithLuck(ItemID.Ruby, 7, 10, 15));

            itemLoot.Add(ItemDropRule.NotScalingWithLuck(ItemID.Diamond, 7, 10, 15));

            itemLoot.Add(ItemDropRule.NotScalingWithLuck(ItemID.Emerald, 7, 10, 15));

            itemLoot.Add(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<Placeables.GemAnvil.GemAnvil>(), 1, 1, 1));

            itemLoot.Add(ItemDropRule.CoinsBasedOnNPCValue(ModContent.NPCType<NPCS.Bosses.GemBoss.GemBoss>())); 
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
}*/