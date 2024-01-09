using Terraria.GameInput;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Terraria.Audio;

namespace DedsQOLMod.Common.Systems
{
    public class RecallPlayer : ModPlayer
    {
        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (KeybindSystem.AutoRecallKeybind.JustPressed) // Replace SpecialKey with the correct KeybindID for the "F" key
            {
                if (Player.HasItem(ItemID.RecallPotion) || Player.HasItem(ItemID.MagicMirror) || Player.HasItem(ItemID.IceMirror) || Player.HasItem(ItemID.CellPhone))
                {
                    // Use Recall Potion or Magic Mirror
                    if (Player.HasItem(ItemID.RecallPotion))
                    {
                        for (int d = 0; d < 70; d++)
                        {
                            Dust.NewDust(Player.position, Player.width, Player.height, DustID.MagicMirror, 0f, 0f, 150, default, 1.5f);
                        }

                        SoundEngine.PlaySound(SoundID.Item3);
                        Player.ConsumeItem(ItemID.RecallPotion);

                        // The actual method that moves the player back to bed/spawn.
                        Player.Spawn(PlayerSpawnContext.RecallFromItem);
                    }
                    else if (Player.HasItem(ItemID.MagicMirror) || Player.HasItem(ItemID.IceMirror) || Player.HasItem(ItemID.CellPhone))
                    {
                        for (int d = 0; d < 70; d++)
                        {
                            Dust.NewDust(Player.position, Player.width, Player.height, DustID.MagicMirror, 0f, 0f, 150, default, 1.5f);
                        }
                        SoundEngine.PlaySound(SoundID.Item3);

                        // The actual method that moves the player back to bed/spawn.
                        Player.Spawn(PlayerSpawnContext.RecallFromItem);
                    }
                }
                else
                {
                    //Main.NewText("You don't have a recall item.");
                }
            }
        }
    }
}
