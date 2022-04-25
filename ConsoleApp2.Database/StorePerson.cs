namespace ConsoleApp2.Database;

public class StorePerson : IStorePerson
{
    public void Invoke(Person person)
    {
        DocumentStoreHolder.Session.Store(person);
        DocumentStoreHolder.Session.SaveChanges();
    }
}