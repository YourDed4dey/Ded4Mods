/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;

namespace RuinMod.Content.Armor.GamerClassArmor.Hardmode.SansArmor
{
    [AutoloadEquip(EquipType.Body)]
    internal class SansBody : ModItem
    {

        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Sans Body");
            //Tooltip.SetDefault("13% increased gamer damage and critical strike chance\n20% increased movement speed");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()//Item stats
        {
            Item.width = 46;
            Item.height = 20;
            Item.rare = ItemRarityID.Cyan;
            Item.defense = 27;
            Item.wornArmor = true;
        }

        public override void UpdateEquip(Player player)//Individual armor piece bonus
        {
            player.GetDamage(GetInstance<Classes.GamerClass.GamerClassDamage>()) += 0.13f;
            player.GetCritChance(GetInstance<Classes.GamerClass.GamerClassDamage>()) += 0.13f;
            player.moveSpeed += 0.2f;
        }

        public override void AddRecipes()
        {
            
        }
    }
}*/
