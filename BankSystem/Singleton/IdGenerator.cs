namespace BankSystem.Singleton;

public sealed class IdGenerator
{
    private int _id;
    private IdGenerator()
    {

    }

    public string NextId() => ++_id + "_ATM";

    public static IdGenerator Instance
    {
        get
        {
            return Nested._instance;
        }
    }

    private class Nested
    {
        static Nested()
        {

        }
        internal static readonly IdGenerator _instance = new IdGenerator();
    }
}
