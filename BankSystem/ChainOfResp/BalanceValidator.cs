using BankSystem.ATM;
using BankSystem.Client;
using BankSystem.Client.ClientFee;
namespace BankSystem.ChainOfResp;

public class BalanceValidator : Validator
{
    private readonly IFee _fee;
    public BalanceValidator(IFee fee)
    {
        _fee = fee;
    }
    public override bool Validate(ClientInfo client, ATMInfo atm, int pin, decimal amount)
    {
        if (client.Balance < amount + _fee.GetFee(client) * amount)
        {
            return false;
        }
        if (_super != null)
        {
            return _super.Validate(client, atm, pin, amount);
        }
        return true;
    }
}