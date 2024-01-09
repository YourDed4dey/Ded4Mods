using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.ItemDropRules;
using DedsBosses.Content.NPCs.Bosses.VoiyedBoss;
using DedsBosses.Content.Items.Drops.VoiyedDrops.VoiyedShield;

namespace DedsBosses.Content.Items.Drops.VoiyedDrops.VoiyedBossBag
{
    public class VoiyedBossBag : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Treasure Bag (Mechanical Brain)");
            //Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");

            ItemID.Sets.BossBag[Type] = true;

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
        }

        public override void SetDefaults()
        {
            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true;
            Item.width = 32;
            Item.height = 32;
            Item.rare = ItemRarityID.Purple;
            Item.expert = true; // This makes sure that "Expert" displays in the tooltip and the item name color changes
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void ModifyItemLoot(ItemLoot itemLoot)
        {
            itemLoot.Add(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<Armor.Vanity.BossMasks.VoiyedMask>(), 7));

            itemLoot.Add(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<VoiyedShield.VoiyedShield>(), 1));

            itemLoot.Add(ItemDropRule.CoinsBasedOnNPCValue(ModContent.NPCType<Voiyed>()));
        }
    }
}