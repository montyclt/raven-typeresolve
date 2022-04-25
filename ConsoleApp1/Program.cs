using System;
using System.IO;
using System.Linq;
using ConsoleApp1.Plugins;
using ConsoleApp2;
using ConsoleApp2.Register;

var pluginDirectory = new DirectoryInfo("./plugins");

foreach (var file in pluginDirectory.GetFiles().Where(file => file.Name.EndsWith(".dll")))
{
    using var stream = file.OpenRead();
    var context = new PluginLoadContext(file.Name);
    context.LoadFromStream(stream);
    Plugin.Contexts.Add(context);
}

foreach (var asm in Plugin.LoadedAssemblies)
{
    var initializerTypes = asm.GetExportedTypes().Where(x => x.IsAssignableTo(typeof(IInitializer)));

    foreach (var initializerType in initializerTypes)
    {
        var initializer = (IInitializer)Activator.CreateInstance(initializerType);
        initializer?.Initialize();
    }
}

AppDomain.CurrentDomain.TypeResolve += (_, args) =>
{
    var type = Plugin.GetType(args.Name);
    var asm = type.Assembly;
    return asm;
};

Console.WriteLine("1. Store person");
Console.WriteLine("2. Retrieve person");
Console.WriteLine("0. Exit");
Console.Write("Select option: ");

string key = Console.ReadLine();

if (key == "1")
{
    var person = new PersonB()
    {
        GivenName = "Jane",
        FamilyName = "Doe"
    };
    Register.StorePerson().Invoke(person);
}
else if (key == "2")
{
    // When loading an entity by ID here, CurrentDomain.TypeResolve
    // event is not dispatched, and I'm getting the exception.
    
    Console.Write("Id: ");
    string id = Console.ReadLine();
    var person = Register.GetPersonById().Invoke(id);
    Console.WriteLine(person);
}

Console.WriteLine("Exit.");