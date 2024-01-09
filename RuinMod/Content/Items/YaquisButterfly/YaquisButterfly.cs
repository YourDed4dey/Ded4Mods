/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using RuinMod.Content.Projectiles.MeleeProjectiles.YaquiturimishaButterfly;
using RuinMod.Content.Items.YaquisButterfly;
using RuinMod.Content.Items.Drops.EssencesOrSoulsOrFragments.Souls.SoulOfBlight;
using RuinMod.Content.Armor.GamerClassArmor.Hardmode.RickSanchezArmor;
using RuinMod.Content.Weapons.GamerClassWeapons.Hardmode.RaygunMKII;
using RuinMod.Content.Armor.Accesories.GamerClassAccesories.Hardmode.GamingEmblem;
using RuinMod.Content.Classes.GamerClass;
using static Terraria.ModLoader.ModContent;


namespace RuinMod.Content.Items.YaquisButterfly
{
    internal class YaquisButterfly : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Yaqui's Butterfly");
            //Tooltip.SetDefault("27% increased melee, gamer, ranged, and magic damage\n12% increased melee, gamer, ranged, and magic critical strike chance\n122% increased summon damage and critical strike chance\n20% chance to not consume ammo\n12% increased melee knockback\nIncreased life regeneration\nProvides same effects as a mana flower\n\n84 defense\n+4 max minions");

            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 12));
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
            ItemID.Sets.ItemIconPulse[Item.type] = true;
            ItemID.Sets.ItemNoGravity[Item.type] = true;
        }
        public override void SetDefaults()
        {
            Item.width = 50;
            Item.height = 38;

            Item.accessory = true;
            Item.rare = ItemRarityID.Purple;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Ranged) += 0.27f;
            player.GetCritChance(DamageClass.Ranged) += 0.12f;

            player.ammoCost80 = true;

            //

            player.GetDamage(GetInstance<GamerClassDamage>()) += 0.27f;
            player.GetCritChance(GetInstance<GamerClassDamage>()) += 0.12f;

            //

            player.GetDamage(DamageClass.Magic) += 0.27f;
            player.GetCritChance(DamageClass.Magic) += 0.12f;

            player.manaFlower = true;

            //

            player.GetDamage(DamageClass.Melee) += 0.27f;
            player.GetCritChance(DamageClass.Melee) += 0.12f;

            player.lifeRegen += 15;

            //

            player.GetKnockback(DamageClass.Melee) += 0.12f;

            player.GetDamage(DamageClass.Summon) += 1.22f;
            player.GetCritChance(DamageClass.Summon) += 1.22f;

            player.maxMinions += 4;
            player.numMinions += 4;
            player.slotsMinions += 4;

            player.statDefense += 84;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.SoulofFright, 15)
                .AddIngredient(ItemID.SoulofMight, 15)
                .AddIngredient(ItemType<SoulOfBlight>(), 15)
                .AddIngredient(ItemID.SoulofSight, 15)
                .AddIngredient(ItemType<YaquisRedButterfly>()) //Done
                .AddIngredient(ItemType<YaquisPurpleButterfly>()) //Done
                .AddIngredient(ItemType<YaquisOrangeButterfly>()) //Done
                .AddIngredient(ItemType<YaquisGreenButterfly>()) //Done
                .AddIngredient(ItemType<YaquisBlueButterfly>()) //Done
                .AddIngredient(ItemType<YaquisYellowButterfly>()) //Done
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}*/
