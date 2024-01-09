using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using RuinMod.Content.Classes.ShieldClass;

namespace RuinMod.Content.Potions.Buffs.BlueDemon
{
    internal class BlueDemonBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Blue Demon");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetCritChance(ModContent.GetInstance<ShieldClassDamage>()) += 1.80f;
            player.GetDamage(ModContent.GetInstance<ShieldClassDamage>()) += 1.80f;
            //player.stepSpeed -= 15f;

            Dust dust18 = Dust.NewDustDirect(new Vector2(player.position.X - 2f, player.position.Y - 2f), player.width + 4, player.height + 4, DustID.BlueTorch, player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default(Color), 3.5f);
            dust18.noGravity = true;
            dust18.velocity.X = 1.8f;
            dust18.velocity.Y -= 0.5f;
        }
    }
}
