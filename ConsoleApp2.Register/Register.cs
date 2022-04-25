using System;
using ConsoleApp1.Plugins;

namespace ConsoleApp2.Register;

public static class Register
{
    public static dynamic GetPersonById()
    {
        var type = Plugin.GetType("ConsoleApp2.Database.GetPersonById, ConsoleApp2.Database");
        var command = Activator.CreateInstance(type);
        return command;
    }

    public static dynamic StorePerson()
    {
        var type = Plugin.GetType("ConsoleApp2.Database.StorePerson, ConsoleApp2.Database");
        var command = Activator.CreateInstance(type);
        return command;
    }
}