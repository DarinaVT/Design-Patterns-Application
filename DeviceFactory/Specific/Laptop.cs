namespace _07._03._26;

public class Laptop : Computer
{
    public string BatteryCapacity { get; set; }
    public Laptop(string brand, string motherboard, string cpu, string batteryCapacity) : base(brand, motherboard, cpu)
    {
        BatteryCapacity = batteryCapacity;
    }
    public override void Produce()
    {
        Console.WriteLine($"Producing {Brand} Laptop");
    }
    public override DevicePrototype Clone()
    {
        return this.MemberwiseClone() as Computer;
    }
    public override void DisplayInfo()
    {
        Console.WriteLine($"Laptop Info: Id: {Id}, Brand: {Brand}, Motherboard: {Motherboard}, CPU: {CPU}, Battery capacity: {BatteryCapacity}");
    }

    public override string ToString()
    {
        return $"Laptop: Brand={Brand}, Motherboard={Motherboard}, CPU={CPU}, Battery Capacity={BatteryCapacity}";
    }
}
