namespace BankSystem.ATM;

public class LoadATM
{
    private List<ATMInfo> _atms;
    public LoadATM(List<ATMInfo> atms)
    {
        _atms = atms;
    }

    public async Task Start()
    {
        await Task.Run(() =>
        {
            while (true)
            {
                Thread.Sleep(5000);
                MonitorATM monitor = new MonitorATM(_atms);
                foreach (var atm in monitor)
                {
                    atm.Balance += 5000;
                    Data.Instance.Log($"\nATM {atm.Id} reloaded\nBalance: {atm.Balance}\n");
                }
            }
        });
    }
}
