namespace _21._04;

public class ChatObserver : IChatObserver
{
    private ILogger _logger;
    private Participant _participant;
    public ChatObserver(Participant participant, ILogger logger)
    {
        _participant = participant;
        _logger = logger;
    }

    public void Notify(string message)
    {
        _logger.Print($"{_participant.Name} received a new notification:\n{message}");
    }
}
