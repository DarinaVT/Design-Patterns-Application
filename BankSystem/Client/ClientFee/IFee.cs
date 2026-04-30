namespace BankSystem.Client.ClientFee;

public interface IFee
{
    decimal GetFee(ClientInfo client);
}
