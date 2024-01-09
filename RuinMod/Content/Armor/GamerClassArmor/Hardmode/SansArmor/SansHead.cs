/*using Terraria;
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

namespace RuinMod.Content.Armor.GamerClassArmor.Hardmode.SansArmor
{
    [AutoloadEquip(EquipType.Head)]
    internal class SansHead : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Sans Head");
            //Tooltip.SetDefault("15% increased gamer damage and critical strike chance");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
        }

        public override void SetDefaults() //Item Stats
        {
            Item.width = 34;
            Item.height = 30;
            Item.rare = ItemRarityID.Cyan;
            Item.defense = 17;
            Item.wornArmor = true;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<SansBody>() && legs.type == ItemType<SansLegs>(); //What makes armor set bonus work
        }

        public override void UpdateArmorSet(Player player) //Armor set bonuses
        {
            //player.setBonus = "30% increased gamer damage";
            player.setBonus = Language.GetTextValue("Mods.RuinMod.ItemSetBonus.SansSet");
            player.GetDamage(GetInstance<Classes.GamerClass.GamerClassDamage>()) += 0.3f;

            /*float speed = 0f;
            Vector2 direction = player.Top;
            Vector2 velocity = direction * speed;

            int proj = Projectile.NewProjectile(null, Main.MouseWorld, velocity, ProjectileID.CultistBossLightningOrb, 10, 0, player.whoAmI);
            Main.projectile[proj].friendly = true;
            Main.projectile[proj].hostile = false;
            Main.projectile[proj].timeLeft = 15; //15
            Main.projectile[proj].rotation = 0;
            Main.projectile[proj].ArmorPenetration = 100;
            Main.projectile[proj].owner = Main.myPlayer;*/
        /*}

        public override void UpdateEquip(Player player) //Individual armor piece bonus
        {
            player.GetDamage(GetInstance<Classes.GamerClass.GamerClassDamage>()) += 0.15f;
            player.GetCritChance(GetInstance<Classes.GamerClass.GamerClassDamage>()) += 0.15f;
        }

        public override void AddRecipes()
        {
            
        }
    }
}*/