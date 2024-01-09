/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;

namespace RuinMod.Content.Armor.Hardmode.Melee.TrueShadowArmor
{
    [AutoloadEquip(EquipType.Legs)]
    internal class TrueShadowLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("True Shadow Greaves");
            //Tooltip.SetDefault("25% increased movement speed");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 18;
            Item.rare = ItemRarityID.Yellow;
            Item.defense = 18;
            Item.wornArmor = true;
        }

        public override void UpdateEquip(Player player) //Individual armor piece bonus
        {
            player.moveSpeed += 0.25f;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.ShadowGreaves, 1)
                .AddIngredient(ItemID.SoulofFright, 5)
                .AddIngredient(ItemID.SoulofMight, 5)
                .AddIngredient(ItemID.SoulofSight, 5)
                .AddIngredient(ItemType<Items.Drops.EssencesOrSoulsOrFragments.Souls.SoulOfBlight.SoulOfBlight>(), 5)
                .AddTile(TileID.MythrilAnvil)
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.CrimsonGreaves, 1)
                .AddIngredient(ItemID.SoulofFright, 5)
                .AddIngredient(ItemID.SoulofMight, 5)
                .AddIngredient(ItemID.SoulofSight, 5)
                .AddIngredient(ItemType<Items.Drops.EssencesOrSoulsOrFragments.Souls.SoulOfBlight.SoulOfBlight>(), 5)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}*/
