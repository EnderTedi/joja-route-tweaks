using HarmonyLib;
using JetBrains.Annotations;
using Microsoft.Xna.Framework;
using StardewValley;
using StardewValley.Events;
using StardewValley.Locations;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Emit;

namespace JojaTheaterTweaks.Patches;

[UsedImplicitly, HarmonyPatch(typeof(Town))]
[SuppressMessage("ReSharper", "InconsistentNaming")]
public class MoveMovieTheater
{
    [HarmonyPatch(nameof(Town.MakeMapModifications)), HarmonyTranspiler]
    public static IEnumerable<CodeInstruction> MoveMovieTheaterInJojaRoute(IEnumerable<CodeInstruction> insns, ILGenerator gen)
    {
        CodeMatcher matcher = new(insns);

        matcher.MatchStartForward(
            new(OpCodes.Ldstr, "ccMovieTheaterJoja"),
            new(OpCodes.Call, AccessTools.Method(typeof(Utility), nameof(Utility.doesMasterPlayerHaveMailReceivedButNotMailForTomorrow)))
        );
        matcher.ThrowIfInvalid("a");
        matcher.RemoveInstructions(2);
        matcher.InsertAndAdvance(
            new CodeInstruction(OpCodes.Ldc_I4_0)
        );

        return matcher.Instructions();
    }

    [HarmonyPatch(nameof(Town.GetTheaterTileOffset)), HarmonyPostfix]
    public static void MoviePosterPositions(ref Point __result)
    {
        __result = new(0, 0);
    }
}

[UsedImplicitly, HarmonyPatch(typeof(Utility)), SuppressMessage("ReSharper", "InconsistentNaming")]
public class NoFixingTheWarehouseJustToNotChangeIt
{
    [HarmonyPatch(nameof(Utility.pickFarmEvent)), HarmonyPostfix]
    public static void RemoveFarmEvent(ref FarmEvent? __result)
    {
        if (__result is WorldChangeEvent wce && wce.whichEvent.Value == 10)
            __result = null;
    }
}