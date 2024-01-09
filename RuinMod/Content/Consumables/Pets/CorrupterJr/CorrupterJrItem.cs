/*
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace RuinMod.Content.Consumables.Pets.CorrupterJr
{
	public class CorrupterJrItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Heart of Evil");
			//Tooltip.SetDefault("Summons a miniature Corrupter\n'Ugly but...wait...what else does it do?'");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.ZephyrFish);

			Item.rare = ItemRarityID.Master;
			Item.shoot = ModContent.ProjectileType<CorrupterJrProjectile>();
			Item.buffType = ModContent.BuffType<CorrupterJrBuff>();
		}

		public override void UseStyle(Player player, Rectangle heldItemFrame)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(Item.buffType, 3600);
			}
		}
	}
}*/
