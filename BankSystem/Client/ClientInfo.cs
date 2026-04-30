using BankSystem.Client.ClientStatus;
namespace BankSystem.Client;

public class ClientInfo
{
    public string Name { get; set; }
    public int Pin { get; }
    public decimal Balance { get; set; }
    public StatusList Status { get; set; }
    public int WithdrawalCount { get; set; }

    public ClientInfo(string name, int pin, decimal balance)
    {
        Name = name;
        Pin = pin;
        Balance = balance;
        Status = StatusList.Regular;
        WithdrawalCount = 0;
    }
}
