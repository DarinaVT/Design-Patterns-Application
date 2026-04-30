namespace _07._03._26.Factory;

public class DesktopFactory : DeviceFactory
{
    private readonly string _brand;
    private readonly string _motherboard;
    private readonly string _cpu;
    private readonly string _gpu;

    public DesktopFactory(string brand, string motherboard, string cpu, string gpu)
    {
        _brand = brand;
        _motherboard = motherboard;
        _cpu = cpu;
        _gpu = gpu;
    }

    public override IDevice Create() => new Desktop(_brand, _motherboard, _cpu, _gpu);


}
