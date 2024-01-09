/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;
using Terraria.Audio;
using Terraria.Localization;

namespace RuinMod.Content.Armor.PreHardmode.Melee.DiamondArmor
{
    [AutoloadEquip(EquipType.Head)]
    internal class DiamondHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Diamond Helmet");
            //Tooltip.SetDefault("5% increased melee critical strike chance");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
        }

        public override void SetDefaults() //Item Stats
        {
            Item.width = 22;
            Item.height = 20;
            Item.rare = ItemRarityID.Blue;
            Item.defense = 8;
            Item.wornArmor = true;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<DiamondChestplate>() && legs.type == ItemType<DiamondLeggings>(); //What makes armor set bonus work
        }

        public override void UpdateArmorSet(Player player) //Armor set bonuses
        {
            //player.setBonus = "10% increased melee damage";
            player.setBonus = Language.GetTextValue("Mods.RuinMod.ItemSetBonus.DiamondSet");
            player.GetDamage(DamageClass.Melee) += 0.10f;
        }

        public override void UpdateEquip(Player player) //Individual armor piece bonus
        {
            player.GetCritChance(DamageClass.Melee) += 0.05f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Diamond, 8)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}*/