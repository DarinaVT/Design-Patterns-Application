namespace _21._04;

public class Participant
{
    private ILogger _logger;
    public string Name { get; }

    public Chatroom Chatroom { get; set; }

    public Participant(string name)
    {
        Name = name;
    }
}