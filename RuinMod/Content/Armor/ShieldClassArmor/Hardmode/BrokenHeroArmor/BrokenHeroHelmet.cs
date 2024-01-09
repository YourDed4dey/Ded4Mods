using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;
using Terraria.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria.ModLoader.IO;
using Mono.Cecil;
using Terraria.DataStructures;
using Terraria.Localization;
using RuinMod.Common.Systems;
using static Terraria.ModLoader.PlayerDrawLayer;
using RuinMod.Content.Projectiles.ShieldClass.MiniMothronBaby;
using RuinMod.Content.Classes.ShieldClass;

namespace RuinMod.Content.Armor.ShieldClassArmor.Hardmode.BrokenHeroArmor
{
    [AutoloadEquip(EquipType.Head)]
    internal class BrokenHeroHelmet : ModItem
    {
        public bool Egg;
        int timer;
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Broken Hero Mask");
            //Tooltip.SetDefault("18% increased contact damage and critical strike chance\nIncreased contact damage armor penetration by 6");
            //CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
        }

        public override void SetDefaults() //Item Stats
        {
            Item.width = 44;
            Item.height = 56;
            Item.rare = ItemRarityID.Yellow;
            Item.defense = 25;
            Item.wornArmor = true;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<BrokenHeroChestplate>() && legs.type == ItemType<BrokenHeroLeggings>(); //What makes armor set bonus work
        }
        public override void UpdateArmorSet(Player player) //Armor set bonuses
        {
            player.setBonus = Language.GetTextValue("Mods.RuinMod.ItemSetBonus.BrokenHeroSet"); // "Baby Mothrons help you kill your enemies"

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
                        if (Egg == false)
                        {
                            Vector2 position = nPC.Center;
                            Vector2 targetPosition = Main.player[nPC.target].Center;
                            Vector2 direction = targetPosition - position;
                            direction.Normalize();
                            float speed = 10f;

                            int type = ProjectileType<MiniMothronBabyProjectile>(); //ProjectileID.EyeLaser;
                            Vector2 velocity = direction * speed;
                            int damage = 45;
                            //int egg = NPC.NewNPC(nPC.GetSource_FromAI(), (int)player.position.X, (int)player.position.Y, NPCID.MothronSpawn, 10);
                            //int egg = Projectile.NewProjectile(pROJ.GetSource_FromAI(), (int)player.position.X, (int)player.position.Y, NPCID.MothronSpawn, 10);
                            const int NumProjectiles = 8;
                            for (int e = 0; e < NumProjectiles; e++)
                            {
                                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(15)); //15

                                newVelocity *= 1f - Main.rand.NextFloat(0.3f);

                                int egg = Projectile.NewProjectile(pROJ.GetSource_FromAI(), position, newVelocity, type, damage, 0, Main.myPlayer);
                                //Main.npc[egg].friendly = true; //Makes npc friendly when hitting player
                                Main.projectile[egg].friendly = true;
                                Main.projectile[egg].hostile = false;
                                Egg = true;
                            }
                        }
                    }
                }
            }
            if (Egg == true)
            {
                timer++;
                if (timer >= 60 * 4) //15
                {
                    timer = 0;
                    Egg = false;
                    Dust dust18 = Dust.NewDustDirect(new Vector2(player.position.X - 2f, player.position.Y - 2f), player.width + 4, player.height + 4, DustID.WhiteTorch, player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default(Color), 3.5f);
                    dust18.noGravity = true;
                    dust18.velocity.X = 1.8f;
                    dust18.velocity.Y -= 0.5f;
                }
            }
        }
        public override void UpdateEquip(Player player) //Individual armor piece bonus
        {
            player.GetCritChance(ModContent.GetInstance<ShieldClassDamage>()) += 0.18f;
            player.GetDamage(ModContent.GetInstance<ShieldClassDamage>()) += 0.18f;
            player.GetArmorPenetration(ModContent.GetInstance<ShieldClassDamage>()) += 6f;
        }
    }
}