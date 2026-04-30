namespace _07._03._26.Adapter.Driver;

public class InstallDriver
{
    private bool IsTested(IDevice device)
    {
        if (device.IsTested == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool IsInstalled(IDevice device)
    {
        if(device.Driver != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private string GenerateDriver(IDevice device)
    {
        string hex = Random.Shared.NextInt64(0x100000, 0xFFFFFF).ToString("x6");

        return device is Computer ? $"<{hex}>" : hex;
    }
    public void Install(IDevice device)
    {
        if (IsTested(device) && !IsInstalled(device))
        {
            device.Driver = GenerateDriver(device);
        }
        else if (!IsTested(device))
        {
            Console.WriteLine("You cannot install a driver on an untested device");
        }
        else
        {
            Console.WriteLine("The driver is already installed for " + device.Brand);
        }
    }
}
