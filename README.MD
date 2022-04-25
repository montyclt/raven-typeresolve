STR:

1. In `ConsoleApp2.Database.DocumentHolder` class, configure database connection.
2. Build solution
3. Go to `ConsoleApp1/bin/Debug/net6.0` and create a directory called `plugins`
4. Copy into  `plugins` directory `ConsoleApp2.dll` and `ConsoleApp2.Database.dll`
5. Run application and use option 1 to create a new entity.
6. Run application and use option 2 to retrieve the entity.

The exception is:
```
Unhandled exception. System.InvalidOperationException: Could not convert document people/1-A to entity of type ConsoleApp2.Person. Json: {"GivenName":"Jane","FamilyName":"Doe","@metadata":{"@collection":"people","Raven-Clr-Type":"ConsoleApp2.PersonB, ConsoleApp2","@change-vector":"A:21-HddcEGyL/UG2pKc4Zk4Fiw","@id":"people/1-A","@last-modified":"2022-04-25T17:21:10.8172054Z"}}
 ---> Newtonsoft.Json.JsonSerializationException: Could not create an instance of type ConsoleApp2.Person. Type is an interface or abstract class and cannot be instantiated. Path 'GivenName'.
   at Newtonsoft.Json.Serialization.JsonSerializerInternalReader.CreateNewObject(JsonReader reader, JsonObjectContract objectContract, JsonProperty containerMember, JsonProperty containerProperty, String id, Boolean& createdFromNonDefaultCreator)
   at Newtonsoft.Json.Serialization.JsonSerializerInternalReader.CreateObject(JsonReader reader, Type objectType, JsonContract contract, JsonProperty member, JsonContainerContract containerContract, JsonProperty containerMember, Object existingValue)
   at Newtonsoft.Json.Serialization.JsonSerializerInternalReader.CreateValueInternal(JsonReader reader, Type objectType, JsonContract contract, JsonProperty member, JsonContainerContract containerContract, JsonProperty containerMember, Object existingValue)
   at Newtonsoft.Json.Serialization.JsonSerializerInternalReader.Deserialize(JsonReader reader, Type objectType, Boolean checkAdditionalContent)
   at Newtonsoft.Json.JsonSerializer.DeserializeInternal(JsonReader reader, Type objectType)
   at Newtonsoft.Json.JsonSerializer.Deserialize(JsonReader reader, Type objectType)
   at Raven.Client.Json.Serialization.NewtonsoftJson.Internal.NewtonsoftJsonJsonSerializer.Raven.Client.Json.Serialization.IJsonSerializer.Deserialize(IJsonReader reader, Type type) in C:\Builds\RavenDB-Stable-5.3\53016\src\Raven.Client\Json\Serialization\NewtonsoftJson\Internal\NewtonsoftJsonJsonSerializer.cs:line 10
   at Raven.Client.Json.Serialization.NewtonsoftJson.Internal.NewtonsoftJsonBlittableEntitySerializer.EntityFromJsonStream(Type type, BlittableJsonReaderObject json) in C:\Builds\RavenDB-Stable-5.3\53016\src\Raven.Client\Json\Serialization\NewtonsoftJson\Internal\NewtonsoftJsonBlittableEntitySerializer.cs:line 64
   at Raven.Client.Json.Serialization.NewtonsoftJson.NewtonsoftJsonSerializationConventions.Raven.Client.Json.Serialization.ISerializationConventions.DeserializeEntityFromBlittable(Type type, BlittableJsonReaderObject json) in C:\Builds\RavenDB-Stable-5.3\53016\src\Raven.Client\Json\Serialization\NewtonsoftJson\NewtonsoftJsonSerializationConventions.cs:line 155
   at Raven.Client.Json.Serialization.NewtonsoftJson.Internal.SessionBlittableJsonConverter.FromBlittable(Type type, BlittableJsonReaderObject& json, String id, Boolean trackEntity) in C:\Builds\RavenDB-Stable-5.3\53016\src\Raven.Client\Json\Serialization\NewtonsoftJson\Internal\SessionBlittableJsonConverter.cs:line 62
   --- End of inner exception stack trace ---
   at Raven.Client.Json.Serialization.NewtonsoftJson.Internal.SessionBlittableJsonConverter.FromBlittable(Type type, BlittableJsonReaderObject& json, String id, Boolean trackEntity) in C:\Builds\RavenDB-Stable-5.3\53016\src\Raven.Client\Json\Serialization\NewtonsoftJson\Internal\SessionBlittableJsonConverter.cs:line 77
   at Raven.Client.Documents.Session.InMemoryDocumentSessionOperations.TrackEntity(Type entityType, String id, BlittableJsonReaderObject document, BlittableJsonReaderObject metadata, Boolean noTracking) in C:\Builds\RavenDB-Stable-5.3\53016\src\Raven.Client\Documents\Session\InMemoryDocumentSessionOperations.cs:line 532
   at Raven.Client.Documents.Session.InMemoryDocumentSessionOperations.TrackEntity(Type entityType, DocumentInfo documentFound) in C:\Builds\RavenDB-Stable-5.3\53016\src\Raven.Client\Documents\Session\InMemoryDocumentSessionOperations.cs:line 484
   at Raven.Client.Documents.Session.InMemoryDocumentSessionOperations.TrackEntity[T](DocumentInfo documentFound) in C:\Builds\RavenDB-Stable-5.3\53016\src\Raven.Client\Documents\Session\InMemoryDocumentSessionOperations.cs:line 446
   at Raven.Client.Documents.Session.Operations.LoadOperation.GetDocument[T](String id) in C:\Builds\RavenDB-Stable-5.3\53016\src\Raven.Client\Documents\Session\Operations\LoadOperation.cs:line 146
   at Raven.Client.Documents.Session.Operations.LoadOperation.GetDocument[T]() in C:\Builds\RavenDB-Stable-5.3\53016\src\Raven.Client\Documents\Session\Operations\LoadOperation.cs:line 134
   at Raven.Client.Documents.Session.DocumentSession.Load[T](String id) in C:\Builds\RavenDB-Stable-5.3\53016\src\Raven.Client\Documents\Session\DocumentSession.Load.cs:line 43
   at ConsoleApp2.Database.GetPersonById.Invoke(String personId)
   at System.Dynamic.UpdateDelegates.UpdateAndExecute2[T0,T1,TRet](CallSite site, T0 arg0, T1 arg1)
   at Program.<Main>$(String[] args) in /Users/vadavo/Projects/RiderProjects/ConsoleApp1/ConsoleApp1/Program.cs:line 56
```

Debug with a breakpoint on `ConsoleApp1.Program.cs` line 31. The event handler is not dispatched.
