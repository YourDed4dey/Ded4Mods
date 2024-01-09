/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;

namespace RuinMod.Content.Armor.PreHardmode.Melee.DiamondArmor
{
    [AutoloadEquip(EquipType.Body)]
    internal class DiamondChestplate : ModItem
    {

        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Diamond Chestplate");
            //Tooltip.SetDefault("5% increased melee damage\n+5 defense");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()//Item stats
        {
            Item.width = 34;
            Item.height = 24;
            Item.rare = ItemRarityID.Blue;
            Item.defense = 7;
            Item.wornArmor = true;
        }

        public override void UpdateEquip(Player player)//Individual armor piece bonus
        {
            player.GetDamage(DamageClass.Melee) += 0.05f;
            player.statDefense += 5;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Diamond, 8)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}*/
