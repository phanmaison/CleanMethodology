namespace CleanMethodology.Core.Helpers;

public static class LogHelper
{
    private static void WriteLog(string type, string message, Exception? ex = null)
    {
        var logMessage = $"{DateTime.Now:HH:mm:ss} [{type}] {message}";

        if (ex != null)
        {
            logMessage += Environment.NewLine + ex;
        }

        Console.WriteLine(logMessage);
    }

    public static void Info(string message) => WriteLog("INFO", message);

    public static void Warn(string message) => WriteLog("WARN", message);

    public static void Error(string message, Exception ex) => WriteLog("ERROR", message, ex);

    public static void Error(string message) => WriteLog("ERROR", message);
}
