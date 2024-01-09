using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using RuinMod.Content.Classes.ShieldClass;
using System;
using Microsoft.Xna.Framework;
using RuinMod.Content.Potions.Buffs.RoyalGuard;
using RuinMod.Content.Projectiles;
using RuinMod.Content.Items.Drops.EssencesOrSoulsOrFragments.Fragments.FaithfulFragment;

namespace RuinMod.Content.Armor.ShieldClassArmor.Endgame.RoyalGuardArmor
{
    [AutoloadEquip(EquipType.Head)]
    internal class RoyalGuardMask : ModItem
    {
        public bool Friend;
        int timer;
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Royal Guard Mask");
            //Tooltip.SetDefault("25% increased contact damage and critical strike chance\nIncreased contact damage armor penetration by 10\nEnemies are less likely to target you");
            //CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
        }

        public override void SetDefaults() //Item Stats
        {
            Item.width = 30;
            Item.height = 44;
            Item.rare = ItemRarityID.Red;
            Item.defense = 28;
            Item.wornArmor = true;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<RoyalGuardBreastplate>() && legs.type == ItemType<RoyalGuardGreaves>(); //What makes armor set bonus work
        }

        public override void UpdateArmorSet(Player player) //Armor set bonuses
        {
            player.setBonus = Language.GetTextValue("Mods.RuinMod.ItemSetBonus.RoyalGuardSet"); // "’The king blesses you.’\nYou obtain the “Royal Guard” effect."
            player.AddBuff(ModContent.BuffType<RoyalGuardBuff>(), timeToAdd: 1);
            for (int i = 0; i < 200; i++)
            {
                Rectangle rectangle = new Rectangle((int)(player.position.X + player.velocity.X * 0.5 - 4.0), (int)(player.position.Y + player.velocity.Y * 0.5 - 4.0), player.width + 8, player.height + 8);
                NPC nPC = Main.npc[i];
                Projectile pROJ = Main.projectile[i];
                if (!nPC.active || nPC.dontTakeDamage || nPC.friendly || nPC.aiStyle == 112 && !(nPC.ai[2] <= 1f) || !player.CanNPCBeHitByPlayerOrPlayerProjectile(nPC))
                {
                    continue;
                }
                Rectangle rect = nPC.getRect();
                if (rectangle.Intersects(rect) && (nPC.noTileCollide || player.CanHit(nPC)))
                {
                    if (player.whoAmI == Main.myPlayer)
                    {
                        if (Friend == false)
                        {
                            if (nPC.boss == false)
                            {
                                nPC.friendly = true;
                                Friend = true;
                            }
                        }
                    }
                }
            }
            if (Friend == true)
            {
                timer++;
                if (timer >= 60 * 10) //15
                {
                    timer = 0;
                    Friend = false;
                    Dust dust18 = Dust.NewDustDirect(new Vector2(player.position.X - 2f, player.position.Y - 2f), player.width + 4, player.height + 4, DustID.WhiteTorch, player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default(Color), 3.5f);
                    dust18.noGravity = true;
                    dust18.velocity.X = 1.8f;
                    dust18.velocity.Y -= 0.5f;
                }
            }

        }
        public override void UpdateEquip(Player player) //Individual armor piece bonus
        {
            player.GetCritChance(ModContent.GetInstance<ShieldClassDamage>()) += 0.25f;
            player.GetDamage(ModContent.GetInstance<ShieldClassDamage>()) += 0.25f;
            player.GetArmorPenetration(ModContent.GetInstance<ShieldClassDamage>()) += 10f;
            player.aggro -= 200; //Enemies are less likely to target you
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.LunarBar, 18)
                .AddIngredient(ModContent.ItemType<FaithfulFragment>(), 15)
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }
}