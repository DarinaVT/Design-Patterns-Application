namespace _21._04;

public class ParticipantActions
{
    private readonly Dictionary<string, Participant> _participants = new();

    public bool Add(Participant participant)
    {
        if (_participants.ContainsKey(participant.Name))
        {
            return false;
        }

        _participants[participant.Name] = participant;
        return true;
    }

    public bool Remove(string name)
    {
        return _participants.Remove(name);
    }

    public bool Exists(string name)
    {
        return _participants.ContainsKey(name);
    }
}
