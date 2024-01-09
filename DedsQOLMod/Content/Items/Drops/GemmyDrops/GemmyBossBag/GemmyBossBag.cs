using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.ItemDropRules;
using System;
using DedsQOLMod.Content.NPCs.Bosses.GemBoss;
using Terraria.DataStructures;
using DedsQOLMod.Content.Weapons.RangerClass.PreHardmode.GemmyGun;
using DedsQOLMod.Content.Items.Armor.Vanity.BossMasks;
using DedsQOLMod.Content.Weapons.MageClass.PreHardmode.GemmySpellBooks;

namespace DedsQOLMod.Content.Items.Drops.GemmyDrops.GemmyBossBag
{
    internal class GemmyBossBag : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.BossBag[Type] = true;
            ItemID.Sets.PreHardmodeLikeBossBag[Type] = true; // ..But this set ensures that dev armor will only be dropped on special world seeds, since that's the behavior of pre-hardmode boss bags.

            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(10, 6)); // first it the amount of ticks per frame and second is the number of frames

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
        }

        public override void SetDefaults()
        {
            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true;
            Item.width = 32;
            Item.height = 37;
            Item.rare = ItemRarityID.Purple;
            Item.expert = true; // This makes sure that "Expert" displays in the tooltip and the item name color changes
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void ModifyItemLoot(ItemLoot itemLoot)
        {
            itemLoot.Add(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<GemmyMask>(), 7));

            itemLoot.Add(ItemDropRule.CoinsBasedOnNPCValue(ModContent.NPCType<GemBoss>()));

            bool findMod = ModLoader.TryGetMod("DedsBosses", out Mod dedsQOLMod);
            if (findMod)
            {
                //itemLoot.Add(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<GemmyGun>(), 10));

                itemLoot.Add(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<GemmyGemSpellBook>(), 10));

                itemLoot.Add(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<GemmyFireSpellBook>(), 10));
            }
        }
    }
}
