/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;

namespace RuinMod.Content.Armor.Hardmode.Melee.DragonArmor
{
    [AutoloadEquip(EquipType.Legs)]
    internal class DragonLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Dragon Leggings");
            //Tooltip.SetDefault("12% increased movement speed\r\n2% increased melee speed");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 18;
            Item.rare = ItemRarityID.Yellow;
            Item.defense = 14;
            Item.wornArmor = true;
        }

        public override void UpdateEquip(Player player) //Individual armor piece bonus
        {
            player.GetAttackSpeed(DamageClass.Melee) += 0.02f;

            player.moveSpeed += 0.12f;
        }
    }
}*/
