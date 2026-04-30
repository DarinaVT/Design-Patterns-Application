class Dir : IDir
{
    public void CreateDir(string path)
    {
        Directory.CreateDirectory($"{Global.DirectoryPath}\\{path}");
        Console.WriteLine($"Created the directory at {Global.DirectoryPath}\\{path}");
    }
    public void RemoveDir(string path)
    {
        Directory.Delete($"{Global.DirectoryPath}\\{path}");
        Console.WriteLine($"Deleted the directory at {Global.DirectoryPath}\\{path}");
    }
    public void FullDirRemoval(string path)
    {
        Directory.Delete($"{Global.DirectoryPath}\\{path}", true);
        Console.WriteLine($"Deleted the directory at {Global.DirectoryPath}\\{path} with all its content");
    }
    public void ShowDirContent(string path)
    {
        Console.WriteLine($"Visualising directory at {Global.DirectoryPath}\\{path}:");
        List<string> content = Directory.GetFileSystemEntries($"{Global.DirectoryPath}\\{path}").ToList();

        if (content.Count == 0)
        {
            Console.WriteLine("Directory is empty");
            return;
        }

        foreach (string entry in content)
        {
            Console.WriteLine(entry);
        }
    }
    public bool DirExists(string path)
    {
        return Directory.Exists($"{Global.DirectoryPath}\\{path}");
    }
}
