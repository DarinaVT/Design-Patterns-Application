using BankSystem.Singleton;
namespace BankSystem.ATM;

public class ATMInfo
{
    public string Id { get; set; }
    public decimal Balance { get; set; }
    public ATMInfo(decimal balance)
    {
        Balance = balance;
        Id = IdGenerator.Instance.NextId();
    }
}
