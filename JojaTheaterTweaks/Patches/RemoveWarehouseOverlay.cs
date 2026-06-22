using HarmonyLib;
using JetBrains.Annotations;
using StardewValley;
using StardewValley.Locations;

namespace JojaTheaterTweaks.Patches;

[UsedImplicitly, HarmonyPatch(typeof(Town))]
public class RemoveWarehouseOverlay
{
    [HarmonyPatch(nameof(Town.refurbishCommunityCenter)), HarmonyPrefix]
    public static bool RemoveWarehouseOverlayPrefix()
    {
        return !Game1.MasterPlayer.mailReceived.Contains("JojaMember");
    }
}