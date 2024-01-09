/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;

namespace RuinMod.Content.Items.Drops.EssencesOrSoulsOrFragments.Essences.EssenceOfDeath;

internal class EssenceOfDeath : ModItem
{
    public override void SetStaticDefaults()
    {
        //DisplayName.SetDefault("Essence of Death");
        //Tooltip.SetDefault("'The reincarnation of death right in your hands'");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
        ItemID.Sets.SortingPriorityMaterials[Type] = 69;

        Main.RegisterItemAnimation(Item.type, new DrawAnimation());
        Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 4)); //What makes animation work, using Terraria.DataStructures; needed for it to work

        ItemID.Sets.AnimatesAsSoul[Item.type] = true;
        ItemID.Sets.ItemIconPulse[Item.type] = true;
        ItemID.Sets.ItemNoGravity[Item.type] = true;
    }


    public override void SetDefaults()
    {
        Item.width = 22;
        Item.height = 28;
        Item.maxStack = 999;
        Item.CloneDefaults(ItemID.SoulofFright);

        Item.rare = ItemRarityID.Pink;
        Item.value = 0;
    }
}*/

