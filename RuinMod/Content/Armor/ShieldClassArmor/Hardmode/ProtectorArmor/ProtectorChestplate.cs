using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;
using RuinMod.Content.Classes.ShieldClass;

namespace RuinMod.Content.Armor.ShieldClassArmor.Hardmode.ProtectorArmor
{
    [AutoloadEquip(EquipType.Body)]
    internal class ProtectorChestplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Protector Chestplate");
            //Tooltip.SetDefault("14% increased contact damage and critical strike chance\nIncreased contact damage armor penetration by 5");
            //CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()//Item stats
        {
            Item.width = 56;
            Item.height = 36;
            Item.rare = ItemRarityID.Pink;
            Item.defense = 22;
            Item.wornArmor = true;
        }

        public override void UpdateEquip(Player player)//Individual armor piece bonus
        {
            player.GetCritChance(ModContent.GetInstance<ShieldClassDamage>()) += 0.14f;
            player.GetDamage(ModContent.GetInstance<ShieldClassDamage>()) += 0.14f;
            player.GetArmorPenetration(ModContent.GetInstance<ShieldClassDamage>()) += 5f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.HallowedBar, 34)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}
