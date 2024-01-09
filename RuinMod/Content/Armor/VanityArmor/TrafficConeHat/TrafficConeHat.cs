using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;

namespace RuinMod.Content.Armor.VanityArmor.TrafficConeHat
{
    [AutoloadEquip(EquipType.Head)]
    internal class TrafficConeHat: ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Traffic Cone Hat");
            //Tooltip.SetDefault("'Meant to prevent accidents, repurposed to a hat.'");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 24;

            Item.rare = ItemRarityID.Blue;

            Item.vanity = true;
            Item.maxStack = 1;
        }
    }
}
