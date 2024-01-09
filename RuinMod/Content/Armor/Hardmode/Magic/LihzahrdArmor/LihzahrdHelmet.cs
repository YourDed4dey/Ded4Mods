/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;
using Terraria.Audio;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using RuinMod.Common.Systems;
using RuinMod.Content.Items.Drops.LihzahrdScale;
using RuinMod.Content.Items.Drops.EssencesOrSoulsOrFragments.Souls.SoulOfInertness;

namespace RuinMod.Content.Armor.Hardmode.Magic.LihzahrdArmor
{
    [AutoloadEquip(EquipType.Head)]
    internal class LihzahrdHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Lihzahrd Helmet");
            //Tooltip.SetDefault("5% increased magical damage\nIncreases maximum mana by 55\n10% reduced mana use");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
        }

        public override void SetDefaults() //Item Stats
        {
            Item.width = 26;
            Item.height = 26;
            Item.rare = ItemRarityID.Yellow;
            Item.defense = 15;
            Item.wornArmor = true;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<LihzahrdChestplate>() && legs.type == ItemType<LihzahrdLeggings>(); //What makes armor set bonus work
        }
        public override void UpdateArmorSet(Player player) //Armor set bonuses
        {
            //player.setBonus = "Increases maximum mana by 20\nAllows the player to dash\nDouble tap a direction";
            player.setBonus = Language.GetTextValue("Mods.RuinMod.ItemSetBonus.LihzahrdSet");
            player.statManaMax2 += 20;
            //player.GetModPlayer<RuinDashPlayer>().DashAccessoryEquipped = true;
        }

        public override void UpdateEquip(Player player) //Individual armor piece bonus
        {
            player.GetDamage(DamageClass.Magic) += 0.05f;
            player.statManaMax2 += 55;
            player.manaCost -= 0.1f;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemType<LihzahrdScale>(), 15)
                .AddIngredient(ItemID.Bone, 45)
                .AddIngredient(ItemType<SoulOfInertness>(), 5)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}*/
