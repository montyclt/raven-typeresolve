using Raven.Client.Documents;
using Raven.Client.Documents.Conventions;
using Raven.Client.Documents.Session;

namespace ConsoleApp2.Database;

public static class DocumentStoreHolder
{
    public static IDocumentStore DocumentStore;
    public static IDocumentSession Session;
    
    public static void Initialize()
    {
        var documentStore = new DocumentStore
        {
            Urls = new[] { "http://localhost:8080" },
            Database = "tryouts",
            Conventions = new DocumentConventions()
            {
                FindCollectionName = _ => "people"
            }
        };

        documentStore.Initialize();

        DocumentStore = documentStore;
        Session = DocumentStore.OpenSession();
    }
}