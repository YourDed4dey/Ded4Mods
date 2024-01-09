using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace DedsBosses.Content.Items.Drops.VoiyedDrops.VoiyedShield
{
    [AutoloadEquip(EquipType.Shield)]
    public class VoiyedShield : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 32;
            Item.accessory = true;
            Item.rare = ItemRarityID.Pink;

            Item.damage = 50;
            Item.DamageType = DamageClass.Melee;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<VoiyedShieldDash>().DashAccessoryEquipped = true;
            player.statDefense += 9;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Clear the existing tooltips
            tooltips.Clear();

            // Add your custom tooltip
            TooltipLine line = new TooltipLine(Mod, "CustomTooltip", "[c/D77ED8:Voiyed Shield]\n50 melee damage\n4% critical strike chance but increases to 9% when dashing\nKnockbacks player and enemy\nEquipable\n9 defense\nUn-reforgable\nUn-sellable\nAllows the player to dash\nA trail of red light follows the player when dashing\nDouble tap a direction");
            tooltips.Add(line);
        }
        private static readonly int[] unwantedPrefixes = new int[] 
            { 
                PrefixID.Adept,
                PrefixID.Agile,
                PrefixID.Angry,
                PrefixID.Annoying,
                PrefixID.Arcane,
                PrefixID.Armored,
                PrefixID.Awful,
                PrefixID.Awkward,
                PrefixID.Brisk,
                PrefixID.Broken,
                PrefixID.Bulky,
                PrefixID.Celestial,
                PrefixID.Damaged,
                PrefixID.Dangerous,
                PrefixID.Deadly,
                PrefixID.Deadly2,
                PrefixID.Demonic,
                PrefixID.Deranged,
                PrefixID.Dull,
                PrefixID.Fleeting,
                PrefixID.Forceful,
                PrefixID.Frenzying,
                PrefixID.Furious,
                PrefixID.Godly,
                PrefixID.Guarding,
                PrefixID.Hard,
                PrefixID.Hasty,
                PrefixID.Hasty2,
                PrefixID.Heavy,
                PrefixID.Hurtful,
                PrefixID.Ignorant,
                PrefixID.Inept,
                PrefixID.Intense,
                PrefixID.Intimidating,
                PrefixID.Intrepid,
                PrefixID.Jagged,
                PrefixID.Keen,
                PrefixID.Large,
                PrefixID.Lazy,
                PrefixID.Legendary,
                PrefixID.Legendary2,
                PrefixID.Lethargic,
                PrefixID.Light,
                PrefixID.Lucky,
                PrefixID.Manic,
                PrefixID.Massive,
                PrefixID.Masterful,
                PrefixID.Menacing,
                PrefixID.Murderous,
                PrefixID.Mystic,
                PrefixID.Mythical,
                PrefixID.Nasty,
                PrefixID.Nimble,
                PrefixID.Pointy,
                PrefixID.Powerful,
                PrefixID.Precise,
                PrefixID.Quick,
                PrefixID.Quick2,
                PrefixID.Rapid,
                PrefixID.Rash,
                PrefixID.Ruthless,
                PrefixID.Savage,
                PrefixID.Shameful,
                PrefixID.Sharp,
                PrefixID.Shoddy,
                PrefixID.Sighted,
                PrefixID.Slow,
                PrefixID.Sluggish,
                PrefixID.Small,
                PrefixID.Spiked,
                PrefixID.Staunch,
                PrefixID.Strong,
                PrefixID.Superior,
                PrefixID.Taboo,
                PrefixID.Terrible,
                PrefixID.Tiny,
                PrefixID.Unhappy,
                PrefixID.Unpleasant,
                PrefixID.Unreal,
                PrefixID.Violent,
                PrefixID.Warding,
                PrefixID.Weak,
                PrefixID.Wild,
                PrefixID.Zealous
            };
        public override bool AllowPrefix(int pre)
        {
            // return false to make the game reroll the prefix.

            // DON'T DO THIS BY ITSELF:
            // return false;
            // This will get the game stuck because it will try to reroll every time. Instead, make it have a chance to return true.

            if (Array.IndexOf(unwantedPrefixes, pre) > -1)
            {
                // IndexOf returns a positive index of the element you search for. If not found, it's less than 0.
                // Here we check if the selected prefix is positive (it was found).
                // If so, we found a prefix that we don't want. Reroll.
                return false;
            }

            // Don't reroll
            return true;
        }
    }

    public class UnsellableShield : ModPlayer
    {
        public override bool CanSellItem(NPC vendor, Item[] shopInventory, Item item)
        {
            // Replace YourCustomItem with the type of your custom item
            if (item.type == ModContent.ItemType<VoiyedShield>())
            {
                return false; // Prevent selling your custom item
            }
            return true; // Allow selling other items
        }
    }
}
