using _07._03._26.Adapter.Driver;

namespace _07._03._26.Adapter;

public interface ITarget
{
    public void Execute(IDevice device);
    public void InstallDriver(IDevice device, InstallDriver install);
}
