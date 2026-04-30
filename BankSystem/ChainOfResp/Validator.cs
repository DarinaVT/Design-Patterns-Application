using BankSystem.ATM;
using BankSystem.Client;
namespace BankSystem.ChainOfResp;

public abstract class Validator
{
    protected Validator _super;
    public void SetSuper(Validator super)
    {
        _super = super;
    }
    public abstract bool Validate(ClientInfo client, ATMInfo atm, int pin, decimal amount);
}