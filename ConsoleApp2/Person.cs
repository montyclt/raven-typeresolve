namespace ConsoleApp2;

public abstract class Person
{
    public string Id { get; set; }
    public string GivenName { get; set; }
    public string FamilyName { get; set; }

    public override string ToString()
    {
        return $"{GivenName} {FamilyName}";
    }
}

public class PersonA : Person
{
}

public class PersonB : Person
{
}