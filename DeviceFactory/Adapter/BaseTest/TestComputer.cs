namespace _07._03._26.Adapter;

public class TestComputer : Adaptee
{
    public override void StartExam(IDevice device)
    {
        string message = "Starting the exam on the computer: ";

        if(device is Computer computer)
        {
            Console.WriteLine(message + computer.ToString());
            device.IsTested = true;
        }
        else
        {
            Console.WriteLine("You cannot perform a computer exam on a peripheral device");
        }
    }
}
