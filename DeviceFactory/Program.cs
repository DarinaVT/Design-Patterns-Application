using _07._03._26;
using _07._03._26.Factory;
using _07._03._26.Adapter;
using _07._03._26.Adapter.Driver;
class Program
{
    public static void Main()
    {
        Store store = new Store();
        DeviceManager manager = new DeviceManager();

        IDevice laptop = store.Create(new LaptopFactory("Dell", "ASUS B550", "Intel i7", "5000mAh"));
        IDevice desktop = store.Create(new DesktopFactory("HP", "MSI Z690", "AMD Ryzen 9", "RTX 4090"));
        IDevice printer = store.Create(new PrinterFactory("Canon", "TP-Link", "Laser"));
        IDevice scanner = store.Create(new ScannerFactory("Epson", "D-Link", "CCD"));

        //manager[laptop.Id] = laptop;
        //manager[desktop.Id] = desktop;
        //manager[printer.Id] = printer;
        //manager[scanner.Id] = scanner;

        
        //IDevice device1 = manager[laptop.Id].Clone() as IDevice;
        //Console.WriteLine("\nBefore");
        //Console.WriteLine($"Original: {laptop}");
        //Console.WriteLine($"Clone: {device1}");

        //(device1 as Laptop).Brand = "Lenovo";

        //Console.WriteLine("\nAfter");
        //Console.WriteLine($"Original: {laptop}");
        //Console.WriteLine($"Clone: {device1}");


        InstallDriver install = new InstallDriver();
        //adapter for computer devices
        Adaptee adaptee = new TestComputer();
        Adapter adapter = new Adapter(adaptee);

        //cant install a driver on an untested device
        adapter.InstallDriver(desktop, install);

        //test on a computer device using a computer exam
        adapter.Execute(desktop);
        Console.WriteLine(desktop.IsTested);

        //install a driver on a tested computer device
        adapter.InstallDriver(desktop, install);
        Console.WriteLine(desktop.Driver);

        //cant install a driver on a device that already has one
        adapter.InstallDriver(desktop, install);

        //cant perform a computer exam on a peripheral device
        adapter.Execute(printer);
        Console.WriteLine(printer.IsTested);

        //switch the adaptee to work for peripheral devices
        adaptee = new TestPeripheral();
        adapter = new Adapter(adaptee);

        //perform an exam on a peripheral device
        adapter.Execute(printer);
        Console.WriteLine(printer.IsTested);



        //store.Info(laptop);
        //store.Info(desktop);
        //store.Info(printer);
        //store.Info(scanner);

        //store.DisplayAllDevices();
    }
}
