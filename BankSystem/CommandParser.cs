using BankSystem.ATM;
using BankSystem.ChainOfResp;
using BankSystem.Client;
using BankSystem.Client.ClientFee;
using BankSystem.Client.ClientStatus;
using BankSystem.Command;

namespace BankSystem;

public class CommandParser
{
    private readonly Dictionary<int, ClientInfo> _clients;
    private readonly List<ATMInfo> _atms;
    private readonly IFee _fee;
    private readonly IStatus _status;
    private readonly Random _random = new Random();

    private readonly Dictionary<string, Type> _commands = new Dictionary<string, Type>
    {
        {
            "draw", typeof(DrawCommand)
        },
        {
            "deposit", typeof(DepositCommand)
        }
    };

    public CommandParser(Dictionary<int, ClientInfo> clients, List<ATMInfo> atms, IFee fee, IStatus status)
    {
        _clients = clients;
        _atms = atms;
        _fee = fee;
        _status = status;
    }

    private ICommand CreateCommand(Type type, params object[] args)
    {
        try
        {
            ICommand command = (ICommand)Activator.CreateInstance(type, args);
            return command;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error while creating the command {type.Name}");
        }
    }

    public ICommand? Parse(string input, Validator validator)
    {
        List<string> args = input.Split(' ').ToList();

        if (args.Count != 3)
        {
            throw new Exception("Invalid command format, use: <command> <pin> <amount>");
        }

        string commandName = args[0].ToLower();

        if (!int.TryParse(args[1], out int pin))
        {
            throw new Exception("Invalid PIN format");
        }

        if (!decimal.TryParse(args[2], out decimal amount))
        {
            throw new Exception("Invalid amount format");
        }

        if (!_clients.TryGetValue(pin, out ClientInfo? client) || client == null)
        {
            Data.Instance.Log("Client not found");
            return null;
        }

        ATMInfo atm = _atms[_random.Next(_atms.Count)];
        Data.Instance.Log($"Using ATM {atm.Id}");

        Transaction transaction = new Transaction(client, atm, amount, pin);

        if (!_commands.TryGetValue(commandName, out Type? type))
        {
            throw new Exception($"Unknown command: {commandName}");
        }

        return commandName switch
        {
            "draw" => CreateCommand(type, transaction, BuildChain(validator), _fee, _status),
            "deposit" => CreateCommand(type, transaction, validator),
            _ => throw new Exception($"Unknown command: {commandName}")
        };
    }
    private Validator BuildChain(Validator validator)
    {
        validator.SetSuper(new BalanceValidator(_fee));
        return validator;
    }
}