using HarmonyLib;
using JetBrains.Annotations;
using JojaTheaterTweaks.Util;
using StardewValley;
using StardewValley.Characters;
using StardewValley.Extensions;
using StardewValley.Locations;
using System.Diagnostics.CodeAnalysis;

namespace JojaTheaterTweaks.Patches;

[UsedImplicitly, HarmonyPatch(typeof(Town)), SuppressMessage("ReSharper", "InconsistentNaming")]
public static class TownPatches
{
    [HarmonyPatch(nameof(Town.MakeMapModifications)), HarmonyPostfix]
    public static void ShowAbandonedJojaInJojaRoute(Town __instance)
    {
        if (Utility.doesMasterPlayerHaveMailReceivedButNotMailForTomorrow("ccMovieTheater") || !HelperFuncs.IsJojaMartComplete())
            return;

        __instance.showDestroyedJoja();
        __instance.crackOpenAbandonedJojaMartDoor();
    }
}

[UsedImplicitly, HarmonyPatch(typeof(GameLocation)), SuppressMessage("ReSharper", "InconsistentNaming")]
public static class AbandonedJojaMartPatches
{
    [HarmonyPatch(nameof(GameLocation.MakeMapModifications)), HarmonyPostfix]
    public static void RemoveMissingBundle(GameLocation __instance)
    {
        if (!__instance.Name.Equals("AbandonedJojaMart"))
            return;

        if (!HelperFuncs.IsJojaMartComplete())
            return;

        __instance.map.RequireLayer("Buildings").Tiles[8, 8] = null;
    }

    [HarmonyPatch(nameof(GameLocation.setUpLocationSpecificFlair)), HarmonyPostfix]
    public static void RemoveJunimoFlair(GameLocation __instance)
    {
        if (!__instance.Name.Equals("AbandonedJojaMart"))
            return;

        if (!HelperFuncs.IsJojaMartComplete())
            return;

        __instance.temporarySprites.Clear();
        __instance.characters.RemoveWhere(n => n is Junimo);
    }
}