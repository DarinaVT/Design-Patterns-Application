class DirectoryProxy : IDir
{
    private readonly IDir _directory;
    public DirectoryProxy(IDir directory)
    {
        _directory = directory;
    }
    public void CreateDir(string path)
    {
        if (_directory.DirExists(path))
        {
            Console.WriteLine($"Directory at {Global.DirectoryPath}\\{path} already exists");
            return;
        }
        _directory.CreateDir(path);
    }
    public void RemoveDir(string path)
    {
        if (!_directory.DirExists(path))
        {
            Console.WriteLine($"Directory at {Global.DirectoryPath}\\{path} doesn't exist");
            return;
        }
        try
        {
            _directory.RemoveDir(path);
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Failed to delete the directory at {Global.DirectoryPath}\\{path}: {ex.Message}");
            return;
        }
    }
    public void FullDirRemoval(string path)
    {
        if (!_directory.DirExists(path))
        {
            Console.WriteLine($"Directory at {Global.DirectoryPath}\\{path} doesn't exist");
            return;
        }
        _directory.FullDirRemoval(path);
    }
    public void ShowDirContent(string path)
    {
        if (!_directory.DirExists(path))
        {
            Console.WriteLine($"Directory at {Global.DirectoryPath}\\{path} doesn't exist");
            return;
        }
        _directory.ShowDirContent(path);
    }
    public bool DirExists(string path)
    {
        bool result = _directory.DirExists(path);
        Console.WriteLine("Dir exists: {0}", result);
        return result;
    }
}