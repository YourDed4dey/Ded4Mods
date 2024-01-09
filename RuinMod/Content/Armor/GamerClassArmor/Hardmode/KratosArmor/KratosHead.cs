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
using RuinMod.Common.Systems;

namespace RuinMod.Content.Armor.GamerClassArmor.Hardmode.KratosArmor
{
    [AutoloadEquip(EquipType.Head)]
    internal class KratosHead : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Kratos Head");
            //Tooltip.SetDefault("15% increased gamer damage");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
        }

        public override void SetDefaults() //Item Stats
        {
            Item.width = 24;
            Item.height = 24;
            Item.rare = ItemRarityID.Red;
            Item.defense = 20;
            Item.wornArmor = true;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<KratosBody>() && legs.type == ItemType<KratosLegs>(); //What makes armor set bonus work
        }

        public override void UpdateArmorSet(Player player) //Armor set bonuses
        {
            //player.setBonus = "30% increased gamer damage\nAllows the player to dash\r\nDouble tap a direction";

            player.setBonus = Language.GetTextValue("Mods.RuinMod.ItemSetBonus.KratosSet");

            player.GetDamage(GetInstance<Classes.GamerClass.GamerClassDamage>()) += 0.30f;
            //player.GetModPlayer<RuinDashPlayer>().DashAccessoryEquipped = true;

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
        }

        public override void AddRecipes()
        {

        }
    }
}*/