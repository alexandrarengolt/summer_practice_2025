using CommandLib;
namespace FileSystemCommands;
public class DirectorySizeCommand : ICommand
{
    private string dirPath {get; }

    public long totalSize = 0;

    public DirectorySizeCommand(string path)
    {
        dirPath = path;
    }

    public void Execute()
    {
        if (!Directory.Exists(dirPath))
        {
            return;
        }
        this.totalSize = CalculateSize(dirPath);
    }

    private long CalculateSize(string dir)
    {
        long size = 0;

        foreach (var file in Directory.GetFiles(dir))
            size += new FileInfo(file).Length;

        foreach (var subDir in Directory.GetDirectories(dir))
            size += CalculateSize(subDir);

        return size;
    }
}

public class FindFilesCommand : ICommand
{
    private string dirPath { get; }
    private string filePattern { get; }

    public string[] receivedFiles = Array.Empty<string>();

    public FindFilesCommand(string path, string pattern)
    {
        dirPath = path;
        filePattern = pattern;
    }

    public void Execute()
    {
        if (!Directory.Exists(dirPath))
        {
            return;
        }
        this.receivedFiles = Directory.GetFiles(dirPath, filePattern, SearchOption.AllDirectories);
    }
}