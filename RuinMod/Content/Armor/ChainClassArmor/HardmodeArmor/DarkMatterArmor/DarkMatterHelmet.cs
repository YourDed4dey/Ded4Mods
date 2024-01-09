/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;
using Terraria.Audio;
using RuinMod.Content.Classes.ChainClass;

namespace RuinMod.Content.Armor.ChainClassArmor.HardmodeArmor.DarkMatterArmor
{
    [AutoloadEquip(EquipType.Head)]
    internal class DarkMatterHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Dark Matter Helmet");
            //Tooltip.SetDefault("26% increased chain critical strike chance");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
        }

        public override void SetDefaults() //Item Stats
        {
            Item.width = 24;
            Item.height = 22;
            Item.value = Item.buyPrice(gold: 34);
            Item.rare = ItemRarityID.Red;
            Item.defense = 15;
            Item.wornArmor = true;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<DarkMatterChestplate>() && legs.type == ItemType<DarkMatterLeggings>(); //What makes armor set bonus work
        }

        public override void UpdateArmorSet(Player player) //Armor set bonuses
        {
            //player.setBonus = "Summons a dark piece of reality to shoot at ý̶̢̢̞̰̭͖̹̀͜o̵̗̣̯̼̻͔̳͛̍̑̃ͅû̷̙͇̲̫̩̐̓͝͠, nearby enemies";
            player.setBonus = "???";

            player.GetDamage(GetInstance<ChainClassDamage>()) += 0.1f;
        }

        public override void UpdateEquip(Player player) //Individual armor piece bonus
        {
            //player.GetDamage(GetInstance<ChainClassDamage>()) += 0.07f;
            player.GetCritChance(GetInstance<ChainClassDamage>()) += 0.26f;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<Content.Items.FragmentOfCosmos.FragmentOfCosmos>(), 10)
                .AddIngredient(ItemID.LunarBar, 8)
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }
}*/
