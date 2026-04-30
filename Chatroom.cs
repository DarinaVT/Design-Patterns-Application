namespace _21._04;

public class Chatroom : IChatroom
{
    private readonly ParticipantActions _actions;
    private readonly IMessageService _service;

    public event Action<string> OnBan;
    public event Action<string> OnAdd;
    public event Action<string> OnRemove;

    public Chatroom(ParticipantActions actions, IMessageService service)
    {
        _actions = actions;
        _service = service;
    }

    public string Register(Participant participant)
    {
        if (!_actions.Add(participant))
        {
            return $"{participant.Name} already joined\n";
        }

        string res = $"{participant.Name} joined the chatroom\n";
        OnAdd?.Invoke(res);
        return res;
    }

    public string Send(string from, string to, string message)
    {
        if (!_actions.Exists(to))
        {
            return "Message sending failed\n";
        }

        return _service.ShowMessage(from, to, message);
    }

    public string Ban(string name)
    {
        if (_actions.Remove(name))
        {
            string res = $"{name} was banned from the chatroom\n";
            OnBan?.Invoke(res);
            return res;
        }

        return "User not found\n";
    }

    public string Remove(string name)
    {
        if (_actions.Remove(name))
        {
            string res = $"{name} was removed from the chatroom\n";
            OnRemove?.Invoke(res);
            return res;
        }
        return "User not found\n";

    }
}