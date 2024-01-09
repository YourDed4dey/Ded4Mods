/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;
using RuinMod.Content.Classes.ChainClass;

namespace RuinMod.Content.Armor.ChainClassArmor.PreHardmodeArmor.SolitudeArmor
{
    [AutoloadEquip(EquipType.Head)]
    internal class SolitudeHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Solitude Helmet");
            //Tooltip.SetDefault("7% increased chain critical strike chance");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
        }

        public override void SetDefaults() //Item Stats
        {
            Item.width = 24;
            Item.height = 22;
            Item.value = Item.buyPrice(gold: 12);
            Item.rare = ItemRarityID.Orange;
            Item.defense = 7;
            Item.wornArmor = true;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<SolitudeChestplate>() && legs.type == ItemType<SolitudeLeggings>(); //What makes armor set work
        }

        public override void UpdateArmorSet(Player player) //Armor set bonuses
        {
            player.buffImmune[BuffID.OnFire] = true;
            player.buffImmune[BuffID.OnFire3] = true;
            player.setBonus = "10% extra chain damage,\nCannot be set on fire";
            player.GetDamage(GetInstance<ChainClassDamage>()) += 0.10f;
        }

        public override void UpdateEquip(Player player) //Individual armor piece bonus
        {
            player.GetCritChance(GetInstance<ChainClassDamage>()) += 0.07f;
        }

        public override void AddRecipes() //Item Recipe
        {
            CreateRecipe()
                .AddIngredient(ItemID.HellstoneBar, 8)
                .AddIngredient(ModContent.ItemType<Content.Items.LostFragment.LostFragment>(), 5)
                .AddTile(TileID.Anvils)
                .Register();
        }

    }
}*/
