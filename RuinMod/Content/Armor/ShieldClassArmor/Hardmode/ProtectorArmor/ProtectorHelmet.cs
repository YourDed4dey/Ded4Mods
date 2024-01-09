using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using RuinMod.Content.Classes.ShieldClass;
using System;
using Microsoft.Xna.Framework;

namespace RuinMod.Content.Armor.ShieldClassArmor.Hardmode.ProtectorArmor
{
    [AutoloadEquip(EquipType.Head)]
    internal class ProtectorHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Protector Mask");
            //Tooltip.SetDefault("16% increased contact damage and critical strike chance\nIncreased contact damage armor penetration by 5");
            //CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
        }

        public override void SetDefaults() //Item Stats
        {
            Item.width = 32;
            Item.height = 40;
            Item.rare = ItemRarityID.Pink;
            Item.defense = 17;
            Item.wornArmor = true;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<ProtectorChestplate>() && legs.type == ItemType<ProtectorLeggings>(); //What makes armor set bonus work
        }

        public override void UpdateArmorSet(Player player) //Armor set bonuses
        {
            player.setBonus = Language.GetTextValue("Mods.RuinMod.ItemSetBonus.ProtectorSet"); // "Confuse enemies after being struck by them"

            for (int i = 0; i < 200; i++)
            {
                Rectangle rectangle = new Rectangle((int)(player.position.X + player.velocity.X * 0.5 - 4.0), (int)(player.position.Y + player.velocity.Y * 0.5 - 4.0), player.width + 8, player.height + 8);
                NPC nPC = Main.npc[i];
                if (!nPC.active || nPC.dontTakeDamage || nPC.friendly || nPC.aiStyle == 112 && !(nPC.ai[2] <= 1f) || !player.CanNPCBeHitByPlayerOrPlayerProjectile(nPC))
                {
                    continue;
                }
                Rectangle rect = nPC.getRect();
                if (rectangle.Intersects(rect) && (nPC.noTileCollide || player.CanHit(nPC)))
                {
                    if (player.whoAmI == Main.myPlayer)
                    {
                        nPC.AddBuff(type: BuffID.Confused, time: 60 * 15);
                    }
                }
            }
        }
        public override void UpdateEquip(Player player) //Individual armor piece bonus
        {
            player.GetCritChance(ModContent.GetInstance<ShieldClassDamage>()) += 0.16f;
            player.GetDamage(ModContent.GetInstance<ShieldClassDamage>()) += 0.16f;
            player.GetArmorPenetration(ModContent.GetInstance<ShieldClassDamage>()) += 5f;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.HallowedBar, 22)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}