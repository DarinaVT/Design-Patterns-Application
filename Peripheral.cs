namespace _07._03._26;

public abstract class Peripheral : DevicePrototype, IDevice
{
    public string Id { get; }
    public string Brand { get; set; }
    public string? Driver { get; set; }
    public bool? IsTested { get; set; } = false;
    public string NetworkAdapter { get; set; }
    public Peripheral(string brand, string networkAdapter)
    {
        Id = IdGenerator.Instance.NextDSId();
        Brand = brand;
        NetworkAdapter = networkAdapter;
    }

    public abstract void Produce();
    public abstract void DisplayInfo();

    public abstract override DevicePrototype Clone();
}
