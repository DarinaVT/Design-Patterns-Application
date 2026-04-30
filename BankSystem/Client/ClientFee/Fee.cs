using BankSystem.Client.ClientStatus;
namespace BankSystem.Client.ClientFee;

public class Fee : IFee
{
    public decimal GetFee(ClientInfo client)
    {
        decimal fee = 0;
        switch (client.Status)
        {
            case StatusList.Regular:
                fee = 0.05M;
                break;
            case StatusList.Business:
                fee = 0.03M;
                break;
            case StatusList.Prime:
                fee = 0.01M;
                break;
            default:
                fee = 0.05M;
                break;
        }
        return fee;
    }
}
