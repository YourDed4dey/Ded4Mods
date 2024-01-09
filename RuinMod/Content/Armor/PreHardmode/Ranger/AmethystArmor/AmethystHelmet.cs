/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;
using Terraria.Audio;
using Terraria.Localization;

namespace RuinMod.Content.Armor.PreHardmode.Ranger.AmethystArmor
{
    [AutoloadEquip(EquipType.Head)]
    internal class AmethystHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Amethyst Helmet");
            //Tooltip.SetDefault("8% increased ranged damage");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
        }

        public override void SetDefaults() //Item Stats
        {
            Item.width = 22;
            Item.height = 20;
            Item.rare = ItemRarityID.Blue;
            Item.defense = 7;
            Item.wornArmor = true;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<AmethystChestplate>() && legs.type == ItemType<AmethystLeggings>(); //What makes armor set bonus work
        }

        public override void UpdateArmorSet(Player player) //Armor set bonuses
        {
            //player.setBonus = "10% increased ranged damage and critical strike chance";
            player.setBonus = Language.GetTextValue("Mods.RuinMod.ItemSetBonus.AmethystSet");
            player.GetDamage(DamageClass.Ranged) += 0.1f;
            player.GetCritChance(DamageClass.Ranged) += 0.1f;
        }

        public override void UpdateEquip(Player player) //Individual armor piece bonus
        {
            player.GetDamage(DamageClass.Ranged) += 0.08f;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Amethyst, 8)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}*/