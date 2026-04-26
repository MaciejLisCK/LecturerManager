using LecturerManager.Domain.CourseManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LecturerManager.Infrastructure.Persistence.Configurations;

public class AssignmentTextItemConfiguration : IEntityTypeConfiguration<AssignmentTextItem>
{
    public void Configure(EntityTypeBuilder<AssignmentTextItem> builder)
    {
        builder.OwnsOne(x => x.Text, b =>
            b.Property(x => x.Value).HasColumnName("Text")
        );
    }
}