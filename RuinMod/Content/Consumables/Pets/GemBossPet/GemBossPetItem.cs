/*using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace RuinMod.Content.Consumables.Pets.GemBossPet
{
    internal class GemBossPetItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Gem Pork");
            //Tooltip.SetDefault("Summons a Gemmonide Jr.");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);

            Item.rare = ItemRarityID.Master;
            Item.shoot = ModContent.ProjectileType<GemBossPetProjectile>();
            Item.buffType = ModContent.BuffType<GemBossPetBuff>();
            Item.master = true;
            Item.value = 0;
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
