/*using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace RuinMod.Content.Consumables.HeartOfDarkness
{
	internal class HeartOfDarkness : ModItem
	{
		public const int MaxExampleLifeFruits = 10;
		public const int LifePerFruit = 50;

		public override void SetStaticDefaults()
		{
			//Tooltip.SetDefault($"Permanently increases maximum life by {LifePerFruit}");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 10;
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.LifeFruit);
		}

		public override bool CanUseItem(Player player)
		{
			return player.statLifeMax == 500 && player.GetModPlayer<ExampleLifeFruitPlayer>().exampleLifeFruits < MaxExampleLifeFruits;
		}

		public override bool? UseItem(Player player)
		{
			player.statLifeMax2 += LifePerFruit;
			player.statLife += LifePerFruit;
			if (Main.myPlayer == player.whoAmI)
			{
				player.HealEffect(LifePerFruit);
			}
			player.GetModPlayer<ExampleLifeFruitPlayer>().exampleLifeFruits++;
			return true;
		}
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.LifeFruit, 5)
				.AddIngredient(ModContent.ItemType<Items.EssenceOfDeath.EssenceOfDeath>(), 5)
				.AddTile(TileID.DemonAltar)
				.Register();
		}
	}

	public class ExampleLifeFruitPlayer : ModPlayer
	{
		public int exampleLifeFruits;

		public override void ResetEffects()
		{
			Player.statLifeMax2 += exampleLifeFruits * HeartOfDarkness.LifePerFruit;
		}

		public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
		{
			ModPacket packet = Mod.GetPacket();
			packet.Write((byte)Player.whoAmI);
			packet.Write(exampleLifeFruits);
			packet.Send(toWho, fromWho);
		}
		public override void SaveData(TagCompound tag)
		{
			tag["exampleLifeFruits"] = exampleLifeFruits;
		}

		public override void LoadData(TagCompound tag)
		{
			exampleLifeFruits = (int)tag["exampleLifeFruits"];
		}
	}
}*/