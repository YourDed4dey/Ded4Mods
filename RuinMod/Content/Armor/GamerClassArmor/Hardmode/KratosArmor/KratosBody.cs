/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;

namespace RuinMod.Content.Armor.GamerClassArmor.Hardmode.KratosArmor
{
    [AutoloadEquip(EquipType.Body)]
    internal class KratosBody : ModItem
    {

        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Kratos Body");
            //Tooltip.SetDefault("15% increased gamer damage");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()//Item stats
        {
            Item.width = 42;
            Item.height = 22;
            Item.rare = ItemRarityID.Red;
            Item.defense = 45;
            Item.wornArmor = true;
        }

        public override void UpdateEquip(Player player)//Individual armor piece bonus
        {
            player.GetDamage(GetInstance<Classes.GamerClass.GamerClassDamage>()) += 0.15f;
        }

        public override void AddRecipes()
        {

        }
    }
}*/
