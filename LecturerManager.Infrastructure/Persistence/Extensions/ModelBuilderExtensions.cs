using LecturerManager.Infrastructure.Persistence.Services;
using Microsoft.EntityFrameworkCore;

namespace LecturerManager.Infrastructure.Persistence.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyCustomNamingConventions(this ModelBuilder modelBuilder)
    {
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            if (entity.IsOwned())
                continue;

            if (entity.BaseType is null)
            {
                var clrName = entity.ClrType.Name;
                var tableName = DbNameGenerator.GenerateTableName(clrName);
                entity.SetTableName(tableName);
            }

            foreach (var property in entity.GetProperties())
            {
                var columnName = DbNameGenerator.GenerateColumnName(property.Name);
                property.SetColumnName(columnName);
            }
        }
    }
}