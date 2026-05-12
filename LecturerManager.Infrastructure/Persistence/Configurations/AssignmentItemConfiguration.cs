using LecturerManager.Domain.CourseManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LecturerManager.Infrastructure.Persistence.Configurations;

public class AssignmentItemConfiguration : IEntityTypeConfiguration<AssignmentItem>
{
    public void Configure(EntityTypeBuilder<AssignmentItem> builder)
    {
        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.ItemType)
            .HasConversion<string>();

        builder
            .OwnsOne(x => x.Name, modelBuilder =>
            {
                modelBuilder.Property(x => x.Value)
                    .HasColumnName("Name");
            });
    }
}