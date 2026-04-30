namespace _07._03._26;

public interface IDevice : IDeviceInfo, IDeviceProduce
{
    string Id { get; }
    string Brand { get; set; }
    string? Driver { get; set; }
    bool? IsTested { get; set; }
    DevicePrototype Clone();
}
