using BankSystem.Logger;

public sealed class Data : ILogger
{
    private readonly ILogger _consoleLogger;
    private readonly ILogger _fileLogger;

    private Data()
    {
        _consoleLogger = new ConsoleApp();
        _fileLogger = new FileLog();
    }

    public static Data Instance => Nested._instance;

    public void Log(string message)
    {
        _consoleLogger.Log(message);
        _fileLogger.Log(message);
    }

    private class Nested
    {
        static Nested() { }
        internal static readonly Data _instance = new Data();
    }
}