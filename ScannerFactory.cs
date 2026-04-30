using _07._03._26.Specific;

namespace _07._03._26.Factory;

public class ScannerFactory : DeviceFactory
{
    private readonly string _brand;
    private readonly string _model;
    private readonly string _sensor;
    public ScannerFactory(string brand, string model, string sensor)
    {
        _brand = brand;
        _model = model;
        _sensor = sensor;
    }
    public override IDevice Create() => new Scanner(_brand, _model, _sensor);


}
