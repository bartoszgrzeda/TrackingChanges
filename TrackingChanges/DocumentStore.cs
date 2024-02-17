using Microsoft.EntityFrameworkCore;
using TrackingChanges.Contexts;
using TrackingChanges.Models;
using TrackingChanges.ReadModels;

namespace TrackingChanges;

public class DocumentStore<T> where T : IReadModel
{
    private TestDbContext _dbContext;
    private DbSet<DocumentReadModelEntity<T>> _entities;

    public DocumentStore()
    {
        _dbContext = new TestDbContext("Server=localhost;Database=postgres;Port=5411;User Id=postgres;Password=@postgresQ!;");
        _entities = _dbContext.Set<DocumentReadModelEntity<T>>();
    }

    public Task<T> GetById(Guid id)
    {
        return _entities
            .AsNoTracking()
            .Select(x => x.Data)
            .SingleAsync(x => x.Id == id);
    }

    public void Update(T entity)
    {
        _entities.Entry(new DocumentReadModelEntity<T>(entity)).State = EntityState.Modified;
        Console.WriteLine($"ChangeTracker: {_dbContext.ChangeTracker.DebugView}");
    }

    public Task Save()
    {
        return _dbContext.SaveChangesAsync();
    }
}