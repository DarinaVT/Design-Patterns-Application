namespace _07._03._26;

public class LaptopFactory : DeviceFactory
{
    private readonly string _brand;
    private readonly string _motherboard;
    private readonly string _cpu;
    private readonly string _batteryCapacity;

    public LaptopFactory(string brand, string motherboard, string cpu, string batteryCapacity)
    {
        _brand = brand;
        _motherboard = motherboard;
        _cpu = cpu;
        _batteryCapacity = batteryCapacity;
    }

    public override IDevice Create() => new Laptop(_brand, _motherboard, _cpu, _batteryCapacity);

}
