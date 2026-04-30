using BankSystem.ChainOfResp;
using BankSystem.Client.ClientFee;
using BankSystem.Client.ClientStatus;
namespace BankSystem.Command;

public class DrawCommand : ICommand
{
    private Transaction _transaction;
    private Validator _validator;
    private IFee _fee;
    private IStatus _status;

    public DrawCommand(Transaction transaction, Validator validator, IFee fee, IStatus status)
    {
        _transaction = transaction;
        _validator = validator;
        _fee = fee;
        _status = status;
    }

    public string Execute()
    {
        bool isValid = _validator.Validate(
            _transaction.Client,
            _transaction.ATM,
            _transaction.Pin,
            _transaction.Amount
        );

        if (!isValid)
        {
            return $"Withdraw wasn't successful for {_transaction.Client.Name}\n";
        }

        decimal fee = _fee.GetFee(_transaction.Client) * _transaction.Amount;

        _transaction.Client.Balance -= _transaction.Amount + fee;
        _transaction.ATM.Balance -= _transaction.Amount;
        if (_transaction.ATM.Balance < 0)
        {
            _transaction.ATM.Balance = 0;
        }

        _transaction.Client.WithdrawalCount++;
        _status.ApplyStatus(_transaction.Client);

        return $"Transaction successful: {_transaction.Client.Name} withdrew {_transaction.Amount} with a fee of {fee}\n{_transaction.Client.Name}'s balance: {_transaction.Client.Balance}, {_transaction.ATM.Id}'s balance: {_transaction.ATM.Balance}\n";
    }
}