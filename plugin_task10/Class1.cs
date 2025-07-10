namespace plugin_task10;
public interface IPlugin
{
    void Execute();
}

public class PluginLoad : Attribute
{
    public string[] Dependency { get; }

        public PluginLoad(params string[] depend)
        {
            Dependency = depend;
        }
}
