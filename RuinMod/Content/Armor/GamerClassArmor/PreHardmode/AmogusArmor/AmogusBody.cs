/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;
using System.Threading;
using RuinMod.Content.Items.Placeables.TV;
using RuinMod.Content.Items.Placeables.TV.Tile;

namespace RuinMod.Content.Armor.GamerClassArmor.PreHardmode.AmogusArmor
{
    [AutoloadEquip(EquipType.Body)]
    internal class AmogusBody : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Amogus Body");
            //Tooltip.SetDefault("7% increased gamer damage");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()//Item stats
        {
            Item.width = 30;
            Item.height = 20;
            Item.rare = ItemRarityID.Orange;
            Item.defense = 8;
            Item.wornArmor = true;
        }

        public override void UpdateEquip(Player player)//Individual armor piece bonus
        {
            player.GetDamage(GetInstance<Classes.GamerClass.GamerClassDamage>()) += 0.07f;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.HellstoneBar, 18)
                .AddTile<TVTile>()
                .Register();
        }
    }
}*/
