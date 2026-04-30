namespace BankSystem.Logger;

public class FileLog : ILogger
{
    public void Log(string message)
    {
        using (StreamWriter writer = new StreamWriter(@"D:\log.txt", true))
        {
            writer.Write(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - ");
            writer.WriteLine(message);
        }
    }
}
