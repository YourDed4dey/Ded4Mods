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
using RuinMod.Content.Items.Drops.CoreOfTheForsaken;
using RuinMod.Content.Items.Drops.EssencesOrSoulsOrFragments.Souls.SoulOfStruggle;
using RuinMod.Content.Weapons.MeleeWeapons.Hardmode.SwordOfSouls;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.ItemDropRules;


namespace RuinMod.Content.Weapons.MeleeWeapons.Hardmode.Yaquiturimisha
{
    internal class Yaquiturimisha : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Yaquiturimisha");
            //Tooltip.SetDefault("Shoots butterflies that follow your cursor (when cursor is close to the butterflies)\n'The peace reminds you of a rain of butterflies'");

            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 12)); // first it the amount of ticks per frame and second is the number of frames 
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
        }
        public override void SetDefaults()
        {
            Item.width = 60;
            Item.height = 60;
            Item.scale += 1f;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 8;
            Item.useAnimation = 8;

            Item.DamageType = DamageClass.Melee;
            Item.damage = 680;
            Item.crit = 995;
            Item.knockBack = 50f;
            Item.ArmorPenetration += 100;

            Item.shoot = ModContent.ProjectileType<Projectiles.NothingProjectile>();
            Item.shootSpeed = 10f;

            Item.rare = ItemRarityID.Purple;
            Item.UseSound = SoundID.Item1;
        }

        /*public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            position = Main.MouseWorld + new Vector2(Main.rand.Next(0, 0));

            type = Main.rand.Next(new int[] { type, ModContent.ProjectileType<YaquiturimishaButterflyBlue>(), ModContent.ProjectileType<YaquiturimishaButterflyGreen>(), ModContent.ProjectileType<YaquiturimishaButterflyOrange>(), ModContent.ProjectileType<YaquiturimishaButterflyPurple>(), ModContent.ProjectileType<YaquiturimishaButterflyRed>(), ModContent.ProjectileType<YaquiturimishaButterflyYellow>(), ModContent.ProjectileType<YaquiturimishaButterfly>() });
            Main.projectile[type].timeLeft = 60 * 10;
            Main.projectile[type].ArmorPenetration = 100;
            Main.projectile[type].owner = Main.myPlayer;
        }*/
        /*public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            float kitingOffsetX = Utils.Clamp(player.velocity.X * 16, -500, 500);
            position = player.Bottom + new Vector2(kitingOffsetX + Main.rand.Next(-500, 500), Main.rand.Next(-250, 250) + Main.rand.Next(-500, 500));
            type = Main.rand.Next(new int[] { type, ModContent.ProjectileType<YaquiturimishaButterflyBlue>(), ModContent.ProjectileType<YaquiturimishaButterflyGreen>(), ModContent.ProjectileType<YaquiturimishaButterflyOrange>(), ModContent.ProjectileType<YaquiturimishaButterflyPurple>(), ModContent.ProjectileType<YaquiturimishaButterflyRed>(), ModContent.ProjectileType<YaquiturimishaButterflyYellow>(), ModContent.ProjectileType<YaquiturimishaButterfly>() });
            Main.projectile[type].timeLeft = 60 * 10;
            Main.projectile[type].ArmorPenetration = 100;
            Main.projectile[type].owner = Main.myPlayer;
        }
        /*public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            //Vector2 position1 = Main.MouseWorld + new Vector2(Main.rand.Next(0, 0));

            int proj = Projectile.NewProjectile(null, position, velocity, ProjectileID.BoulderStaffOfEarth, damage, knockback, player.whoAmI);
            //Main.projectile[proj].position = Main.MouseWorld + new Vector2(Main.rand.Next(0, 0), Main.rand.Next(-500, -500)); Star fury type ism i guess (Change Main.MousWorld to player.Top and it may be like the starfury
            Main.projectile[proj].position = player.Center;

            return true;
        }*/

        /*public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<SoulOfStruggle>(), 15)
                .AddIngredient(ModContent.ItemType<SwordOfSouls.SwordOfSouls>())
                .AddIngredient(ModContent.ItemType<CoreOfTheForsaken>())
                .AddIngredient(ModContent.ItemType<YaquisButterfly>())
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }
}*/
