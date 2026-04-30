public sealed class IdGenerator
{
    private int _pcId;
    private int _dsId;

    private IdGenerator() { }

    public string NextPCId() => "PC" + ++_pcId;
    public string NextDSId() => "DS" + ++_dsId;

    public static IdGenerator Instance { get { return Nested.instance; } }

    private class Nested
    {
        static Nested() { }
        internal static readonly IdGenerator instance = new IdGenerator();
    }
}