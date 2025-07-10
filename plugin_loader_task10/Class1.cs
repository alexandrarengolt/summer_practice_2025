using plugin_task10;
using System.Reflection;
namespace plugin_loader_task10;

public class PluginLoader
{
    public static void LoadAndRunPlugins(string pluginDir)
    {
        if (!Directory.Exists(pluginDir))
        {
            Console.WriteLine("Данная папка не обнаружена");
            return;
        }

        var executedPlugins = new HashSet<string>();

        foreach (var pluginDllPath in Directory.GetFiles(pluginDir, "*.dll"))
        {
            var assembly = Assembly.LoadFrom(pluginDllPath);

            var pluginTypes = assembly.GetTypes()
                .Where(IsValidPluginType)
                .ToList();

            var plugins = pluginTypes
           .Select(type => new
           {
               Type = type,
               Name = type.Name,
               Dependency = type.GetCustomAttribute<PluginLoad>()?.Dependence
           }).ToList();

            while (executedPlugins.Count < plugins.Count)
            {
                foreach (var plugin in plugins)
                {
                    if (!executedPlugins.Contains(plugin.Name) && plugin.Dependency != null && plugin.Dependency.All(executedPlugins.Contains) && Activator.CreateInstance(plugin.Type) is IPlugin pluginInstance)
                    {
                        pluginInstance.Execute();
                        executedPlugins.Add(plugin.Name);
                    }
                }
            }
        }
    }

    private static bool IsValidPluginType(Type type)
    {
        return typeof(IPlugin).IsAssignableFrom(type)
               && !type.IsInterface
               && type.GetCustomAttribute<PluginLoad>() != null;
    }
}