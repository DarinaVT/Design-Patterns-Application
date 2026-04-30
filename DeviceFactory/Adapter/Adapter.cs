using _07._03._26.Adapter.Driver;

namespace _07._03._26.Adapter;

public class Adapter : ITarget
{
    private readonly Adaptee _adaptee;
    public Adapter(Adaptee adaptee)
    {
        _adaptee = adaptee;
    }
    public void Execute(IDevice device)
    {
        _adaptee.StartExam(device);
    }
    public void InstallDriver(IDevice device, InstallDriver install)
    {
        install.Install(device);
    }
}
