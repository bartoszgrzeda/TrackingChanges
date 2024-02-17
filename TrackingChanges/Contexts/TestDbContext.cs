using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TrackingChanges.Configurations;
using TrackingChanges.Models;
using TrackingChanges.ReadModels;

namespace TrackingChanges.Contexts;

public class TestDbContext : DbContext
{
    private readonly string _connectionString;

    public TestDbContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var readModelType = typeof(TestReadModel);
        var entityType = typeof(DocumentReadModelEntity<>).MakeGenericType(readModelType);
        var entityMethod = typeof(ModelBuilder).GetMethod(nameof(ModelBuilder.Entity), new Type[] { })!.MakeGenericMethod(entityType);

        var entityConfig = entityMethod.Invoke(modelBuilder, null);

        MethodInfo applyConfigMethod = typeof(DocumentReadModelEntityConfiguration)
            .GetMethod(nameof(DocumentReadModelEntityConfiguration.ApplyDefaultConfiguration))!
            .MakeGenericMethod(readModelType);

        applyConfigMethod?.Invoke(null, new[] { entityConfig });
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_connectionString);
        base.OnConfiguring(optionsBuilder);
    }
}