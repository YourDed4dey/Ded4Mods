using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;

namespace RuinMod.Content.Armor.Hardmode.Magic.SpectralArmor
{
    [AutoloadEquip(EquipType.Body)]
    internal class SpectralArmor : ModItem
    {
        public override void Load()
        {
            if (Main.netMode == NetmodeID.Server)
            {
                return;
            }
            EquipLoader.AddEquipTexture(Mod, $"{Texture}_{EquipType.Legs}", EquipType.Legs, this);
        }

        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Spectral Armor");
            //Tooltip.SetDefault("5% increased magical damage,\n10% reduced mana usage\r\n10% increased magical critical strike chance");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()//Item stats
        {
            Item.width = 24;
            Item.height = 22;
            Item.rare = ItemRarityID.Pink;
            Item.defense = 15;
            Item.wornArmor = true;
        }
        public override void SetMatch(bool male, ref int equipSlot, ref bool robes)
        {
            robes = true;
            equipSlot = EquipLoader.GetEquipSlot(Mod, Name, EquipType.Legs);
        }

        public override void UpdateEquip(Player player)//Individual armor piece bonus
        {
            player.GetDamage(DamageClass.Magic) += 0.05f;
            player.manaCost -= 0.1f;
            player.GetCritChance(DamageClass.Magic) += 0.1f;
        }
    }
}
