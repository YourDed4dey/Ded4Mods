/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;
using Terraria.Audio;
using Terraria.Localization;

namespace RuinMod.Content.Armor.PreHardmode.Summoner.TopazArmor
{
    [AutoloadEquip(EquipType.Head)]
    internal class TopazHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Topaz Helmet");
            //Tooltip.SetDefault("20% increased summon damage");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
        }

        public override void SetDefaults() //Item Stats
        {
            Item.width = 22;
            Item.height = 20;
            Item.rare = ItemRarityID.Blue;
            Item.defense = 5;
            Item.wornArmor = true;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<TopazChestplate>() && legs.type == ItemType<TopazLeggings>(); //What makes armor set bonus work
        }

        public override void UpdateArmorSet(Player player) //Armor set bonuses
        {
            //player.setBonus = "15% increased summon damage\nIncreases whip range by 75% and speed by 40%";
            player.setBonus = Language.GetTextValue("Mods.RuinMod.ItemSetBonus.TopazSet");
            player.GetDamage(DamageClass.Summon) += 0.15f;
            player.whipRangeMultiplier += 0.75f;
            player.GetAttackSpeed(DamageClass.SummonMeleeSpeed) += 0.4f;
        }

        public override void UpdateEquip(Player player) //Individual armor piece bonus
        {
            player.GetDamage(DamageClass.Summon) += 0.2f;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Topaz, 8)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}*/