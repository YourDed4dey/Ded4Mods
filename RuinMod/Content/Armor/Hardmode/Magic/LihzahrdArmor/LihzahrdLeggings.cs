/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;
using RuinMod.Content.Items.Drops.LihzahrdScale;
using RuinMod.Content.Items.Drops.EssencesOrSoulsOrFragments.Souls.SoulOfInertness;

namespace RuinMod.Content.Armor.Hardmode.Magic.LihzahrdArmor
{
    [AutoloadEquip(EquipType.Legs)]
    internal class LihzahrdLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Lihzahrd Leggings");
            //Tooltip.SetDefault("8% increased movement speed and magical damage");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 12;
            Item.rare = ItemRarityID.Yellow;
            Item.defense = 10;
            Item.wornArmor = true;
        }

        public override void UpdateEquip(Player player) //Individual armor piece bonus
        {
            player.GetDamage(DamageClass.Magic) += 0.08f;
            player.moveSpeed += 0.08f;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemType<LihzahrdScale>(), 10)
                .AddIngredient(ItemID.Bone, 25)
                .AddIngredient(ItemType<SoulOfInertness>(), 5)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}*/
