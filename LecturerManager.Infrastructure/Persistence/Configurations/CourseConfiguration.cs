using LecturerManager.Domain.CourseManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LecturerManager.Infrastructure.Persistence.Configurations;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.OwnsOne(x => x.Name, modelBuilder =>
            {
                modelBuilder.Property(x => x.Value)
                    .HasColumnName("Name");
            });
    }
}