/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;
using Terraria.Audio;
using Terraria.Localization;
using RuinMod.Common.Systems;

namespace RuinMod.Content.Armor.GamerClassArmor.PreHardmode.SonicArmor
{
    [AutoloadEquip(EquipType.Head)]
    internal class SonicHead : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Sonic Head");
            //Tooltip.SetDefault("2% increased gamer damage\n25% increased movement speed");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;

            ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = false;
        }

        public override void SetDefaults() //Item Stats
        {
            Item.width = 22;
            Item.height = 18;
            Item.rare = ItemRarityID.Blue;
            Item.defense = 6;
            Item.wornArmor = true;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<SonicBody>() && legs.type == ItemType<SonicLegs>(); //What makes armor set bonus work
        }

        public override void UpdateArmorSet(Player player) //Armor set bonuses
        {
            //player.setBonus = "25% increased movement speed\nAllows the player to dash\nDouble tap a direction";
            player.setBonus = Language.GetTextValue("Mods.RuinMod.ItemSetBonus.SonicSet");
            player.moveSpeed += 0.25f;
            //player.GetModPlayer<RuinDashPlayer>().DashAccessoryEquipped = true;
        }

        public override void UpdateEquip(Player player) //Individual armor piece bonus
        {
            player.moveSpeed += 0.25f;
            player.GetDamage(GetInstance<Classes.GamerClass.GamerClassDamage>()) += 0.02f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.DemoniteBar, 15)
                .AddIngredient(ItemID.ShadowScale, 10)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}*/