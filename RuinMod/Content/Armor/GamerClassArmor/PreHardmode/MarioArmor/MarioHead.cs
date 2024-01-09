/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;
using Terraria.Audio;
using Terraria.Localization;

namespace RuinMod.Content.Armor.GamerClassArmor.PreHardmode.MarioArmor
{
    [AutoloadEquip(EquipType.Head)]
    internal class MarioHead : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Mario Head");
            //Tooltip.SetDefault("2% increased gamer damage\n25% increased movement speed");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;

            ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = false;
        }

        public override void SetDefaults() //Item Stats
        {
            Item.width = 22;
            Item.height = 14;
            Item.rare = ItemRarityID.Blue;
            Item.defense = 6;
            Item.wornArmor = true;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<MarioBody>() && legs.type == ItemType<MarioLegs>(); //What makes armor set bonus work
        }

        public override void UpdateArmorSet(Player player) //Armor set bonuses
        {
            //player.setBonus = "4% increased gamer damage\nGreatly increased life regen";
            player.setBonus = Language.GetTextValue("Mods.RuinMod.ItemSetBonus.MarioSet");
            player.GetDamage(GetInstance<Classes.GamerClass.GamerClassDamage>()) += 0.04f;
            player.crimsonRegen = true;
        }

        public override void UpdateEquip(Player player) //Individual armor piece bonus
        {
            player.moveSpeed += 0.25f;
            player.GetDamage(GetInstance<Classes.GamerClass.GamerClassDamage>()) += 0.02f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.CrimtaneBar, 15)
                .AddIngredient(ItemID.TissueSample, 10)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}*/