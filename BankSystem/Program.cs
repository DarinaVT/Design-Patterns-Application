using BankSystem;
using BankSystem.Client.ClientFee;
using BankSystem.Client.ClientStatus;
using BankSystem.Logger;
using BankSystem.Logger.IO;

class Program
{
    public static void Main(string[] args)
    {
        IConsole console = new ConsoleApp();
        IFee fee = new Fee();
        IStatus status = new Status();

        Engine engine = new Engine(console, fee, status);
        engine.Run();
    }
}