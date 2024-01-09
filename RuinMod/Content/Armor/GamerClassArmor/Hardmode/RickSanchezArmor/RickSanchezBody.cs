/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;

namespace RuinMod.Content.Armor.GamerClassArmor.Hardmode.RickSanchezArmor
{
    [AutoloadEquip(EquipType.Body)]
    internal class RickSanchezBody : ModItem
    {
        public override void Load()
        {
            if (Main.netMode == NetmodeID.Server)
            {
                return;
            }
        }

        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Rick Sanchez Body");
            //Tooltip.SetDefault("5% increased gamer damage\r\n10% increased gamer critical strike chance");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()//Item stats
        {
            Item.width = 36;
            Item.height = 26;
            Item.rare = ItemRarityID.Pink;
            Item.defense = 17;
            Item.wornArmor = true;
        }

        public override void UpdateEquip(Player player)//Individual armor piece bonus
        {
            player.GetDamage(GetInstance<Classes.GamerClass.GamerClassDamage>()) += 0.05f;
            player.GetCritChance(GetInstance<Classes.GamerClass.GamerClassDamage>()) += 0.10f;
        }
    }
}*/
