namespace _07._03._26;

public abstract class Computer : DevicePrototype, IDevice
{
    public string Id { get; }
    public string Brand { get; set; }
    public string? Driver { get; set; }
    public bool? IsTested { get; set; } = false;
    public string Motherboard { get; set; }
    public string CPU { get; set; }
    public Computer(string brand, string motherboard, string cpu)
    {
        Id = IdGenerator.Instance.NextPCId();
        Brand = brand;
        Motherboard = motherboard;
        CPU = cpu;
    }
    public abstract void Produce();
    public abstract void DisplayInfo();
    public abstract override DevicePrototype Clone();
}
