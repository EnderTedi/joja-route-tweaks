using HarmonyLib;
using JetBrains.Annotations;
using JojaTheaterTweaks.Util;
using StardewModdingAPI;

namespace JojaTheaterTweaks;

[UsedImplicitly]
public class JojaTheaterTweaks : Mod
{
    public static LogUtil Log { get; private set; } = null!;

    public new static IModHelper Helper { get; private set; } = null!;

    private static Harmony Harmony { get; set; } = null!;

    public override void Entry(IModHelper helper)
    {
        Helper = helper;
        Log = new(Monitor);
        Harmony = new(ModManifest.UniqueID);

        Harmony.PatchAll();
    }

}