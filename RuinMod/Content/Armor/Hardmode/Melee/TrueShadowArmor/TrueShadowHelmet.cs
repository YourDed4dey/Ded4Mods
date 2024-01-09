/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;
using Terraria.Audio;
using Terraria.Localization;

namespace RuinMod.Content.Armor.Hardmode.Melee.TrueShadowArmor
{
    [AutoloadEquip(EquipType.Head)]
    internal class TrueShadowHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("True Shadow Helmet");
            //Tooltip.SetDefault("15% increased melee speed and damage\n15% increased critical strike chance");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
        }

        public override void SetDefaults() //Item Stats
        {
            Item.width = 24;
            Item.height = 26;
            Item.rare = ItemRarityID.Yellow;
            Item.defense = 18;
            Item.wornArmor = true;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<TrueShadowChestplate>() && legs.type == ItemType<TrueShadowLeggings>(); //What makes armor set bonus work
        }

        public override void UpdateArmorSet(Player player) //Armor set bonuses
        {
            //player.setBonus = "\nGreatly increased life regen\nGrants immunity to most debuffs debuffs";

            player.setBonus = Language.GetTextValue("Mods.RuinMod.ItemSetBonus.TrueShadowSet");

            player.crimsonRegen = true;

            player.lifeRegen += 50;

            player.buffImmune[BuffID.Poisoned] = true;

            player.buffImmune[BuffID.Darkness] = true;

            player.buffImmune[BuffID.Cursed] = true;

            player.buffImmune[BuffID.OnFire] = true;
            player.buffImmune[BuffID.OnFire3] = true;

            player.buffImmune[BuffID.Bleeding] = true;

            player.buffImmune[BuffID.Confused] = true;

            player.buffImmune[BuffID.Slow] = true;

            player.buffImmune[BuffID.Weak] = true;

            player.buffImmune[BuffID.Silenced] = true;

            player.buffImmune[BuffID.BrokenArmor] = true;

            //player.buffImmune[BuffID.Horrified] = true;

            //player.buffImmune[BuffID.TheTongue] = true;

            player.buffImmune[BuffID.CursedInferno] = true;

            player.buffImmune[BuffID.Frostburn] = true;
            player.buffImmune[BuffID.Frostburn2] = true;

            player.buffImmune[BuffID.Chilled] = true;

            player.buffImmune[BuffID.Frozen] = true;

            player.buffImmune[BuffID.Ichor] = true;

            player.buffImmune[BuffID.Venom] = true;

            player.buffImmune[BuffID.Blackout] = true;

            player.buffImmune[BuffID.Electrified] = true;

            player.buffImmune[BuffID.VortexDebuff] = true;

            //player.buffImmune[BuffID.MoonLeech] = true;

            player.buffImmune[BuffID.Rabies] = true;

            player.buffImmune[BuffID.Webbed] = true;

            player.buffImmune[BuffID.Stoned] = true;

            player.buffImmune[BuffID.Obstructed] = true;

            player.buffImmune[BuffID.WitheredArmor] = true;

            player.buffImmune[BuffID.WitheredWeapon] = true;

            player.buffImmune[BuffID.Burning] = true;
        }

        public override void UpdateEquip(Player player) //Individual armor piece bonus
        {
            player.GetDamage(DamageClass.Melee) += 0.15f;

            player.GetCritChance(DamageClass.Default) += 0.15f;
            player.GetCritChance(DamageClass.Generic) += 0.15f;
            player.GetCritChance(DamageClass.Melee) += 0.15f;
            player.GetCritChance(DamageClass.Magic) += 0.15f;
            player.GetCritChance(DamageClass.Ranged) += 0.15f;
            player.GetCritChance(DamageClass.Summon) += 0.15f;
            player.GetCritChance(GetInstance<Classes.GamerClass.GamerClassDamage>()) += 0.15f;

            player.GetAttackSpeed(DamageClass.Melee) += 0.15f;

        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.ShadowHelmet, 1)
                .AddIngredient(ItemID.SoulofFright, 5)
                .AddIngredient(ItemID.SoulofMight, 5)
                .AddIngredient(ItemID.SoulofSight, 5)
                .AddIngredient(ItemType<Items.Drops.EssencesOrSoulsOrFragments.Souls.SoulOfBlight.SoulOfBlight>(), 5)
                .AddTile(TileID.MythrilAnvil)
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.CrimsonHelmet, 1)
                .AddIngredient(ItemID.SoulofFright, 5)
                .AddIngredient(ItemID.SoulofMight, 5)
                .AddIngredient(ItemID.SoulofSight, 5)
                .AddIngredient(ItemType<Items.Drops.EssencesOrSoulsOrFragments.Souls.SoulOfBlight.SoulOfBlight>(), 5)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}*/