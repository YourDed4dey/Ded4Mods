/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;

namespace RuinMod.Content.Potions.SoulPotion
{
    internal class SoulPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Soul Potion");
            //Tooltip.SetDefault("Grants immortality\n'Is it really worth it?'\n(Quick Healing wont enable the 'Soul Manipulation' buff, you have to do it with your main hand or by Quick buffing)");
        }
        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 32;
            Item.maxStack = 30;
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item3;

            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;

            Item.buffType = ModContent.BuffType<Content.Potions.Buffs.SoulBuff.SoulBuff>();
            Item.buffTime = 60 * 15; //5 seconds

            Item.autoReuse = true;
            Item.consumable = true;
        }
        //public override bool CanUseItem(Player player)
        //{
        //   player.AddBuff(ModContent.BuffType<Content.Items.Potions.Buffs.SoulBuff>(), timeToAdd: 60 * 5); //5 seconds      //Makes having item in inv give buff (etc) to player.

        //   return true;
        //}
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.BottledWater, 1)
                //.AddIngredient(ItemID.FragmentSolar, 15)
                //.AddIngredient(ItemID.FragmentNebula, 15)
                //.AddIngredient(ItemID.FragmentStardust, 15)
                //.AddIngredient(ItemID.FragmentVortex, 15)
                //.AddIngredient(ItemID.SoulofFlight, 15)
                .AddIngredient(ItemID.SoulofFright, 15)
                //.AddIngredient(ItemID.SoulofLight, 15)
                .AddIngredient(ItemID.SoulofMight, 15)
                //.AddIngredient(ItemID.SoulofNight, 15)
                .AddIngredient(ItemID.SoulofSight, 15)
                .AddIngredient(ModContent.ItemType<Items.Drops.EssencesOrSoulsOrFragments.Souls.SoulOfBlight.SoulOfBlight>(), 15)
                //.AddIngredient(ModContent.ItemType<Content.Items.EssenceOfDeath.EssenceOfDeath>(), 15)
                //.AddIngredient(ModContent.ItemType<Items.Drops.EssencesOrSoulsOrFragments.Essences.DarkEssence.DarkEssence>(), 15)
                .AddIngredient(ItemID.LifeCrystal, 3)
                //.AddIngredient(ItemID.LifeFruit, 15)
                //.AddIngredient(ModContent.ItemType<Consumables.HeartOfDarkness.HeartOfDarkness>(),15)
                .AddIngredient(ItemID.LifeforcePotion, 5)
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }
}*/
