using System.Reflection;
using System.Runtime.Loader;

namespace ConsoleApp1.Plugins;

public class PluginLoadContext : AssemblyLoadContext
{
    public PluginLoadContext(string pluginName) : base(pluginName, false)
    {
    }

    protected override Assembly Load(AssemblyName assemblyName)
    {
        var asmInSameContext = base.Load(assemblyName);
        return asmInSameContext ?? Plugin.GetAssembly(assemblyName);
    }
}