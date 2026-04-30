namespace _07._03._26;

public class DeviceManager
{
    private Dictionary<string, IDevice> devices = new Dictionary<string, IDevice>();

    public IDevice this[string key]
    {
        get
        {
            return devices[key];
        }
        set
        {
            devices.Add(key, value);
        }
    }
}
