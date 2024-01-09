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

namespace RuinMod.Content.Armor.Accesories.Hardmode.OrbOfPain
{
    internal class OrbOfPain : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Orb of Pain");
            //Tooltip.SetDefault("A orb appears in all of the player's cursors (Only in yours if solo)\n600 dps");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
            ItemID.Sets.ItemIconPulse[Item.type] = true;
            ItemID.Sets.ItemNoGravity[Item.type] = true;
        }

        public override void SetDefaults() //Item Stats
        {
            Item.width = 36;
            Item.height = 32;
            Item.rare = ItemRarityID.Cyan;
            Item.accessory = true;
            Item.canBePlacedInVanityRegardlessOfConditions = true;
        }

        public override void UpdateEquip(Player player) //Individual armor piece bonus
        {
            float speed = 0f;
            Vector2 direction = player.Top;
            Vector2 velocity = direction * speed;

            int proj = Projectile.NewProjectile(null, Main.MouseWorld, velocity, ProjectileID.CultistBossLightningOrb, 10, 0, player.whoAmI);
            Main.projectile[proj].friendly = true;
            Main.projectile[proj].hostile = false;
            Main.projectile[proj].timeLeft = 15; //15
            Main.projectile[proj].rotation = 0;
            Main.projectile[proj].ArmorPenetration = 100;
            Main.projectile[proj].owner = Main.myPlayer;
        }
    }
}*/