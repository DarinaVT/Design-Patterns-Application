namespace _07._03._26;

public class Printer : Peripheral
{
    public string Ink { get; set; }
    public Printer(string brand, string networkAdapter, string ink) : base(brand, networkAdapter)
    {
        Ink = ink;
    }

    public override void Produce()
    {
        Console.WriteLine($"Producing {Brand} printer");
    }
    public override DevicePrototype Clone()
    {
        return this.MemberwiseClone() as Peripheral;
    }
    public override void DisplayInfo()
    {
        Console.WriteLine($"Printer Info: Id: {Id}, Brand: {Brand}, Network adapter: {NetworkAdapter}, Ink: {Ink}");
    }

    public override string ToString()
    {
        return $"Printer: Brand={Brand}, Network adapter ={NetworkAdapter}, Ink type={Ink}";
    }
}
