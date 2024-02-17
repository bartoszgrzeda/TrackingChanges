using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrackingChanges.Models;
using TrackingChanges.ReadModels;
namespace TrackingChanges.Configurations;

public static class DocumentReadModelEntityConfiguration
{
    public static void ApplyDefaultConfiguration<T>(this EntityTypeBuilder<DocumentReadModelEntity<T>> builder) where T : class, IReadModel
    {
        builder.ToTable(typeof(T).Name);

        builder.HasKey(x => x.Id);

        builder.OwnsOne(x => x.Data, x => x.ToJson());
    }
}