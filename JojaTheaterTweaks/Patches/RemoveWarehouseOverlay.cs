using HarmonyLib;
using JetBrains.Annotations;
using StardewValley;
using StardewValley.Locations;
using System.Reflection.Emit;

namespace JojaTheaterTweaks.Patches;

[UsedImplicitly, HarmonyPatch(typeof(Town))]
public class RemoveWarehouseOverlay
{
    [HarmonyPatch(nameof(Town.drawAboveAlwaysFrontLayer)), HarmonyTranspiler]
    public static IEnumerable<CodeInstruction> RemoveWarehouseOverlayP1Transpiler(IEnumerable<CodeInstruction> insns)
    {
        CodeMatcher matcher = new(insns);

        matcher.MatchEndForward(
            new(OpCodes.Ldarg_0),
            new(OpCodes.Ldfld, AccessTools.Field(typeof(Town), nameof(Town.ccJoja))),
            new(OpCodes.Brfalse)
        );
        matcher.Advance(1);
        matcher.Insert(new CodeInstruction(OpCodes.Ret));

        return matcher.Instructions();
    }

    [HarmonyPatch(nameof(Town.draw)), HarmonyTranspiler]
    public static IEnumerable<CodeInstruction> RemoveWarehouseOverlayP2Transpiler(IEnumerable<CodeInstruction> insns)
    {
        CodeMatcher matcher = new(insns);

        matcher.MatchEndForward(
            new(OpCodes.Ldarg_0),
            new(OpCodes.Ldfld, AccessTools.Field(typeof(Town), nameof(Town.ccJoja))),
            new(OpCodes.Brfalse_S)
        );
        object? label = matcher.Instruction.operand;
        matcher.MatchStartForward(
            new(OpCodes.Ldarg_1),
            new(OpCodes.Ldsfld, AccessTools.Field(typeof(Game1), nameof(Game1.mouseCursors)))
        );
        matcher.Insert(new CodeInstruction(OpCodes.Br, label));

        return matcher.Instructions();
    }
}