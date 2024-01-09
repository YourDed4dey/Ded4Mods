/*using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.ID;
using System.Linq;
using Microsoft.Xna.Framework;
namespace RuinMod.Content.Armor.Accesories.ChainClassAccesories.Hardmode.DarkMatterWings
{
    [AutoloadEquip(EquipType.Wings)]
    internal class DarkMatterWings : ModItem
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModContent.GetInstance<Common.RuinModConfig>().RuinModWingsToggle;
        }
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Dark Matter Wings");
            //Tooltip.SetDefault("Allows flight and slow fall");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

            ArmorIDs.Wing.Sets.Stats[Item.wingSlot] = new (180, 9f, 2.5f);
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 28;

            Item.rare = ItemRarityID.Red;
            Item.value = Item.buyPrice(gold: 5, silver: 33, copper: 33);
            Item.accessory = true;

        }
        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
            ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            ascentWhenFalling = 0.85f; // Falling glide speed
            ascentWhenRising = 0.15f; // Rising speed
            maxCanAscendMultiplier = 1f;
            maxAscentMultiplier = 3f;
            constantAscend = 0.135f;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<Content.Items.FragmentOfCosmos.FragmentOfCosmos>(), 14)
                .AddIngredient(ItemID.LunarBar, 10)
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }
}*/
