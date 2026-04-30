namespace _07._03._26.Factory;

public class PrinterFactory : DeviceFactory
{
    private readonly string _brand;
    private readonly string _model;
    private readonly string _ink;
    public PrinterFactory(string brand, string model, string type)
    {
        _brand = brand;
        _model = model;
        _ink = type;
    }
    public override IDevice Create() => new Printer(_brand, _model, _ink);


}
