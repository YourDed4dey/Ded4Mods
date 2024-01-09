/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;
using Terraria.Audio;
using Terraria.Localization;

namespace RuinMod.Content.Armor.PreHardmode.Magic.EmeraldArmor
{
    [AutoloadEquip(EquipType.Head)]
    internal class EmeraldHood : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Emerald Hood");
            //Tooltip.SetDefault("15% increased magic damage\n+10 max mana");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
        }

        public override void SetDefaults() //Item Stats
        {
            Item.width = 24;
            Item.height = 24;
            Item.rare = ItemRarityID.Blue;
            Item.defense = 10;
            Item.wornArmor = true;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<EmeraldRobe>(); //What makes armor set bonus work
        }

        public override void UpdateArmorSet(Player player) //Armor set bonuses
        {
            //player.setBonus = "40% increased magic damage";
            player.setBonus = Language.GetTextValue("Mods.RuinMod.ItemSetBonus.EmeraldSet");
            player.GetDamage(DamageClass.Magic) += 0.40f;
        }

        public override void UpdateEquip(Player player) //Individual armor piece bonus
        {
            player.GetDamage(DamageClass.Magic) += 0.15f;
            player.statManaMax2 += 10;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Emerald, 8)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}*/