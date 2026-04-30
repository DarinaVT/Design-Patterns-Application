using BankSystem.ATM;
using BankSystem.ChainOfResp;
using BankSystem.Client;
using BankSystem.Client.ClientFee;
using BankSystem.Client.ClientStatus;
using BankSystem.Command;
using BankSystem.Logger.IO;
namespace BankSystem;

public class Engine
{
    private readonly IConsole _console;
    private readonly IFee _fee;
    private readonly IStatus _status;
    private readonly CommandParser _parser;
    private readonly List<ATMInfo> _atms;
    private readonly Dictionary<int, ClientInfo> _clients;
    public Engine(IConsole console, IFee fee, IStatus status)
    {
        _console = console;
        _fee = fee;
        _status = status;
        _atms = new List<ATMInfo>
        {
            new ATMInfo(10000),
            new ATMInfo(10000)
        };
        _clients = new Dictionary<int, ClientInfo>
        {
            {
                1234, new ClientInfo("Ivan", 1234, 500)
            },
            {
                5678, new ClientInfo("Maria", 5678, 3000)
            }
        };
        _parser = new CommandParser(_clients, _atms, _fee, _status);
    }
    public void Run()
    {
        LoadATM loader = new LoadATM(_atms);
        _ = loader.Start();
        while (true)
        {
            _console.Write("Enter command: ");
            string input = _console.ReadLine();
            if (input == "exit")
            {
                break;
            }
            try
            {
                string commandName = input.Split(' ')[0].ToLower();

                Validator pinValidator = new PinValidator();

                if (commandName == "draw")
                {
                    Validator balanceValidator = new BalanceValidator(_fee);
                    Validator atmValidator = new ATMValidator();
                    pinValidator.SetSuper(atmValidator);
                    atmValidator.SetSuper(balanceValidator);
                }

                ICommand command = _parser.Parse(input, pinValidator);
                if (command == null)
                {
                    continue;
                }
                string result = command.Execute();
                Data.Instance.Log(result);
            }
            catch (Exception ex)
            {
                Data.Instance.Log(ex.Message);
            }
        }
    }
}