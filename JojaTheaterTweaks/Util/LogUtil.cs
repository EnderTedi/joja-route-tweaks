using StardewModdingAPI;
using System.Runtime.CompilerServices;

namespace JojaTheaterTweaks.Util;

public class LogUtil(IMonitor logger)
{
    public void Trace(string message, bool once = false)
    {
        if (once)
            logger.LogOnce(message);
        else
            logger.Log(message);
    }

    public void Debug(string message, bool once = false)
    {
        if (once)
            logger.LogOnce(message, LogLevel.Debug);
        else
            logger.Log(message, LogLevel.Debug);
    }

    public void Info(string message, bool once = false)
    {
        if (once)
            logger.LogOnce(message, LogLevel.Info);
        else
            logger.Log(message, LogLevel.Info);
    }

    public void Warn(string message, bool once = false)
    {
        if (once)
            logger.LogOnce(message, LogLevel.Warn);
        else
            logger.Log(message, LogLevel.Warn);
    }

    public void Error(string message, bool once = false)
    {
        if (once)
            logger.LogOnce(message, LogLevel.Error);
        else
            logger.Log(message, LogLevel.Error);
    }

    public void AlertHere([CallerMemberName] string name = "", [CallerLineNumber] int num = -1, bool once = false)
    {
        if (once)
            logger.LogOnce($"Warn from {name} at line {num}", LogLevel.Alert);
        else
            logger.Log($"Warn from {name} at line {num}", LogLevel.Alert);
    }
}