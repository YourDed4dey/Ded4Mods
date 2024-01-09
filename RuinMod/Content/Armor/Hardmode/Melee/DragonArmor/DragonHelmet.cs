/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;
using Terraria.Audio;
using Terraria.Localization;

namespace RuinMod.Content.Armor.Hardmode.Melee.DragonArmor
{
    [AutoloadEquip(EquipType.Head)]
    internal class DragonHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Dragon Helmet");
            //Tooltip.SetDefault("15% increased melee speed and damage\n15% increased critical strike chance");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
        }

        public override void SetDefaults() //Item Stats
        {
            Item.width = 30;
            Item.height = 26;
            Item.rare = ItemRarityID.Yellow;
            Item.defense = 26;
            Item.wornArmor = true;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<DragonChestplate>() && legs.type == ItemType<DragonLeggings>(); //What makes armor set bonus work
        }   
        public override void UpdateArmorSet(Player player) //Armor set bonuses
        {
            player.setBonus = Language.GetTextValue("Mods.RuinMod.ItemSetBonus.DragonSet");

            player.GetAttackSpeed(DamageClass.Melee) += 0.21f;

            player.moveSpeed += 0.21f;
        }

        public override void UpdateEquip(Player player) //Individual armor piece bonus
        {
            player.GetAttackSpeed(DamageClass.Melee) += 0.15f;
            player.GetDamage(DamageClass.Melee) += 0.15f;

            player.GetCritChance(DamageClass.Default) += 0.15f;
            player.GetCritChance(DamageClass.Generic) += 0.15f;
            player.GetCritChance(DamageClass.Melee) += 0.15f;
            player.GetCritChance(DamageClass.Magic) += 0.15f;
            player.GetCritChance(DamageClass.Ranged) += 0.15f;
            player.GetCritChance(DamageClass.Summon) += 0.15f;
            player.GetCritChance(GetInstance<Classes.GamerClass.GamerClassDamage>()) += 0.15f;
        }
    }
}*/