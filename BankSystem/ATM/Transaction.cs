using BankSystem.ATM;
using BankSystem.Client;
namespace BankSystem;

public class Transaction
{
    public ClientInfo Client { get; set; }
    public ATMInfo ATM { get; set; }
    public decimal Amount { get; set; }
    public int Pin { get; set; }
    public Transaction(ClientInfo client, ATMInfo atm, decimal amount, int pin)
    {
        Client = client;
        ATM = atm;
        Amount = amount;
        Pin = pin;
    }

}
