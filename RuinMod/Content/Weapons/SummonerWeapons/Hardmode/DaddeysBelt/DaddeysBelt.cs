/*using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using RuinMod.Content.Projectiles.Whips.DaddeysBelt;
using RuinMod.Content.Classes.ChainClass;

namespace RuinMod.Content.Weapons.SummonerWeapons.Hardmode.DaddeysBelt
{
	public class DaddeysBelt : ModItem
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Daddey's Belt");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.DefaultToWhip(ModContent.ProjectileType<DaddeysBeltProjectile>(), 20, 2, 4);

			Item.shootSpeed = 20;
			Item.rare = ItemRarityID.Purple;
			Item.damage = 200;
			Item.DamageType = ModContent.GetInstance<ChainClassDamage>();
			Item.knockBack = 10f;

			Item.channel = true;
		}
		/*public override bool MeleePrefix()
		{
			return true;
		}
	}
}*/