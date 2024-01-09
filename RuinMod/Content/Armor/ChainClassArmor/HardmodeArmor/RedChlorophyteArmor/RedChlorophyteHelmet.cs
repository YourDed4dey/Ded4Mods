/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;
using Terraria.Audio;
using RuinMod.Content.Classes.ChainClass;

namespace RuinMod.Content.Armor.ChainClassArmor.HardmodeArmor.RedChlorophyteArmor
{
    [AutoloadEquip(EquipType.Head)]
    internal class RedChlorophyteHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Red Chlorophyte Helmet");
            //Tooltip.SetDefault("7% increased chain damage");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
        }

        public override void SetDefaults() //Item Stats
        {
            Item.width = 24;
            Item.height = 22;
            Item.value = Item.buyPrice(gold: 34);
            Item.rare = ItemRarityID.Yellow;
            Item.defense = 13;
            Item.wornArmor = true;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<RedChlorophyteChestPlate>() && legs.type == ItemType<RedChlorophyteLeggings>(); //What makes armor set bonus work
        }

        public override void UpdateArmorSet(Player player) //Armor set bonuses
        {
            //player.setBonus = "Summons a dark piece of reality to shoot at ý̶̢̢̞̰̭͖̹̀͜o̵̗̣̯̼̻͔̳͛̍̑̃ͅû̷̙͇̲̫̩̐̓͝͠, nearby enemies";
            player.setBonus = "10% increased chain damage\n'The voices gift you with a greater power'\n[c/DDFF00:Total chain damage increased: 32%]";

            player.GetDamage(GetInstance<ChainClassDamage>()) += 0.1f;
        }

        public override void UpdateEquip(Player player) //Individual armor piece bonus
        {
            player.GetDamage(GetInstance<ChainClassDamage>()) += 0.07f;
        }

        public override void AddRecipes() //Item Recipe
        {
            CreateRecipe()
                .AddIngredient(ItemType<Items.RedChlorophyte.RedChlorophyteBarItem>(), 22)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }

    }
}*/
