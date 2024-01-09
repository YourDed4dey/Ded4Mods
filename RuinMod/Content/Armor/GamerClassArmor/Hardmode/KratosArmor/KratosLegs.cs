/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;

namespace RuinMod.Content.Armor.GamerClassArmor.Hardmode.KratosArmor
{
    [AutoloadEquip(EquipType.Legs)]
    internal class KratosLegs : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Kratos Legs");
            //Tooltip.SetDefault("15% increased gamer damage\n50% increased movement speed");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 42;
            Item.height = 14;
            Item.rare = ItemRarityID.Red;
            Item.defense = 15;
            Item.wornArmor = true;
        }

        public override void UpdateEquip(Player player) //Individual armor piece bonus
        {
            player.GetDamage(GetInstance<Classes.GamerClass.GamerClassDamage>()) += 0.15f;
            player.moveSpeed += 0.50f;
        }
        public override void AddRecipes()
        {

        }
    }
}*/
