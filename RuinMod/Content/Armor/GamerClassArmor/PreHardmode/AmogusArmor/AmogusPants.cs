/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;
using RuinMod.Content.Items.Placeables.TV.Tile;

namespace RuinMod.Content.Armor.GamerClassArmor.PreHardmode.AmogusArmor
{
    [AutoloadEquip(EquipType.Legs)]
    internal class AmogusPants : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Amogus Pants");
            //Tooltip.SetDefault("7% increased gamer damage");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

            ArmorIDs.Legs.Sets.OverridesLegs[Item.legSlot] = true;
        }

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 12;
            Item.rare = ItemRarityID.Orange;
            Item.defense = 8;
            Item.wornArmor = true;
        }

        public override void UpdateEquip(Player player) //Individual armor piece bonus
        {
            player.GetDamage(GetInstance<Classes.GamerClass.GamerClassDamage>()) += 0.07f;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.HellstoneBar, 13)
                .AddTile<TVTile>()
                .Register();
        }
    }
}*/
