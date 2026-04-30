namespace _07._03._26.Adapter;

public abstract class Adaptee
{
    public abstract void StartExam(IDevice device);
    public virtual void InstallDriver(IDevice device)
    {

    }
}
