using BankSystem.ATM;
using BankSystem.Client;
namespace BankSystem.ChainOfResp;

public class ATMValidator : Validator
{
    public override bool Validate(ClientInfo client, ATMInfo atm, int pin, decimal amount)
    {
        if (atm.Balance < amount)
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