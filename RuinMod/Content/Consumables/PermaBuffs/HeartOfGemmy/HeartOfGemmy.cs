/*using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using RuinMod.Content.Items.Placeables.GemAnvil.Tile;
using RuinMod.Content.Items.GemmysGem;
using RuinMod.Content.Items.Drops.EssencesOrSoulsOrFragments.Souls.SoulOfBlight;
using RuinMod.Content.Items.Drops.EssencesOrSoulsOrFragments.Souls.SoulOfInertness;
using RuinMod.Content.Items.Drops.EssencesOrSoulsOrFragments.Souls.SoulOfStruggle;

namespace RuinMod.Content.Consumables.PermaBuffs.HeartOfGemmy
{
    internal class HeartOfGemmy : ModItem
    {
        public const int MaxHeartOfGemmy = 1;
        public const int LifeHeartOfGemmy = 250;

        public override void SetStaticDefaults()
        {
            //Tooltip.SetDefault($"Permanently increases maximum life by {LifeHeartOfGemmy}");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 10;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.LifeFruit);
        }

        public override bool CanUseItem(Player player)
        {
            return player.statLifeMax == 500 && player.GetModPlayer<HeartOfGemmyPlayer>().LifeFruits < MaxHeartOfGemmy;
        }

        public override bool? UseItem(Player player)
        {
            player.statLifeMax2 += LifeHeartOfGemmy;
            player.statLife += LifeHeartOfGemmy;
            if (Main.myPlayer == player.whoAmI)
            {
                player.HealEffect(LifeHeartOfGemmy);
            }
            player.GetModPlayer<HeartOfGemmyPlayer>().LifeFruits++;
            return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.LifeFruit, 5)
                .AddIngredient(ModContent.ItemType<GemmysGem>(), 5)
                .AddIngredient(ItemID.SoulofFright, 5)
                .AddIngredient(ItemID.SoulofMight, 5)
                .AddIngredient(ItemID.SoulofSight, 5)
                .AddIngredient(ModContent.ItemType<SoulOfBlight>(), 5)
                .AddIngredient(ModContent.ItemType<SoulOfInertness>(), 5)
                .AddIngredient(ModContent.ItemType<SoulOfStruggle>(), 5)
                .AddTile<GemAnvilTile>()
                .Register();
        }
    }

    public class HeartOfGemmyPlayer : ModPlayer
    {
        public int LifeFruits;

        public override void ResetEffects()
        {
            Player.statLifeMax2 += LifeFruits * HeartOfGemmy.LifeHeartOfGemmy;
        }

        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
        {
            ModPacket packet = Mod.GetPacket();
            packet.Write((byte)Player.whoAmI);
            packet.Write(LifeFruits);
            packet.Send(toWho, fromWho);
        }
        public override void SaveData(TagCompound tag)
        {
            tag["LifeFruits"] = LifeFruits;
        }

        public override void LoadData(TagCompound tag)
        {
            LifeFruits = (int)tag["LifeFruits"];
        }
    }
}*/
