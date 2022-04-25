using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace ConsoleApp1.Plugins;

public static class Plugin
{
    public static Collection<PluginLoadContext> Contexts = new();
    public static IEnumerable<Assembly> LoadedAssemblies => Contexts.SelectMany(x => x.Assemblies);

    public static Assembly GetAssembly(AssemblyName name)
    {
        var inPluginAsm = LoadedAssemblies.FirstOrDefault(x => x.GetName().Name == name.Name);

        if (inPluginAsm is not null)
        {
            return inPluginAsm;
        }

        return AssemblyLoadContext.Default.LoadFromAssemblyName(name);
    }
    
    public static Type GetType(string fqn)
    {
        return Type.GetType(fqn, GetAssembly, (asm, typeName, caseInsensitive) =>
        {
            if (asm is null)
            {
                return Type.GetType(typeName);
            }

            return asm.GetType(typeName, caseInsensitive);
        });
    }
}