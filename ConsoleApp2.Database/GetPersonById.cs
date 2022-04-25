namespace ConsoleApp2.Database;

public class GetPersonById : IGetPersonById
{
    public Person Invoke(string personId)
    {
        var person = DocumentStoreHolder.Session.Load<Person>(personId);
        return person;
    }
}