using LecturerManager.Domain.CourseManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LecturerManager.Infrastructure.Persistence.Configurations;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.OwnsOne(x => x.Name, modelBuilder =>
            {
                modelBuilder.Property(x => x.Value)
                    .HasColumnName("Name");
            });

        builder.Navigation(x => x.Assignments)
            .UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}