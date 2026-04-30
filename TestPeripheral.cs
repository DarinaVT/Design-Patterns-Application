namespace _07._03._26.Adapter;

public class TestPeripheral : Adaptee
{
    public override void StartExam(IDevice device)
    {
        string message = "Starting the exam on the peripheral device: ";
        if (device is Peripheral peripheral)
        {
            Console.WriteLine(message + peripheral.ToString());
            device.IsTested = true;
        }
        else
        {
            Console.WriteLine("You cannot perform a peripheral exam on a computer device");
        }
    }
}
