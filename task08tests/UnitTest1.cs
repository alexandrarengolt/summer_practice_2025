using System;
using Xunit;
using FileSystemCommands;
namespace task08tests;

public class FileSystemCommandsTests
{
    [Fact]
    public void DirectorySizeCommand_ShouldCalculateSize()
    {
        var tempDirectory = Path.Combine(Path.GetTempPath(), "MomentDir");
        Directory.CreateDirectory(tempDirectory);
        File.WriteAllText(Path.Combine(tempDirectory, "test1.txt"), "Hello");
        File.WriteAllText(Path.Combine(tempDirectory, "test2.txt"), "World");

        var sizeCalculator = new DirectorySizeCommand(tempDirectory);
        sizeCalculator.Execute();

        Assert.Equal(10, sizeCalculator.totalSize);
        Directory.Delete(tempDirectory, true);
    }

    [Fact]
    public void FindFilesCommand_ShouldFindMatchingFiles()
    {
        var searchDirectory = Path.Combine(Path.GetTempPath(), "MomentDir");
        Directory.CreateDirectory(searchDirectory);
        File.WriteAllText(Path.Combine(searchDirectory, "file1.txt"), "Text1");
        File.WriteAllText(Path.Combine(searchDirectory, "file2.log"), "Log");
        File.WriteAllText(Path.Combine(searchDirectory, "file3.txt"), "Text2");

        var fileFinder = new FindFilesCommand(searchDirectory, "*.txt");
        fileFinder.Execute();

        Assert.Equal(2, fileFinder.receivedFiles.Length);

        Directory.Delete(searchDirectory, true);
    }

}