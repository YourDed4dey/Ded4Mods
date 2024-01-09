/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;
using RuinMod.Content.Items.Drops.LihzahrdScale;
using RuinMod.Content.Items.Drops.EssencesOrSoulsOrFragments.Souls.SoulOfInertness;

namespace RuinMod.Content.Armor.Hardmode.Magic.LihzahrdArmor
{
    [AutoloadEquip(EquipType.Body)]
    internal class LihzahrdChestplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Lihzahrd Chestplate");
            //Tooltip.SetDefault("8% increased magical damage and critical strike chance");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()//Item stats
        {
            Item.width = 34;
            Item.height = 30;
            Item.rare = ItemRarityID.Yellow;
            Item.defense = 20;
            Item.wornArmor = true;
        }

        public override void UpdateEquip(Player player)//Individual armor piece bonus
        {
            player.GetDamage(DamageClass.Magic) += 0.08f;
            player.GetCritChance(DamageClass.Magic) += 0.08f;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemType<LihzahrdScale>(), 15)
                .AddIngredient(ItemID.Bone, 25)
                .AddIngredient(ItemType<SoulOfInertness>(), 5)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}*/
