namespace _21._04;

public class MessageService : IMessageService
{
    public string ShowMessage(string from, string to, string message)
    {
        return $"{from} -> {to}: {message}\n";
    }
}
