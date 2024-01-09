/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using RuinMod.Common.Systems.DiffSystem;
using Terraria.GameContent;
using ReLogic.Content;

namespace RuinMod.Common.Global.DevastatedDiff
{
    internal class DevastatedItems : GlobalItem
    {
        public override bool PreDrawInInventory(Item item, SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            if (RuinWorld.devastated == true)
            {
                if (item.type == ItemID.Zenith)
                {
                    TextureAssets.Item[ItemID.Zenith] = ModContent.Request<Texture2D>("RuinMod/Assets/Textures/DevaDiff/Devastated/Item_4956_Deva");
                }
                if (item.type == ItemID.EoCShield)
                {
                    TextureAssets.Item[ItemID.EoCShield] = ModContent.Request<Texture2D>("RuinMod/Assets/Textures/DevaDiff/Devastated/Item_3097_Deva");
                    TextureAssets.AccShield[ArmorIDs.Shield.ShieldofCthulhu] = ModContent.Request<Texture2D>("RuinMod/Assets/Textures/DevaDiff/Devastated/Acc_Shield_5_Deva");
                }
            }
            else
            {
                if (item.type == ItemID.Zenith)
                {
                    TextureAssets.Item[ItemID.Zenith] = ModContent.Request<Texture2D>("RuinMod/Assets/Textures/DevaDiff/Vanilla/Item_4956");
                }
                if (item.type == ItemID.EoCShield)
                {
                    TextureAssets.Item[ItemID.EoCShield] = ModContent.Request<Texture2D>("RuinMod/Assets/Textures/DevaDiff/Vanilla/Item_3097");
                    TextureAssets.AccShield[ArmorIDs.Shield.ShieldofCthulhu] = ModContent.Request<Texture2D>("RuinMod/Assets/Textures/DevaDiff/Vanilla/Acc_Shield_5");
                }
            }
            return true;
        }
    }
}*/
