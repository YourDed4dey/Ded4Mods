/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;

namespace RuinMod.Content.Armor.GamerClassArmor.Hardmode.RickSanchezArmor
{
    [AutoloadEquip(EquipType.Legs)]
    internal class RickSanchezLegs : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Rick Sanchez Legs");
            //Tooltip.SetDefault("10% increased gamer damage\r\n12% increased movement speed");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 20;
            Item.rare = ItemRarityID.Pink;
            Item.defense = 17;
            Item.wornArmor = true;
        }

        public override void UpdateEquip(Player player) //Individual armor piece bonus
        {
            player.GetDamage(GetInstance<Classes.GamerClass.GamerClassDamage>()) += 0.1f;
            player.moveSpeed += 0.12f;
        }
    }
}*/
