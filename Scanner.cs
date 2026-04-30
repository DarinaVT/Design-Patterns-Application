namespace _07._03._26.Specific;

public class Scanner : Peripheral
{
    public string Sensor { get; set; }
    public Scanner(string brand, string networkAdapter, string sensor) : base(brand, networkAdapter)
    {
        Sensor = sensor;
    }

    public override void Produce()
    {
        Console.WriteLine($"Producing {Brand} scanner");
    }
    public override DevicePrototype Clone()
    {
        return this.MemberwiseClone() as Peripheral;
    }
    public override void DisplayInfo()
    {
        Console.WriteLine($"Scanner Info: Id: {Id}, Brand: {Brand}, Network Adapter: {NetworkAdapter}, Sensor: {Sensor}");
    }
    public override string ToString()
    {
        return $"Scanner: Brand={Brand}, Network adapter ={NetworkAdapter}, Sensor tsype={Sensor}";
    }
}
