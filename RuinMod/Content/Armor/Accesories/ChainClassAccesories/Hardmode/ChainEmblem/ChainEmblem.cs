/*using System;
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
using RuinMod.Content.Classes.ChainClass;

namespace RuinMod.Content.Armor.Accesories.ChainClassAccesories.Hardmode.ChainEmblem
{
    internal class ChainEmblem : ModItem
    {
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Chain Emblem");
			//Tooltip.SetDefault("15% increased chain damage");
		}

		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 28;
			Item.accessory = true;
			Item.rare = ItemRarityID.LightRed;
			Item.value = Item.sellPrice(gold: 1);
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetDamage(GetInstance<ChainClassDamage>()) += 0.15f;
		}
	}
}*/
