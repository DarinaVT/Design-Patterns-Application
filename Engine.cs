namespace _21._04;

public class Engine
{
    public void Start()
    {
        ILogger logger = new ConsoleLog();

        var actions = new ParticipantActions();
        var service = new MessageService();

        var chat = new Chatroom(actions, service);

        var john = new Participant("John");
        var mary = new Participant("Mary");

        var johnObserver = new ChatObserver(john, logger);
        var maryObserver = new ChatObserver(mary, logger);

        chat.OnAdd += maryObserver.Notify;
        chat.OnAdd += johnObserver.Notify;

        chat.OnBan += johnObserver.Notify;
        chat.OnBan += maryObserver.Notify;

        chat.OnRemove += johnObserver.Notify;
        chat.OnRemove += maryObserver.Notify;

        logger.Print(chat.Register(john));
        logger.Print(chat.Register(mary));

        logger.Print(chat.Send("John", "Mary", "Hi Mary"));
        logger.Print(chat.Send("Mary", "John", "Hi John, how are you"));

        logger.Print(chat.Ban(john.Name));
        logger.Print(chat.Ban("Ivan"));
    }
}
