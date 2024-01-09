/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;

namespace RuinMod.Content.Armor.GamerClassArmor.PreHardmode.SonicArmor
{
    [AutoloadEquip(EquipType.Body)]
    internal class SonicBody : ModItem
    {

        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Sonic Body");
            //Tooltip.SetDefault("2% increased gamer damage\n25% increased movement speed");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()//Item stats
        {
            Item.width = 15;
            Item.height = 8;
            Item.rare = ItemRarityID.Blue;
            Item.defense = 6;
            Item.wornArmor = true;
        }

        public override void UpdateEquip(Player player)//Individual armor piece bonus
        {
            player.moveSpeed += 0.25f;
            player.GetDamage(GetInstance<Classes.GamerClass.GamerClassDamage>()) += 0.02f;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.DemoniteBar, 25)
                .AddIngredient(ItemID.ShadowScale, 20)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}*/
