namespace _21._04;

interface IChatroom
{
    string Register(Participant participant);
    string Send(string from, string to, string message);
}