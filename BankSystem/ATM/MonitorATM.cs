using System.Collections;
namespace BankSystem.ATM;

public class MonitorATM : IEnumerable<ATMInfo>
{
    private List<ATMInfo> _atms;
    public MonitorATM(List<ATMInfo> atms)
    {
        _atms = atms;
    }

    public IEnumerator<ATMInfo> GetEnumerator()
    {
        foreach (var atm in _atms)
        {
            if (atm.Balance < 1000)
            {
                yield return atm;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
