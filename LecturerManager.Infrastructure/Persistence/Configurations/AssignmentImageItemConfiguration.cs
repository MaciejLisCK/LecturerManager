using LecturerManager.Domain.CourseManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LecturerManager.Infrastructure.Persistence.Configurations;

public class AssignmentImageItemConfiguration : IEntityTypeConfiguration<AssignmentImageItem>
{
    public void Configure(EntityTypeBuilder<AssignmentImageItem> builder)
    {
        builder.OwnsOne(x => x.ImageUrl, b =>
            b.Property(x => x.Value).HasColumnName("ImageUrl")
        );
    }
}