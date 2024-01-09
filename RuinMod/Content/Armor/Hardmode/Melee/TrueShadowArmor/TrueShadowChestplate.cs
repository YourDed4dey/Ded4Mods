/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;

namespace RuinMod.Content.Armor.Hardmode.Melee.TrueShadowArmor
{
    [AutoloadEquip(EquipType.Body)]
    internal class TrueShadowChestplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("True Shadow Scalemail");
            //Tooltip.SetDefault("10% increased critical strike chance");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()//Item stats
        {
            Item.width = 26;
            Item.height = 18;
            Item.rare = ItemRarityID.Yellow;
            Item.defense = 18;
            Item.wornArmor = true;
        }

        public override void UpdateEquip(Player player)//Individual armor piece bonus
        {
            player.GetCritChance(DamageClass.Default) += 0.10f;
            player.GetCritChance(DamageClass.Generic) += 0.10f;
            player.GetCritChance(DamageClass.Melee) += 0.10f;
            player.GetCritChance(DamageClass.Magic) += 0.10f;
            player.GetCritChance(DamageClass.Ranged) += 0.10f;
            player.GetCritChance(DamageClass.Summon) += 0.10f;
            player.GetCritChance(GetInstance<Classes.GamerClass.GamerClassDamage>()) += 0.10f;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.ShadowScalemail, 1)
                .AddIngredient(ItemID.SoulofFright, 10)
                .AddIngredient(ItemID.SoulofMight, 10)
                .AddIngredient(ItemID.SoulofSight, 10)
                .AddIngredient(ItemType<Items.Drops.EssencesOrSoulsOrFragments.Souls.SoulOfBlight.SoulOfBlight>(), 10)
                .AddTile(TileID.MythrilAnvil)
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.CrimsonScalemail, 1)
                .AddIngredient(ItemID.SoulofFright, 10)
                .AddIngredient(ItemID.SoulofMight, 10)
                .AddIngredient(ItemID.SoulofSight, 10)
                .AddIngredient(ItemType<Items.Drops.EssencesOrSoulsOrFragments.Souls.SoulOfBlight.SoulOfBlight>(), 10)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}*/
