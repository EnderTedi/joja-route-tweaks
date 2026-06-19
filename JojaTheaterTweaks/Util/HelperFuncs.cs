using StardewValley;

namespace JojaTheaterTweaks.Util;

public static class HelperFuncs
{
    public static bool IsJojaMartComplete()
    {
        Farmer? host = Game1.MasterPlayer ?? SaveGame.loaded.player;

        return
            host?.mailReceived.Any(flag => flag is "jojaVault" or "jojaPantry" or "jojaBoilerRoom" or "jojaCraftsRoom" or "jojaFishTank" or "JojaMember") is true && host.mailReceived.Contains("ccVault") && host.mailReceived.Contains("ccPantry") && host.mailReceived.Contains("ccBoilerRoom") && host.mailReceived.Contains("ccCraftsRoom") && host.mailReceived.Contains("ccFishTank");
    }
}