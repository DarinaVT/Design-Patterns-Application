namespace _21._04;

public class ConsoleLog : ILogger
{
    public void Print(string message)
    {
        Console.WriteLine(message);
    }
}