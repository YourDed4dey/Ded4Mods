/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;
using Terraria.Audio;
//using RuinMod.Content.Classes.GamerClass;
//using RuinMod.Content.Armor.PreHardmode.Magic.AmberArmor;
//using RuinMod.Content.Armor.PreHardmode.Summoner.TopazArmor;
//using RuinMod.Content.Armor.PreHardmode.Ranger.SapphireArmor;
//using RuinMod.Content.Armor.PreHardmode.Melee.RubyArmor;
//using RuinMod.Content.Armor.PreHardmode.Magic.EmeraldArmor;
//using RuinMod.Content.Armor.PreHardmode.Melee.DiamondArmor;
//using RuinMod.Content.Armor.PreHardmode.Ranger.AmethystArmor;
using RuinMod.Content.Items.Placeables.GemAnvil.Tile;
using RuinMod.Content.Potions.Debuffs.BloodButchered;
using RuinMod.Content.Classes.ShieldClass;
using RuinMod.Content.Weapons.ShieldClassWeapons.PreHardmode.GoldShield;

namespace RuinMod.Content.Weapons.ShieldClassWeapons.PreHardmode.ReinforcedGem
{
    [AutoloadEquip(EquipType.Shield)]
    internal class ReinforcedGemShield : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Reinforced Gem");
            ////Tooltip.SetDefault("25% increased melee, magic, ranged and summon damage\n50% increased movement speed\n10% reduced mana cost\n+20 max mana\n+6 defense\nAllows the player to dash\nDouble tap a direction");
            //Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            Item.width = 42;
            Item.height = 46;
            Item.accessory = true;
            Item.rare = ItemRarityID.Expert;
            Item.expert = true;

            Item.damage = 28;
            Item.DamageType = GetInstance<ShieldClassDamage>();
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            float DashKeys = ReinforcedGemShieldDash.DashVelocity;
            int index = tooltips.FindIndex(tip => tip.Name.StartsWith("Tooltip"));
            if (index > -1)
            {
                tooltips.Insert(index, new(Mod, "KeybindTooltip", $"Freezes or makes enemies do mysterious things\n'I feel the power of the rainbow!'\nCurrent Dash= {DashKeys}\n6 defense\nAllows the player to dash into the enemy\nDouble tap a direction"));
            }
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            /*player.GetDamage(DamageClass.Melee) += 0.25f; // 16% increased melee damage

            player.GetDamage(DamageClass.Magic) += 0.25f; // 22% increased magic damage

            player.GetDamage(DamageClass.Ranged) += 0.25f; // 22% increased ranged damage

            player.GetDamage(DamageClass.Summon) += 0.25f; // 14% increased ranged damage

            player.moveSpeed += 0.50f; // 10% increased movement speed
            player.statDefense += 6; // +6 defense

            player.statManaMax2 += 20; // +20 max mana

            player.manaCost -= 0.10f; // 10% reduced mana cost*/

            /*player.GetModPlayer<ReinforcedGemShieldDash>().DashAccessoryEquipped = true;
            player.statDefense += 6; // +6 defense

            //player.dash = 2;
            //player.dashType = 2;
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
                .AddIngredient(ItemID.Amethyst, 15)
                .AddIngredient(ItemID.Amber, 15)
                .AddIngredient(ItemID.Sapphire, 15)
                .AddIngredient(ItemID.Topaz, 15)
                .AddIngredient(ItemID.Ruby, 15)
                .AddIngredient(ItemID.Diamond, 15)
                .AddIngredient(ItemID.Emerald, 15)
                .AddTile<GemAnvilTile>()
                .Register();

            /*CreateRecipe()
                .AddIngredient(ItemType<AmberHood>(), 1)
                .AddIngredient(ItemType<AmethystHelmet>(), 1)
                .AddIngredient(ItemType<DiamondHelmet>(), 1)
                .AddIngredient(ItemType<EmeraldHood>(), 1)
                .AddIngredient(ItemType<RubyHelmet>(), 1)
                .AddIngredient(ItemType<SapphireHelmet>(), 1)
                .AddIngredient(ItemType<TopazHelmet>(), 1)
                //
                .AddIngredient(ItemType<AmberRobe>(), 1)
                .AddIngredient(ItemType<AmethystChestplate>(), 1)
                .AddIngredient(ItemType<DiamondChestplate>(), 1)
                .AddIngredient(ItemType<EmeraldRobe>(), 1)
                .AddIngredient(ItemType<RubyChestplate>(), 1)
                .AddIngredient(ItemType<SapphireChestplate>(), 1)
                .AddIngredient(ItemType<TopazChestplate>(), 1)
                //
                .AddIngredient(ItemType<AmethystLeggings>(), 1)
                .AddIngredient(ItemType<DiamondLeggings>(), 1)
                .AddIngredient(ItemType<RubyLeggings>(), 1)
                .AddIngredient(ItemType<SapphireLeggings>(), 1)
                .AddIngredient(ItemType<TopazLeggings>(), 1)
                .AddTile(TileID.Anvils)
                .Register();*/
        /*}
    }
}*/
