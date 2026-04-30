interface IDir
{
    void CreateDir(string path);
    void RemoveDir(string path);
    void FullDirRemoval(string path);
    void ShowDirContent(string path);
    bool DirExists(string path);
}
