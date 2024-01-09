using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using RuinMod.Content.Weapons.ShieldClassWeapons.PreHardmode.StarShield;
using RuinMod.Content.Weapons.ShieldClassWeapons.PreHardmode.MagicShield;

namespace RuinMod.Common.Systems
{
	internal class WorldSystem : ModSystem
	{
		/*public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
		{
			int shiniesIndex = tasks.FindIndex(t => t.Name.Equals("Shinies"));
			if (shiniesIndex != -1)
			{
				tasks.Insert(shiniesIndex + 1, new LostFragmentGenPass("Lost Fragment Pass", 320f));
			}
		}*/

		public override void PostWorldGen()
		{
			int[] itemsToPlaceInDungeonChests = { ModContent.ItemType<MagicShield>() };
			int itemsToPlaceInDungeonChestsChoice = 0;
			for (int chestIndex = 0; chestIndex < 11; chestIndex++)
			{
				Chest chest = Main.chest[chestIndex];
				// If you look at the sprite for Chests by extracting Tiles_21.xnb, you'll see that the 3rd chest is the Dungeon Chest. Since we are counting from 0, this is where 2 comes from. 36 comes from the width of each tile including padding. 
				if (chest != null && Main.tile[chest.x, chest.y].TileType == TileID.Containers && Main.tile[chest.x, chest.y].TileFrameX == 2 * 36)
				{
					for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
					{
						if (chest.item[inventoryIndex].type == ItemID.None)
						{
							chest.item[inventoryIndex].SetDefaults(itemsToPlaceInDungeonChests[itemsToPlaceInDungeonChestsChoice]);
							itemsToPlaceInDungeonChestsChoice = (itemsToPlaceInDungeonChestsChoice + 1) % itemsToPlaceInDungeonChests.Length;
							break;
						}
					}
				}
			}
			int[] itemsToPlaceInSkyChests = { ModContent.ItemType<StarShield>() };
			int itemsToPlaceInSkyChestsChoice = 0;
			for (int chestIndex = 0; chestIndex < 170; chestIndex++)
			{
				Chest chest = Main.chest[chestIndex];
                // If you look at the sprite for Chests by extracting Tiles_21.xnb, you'll see that the 14th chest is the Sky Chest. Since we are counting from 0, this is where 13 comes from. 36 comes from the width of each tile including padding. 
                if (chest != null && Main.tile[chest.x, chest.y].TileType == TileID.Containers && Main.tile[chest.x, chest.y].TileFrameX == 13 * 36)
				{
					for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
					{
						if (chest.item[inventoryIndex].type == ItemID.None)
						{
							chest.item[inventoryIndex].SetDefaults(itemsToPlaceInSkyChests[itemsToPlaceInSkyChestsChoice]);
							itemsToPlaceInSkyChestsChoice = (itemsToPlaceInSkyChestsChoice + 1) % itemsToPlaceInSkyChests.Length;
							break;
						}
					}
				}
			}
		}
	}
}
