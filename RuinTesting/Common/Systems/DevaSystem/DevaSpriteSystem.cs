/*using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using IL.Terraria.DataStructures;
using Microsoft.Xna.Framework;
using RuinTesting.Common.Systems.DevaSystem.Net;
using RuinTesting.Common.Systems.DevaSystem.Net.Strategies;
using RuinTesting.Common.Systems.DevaSystem.NPCMatching;

namespace RuinTesting.Common.Systems.DevaSystem
{
    public abstract class DevaSpriteSystem : GlobalNPC
    {
        public NPCMatcher Matcher;

        public override bool InstancePerEntity => true;
        public sealed override bool AppliesToEntity(NPC entity, bool lateInstantiation)
        {
            if (Matcher.Satisfies(entity.type))
            {
                TryLoadSprites(entity);

                return RuinWorld.devastated || Main.gameMenu;
            }
            return false;
        }

        public sealed override void SendExtraAI(NPC npc, BitWriter bitWriter, BinaryWriter binaryWriter)
        {
            if (RuinWorld.devastated)
            {
                Dictionary<Ref<object>, CompoundStrategy> netInfo = GetNetInfo();
                if (netInfo == default)
                    return;

                for (int i = 0; i < netInfo.Count; i++)
                {
                    KeyValuePair<Ref<object>, CompoundStrategy> query = netInfo.ElementAt(i);
                    query.Value.Send(query.Key.Value, bitWriter, binaryWriter);
                }
            }
        }

        public sealed override void ReceiveExtraAI(NPC npc, BitReader bitReader, BinaryReader binaryReader)
        {
            if (RuinWorld.devastated)
            {
                Dictionary<Ref<object>, CompoundStrategy> netInfo = GetNetInfo();
                if (netInfo == default)
                    return;

                for (int i = 0; i < netInfo.Count; i++)
                {
                    KeyValuePair<Ref<object>, CompoundStrategy> query = netInfo.ElementAt(i);
                    query.Value.Recieve(ref query.Key.Value, bitReader, binaryReader);
                }
            }
        }

        public override void Load()
        {
            Matcher = CreateMatcher();
            base.Load();
        }

        public virtual Dictionary<Ref<object>, CompoundStrategy> GetNetInfo() => default;

        public abstract NPCMatcher CreateMatcher();
        /// <summary>
        /// Override this and return a new instance of your EModeNPCBehaviour subclass if you have any reference-type variables
        /// </summary>
        public virtual DevaSpriteSystem NewInstance() => (DevaSpriteSystem)MemberwiseClone();


        public bool FirstTick = true;
        public virtual void OnFirstTick(NPC npc) { }

        public virtual bool SafePreAI(NPC npc) => base.PreAI(npc);
        public sealed override bool PreAI(NPC npc)
        {
            if (RuinWorld.devastated)
            {
                if (FirstTick)
                {
                    FirstTick = false;

                    OnFirstTick(npc);
                }

            }
            return SafePreAI(npc);
        }
        protected static void NetSync(NPC npc, bool onlySendFromServer = true)
        {
            if (RuinWorld.devastated)
            {
                if (onlySendFromServer && Main.netMode != NetmodeID.Server)
                    return;

                //npc.GetGlobalNPC<NewEModeGlobalNPC>().NetSync(npc);
                if (Main.netMode != NetmodeID.SinglePlayer)
                    NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, npc.whoAmI);
            }
        }

        /// <summary>
        /// Checks if loading sprites is necessary and does it if so.
        /// </summary>
        public void TryLoadSprites(NPC npc)
        {
            if (RuinWorld.devastated)
            {
                if (!Main.dedServ)
                {
                    bool recolor = RuinWorld.devastated;
                    if (recolor || RuinTesting.Instance.LoadedNewSprites)
                    {
                        RuinTesting.Instance.LoadedNewSprites = true;
                        LoadSprites(npc, recolor);
                    }
                }
            }
        }

        public virtual void LoadSprites(NPC npc, bool recolor) { }

        #region Sprite Loading
        protected static Asset<Texture2D> LoadSprite(bool recolor, string texture)
            => ModContent.Request<Texture2D>("RuinTesting/NPCs/" + (recolor ? "Resprites/" : "Vanilla/") + texture, AssetRequestMode.ImmediateLoad);

        protected static void LoadSpriteBuffered(bool recolor, int type, Asset<Texture2D>[] vanillaTexture, Dictionary<int, Asset<Texture2D>> fargoBuffer, string texturePrefix)
        {
            if (RuinWorld.devastated)
            {
                if (recolor)
                {
                    if (!fargoBuffer.ContainsKey(type))
                    {
                        fargoBuffer[type] = vanillaTexture[type];
                        vanillaTexture[type] = LoadSprite(recolor, $"{texturePrefix}{type}");
                    }
                }
                else
                {
                    if (fargoBuffer.ContainsKey(type))
                    {
                        vanillaTexture[type] = fargoBuffer[type];
                        fargoBuffer.Remove(type);
                    }
                }
            }
        }

        protected static void LoadSpecial(bool recolor, ref Asset<Texture2D> vanillaResource, ref Asset<Texture2D> fargoSoulsBuffer, string name)
        {
            if (RuinWorld.devastated)
            {
                if (recolor)
                {
                    if (fargoSoulsBuffer == null)
                    {
                        fargoSoulsBuffer = vanillaResource;
                        vanillaResource = LoadSprite(recolor, name);
                    }
                }
                else
                {
                    if (fargoSoulsBuffer != null)
                    {
                        vanillaResource = fargoSoulsBuffer;
                        fargoSoulsBuffer = null;
                    }
                }
            }
        }

        protected static void LoadNPCSprite(bool recolor, int type)
        {
            if (RuinWorld.devastated)
            {
                LoadSpriteBuffered(recolor, type, TextureAssets.Npc, RuinTesting.TextureBuffer.NPC, "NPC_");
            }
        }

        /*protected static void LoadBossHeadSprite(bool recolor, int type)
        {
            if (RuinWorld.devastated)
            {
                LoadSpriteBuffered(recolor, type, TextureAssets.NpcHeadBoss, RuinTesting.TextureBuffer.NPCHeadBoss, "NPC_Head_Boss_");
            }
        }

        protected static void LoadGore(bool recolor, int type)
        {
            if (RuinWorld.devastated)
            {
                LoadSpriteBuffered(recolor, type, TextureAssets.Gore, RuinTesting.TextureBuffer.Gore, "Gores/Gore_");
            }
        }

        protected static void LoadGoreRange(bool recolor, int type, int lastType)
        {
            if (RuinWorld.devastated)
            {
                for (int i = type; i <= lastType; i++)
                    LoadGore(recolor, i);
            }
        }

        protected static void LoadExtra(bool recolor, int type)
        {
            if (RuinWorld.devastated)
            {
                LoadSpriteBuffered(recolor, type, TextureAssets.Extra, RuinTesting.TextureBuffer.Extra, "Extra_");
            }
        }

        protected static void LoadGolem(bool recolor, int type)
        {
            if (RuinWorld.devastated)
            {
                LoadSpriteBuffered(recolor, type, TextureAssets.Golem, RuinTesting.TextureBuffer.Golem, "GolemLights");
            }
        }
        #endregion
    }
}*/