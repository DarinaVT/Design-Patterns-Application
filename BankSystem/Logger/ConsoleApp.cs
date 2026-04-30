using BankSystem.Logger.IO;
namespace BankSystem.Logger;

public class ConsoleApp : IConsole, ILogger
{
    public void Write(string message) => Console.Write(message);
    public void WriteLine(string message) => Console.WriteLine(message);
    public string ReadLine() => Console.ReadLine();
    public void Log(string message) => Console.WriteLine(message);
}
