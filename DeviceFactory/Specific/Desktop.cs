namespace _07._03._26;
//adapter method that will be used to test a device
//tested device that pass the exam will get a driver installed and will be able to be sold
//computers will have XML formatted drivers
//peripherals will have hexadecimal formatted drivers
public class Desktop : Computer
{
    public string GPU { get; set; }
    public Desktop(string brand, string motherboard, string cpu, string gpu) : base(brand, motherboard, cpu)
    {
        GPU = gpu;
    }
    public override void Produce()
    {
        Console.WriteLine($"Producing {Brand} Desktop");
    }

    public override DevicePrototype Clone()
    {
        return this.MemberwiseClone() as Computer;
    }
    public override void DisplayInfo()
    {
        Console.WriteLine($"Desktop Info: Id: {Id}, Brand: {Brand}, Motherboard: {Motherboard}, CPU: {CPU}, GPU: {GPU}");
    }
    public override string ToString()
    {
        return $"Desktop: Brand={Brand}, Motherboard={Motherboard}, CPU={CPU}, GPU={GPU}";
    }
}
