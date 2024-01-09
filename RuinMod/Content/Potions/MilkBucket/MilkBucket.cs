/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using RuinMod.Content.Potions.Buffs.MilkBuff;

namespace RuinMod.Content.Potions.MilkBucket
{
    internal class MilkBucket : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Milk Bucket");
            //Tooltip.SetDefault("Removes all Vanilla Debuffs");
        }
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 26;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item3;

            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;

            Item.buffType = ModContent.BuffType<MilkBuff>();
            Item.buffTime = 60 * 1; //5 seconds

            Item.autoReuse = true;
            Item.consumable = true;
        }
        //public override bool CanUseItem(Player player)
        //{
        //   player.AddBuff(ModContent.BuffType<Content.Items.Potions.Buffs.SoulBuff>(), timeToAdd: 60 * 5); //5 seconds      //Makes having item in inv give buff (etc) to player.

        //   return true;
        //}
    }
}*/
