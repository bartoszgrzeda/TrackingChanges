using TrackingChanges.ReadModels;

namespace TrackingChanges.Models;

public class DocumentReadModelEntity<T> where T : IReadModel
{
    public Guid Id { get; set; }
    public T Data { get; set; }

    public DocumentReadModelEntity()
    {
    }

    public DocumentReadModelEntity(T data)
    {
        Data = data;
        Id = data.Id;
    }
}