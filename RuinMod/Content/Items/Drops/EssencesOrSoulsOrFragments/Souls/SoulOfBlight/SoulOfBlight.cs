/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Mono.Cecil;
//using RuinMod.Content.Projectiles.MeleeProjectiles.SwordOfSouls;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.ItemDropRules;
using static System.Formats.Asn1.AsnWriter;

namespace RuinMod.Content.Items.Drops.EssencesOrSoulsOrFragments.Souls.SoulOfBlight;

internal class SoulOfBlight : ModItem
{
    public override void SetStaticDefaults()
    {
        //DisplayName.SetDefault("Soul of Blight");
        //Tooltip.SetDefault("'The essence of infected creatures'");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
        ItemID.Sets.SortingPriorityMaterials[Type] = 69;

        Main.RegisterItemAnimation(Item.type, new DrawAnimation());
        Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 4)); //What makes animation work, using Terraria.DataStructures; needed for it to work

        ItemID.Sets.AnimatesAsSoul[Item.type] = true;
        ItemID.Sets.ItemIconPulse[Item.type] = true;
        ItemID.Sets.ItemNoGravity[Item.type] = true;
    }


    public override void SetDefaults()
    {
        Item.width = 22;
        Item.height = 22;
        Item.maxStack = 999;
        Item.CloneDefaults(ItemID.SoulofFright);

        Item.rare = ItemRarityID.Pink;
        Item.value = 0;
    }
    public override Color? GetAlpha(Color lightColor)
    {
        // Makes sure the dropped bag is always visible
        return Color.Lerp(lightColor, Color.White, 0.4f);
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
}*/

