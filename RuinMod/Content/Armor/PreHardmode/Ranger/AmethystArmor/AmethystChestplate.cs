﻿/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;

namespace RuinMod.Content.Armor.PreHardmode.Ranger.AmethystArmor
{
    [AutoloadEquip(EquipType.Body)]
    internal class AmethystChestplate : ModItem
    {

        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Amethyst Chestplate");
            //Tooltip.SetDefault("8% increased ranged damage");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()//Item stats
        {
            Item.width = 34;
            Item.height = 24;
            Item.rare = ItemRarityID.Blue;
            Item.defense = 7;
            Item.wornArmor = true;
        }

        public override void UpdateEquip(Player player)//Individual armor piece bonus
        {
            player.GetDamage(DamageClass.Ranged) += 0.08f;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Amethyst, 8)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}*/
