using LecturerManager.Domain.CourseManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LecturerManager.Infrastructure.Persistence.Configurations;

public class AssignmentConfiguration : IEntityTypeConfiguration<Assignment>
{
    public void Configure(EntityTypeBuilder<Assignment> builder)
    {
        builder.OwnsOne(x => x.Name, modelBuilder =>
            {
                modelBuilder.Property(x => x.Value)
                    .HasColumnName("Name");
            });
    }
}