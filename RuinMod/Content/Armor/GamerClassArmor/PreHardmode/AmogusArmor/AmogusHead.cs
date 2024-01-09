/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;
using Terraria.Audio;
using Terraria.Localization;
using RuinMod.Common.Systems;
using RuinMod.Content.Armor.GamerClassArmor.PreHardmode.SonicArmor;
using RuinMod.Content.Items.Placeables.TV.Tile;

namespace RuinMod.Content.Armor.GamerClassArmor.PreHardmode.AmogusArmor
{
    [AutoloadEquip(EquipType.Head)]
    internal class AmogusHead : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Amogus Head");
            //Tooltip.SetDefault("7% increased gamer damage\n4% increased gamer critical strike chance");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;

            ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = false;
        }

        public override void SetDefaults() //Item Stats
        {
            Item.width = 22;
            Item.height = 20;
            Item.rare = ItemRarityID.Orange;
            Item.defense = 8;
            Item.wornArmor = true;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<AmogusBody>() && legs.type == ItemType<AmogusPants>(); //What makes armor set bonus work
        }

        public override void UpdateArmorSet(Player player) //Armor set bonuses
        {
            //player.setBonus = "10% extra gamer damage";
            player.setBonus = Language.GetTextValue("Mods.RuinMod.ItemSetBonus.AmogusSet");
            player.GetDamage(GetInstance<Classes.GamerClass.GamerClassDamage>()) += 0.1f;
        }

        public override void UpdateEquip(Player player) //Individual armor piece bonus
        {
            player.GetDamage(GetInstance<Classes.GamerClass.GamerClassDamage>()) += 0.07f;
            player.GetCritChance(GetInstance<Classes.GamerClass.GamerClassDamage>()) += 4f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.HellstoneBar, 8)
                .AddTile<TVTile>()
                .Register();
        }
    }
}*/
