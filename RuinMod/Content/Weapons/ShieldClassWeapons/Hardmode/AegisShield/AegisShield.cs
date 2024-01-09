using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using RuinMod.Content.Classes.ShieldClass;
using RuinMod.Content.Weapons.ShieldClassWeapons.Hardmode.HallowedShield;
//using RuinMod.Content.Items.Drops.EssencesOrSoulsOrFragments.Souls.SoulOfBlight;
using RuinMod.Common.Systems;
using Microsoft.Xna.Framework;
using RuinMod.Content.Potions.Debuffs.ShieldSickness;
using System.Collections.Generic;

namespace RuinMod.Content.Weapons.ShieldClassWeapons.Hardmode.AegisShield
{
    [AutoloadEquip(EquipType.Shield)]
    internal class AegisShield : ModItem
    {
        public bool HolyBuffIsTrue;
        int timer;
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Aegis Shield");
            //Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            Item.width = 42;
            Item.height = 46;
            Item.accessory = true;
            Item.rare = ItemRarityID.Pink;

            Item.damage = 47;
            Item.DamageType = GetInstance<ShieldClassDamage>();
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            var keys = RuinKeybinds.SpecialAbilityKeybind.GetAssignedKeys();
            string key = keys.Count == 0 ? "<NOT BOUND>" : keys[0];
            float DashKeys = AegisShieldDash.DashVelocity;
            int index = tooltips.FindIndex(tip => tip.Name.StartsWith("Tooltip"));
            if (index > -1)
            {
                tooltips.Insert(index, new(Mod, "KeybindTooltip", $"God persecutes enemies on hit\nPress '{key}' to activate Special Ability\n[c/FFFF00:Special Ability: Costs 150 mana and becomes immune]\n60 second cooldown\nCurrent Dash= {DashKeys}\n9 defense\nAllows the player to dash into the enemy\nDouble tap a direction"));
            }
            //tooltips.Insert(index, new(Mod, "KeybindTooltip", $"Press '{RuinKeybinds.SpecialAbilityKeybind.GetAssignedKeys()}' to activate Special Ability"));
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<AegisShieldDash>().DashAccessoryEquipped = true;
            player.statDefense += 9;

            if (player.whoAmI == Main.myPlayer)
            {
                if (RuinKeybinds.SpecialAbilityKeybind.JustPressed)
                {
                    if (player.statMana >= 150)
                    {
                        if (HolyBuffIsTrue == false)
                        {
                            player.AddBuff(type: BuffID.ShadowDodge, timeToAdd: 60 * 19);
                            player.statMana -= 150;
                            HolyBuffIsTrue = true;
                        }
                    }
                    else
                    {
                        player.AddBuff(ModContent.BuffType<Shield_Sickness>(), 60 * 10);
                    }
                }
            }
            if (HolyBuffIsTrue == true)
            {
                //if (timer == 0)
                //Player.AddBuff(type: BuffID.ShadowDodge, timeToAdd: 60 * 15);
                timer++;
                if (timer >= 60 * 60)
                {
                    timer = 0;
                    HolyBuffIsTrue = false;
                    Dust dust18 = Dust.NewDustDirect(new Vector2(player.position.X - 2f, player.position.Y - 2f), player.width + 4, player.height + 4, DustID.WhiteTorch, player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default(Color), 3.5f);
                    dust18.noGravity = true;
                    dust18.velocity.X = 1.8f;
                    dust18.velocity.Y -= 0.5f;
                }
            }
        }
        public override bool CanEquipAccessory(Player player, int slot, bool modded)
        {
            if (Item.shieldSlot > 0)
                return false;

            else
                return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemType<HallowedShield.HallowedShield>(), 1)
                .AddIngredient(ItemID.SoulofFright, 5)
                //.AddIngredient(ItemType<SoulOfBlight>(), 5)
                .AddTile(TileID.MythrilAnvil) //.AddTile(TileID.DemonAltar)
                .Register();
        }
    }
}
