using RuinMod.Content.Weapons.ShieldClassWeapons.Endgame.MeowShield;
using RuinMod.Content.Weapons.ShieldClassWeapons.Endgame.StellarShield;
using RuinMod.Content.Weapons.ShieldClassWeapons.Hardmode.SeedShield;
using RuinMod.Content.Weapons.ShieldClassWeapons.PreHardmode.BeeShield;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace RuinMod.Content.Weapons.ShieldClassWeapons
{
    internal class GlobalShieldItemWeapons : GlobalItem
    {
        public override void ModifyItemLoot(Item item, ItemLoot itemLoot)
        {
            if (item.type == ItemID.QueenBeeBossBag)
            {
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<BeeShield>(), (int)3, 1, 1));
            }
            if (item.type == ItemID.PlanteraBossBag)
            {
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<SeedShield>(), (int)7, 1, 1));
            }
            if (item.type == ItemID.MoonLordBossBag)
            {
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<StellarShield>(), (int)9, 1, 1));
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<MeowShield>(), (int)9, 1, 1));
            }
        }
    }
}
