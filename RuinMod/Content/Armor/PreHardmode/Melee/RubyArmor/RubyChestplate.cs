/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;

namespace RuinMod.Content.Armor.PreHardmode.Melee.RubyArmor
{
    [AutoloadEquip(EquipType.Body)]
    internal class RubyChestplate : ModItem
    {

        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Ruby Chestplate");
            //Tooltip.SetDefault("14% increased melee damage");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()//Item stats
        {
            Item.width = 34;
            Item.height = 24;
            Item.rare = ItemRarityID.Blue;
            Item.defense = 8;
            Item.wornArmor = true;
        }

        public override void UpdateEquip(Player player)//Individual armor piece bonus
        {
            player.GetDamage(DamageClass.Melee) += 0.14f;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Ruby, 8)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}*/
