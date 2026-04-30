using System.IO;
class Program
{
    public static void Main()
    {
        Dir dir = new Dir();
        DirectoryProxy dirProxy = new DirectoryProxy(dir);

        //will create the directory at D:\Test
        dirProxy.CreateDir("Test");

        //won't create the directory at D:\Test, because it already exists
        dirProxy.CreateDir("Test");

        //will show the content of the directory at D:\Test, which is empty
        dirProxy.ShowDirContent("Test");

        //will check if the directory at D:\Test\SubDir exists, which is false
        dirProxy.DirExists("Test\\SubDir");

        //will create the directory at D:\Test\SubDir
        dirProxy.CreateDir("Test\\SubDir");
        dirProxy.CreateDir("Test\\AnotherSubDir");

        //will check if the directory at D:\Test\SubDir exists, which is true
        dirProxy.DirExists("Test\\SubDir");

        //will show the content of the directory at D:\Test, which is SubDir
        dirProxy.ShowDirContent("Test");

        //won't delete the directory at D:\Test, because it is not empty
        dirProxy.RemoveDir("Test");

        //will delete the directory at D:\Test\SubDir
        dirProxy.RemoveDir("Test\\SubDir");

        //will delete all the content of the directory at D:\Test and then delete the directory itself
        dirProxy.FullDirRemoval("Test");
    }
}
