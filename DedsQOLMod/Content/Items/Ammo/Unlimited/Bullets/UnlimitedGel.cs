using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using Terraria.ModLoader.IO;
using Mono.Cecil;
using Terraria.DataStructures;

namespace DedsQOLMod.Content.Items.Ammo.Unlimited.Bullets
{
    internal class UnlimitedGel : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.Gel;
        public override void SetStaticDefaults()
        {
            Item.CloneDefaults(ItemID.Gel);

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99; ItemID.Sets.ItemIconPulse[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Gel);
            Item.maxStack = 1;
            Item.color = Color.LightGreen;
            Item.rare = ItemRarityID.Red;
        }

        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return false;
        }
        public override bool CanBeConsumedAsAmmo(Item weapon, Player player) // Makes Ammo not consumable, using static Terraria.ModLoader.ModContent; needed
        {
            return false;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Gel, 999)
                .Register();
        }
    }
}
