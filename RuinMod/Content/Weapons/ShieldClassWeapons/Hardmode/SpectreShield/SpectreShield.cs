using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using RuinMod.Content.Classes.ShieldClass;
//using RuinMod.Content.Weapons.ShieldClassWeapons.PreHardmode.ReinforcedGem;
using RuinMod.Common;
using RuinMod.Common.Systems;
using System.Collections.Generic;
using System.Linq;
using RuinMod.Content.Potions.Debuffs.ShieldSickness;
using RuinMod.Content.Projectiles.ShieldClass.LavaShield;
using RuinMod.Content.Potions.Buffs.BlueDemon;
using Microsoft.Xna.Framework;

namespace RuinMod.Content.Weapons.ShieldClassWeapons.Hardmode.SpectreShield
{
    [AutoloadEquip(EquipType.Shield)]
    internal class SpectreShield : ModItem
    {
        public bool DemonBuffIsTrue;
        int timer;
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Spectre Shield");
            //Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            Item.width = 42;
            Item.height = 46;
            Item.accessory = true;
            Item.rare = ItemRarityID.Yellow;

            Item.damage = 55;
            Item.DamageType = GetInstance<ShieldClassDamage>();
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            var keys = RuinKeybinds.SpecialAbilityKeybind.GetAssignedKeys();
            string key = keys.Count == 0 ? "<NOT BOUND>" : keys[0];
            float DashKeys = SpectreShieldDash.DashVelocity;
            int index = tooltips.FindIndex(tip => tip.Name.StartsWith("Tooltip"));
            if (index > -1)
            {
                tooltips.Insert(index, new(Mod, "KeybindTooltip", $"Press '{key}' to activate Special Ability\n[c/FFFF00:Special Ability: Costs 180 mana and increases player contact damage by 180% for 18 seconds]\n60 second cooldown\nCurrent Dash= {DashKeys}\n8 defense\nAllows the player to dash into the enemy\nDouble tap a direction"));
            }
            //tooltips.Insert(index, new(Mod, "KeybindTooltip", $"Press '{RuinKeybinds.SpecialAbilityKeybind.GetAssignedKeys()}' to activate Special Ability"));
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            //RuinPlayer.SpectreShieldSpecial = true;
            player.GetModPlayer<SpectreShieldDash>().DashAccessoryEquipped = true;
            player.statDefense += 8;

            if (player.whoAmI == Main.myPlayer)
            {
                if (RuinKeybinds.SpecialAbilityKeybind.JustPressed)
                {
                    if (player.statMana >= 180)
                    {
                        if (DemonBuffIsTrue == false)
                        {
                            DemonBuffIsTrue = true;
                            player.statMana -= 180;
                            player.AddBuff(ModContent.BuffType<BlueDemonBuff>(), timeToAdd: 60 * 19);
                        }
                    }
                    else
                    {
                        player.AddBuff(ModContent.BuffType<Shield_Sickness>(), 60 * 10);
                    }
                }
            }
            if (DemonBuffIsTrue == true)
            {
                timer++;
                if (timer >= 60 * 60)
                {
                    timer = 0;
                    DemonBuffIsTrue = false;
                    Dust dust18 = Dust.NewDustDirect(new Microsoft.Xna.Framework.Vector2(player.position.X - 2f, player.position.Y - 2f), player.width + 4, player.height + 4, DustID.WhiteTorch, player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default(Color), 3.5f);
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
                .AddIngredient(ItemID.SpectreBar, 15)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}
