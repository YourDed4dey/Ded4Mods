/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;

namespace RuinMod.Content.Armor.GamerClassArmor.Hardmode.SansArmor
{
    [AutoloadEquip(EquipType.Legs)]
    internal class SansLegs : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Sans Legs");
            //Tooltip.SetDefault("7% increased gamer damage and critical strike chance\n15% increased movement speed");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 38;
            Item.height = 14;
            Item.rare = ItemRarityID.Cyan;
            Item.defense = 12;
            Item.wornArmor = true;
        }

        public override void UpdateEquip(Player player) //Individual armor piece bonus
        {
            player.GetDamage(GetInstance<Classes.GamerClass.GamerClassDamage>()) += 0.07f;
            player.GetCritChance(GetInstance<Classes.GamerClass.GamerClassDamage>()) += 0.07f;
            player.moveSpeed += 0.15f;
        }
        public override void AddRecipes()
        {
            
        }
    }
}*/
