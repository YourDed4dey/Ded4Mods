using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria;
using static Terraria.ModLoader.ModContent;

namespace RuinMod.Content.Items.Ammo.MiniSkull
{
    public class MiniSkull : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Mini-Skull");
            //Tooltip.SetDefault("'Where did the skull come from?'"); // The item's description, can be set to whatever you want.

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.damage = 15;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 11;
            Item.height = 10;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.knockBack = 2f;
            Item.value = 0;
            Item.rare = ItemRarityID.Pink;
            Item.shoot = ModContent.ProjectileType < Content.Projectiles.Ranged.MiniSkull.MiniSkullProjectile> ();
            Item.shootSpeed = 16f;
            Item.ammo = Item.type;
        }
        /*public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return false;
        }*/
        /*public override bool CanBeConsumedAsAmmo(Item weapon, Player player) // Makes Ammo not consumable, using static Terraria.ModLoader.ModContent; needed
        {
            return false;
        }*/
    }
}

