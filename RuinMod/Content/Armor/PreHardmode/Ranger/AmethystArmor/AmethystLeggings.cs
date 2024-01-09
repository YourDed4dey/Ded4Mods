/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;

namespace RuinMod.Content.Armor.PreHardmode.Ranger.AmethystArmor
{
    [AutoloadEquip(EquipType.Legs)]
    internal class AmethystLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Amethyst Leggings");
            //Tooltip.SetDefault("8% increased ranged damage\n15% increased movement speed");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 22;
            Item.rare = ItemRarityID.Blue;
            Item.defense = 7;
            Item.wornArmor = true;
        }

        public override void UpdateEquip(Player player) //Individual armor piece bonus
        {
            player.moveSpeed += 0.15f;
            player.GetDamage(DamageClass.Ranged) += 0.08f;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Amethyst, 8)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}*/
