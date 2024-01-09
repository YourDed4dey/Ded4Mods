/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;

namespace RuinMod.Content.Armor.Hardmode.Melee.DragonArmor
{
    [AutoloadEquip(EquipType.Body)]
    internal class DragonChestplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Dragon Chestplate");
            //Tooltip.SetDefault("10% increased critical strike chance\n5% increased melee damage");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()//Item stats
        {
            Item.width = 26;
            Item.height = 18;
            Item.rare = ItemRarityID.Yellow;
            Item.defense = 20;
            Item.wornArmor = true;
        }

        public override void UpdateEquip(Player player)//Individual armor piece bonus
        {
            player.GetDamage(DamageClass.Melee) += 0.05f;

            player.GetCritChance(DamageClass.Default) += 0.10f;
            player.GetCritChance(DamageClass.Generic) += 0.10f;
            player.GetCritChance(DamageClass.Melee) += 0.10f;
            player.GetCritChance(DamageClass.Magic) += 0.10f;
            player.GetCritChance(DamageClass.Ranged) += 0.10f;
            player.GetCritChance(DamageClass.Summon) += 0.10f;
            player.GetCritChance(GetInstance<Classes.GamerClass.GamerClassDamage>()) += 0.10f;
        }
    }
}*/
