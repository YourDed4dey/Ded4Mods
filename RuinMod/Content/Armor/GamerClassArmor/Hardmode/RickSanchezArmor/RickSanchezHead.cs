/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;
using Terraria.Audio;
using Terraria.Localization;

namespace RuinMod.Content.Armor.GamerClassArmor.Hardmode.RickSanchezArmor
{
    [AutoloadEquip(EquipType.Head)]
    internal class RickSanchezHead : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Rick Sanchez Head");
            //Tooltip.SetDefault("15% increased gamer damage and critical strike chance");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
        }

        public override void SetDefaults() //Item Stats
        {
            Item.width = 36;
            Item.height = 30;
            Item.rare = ItemRarityID.Pink;
            Item.defense = 12;
            Item.wornArmor = true;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<RickSanchezBody>() && legs.type == ItemType<RickSanchezLegs>(); //What makes armor set bonus work
        }

        public override void UpdateArmorSet(Player player) //Armor set bonuses
        {
            //player.setBonus = "21% increased gamer damage";

            player.setBonus = Language.GetTextValue("Mods.RuinMod.ItemSetBonus.RickSanchezSet");
            player.GetDamage(GetInstance<Classes.GamerClass.GamerClassDamage>()) += 0.21f;
        }

        public override void UpdateEquip(Player player) //Individual armor piece bonus
        {
            player.GetDamage(GetInstance<Classes.GamerClass.GamerClassDamage>()) += 0.15f;
            player.GetCritChance(GetInstance<Classes.GamerClass.GamerClassDamage>()) += 0.15f;
        }
    }
}*/