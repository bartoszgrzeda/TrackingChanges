using TrackingChanges;
using TrackingChanges.ReadModels;

var documentStore = new DocumentStore<TestReadModel>();

var id = new Guid("4f4cceb7-f601-47d7-9f95-1731f57da535");
var entity = await documentStore.GetById(id);

Console.WriteLine($"Before update: {entity}");

var newPropertyValue = Guid.NewGuid().ToString();
entity.TestProperty = newPropertyValue;

documentStore.Update(entity);
await documentStore.Save();

var newDocumentStore = new DocumentStore<TestReadModel>();
var updatedEntity = await newDocumentStore.GetById(id);

Console.WriteLine($"After update: {updatedEntity}");