using ConsoleApp1.Plugins;

namespace ConsoleApp2.Database;

public class Initializer : IInitializer
{
    public void Initialize()
    {
        DocumentStoreHolder.Initialize();
    }
}