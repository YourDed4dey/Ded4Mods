﻿/*using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace RuinMod.Content.Items.Placeables.TV.Tile
{
    internal class TVTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileTable[Type] = false;
            Main.tileSolidTop[Type] = false;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            Main.tileFrameImportant[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileID.Sets.IgnoredByNpcStepUp[Type] = true;

            DustType = DustID.Ash;
            //AdjTiles = new int[] { TileID.Anvils };

            // Placement
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
            TileObjectData.newTile.CoordinateHeights = new[] { 18 };
            TileObjectData.addTile(Type);

            //AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);

            // Etc
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Monitor");
            AddMapEntry(new Color(40, 40, 40), name);
        }

        public override void NumDust(int x, int y, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }

        public override void KillMultiTile(int x, int y, int frameX, int frameY)
        {
            Item.NewItem(new EntitySource_TileBreak(x, y), x * 16, y * 16, 32, 16, ModContent.ItemType<TV>());
        }
    }
}*/
