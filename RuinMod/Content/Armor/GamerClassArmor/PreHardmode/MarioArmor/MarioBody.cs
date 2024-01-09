/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;

namespace RuinMod.Content.Armor.GamerClassArmor.PreHardmode.MarioArmor
{
    [AutoloadEquip(EquipType.Body)]
    internal class MarioBody : ModItem
    {

        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Mario Body");
            //Tooltip.SetDefault("2% increased gamer damage\n25% increased movement speed");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()//Item stats
        {
            Item.width = 24;
            Item.height = 12;
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
                .AddIngredient(ItemID.CrimtaneBar, 25)
                .AddIngredient(ItemID.TissueSample, 20)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}*/
