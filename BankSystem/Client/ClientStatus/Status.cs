namespace BankSystem.Client.ClientStatus;

public class Status : IStatus
{
    public void ApplyStatus(ClientInfo client)
    {
        switch (client.WithdrawalCount)
        {
            case 5:
                client.Status = StatusList.Business;
                break;
            case 10:
                client.Status = StatusList.Prime;
                break;
        }
    }
}
