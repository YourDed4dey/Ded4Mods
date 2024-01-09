using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace RuinMod.Content.Weapons.SummonerWeapons.Hardmode.ProbeWhip
{
    public class ProbeWhip : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Probe Whip");
            //Tooltip.SetDefault("7 summon tag damage\nYour summons will focus struck enemies");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.BoneWhip);

            Item.DefaultToWhip(ModContent.ProjectileType<Projectiles.Whips.ProbeWhip.ProbeWhipProjectile>(), 20, 2, 4);

            Item.shootSpeed = 10;
            Item.rare = ItemRarityID.Pink;
            Item.damage = 67;
            Item.DamageType = DamageClass.SummonMeleeSpeed;
            Item.crit = 5;
            Item.knockBack = 4f;
            Item.value = 0;
        }
        public override bool MeleePrefix()
		{
			return true;
		}
	}
}