using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;
using RuinMod.Content.Classes.ShieldClass;

namespace RuinMod.Content.Armor.ShieldClassArmor.Hardmode.ProtectorArmor
{
    [AutoloadEquip(EquipType.Legs)]
    internal class ProtectorLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Protector Boots");
            //Tooltip.SetDefault("10% increased contact damage and critical strike chance\nIncreased contact damage armor penetration by 5\n8% increased movement speed");
            //CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 96;
            Item.height = 74;
            Item.rare = ItemRarityID.Pink;
            Item.defense = 13;
            Item.wornArmor = true;
        }

        public override void UpdateEquip(Player player) //Individual armor piece bonus
        {
            player.GetCritChance(ModContent.GetInstance<ShieldClassDamage>()) += 0.10f;
            player.GetDamage(ModContent.GetInstance<ShieldClassDamage>()) += 0.10f;
            player.GetArmorPenetration(ModContent.GetInstance<ShieldClassDamage>()) += 5f;
            player.stepSpeed += 0.08f;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.HallowedBar, 28)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}
