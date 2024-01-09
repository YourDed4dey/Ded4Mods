using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using RuinTesting.Common.Systems;
using RuinTesting.Common.Global;
using Terraria.WorldBuilding;
using System.Collections.Generic;

namespace RuinTesting
{
    public class RuinTesting : Mod
    {
        /*public const int CabinWidth = 12;
        public const int CabinHeight = 10;

        public static void PlaceSnowCabin(int x, int y)
        {
            // Check if the area is valid for generating the cabin
            if (Main.tile[x, y].TileType == TileID.SnowBlock)
            {

            }
        }*/
    }
}

/*public static void PlaceSnowCabin(int x, int y)
        {
            // Clear the area for the cabin
            for (int i = x; i < x + 10; i++)
            {
                for (int j = y; j < y + 8; j++)
                {
                    WorldGen.KillTile(i, j);
                }
            }

            // Place the cabin walls
            for (int i = x; i < x + 10; i++)
            {
                WorldGen.PlaceTile(i, y, TileID.SnowBlock, true);
                WorldGen.PlaceTile(i, y + 7, TileID.SnowBlock, true);
            }

            for (int j = y + 1; j < y + 7; j++)
            {
                WorldGen.PlaceTile(x, j, TileID.SnowBlock, true);
                WorldGen.PlaceTile(x + 9, j, TileID.SnowBlock, true);
            }

            // Place the doors
            Point leftDoor = new Point(x + 1, y + 2);
            Point rightDoor = new Point(x + 8, y + 2);
            WorldUtils.Gen(new Point(leftDoor.X, leftDoor.Y - 1), new Shapes.Rectangle(3, 3), Actions.Chain(new Actions.ClearTile(true), new Actions.PlaceTile(3)));
            WorldUtils.Gen(new Point(rightDoor.X, rightDoor.Y - 1), new Shapes.Rectangle(3, 3), Actions.Chain(new Actions.ClearTile(true), new Actions.PlaceTile(3)));
        }*/






/*internal static RuinTesting Instance;

internal bool LoadedNewSprites;

public UserInterface CustomResources;

internal static Dictionary<int, int> ModProjDict = new Dictionary<int, int>();

internal struct TextureBuffer
{
    public static readonly Dictionary<int, Asset<Texture2D>> NPC = new Dictionary<int, Asset<Texture2D>>();
    //public static readonly Dictionary<int, Asset<Texture2D>> NPCHeadBoss = new Dictionary<int, Asset<Texture2D>>();
    //public static readonly Dictionary<int, Asset<Texture2D>> Gore = new Dictionary<int, Asset<Texture2D>>();
    //public static readonly Dictionary<int, Asset<Texture2D>> Golem = new Dictionary<int, Asset<Texture2D>>();
    //public static readonly Dictionary<int, Asset<Texture2D>> Extra = new Dictionary<int, Asset<Texture2D>>();
    //public static Asset<Texture2D> Ninja = null;
    public static Asset<Texture2D> BoneArm = null;
    //public static Asset<Texture2D> BoneArm2 = null;
    //public static Asset<Texture2D> Chain12 = null;
    //public static Asset<Texture2D> Chain26 = null;
    //public static Asset<Texture2D> Chain27 = null;
    //public static Asset<Texture2D> Wof = null;
}
public override void Load()
{
    Instance = this;
    ToggleLoader.Load();
}
public override void Unload()
{
    //On.Terraria.GameContent.ItemDropRules.Conditions.IsMasterMode.CanDrop -= IsMasterModeOrEMode_CanDrop;
    //On.Terraria.GameContent.ItemDropRules.Conditions.IsMasterMode.CanShowItemDropInUI -= IsMasterModeOrEMode_CanShowItemDropInUI;
    //On.Terraria.GameContent.ItemDropRules.DropBasedOnMasterMode.CanDrop -= DropBasedOnMasterOrEMode_CanDrop;
    //On.Terraria.GameContent.ItemDropRules.DropBasedOnMasterMode.TryDroppingItem_DropAttemptInfo_ItemDropRuleResolveAction -= DropBasedOnMasterOrEMode_TryDroppingItem_DropAttemptInfo_ItemDropRuleResolveAction;

    void RestoreSprites(Dictionary<int, Asset<Texture2D>> buffer, Asset<Texture2D>[] original)
    {
        foreach (KeyValuePair<int, Asset<Texture2D>> pair in buffer)
            original[pair.Key] = pair.Value;

        buffer.Clear();
    }

    RestoreSprites(TextureBuffer.NPC, TextureAssets.Npc);
    /*RestoreSprites(TextureBuffer.NPCHeadBoss, TextureAssets.NpcHeadBoss);
    RestoreSprites(TextureBuffer.Gore, TextureAssets.Gore);
    RestoreSprites(TextureBuffer.Golem, TextureAssets.Golem);
    RestoreSprites(TextureBuffer.Extra, TextureAssets.Extra);

    if (TextureBuffer.Ninja != null)
        TextureAssets.Ninja = TextureBuffer.Ninja;
    if (TextureBuffer.BoneArm != null)
        TextureAssets.BoneArm = TextureBuffer.BoneArm;
    if (TextureBuffer.BoneArm2 != null)
        TextureAssets.BoneArm2 = TextureBuffer.BoneArm2;
    if (TextureBuffer.Chain12 != null)
        TextureAssets.Chain12 = TextureBuffer.Chain12;
    if (TextureBuffer.Chain26 != null)
        TextureAssets.Chain26 = TextureBuffer.Chain26;
    if (TextureBuffer.Chain27 != null)
        TextureAssets.Chain27 = TextureBuffer.Chain27;
    if (TextureBuffer.Wof != null)
        TextureAssets.Wof = TextureBuffer.Wof;

    ToggleLoader.Unload();

    ModProjDict.Clear();

    Instance = null;
}

}
}*/