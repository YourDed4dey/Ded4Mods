/*using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace DedsBosses.Content.Items.Placeable.AutoDrill.Tile
{
    internal class AutoDrillTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            // Properties
            Main.tileTable[Type] = true;
            Main.tileSolidTop[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            Main.tileFrameImportant[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileID.Sets.IgnoredByNpcStepUp[Type] = true; // This line makes NPCs not try to step up this tile during their movement. Only use this for furniture with solid tops.

            DustType = DustID.Stone;

            // Placement
            TileObjectData.newTile.CopyFrom(TileObjectData.Style5x4);
            TileObjectData.newTile.CoordinateHeights = new[] { 16,16,16,18 };
            TileObjectData.newTile.Height = 4;
            TileObjectData.newTile.Width = 4;
            TileObjectData.addTile(Type);

            AddMapEntry(new Color(200, 200, 200));

            AnimationFrameHeight = 74;
        }
        private bool drillIsOn = false;
        public override void PlaceInWorld(int i, int j, Item item)
        {
            drillIsOn = false;
        }
        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            // Animate the tile's frame based on game time
            if (++frameCounter >= 3)
            {
                frameCounter = 0;

                if (!drillIsOn)
                {
                    frame = 0;
                }
                else
                {
                    frame = (frame + 1) % (AnimationFrameHeight / 5) + 1; // Use AnimationFrameHeight
                }
            }
        }

        public override bool RightClick(int i, int j)
        {
            // Toggle the frame state on right-click
            drillIsOn = !drillIsOn;

            return true;
        }
    }
}*/