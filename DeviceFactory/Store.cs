namespace _07._03._26;

public class Store
{
    private List<IDevice> _devices = new List<IDevice>();
    public IDevice Create(DeviceFactory factory)
    {
        IDevice device = factory.Create();
        _devices.Add(device);
        device.Produce();
        return device;
    }

    public void Info(IDevice device)
    {
        device.DisplayInfo();
    }

    public void DisplayAllDevices()
    {
        Console.WriteLine("All Devices in Store:");
        foreach (var device in _devices)
        {
            device.DisplayInfo();
        }
    }
}
