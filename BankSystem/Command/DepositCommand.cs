using BankSystem.ChainOfResp;
namespace BankSystem.Command;

public class DepositCommand : ICommand
{
    private Transaction _transaction;
    private Validator _validator;

    public DepositCommand(Transaction transaction, Validator validator)
    {
        _transaction = transaction;
        _validator = validator;
    }

    public string Execute()
    {
        bool isValid = _validator.Validate(_transaction.Client, _transaction.ATM, _transaction.Pin, _transaction.Amount);

        if (!isValid)
        {
            return $"Deposit wasn't successful for {_transaction.Client.Name}\n";
        }

        _transaction.Client.Balance += _transaction.Amount;
        _transaction.ATM.Balance += _transaction.Amount;

        return $"Deposit was successful - {_transaction.Client.Name} deposited {_transaction.Amount}\n{_transaction.ATM.Id}'s balance: {_transaction.ATM.Balance}\n";
    }
}
