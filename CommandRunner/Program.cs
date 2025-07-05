using System.Reflection;
using CommandLib;
class Program
{
    static void Main(string[] args)
    {
        var dllAssembly = Assembly.LoadFrom("FileSystemCommands.dll");

        var commandTypeSize = dllAssembly.GetType("FileSystemCommands.DirectorySizeCommand");
        var sizeCommand = (ICommand)Activator.CreateInstance(commandTypeSize, new object[] { @"C:\Test" });
        sizeCommand.Execute();

        var commandTypeFind = dllAssembly.GetType("FileSystemCommands.FindFilesCommand");
        var findCommand = (ICommand)Activator.CreateInstance(commandTypeFind, new object[] { @"C:\Test", "*.txt" });
        findCommand.Execute();
    }
}
